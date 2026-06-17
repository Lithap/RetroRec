using HarmonyLib;
using RetroRec.Utilities;

namespace RetroRec.Patches
{
    [HarmonyPatch(typeof(CheatManager), nameof(CheatManager.Awake))]
    internal static class CheatPatch
    {
        private static bool Prefix() => PrefixResult.SkipOriginal;
    }
}
