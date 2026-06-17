using HarmonyLib;
using RetroRec.Utilities;

namespace RetroRec.Patches
{
    [HarmonyPatch(
        typeof(Org.BouncyCastle.Crypto.Tls.LegacyTlsAuthentication),
        nameof(Org.BouncyCastle.Crypto.Tls.LegacyTlsAuthentication.NotifyServerCertificate))]
    internal static class TlsPatch
    {
        private static bool Prefix()
        {
            LogHelper.Log("[RetroRec] TLS certificate check bypassed.");
            return PrefixResult.SkipOriginal;
        }
    }
}
