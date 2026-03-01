using System.Collections.Generic;
using HUDReplacer.UI;
using KSP.UI.Screens;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HUDReplacer;

[KSPAddon(KSPAddon.Startup.AllGameScenes, once: false)]
internal class HUDReplacerDebug : MonoBehaviour
{
    internal static HUDReplacerDebug Instance { get; private set; } = null;

    private ApplicationLauncherButton ToolbarButton;
    private static Texture OnTexture;
    private static Texture OffTexture;
    internal static bool EnableDebug { get; set; }

    public static void ModuleManagerPostLoad()
    {
        OnTexture = GameDatabase.Instance.GetTexture("HUDReplacer/Assets/ToolbarOn", false);
        OffTexture = GameDatabase.Instance.GetTexture("HUDReplacer/Assets/ToolbarOff", false);
    }

    protected void Awake()
    {
        if (!SettingsManager.ShowDebugToolbar)
        {
            enabled = false;
            Destroy(this);
            return;
        }

        Instance = this;
    }

    protected void Start()
    {
        GameEvents.onGUIApplicationLauncherReady.Add(OnGUIApplicationLauncherReady);
    }

    protected void OnDestroy()
    {
        if (Instance == this)
            Instance = null;

        GameEvents.onGUIApplicationLauncherReady.Remove(OnGUIApplicationLauncherReady);

        if (ToolbarButton != null)
            ApplicationLauncher.Instance?.RemoveModApplication(ToolbarButton);
    }

    protected void OnGUIApplicationLauncherReady()
    {
        if (ToolbarButton != null)
            return;

        ToolbarButton = ApplicationLauncher.Instance.AddModApplication(
            OnToolbarToggleOn,
            OnToolbarToggleOff,
            null,
            null,
            null,
            null,
            ApplicationLauncher.AppScenes.ALWAYS,
            EnableDebug ? OnTexture : OffTexture
        );

        GameEvents.onGUIApplicationLauncherReady.Remove(OnGUIApplicationLauncherReady);
    }

    void OnToolbarToggleOn()
    {
        DebugWindow.Toggle();
    }

    void OnToolbarToggleOff()
    {
        DebugWindow.Toggle();
    }

    internal void UpdateToolbarTexture()
    {
        if (ToolbarButton != null)
            ToolbarButton.SetTexture(EnableDebug ? OnTexture : OffTexture);
    }

    /// <summary>
    /// Called when the debug window is closed via its X button,
    /// so the AppLauncher button state stays in sync.
    /// </summary>
    internal void OnWindowClosed()
    {
        if (ToolbarButton != null)
            ToolbarButton.SetFalse(makeCall: false);
    }

    static void DumpTexturesUnderCursor()
    {
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y),
        };

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        Debug.Log("HUDReplacer: ========================================");
        foreach (var result in results)
        {
            var image = result.gameObject.GetComponent<Image>();
            if (image == null)
                continue;

            if (image.mainTexture is Texture2D tex)
                Debug.Log($"HUDReplacer: {tex.name} - WxH={tex.width}x{tex.height}");
        }
    }

    void Update()
    {
        if (!EnableDebug)
            return;

        if (Input.GetKeyUp(KeyCode.D))
            DumpTexturesUnderCursor();

        if (Input.GetKeyUp(KeyCode.W))
            DebugWindow.DumpWindow();

        if (Input.GetKeyUp(KeyCode.E))
            DumpTexturesButton.DumpAllTextures();

        if (Input.GetKeyUp(KeyCode.Q))
        {
            HUDReplacer.Instance?.DebugReset();
            Debug.Log("HUDReplacer: Refreshed.");
        }
    }
}

[KSPAddon(KSPAddon.Startup.MainMenu, once: false)]
internal class HUDReplacerDebugMainMenu : HUDReplacerDebug { }
