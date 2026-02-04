namespace MemoriaAlpha.Models;
using System;

/// <summary>
/// Represents a single FFXIV quest.
/// Designed to match community-vetted quest data structure (2.0-7.3).
/// </summary>
public sealed class Quest
{
    /// <summary>
    /// Quest title as displayed in-game.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Quest ID(s) from FFXIV's internal database.
    /// Multiple IDs exist for quests with branching paths or city-specific variants.
    /// </summary>
    public uint[] Id { get; set; } = Array.Empty<uint>();

    /// <summary>
    /// Geographic area where the quest is located.
    /// </summary>
    public string Area { get; set; } = string.Empty;

    /// <summary>
    /// Starting city/location restriction (for city-specific quests).
    /// Values: "Gridania", "Limsa Lominsa", "Ul'dah", or empty.
    /// </summary>
    public string Start { get; set; } = string.Empty;

    /// <summary>
    /// Grand Company restriction (if applicable).
    /// Values: "Twin Adder", "Maelstrom", "Immortal Flames", or empty.
    /// </summary>
    public string Gc { get; set; } = string.Empty;

    /// <summary>
    /// Minimum level required to accept the quest.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Returns a human-readable representation of the quest.
    /// </summary>
    public override string ToString()
    {
        return $"[Lv{Level}] {Title} ({Area})";
    }
}
