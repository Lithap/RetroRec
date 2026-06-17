namespace RetroRec.Utilities
{
    /// <summary>
    /// Shared logging helper that wraps the Il2Cpp → Unity Debug.Log bridge
    /// so every patch site doesn't have to repeat the two-call conversion.
    /// </summary>
    public static class LogHelper
    {
        public static void Log(string message)
        {
            UnityEngine.Debug.Log(
                (Il2CppSystem.Object)message);
        }
    }
}
