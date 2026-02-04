using Dalamud.Plugin;

namespace MemoriaAlpha;

public sealed class Plugin : IDalamudPlugin
{
    public string Name => "Memoria Alpha";

    // Changed: DalamudPluginInterface → IDalamudPluginInterface
    public Plugin(IDalamudPluginInterface pluginInterface)
    {
        ServiceContainer.Initialize(pluginInterface);
        ServiceContainer.Log.Information("Memoria Alpha v14.2.0.0 initialized!");
    }

    public void Dispose()
    {
        ServiceContainer.Dispose();
        ServiceContainer.Log.Information("Memoria Alpha disposed.");
    }
}
