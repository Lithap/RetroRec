using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace RetroRec
{
    [BepInPlugin("RetroPatcher", "RetroPatcher", "1.0.0")]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            new Harmony("RetroRec").PatchAll();
            Log.LogInfo("[RetroRec] Patcher loaded.");
        }
    }
}
