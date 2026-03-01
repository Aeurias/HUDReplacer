using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace HUDReplacer;

[KSPAddon(KSPAddon.Startup.Instantly, true)]
internal class HarmonyPatcher : MonoBehaviour
{
    void Awake()
    {
        // NOTE: A Harmony patcher should be placed in a run once Startup addon. The patch is kept between scene changes.
        var harmony = new Harmony("UltraJohn.Mods.HUDReplacer");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}
