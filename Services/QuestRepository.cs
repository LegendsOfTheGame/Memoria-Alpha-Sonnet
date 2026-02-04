using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game;
using MemoriaAlpha.Models;

namespace MemoriaAlpha.Services;

/// <summary>
/// Manages loading and caching of quest data with intelligent filtering based on player progress.
/// </summary>
public sealed class QuestRepository : IDisposable
{
    private readonly IDalamudPluginInterface pluginInterface;
    private readonly IPluginLog log;
    
    private List<TocEntry> tocEntries = new();
    private List<Quest> loadedQuests = new();
    private HashSet<string> completedFiles = new();
    
    public IReadOnlyList<Quest> Quests => loadedQuests;
    public string PlayerMaxPatch { get; private set; } = "2.0";
    public int FilesSkipped { get; private set; }
    
    public QuestRepository(IDalamudPluginInterface pluginInterface, IPluginLog log)
    {
        this.pluginInterface = pluginInterface;
        this.log = log;
    }
    
    /// <summary>
    /// Initializes the repository by loading ToC and detecting player progress.
    /// </summary>
    public void Initialize()
    {
        try
        {
            log.Information("Initializing QuestRepository...");
            
            // Step 1: Load toc.json
            LoadToc();
            
            // Step 2: Detect player's furthest MSQ progress
            PlayerMaxPatch = DetectPlayerProgress();
            log.Information($"Player progress detected: {PlayerMaxPatch}");
            
            // Step 3: Load only relevant quest files
            LoadQuestsUpToPatch(PlayerMaxPatch);
            
            log.Information($"QuestRepository initialized: {loadedQuests.Count} quests loaded, {FilesSkipped} files skipped");
        }
        catch (Exception ex)
        {
            log.Error(ex, "Failed to initialize QuestRepository");
        }
    }
    
    /// <summary>
    /// Loads toc.json from the Data directory.
    /// </summary>
    private void LoadToc()
    {
        var tocPath = Path.Combine(pluginInterface.AssemblyLocation.Directory?.FullName ?? "", "Data", "toc.json");
        
        if (!File.Exists(tocPath))
        {
            log.Warning($"toc.json not found at {tocPath}");
            return;
        }
        
        var json = File.ReadAllText(tocPath);
        tocEntries = JsonSerializer.Deserialize<List<TocEntry>>(json) ?? new List<TocEntry>();
        
        log.Information($"Loaded {tocEntries.Count} ToC entries");
    }
    
    /// <summary>
    /// Detects the player's current MSQ patch by checking completion of final quests in reverse order.
    /// </summary>
    private string DetectPlayerProgress()
    {
        // Get all "Final" quests in reverse order (7.3 → 2.0)
        var finalQuests = tocEntries
            .Where(e => e.Role.Equals("Final", StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(e => e.Patch)
            .ToList();
        
        foreach (var entry in finalQuests)
        {
            // Check if ANY of the quest IDs are complete
            if (entry.Ids.Any(IsQuestComplete))
            {
                log.Information($"Player completed '{entry.Name}' (Patch {entry.Patch})");
                return entry.Patch;
            }
        }
        
        // Default to ARR if no MSQ quests are complete
        return "2.0";
    }
    
    /// <summary>
    /// Loads all quest files up to the specified patch.
    /// </summary>
    private void LoadQuestsUpToPatch(string maxPatch)
    {
        // For now, just load 2.0 MSQ as a test
        // We'll expand this to load all patches later
        LoadPatchDrawer("2-ARR", "2.0", "1-msq.json");
    }
    
    /// <summary>
    /// Loads a specific quest file (drawer) for a patch.
    /// </summary>
    private void LoadPatchDrawer(string expansion, string patch, string drawer)
    {
        var filePath = Path.Combine(
            pluginInterface.AssemblyLocation.Directory?.FullName ?? "",
            "Data",
            "Quests",
            expansion,
            patch,
            drawer
        );
        
        if (!File.Exists(filePath))
        {
            log.Debug($"Quest file not found: {filePath}");
            return;
        }
        
        try
        {
            var json = File.ReadAllText(filePath);
            var quests = JsonSerializer.Deserialize<List<Quest>>(json) ?? new List<Quest>();
            
            // Check if all quests in this file are complete
            if (quests.Count > 0 && quests.All(q => q.Id.Any(IsQuestComplete)))
            {
                log.Information($"{expansion}/{patch}/{drawer} → ALL COMPLETE (skipped)");
                completedFiles.Add($"{expansion}/{patch}/{drawer}");
                FilesSkipped++;
                return;
            }
            
            loadedQuests.AddRange(quests);
            log.Information($"Loaded {quests.Count} quests from {expansion}/{patch}/{drawer}");
        }
        catch (Exception ex)
        {
            log.Error(ex, $"Failed to load quest file: {filePath}");
        }
    }
    
    /// <summary>
    /// Checks if a quest is complete using FFXIV's QuestManager.
    /// </summary>
    private static unsafe bool IsQuestComplete(uint questId)
    {
        return QuestManager.IsQuestComplete((ushort)questId);
    }
    
    public void Dispose()
    {
        loadedQuests.Clear();
        tocEntries.Clear();
        completedFiles.Clear();
    }
}
