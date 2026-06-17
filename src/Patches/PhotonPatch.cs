using HarmonyLib;
using Photon.Realtime;
using RetroRec.Utilities;

namespace RetroRec.Patches
{
    [HarmonyPatch(typeof(PUNNetworkManager), nameof(PUNNetworkManager.FJOLIPKKIBE))]
    internal static class PhotonPatch
    {
        private static void Prefix(ref string __0, ref AppSettings __1)
        {
            __1 = new AppSettings
            {
                AppIdRealtime = "04be29dd-efa0-4a61-b4df-f03d65e01115",
                AppIdVoice    = "35b7f8ad-b55a-4e93-b8dc-1cb9588880d9",
                AppVersion    = "20210804_prod",
                FixedRegion   = __0,
            };

            LogHelper.Log("[RetroRec] Photon AppSettings redirected.");
        }
    }
}
