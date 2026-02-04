namespace MemoriaAlpha.Models;
using System;


/// <summary>
/// Represents a Main Scenario Quest patch boundary entry from toc.json.
/// Used to detect player progress and determine which quest files to load.
/// </summary>
public sealed class TocEntry
{
    /// <summary>
    /// Patch number (e.g., "2.0", "3.2", "7.3").
    /// </summary>
    public string Patch { get; set; } = string.Empty;
    
    /// <summary>
    /// Expansion abbreviation (e.g., "ARR", "HW", "SB", "ShB", "EW", "DT").
    /// </summary>
    public string Expansion { get; set; } = string.Empty;
    
    /// <summary>
    /// Quest role: "Start" (first quest in patch) or "Final" (last quest in patch).
    /// </summary>
    public string Role { get; set; } = string.Empty;
    
    /// <summary>
    /// Quest name (e.g., "Close to Home", "The Ultimate Weapon").
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Quest IDs associated with this entry. Multiple IDs exist for city-specific variants.
    /// </summary>
    public uint[] Ids { get; set; } = Array.Empty<uint>();
}
