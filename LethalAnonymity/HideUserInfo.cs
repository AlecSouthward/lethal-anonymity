using Steamworks;
using HarmonyLib;

namespace LethalAnonymity;

[HarmonyPatch(typeof(SteamClient), nameof(SteamClient.Name), MethodType.Getter)]
public static class HideUsername
{
    public static bool Prefix(ref string __result)
    {
        __result = Plugin.PluginConfig.Username.Value;

        return false;
    }
}

[HarmonyPatch(typeof(Friend), nameof(Friend.Name), MethodType.Getter)]
public static class HidePersona
{
    public static bool Prefix(ref string __result)
    {
        __result = Plugin.PluginConfig.Username.Value;

        return false;
    }
}

[HarmonyPatch(typeof(HUDManager), nameof(HUDManager.FillImageWithSteamProfile))]
public static class HidePicture
{
    public static bool Prefix()
    {
        return !Plugin.PluginConfig.HideProfilePicture.Value;
    }
}
