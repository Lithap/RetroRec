using System;
using HarmonyLib;

namespace RetroRec.Patches
{
    [HarmonyPatch(typeof(BestHTTP.HTTPManager), nameof(BestHTTP.HTTPManager.SendRequest),
        new Type[] { typeof(BestHTTP.HTTPRequest) })]
    internal static class NameserverPatch
    {
        private static void Prefix(ref BestHTTP.HTTPRequest __0)
        {
            if (__0.Uri == null)
                return;

            var url = __0.Uri.ToString();

            if (url.Contains("rectrorec.net"))
                return;

            if (!url.Contains("rec.net"))
                return;

            string redirected;
            if (url.Contains("ns.rec.net"))
            {
                redirected = "https://rectrorec.net/2";
            }
            else
            {
                int schemeEnd = url.IndexOf("://") + 3;
                int pathStart = url.IndexOf('/', schemeEnd);
                string path = pathStart >= 0 ? url.Substring(pathStart) : "";
                redirected = "https://rectrorec.net" + path;
            }

            __0.Uri = new Il2CppSystem.Uri(redirected);
        }
    }
}
