namespace RetroRec.Utilities
{
    /// <summary>
    /// Reusable helpers for common Harmony Prefix return patterns.
    /// </summary>
    public static class PrefixResult
    {
        /// <summary>
        /// Standard "skip the original method" return value for a Harmony Prefix.
        /// </summary>
        public const bool SkipOriginal = false;

        /// <summary>
        /// Sets <paramref name="result"/> to <c>true</c> and returns
        /// <see cref="SkipOriginal"/> — the most common bypass pattern used
        /// by the image-signature and verification patches.
        /// </summary>
        public static bool BypassWithTrue(out bool result)
        {
            result = true;
            return SkipOriginal;
        }
    }
}
