using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using MemoriaAlpha.Services;

namespace MemoriaAlpha;

public class ServiceContainer  // ← Changed from Services
{
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; set; } = null!;
    [PluginService] public static IPluginLog Log { get; set; } = null!;
    [PluginService] public static ICommandManager CommandManager { get; set; } = null!;
    [PluginService] public static IClientState ClientState { get; set; } = null!;
    
    public static QuestRepository QuestRepository { get; private set; } = null!;
    
    public static void Initialize(IDalamudPluginInterface pluginInterface)
    {
        pluginInterface.Create<ServiceContainer>();  // ← Changed
        
        QuestRepository = new QuestRepository(PluginInterface, Log);
        QuestRepository.Initialize();
        
        Log.Information("Services initialized.");
    }
    
    public static void Dispose()
    {
        QuestRepository?.Dispose();
        Log.Information("Services disposed.");
    }
}
