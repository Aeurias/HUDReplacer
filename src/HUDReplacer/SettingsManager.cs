using UnityEngine;

namespace HUDReplacer
{
    internal static class SettingsManager
    {
        public static bool ShowDebugToolbar;

        internal static void LoadConfig()
        {
            var node = GameDatabase.Instance.GetConfigNode(
                "HUDReplacer/Settings/HUDReplacerSettings"
            );
            if (node == null)
            {
                Debug.LogError(
                    "[HUDReplacer] Could not load settings. Settings.cfg may be missing."
                );
                return;
            }

            node.TryGetValue("showDebugToolbar", ref ShowDebugToolbar);
        }
    }
}
