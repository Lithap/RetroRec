using HarmonyLib;
using RetroRec.Utilities;

namespace RetroRec.Patches
{
    /// <summary>
    /// Consolidated image-related patches.  Previously these lived in three
    /// separate classes across two namespaces (<c>RetroRec.Images</c> +
    /// <c>RetroRec.ImagesPatch</c>, <c>Patches.ImageSigPatch</c>, and
    /// <c>Patches.BypassImageHeaderPatch</c>).
    /// </summary>
    internal static class ImagePatches
    {
        /// <summary>
        /// Public helper retained for any external callers that referenced
        /// <c>RetroRec.Images.VerifySignature</c>.
        /// </summary>
        public static bool VerifySignature(byte[] payload, byte[] signature) => true;

        // ── RetroRec.Images.VerifySignature bypass ──────────────────────

        [HarmonyPatch(typeof(Images), nameof(Images.VerifySignature))]
        internal static class VerifySignaturePatch
        {
            private static bool Prefix(ref byte[] payload, ref byte[] signature, out bool __result)
            {
                LogHelper.Log("[RetroRec] Image signature verification bypassed.");
                return PrefixResult.BypassWithTrue(out __result);
            }
        }

        // ── OHDHPENHDAP.DHEFMCDHLCG bypass (obfuscated sig check) ──────

        [HarmonyPatch(typeof(OHDHPENHDAP), nameof(OHDHPENHDAP.DHEFMCDHLCG))]
        internal static class ObfuscatedSigPatch
        {
            private static bool Prefix(out bool __result)
            {
                return PrefixResult.BypassWithTrue(out __result);
            }
        }

        // ── HOOILIHKMEG.NCEALEFPEKL header rewrite ─────────────────────

        [HarmonyPatch(typeof(HOOILIHKMEG), nameof(HOOILIHKMEG.NCEALEFPEKL))]
        internal static class HeaderPatch
        {
            private static void Postfix(string __0, ref string __result)
            {
                if (__0 != "Content-Signature")
                    return;

                var id = OHDHPENHDAP.JCHKODEDLIL();
                __result = "key-id=KEY:RSA:" + id + ".rec.net;data=AA==";
            }
        }
    }

    /// <summary>
    /// Kept as a public façade so existing code referencing
    /// <c>RetroRec.Images.VerifySignature</c> still compiles.
    /// </summary>
    public static class Images
    {
        public static bool VerifySignature(byte[] payload, byte[] signature)
            => ImagePatches.VerifySignature(payload, signature);
    }
}
