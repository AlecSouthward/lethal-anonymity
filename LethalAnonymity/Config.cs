using System.Reflection;
using System.Collections.Generic;
using HarmonyLib;
using BepInEx.Configuration;

namespace LethalAnonymity;

class Config
{
    public readonly ConfigEntry<string> Username;

    public readonly ConfigEntry<bool> HideProfilePicture;

    public Config(ConfigFile cfg)
    {
        cfg.SaveOnConfigSet = false;

        Username = cfg.Bind(
            "General",
            "Username",
            "Player",
            "Username to replace your own with"
        );

        HideProfilePicture = cfg.Bind(
            "General",
            "HideProfilePicture",
            true,
            "Show/hide your profile picture in-game"
        );

        ClearOrphanedEntries(cfg);
        cfg.Save();

        cfg.SaveOnConfigSet = true;
    }

    private static void ClearOrphanedEntries(ConfigFile cfg)
    {
        PropertyInfo orphanedEntriesProp = AccessTools.Property(typeof(ConfigFile), "OrphanedEntries");
        var orphanedEntries = (Dictionary<ConfigDefinition, string>)orphanedEntriesProp.GetValue(cfg);

        orphanedEntries.Clear();
    }
}
