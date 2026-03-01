using System.Linq;
using UnityEngine;

namespace HUDReplacer;

internal static class HUDReplacerColor
{
    const string ConfigPath = "HUDReplacerRecolor";

    // Tumbler colors
    internal static Color? TumblerColorPositive = null;
    internal static Color? TumblerColorNegative = null;

    // PAW (Part Action Window)
    internal static Color? PAWTitleBar = null;
    internal static Color? PAWBlueButton = null;
    internal static Color? PAWBlueButtonToggle = null;
    internal static Color? PAWVariantSelectorNext = null;
    internal static Color? PAWVariantSelectorPrevious = null;
    internal static Color? PAWResourcePriorityIncrease = null;
    internal static Color? PAWResourcePriorityDecrease = null;
    internal static Color? PAWResourcePriorityReset = null;
    internal static Color? PAWFuelSliderColor = null;
    internal static Color? PAWFuelSliderTextColor = null;

    // KAL-1000 Editor
    internal static Color? KALTitleBar = null;

    // Yaw/Pitch/Roll gauge needles
    internal static Color? GaugeNeedleYawPitchRollColor = null;
    internal static Color? GaugeNeedleYawPitchRollPrecisionColor = null;

    // MET Display (top left clock widget)
    internal static Color? METDisplayColorRed = null;
    internal static Color? METDisplayColorYellow = null;
    internal static Color? METDisplayColorGreen = null;

    // NavBall speed display
    internal static Color? SpeedDisplayColorText = null;
    internal static Color? SpeedDisplayColorSpeed = null;

    // NavBall heading
    internal static Color? NavBallHeadingColor = null;

    // NavBall cursor
    internal static Color? NavBallCursorColor = null;

    // Stage total deltaV
    internal static Color? StageTotalDeltaVColor = null;

    // Stage group deltaV
    internal static Color? StageGroupDeltaVTextColor = null;
    internal static Color? StageGroupDeltaVNumberColor = null;
    internal static Color? StageGroupDeltaVBackgroundColor = null;

    // Stage engine fuel gauge
    internal static Color? StageEngineFuelGaugeTextColor = null;
    internal static Color? StageEngineFuelGaugeBackgroundColor = null;
    internal static Color? StageEngineFuelGaugeFillColor = null;
    internal static Color? StageEngineFuelGaugeFillBackgroundColor = null;

    // Stage engine heat gauge
    internal static Color? StageEngineHeatGaugeTextColor = null;
    internal static Color? StageEngineHeatGaugeBackgroundColor = null;
    internal static Color? StageEngineHeatGaugeFillColor = null;
    internal static Color? StageEngineHeatGaugeFillBackgroundColor = null;

    // Vertical speed gauge
    internal static Color? VerticalSpeedGaugeNeedleColor = null;

    // Maneuver node editor
    internal static Color? ManeuverNodeEditorTextColor = null;

    // SAS display
    internal static Color? SASDisplayOnColor = null;
    internal static Color? SASDisplayOffColor = null;

    // RCS display
    internal static Color? RCSDisplayOnColor = null;
    internal static Color? RCSDisplayOffColor = null;

    // Editor category buttons
    internal static Color? EditorCategoryButtonColor = null;
    internal static Color? EditorCategoryModuleButtonColor = null;
    internal static Color? EditorCategoryResourceButtonColor = null;
    internal static Color? EditorCategoryManufacturerButtonColor = null;
    internal static Color? EditorCategoryTechButtonColor = null;
    internal static Color? EditorCategoryProfileButtonColor = null;
    internal static Color? EditorCategorySubassemblyButtonColor = null;
    internal static Color? EditorCategoryVariantsButtonColor = null;
    internal static Color? EditorCategoryCustomButtonColor = null;

    // csharpier-ignore
    internal static void LoadConfigs()
    {
        UrlDir.UrlConfig[] configs = GameDatabase.Instance.GetConfigs(ConfigPath);
        if (configs.Length <= 0)
            return;

        configs = configs
            .OrderByDescending(x => int.Parse(x.config.GetValue("priority")))
            .ToArray();

        foreach (UrlDir.UrlConfig configFile in configs)
        {
            LoadColor(configFile.config, "tumblerColorPositive", ref TumblerColorPositive);
            LoadColor(configFile.config, "tumblerColorNegative", ref TumblerColorNegative);

            LoadColor(configFile.config, "PAWTitleBar", ref PAWTitleBar);
            LoadColor(configFile.config, "PAWBlueButton", ref PAWBlueButton);
            LoadColor(configFile.config, "PAWBlueButtonToggle", ref PAWBlueButtonToggle);
            LoadColor(configFile.config, "PAWVariantSelectorNext", ref PAWVariantSelectorNext);
            LoadColor(configFile.config, "PAWVariantSelectorPrevious", ref PAWVariantSelectorPrevious);
            LoadColor(configFile.config, "PAWResourcePriorityIncrease", ref PAWResourcePriorityIncrease);
            LoadColor(configFile.config, "PAWResourcePriorityDecrease", ref PAWResourcePriorityDecrease);
            LoadColor(configFile.config, "PAWResourcePriorityReset", ref PAWResourcePriorityReset);
            LoadColor(configFile.config, "PAWFuelSliderColor", ref PAWFuelSliderColor);
            LoadColor(configFile.config, "PAWFuelSliderTextColor", ref PAWFuelSliderTextColor);

            LoadColor(configFile.config, "KALTitleBar", ref KALTitleBar);

            LoadColor(configFile.config, "gaugeNeedleYawPitchRoll", ref GaugeNeedleYawPitchRollColor);
            LoadColor(configFile.config, "gaugeNeedleYawPitchRollPrecision", ref GaugeNeedleYawPitchRollPrecisionColor);

            LoadColor(configFile.config, "METDisplayColorRed", ref METDisplayColorRed);
            LoadColor(configFile.config, "METDisplayColorYellow", ref METDisplayColorYellow);
            LoadColor(configFile.config, "METDisplayColorGreen", ref METDisplayColorGreen);

            LoadColor(configFile.config, "speedDisplayColorText", ref SpeedDisplayColorText);
            LoadColor(configFile.config, "speedDisplayColorSpeed", ref SpeedDisplayColorSpeed);

            LoadColor(configFile.config, "navBallHeadingColor", ref NavBallHeadingColor);
            LoadColor(configFile.config, "navballCursor", ref NavBallCursorColor);

            LoadColor(configFile.config, "stageTotalDeltaVColor", ref StageTotalDeltaVColor);

            LoadColor(configFile.config, "stageGroupDeltaVTextColor", ref StageGroupDeltaVTextColor);
            LoadColor(configFile.config, "stageGroupDeltaVNumberColor", ref StageGroupDeltaVNumberColor);
            LoadColor(configFile.config, "stageGroupDeltaVBackgroundColor", ref StageGroupDeltaVBackgroundColor);

            LoadColor(configFile.config, "stageEngineFuelGaugeTextColor", ref StageEngineFuelGaugeTextColor);
            LoadColor(configFile.config, "stageEngineHeatGaugeTextColor", ref StageEngineHeatGaugeTextColor);
            LoadColor(configFile.config, "stageEngineFuelGaugeBackgroundColor", ref StageEngineFuelGaugeBackgroundColor);
            LoadColor(configFile.config, "stageEngineHeatGaugeBackgroundColor", ref StageEngineHeatGaugeBackgroundColor);
            LoadColor(configFile.config, "stageEngineFuelGaugeFillColor", ref StageEngineFuelGaugeFillColor);
            LoadColor(configFile.config, "stageEngineHeatGaugeFillColor", ref StageEngineHeatGaugeFillColor);
            LoadColor(configFile.config, "stageEngineFuelGaugeFillBackgroundColor", ref StageEngineFuelGaugeFillBackgroundColor);
            LoadColor(configFile.config, "stageEngineHeatGaugeFillBackgroundColor", ref StageEngineHeatGaugeFillBackgroundColor);

            LoadColor(configFile.config, "verticalSpeedGaugeNeedleColor", ref VerticalSpeedGaugeNeedleColor);

            LoadColor(configFile.config, "maneuverNodeEditorTextColor", ref ManeuverNodeEditorTextColor);

            LoadColor(configFile.config, "SASDisplayOnColor", ref SASDisplayOnColor);
            LoadColor(configFile.config, "SASDisplayOffColor", ref SASDisplayOffColor);

            LoadColor(configFile.config, "RCSDisplayOnColor", ref RCSDisplayOnColor);
            LoadColor(configFile.config, "RCSDisplayOffColor", ref RCSDisplayOffColor);

            LoadColor(configFile.config, "EditorCategoryButtonColor", ref EditorCategoryButtonColor);
            LoadColor(configFile.config, "EditorCategoryModuleButtonColor", ref EditorCategoryModuleButtonColor);
            LoadColor(configFile.config, "EditorCategoryResourceButtonColor", ref EditorCategoryResourceButtonColor);
            LoadColor(configFile.config, "EditorCategoryManufacturerButtonColor", ref EditorCategoryManufacturerButtonColor);
            LoadColor(configFile.config, "EditorCategoryTechButtonColor", ref EditorCategoryTechButtonColor);
            LoadColor(configFile.config, "EditorCategoryProfileButtonColor", ref EditorCategoryProfileButtonColor);
            LoadColor(configFile.config, "EditorCategorySubassemblyButtonColor", ref EditorCategorySubassemblyButtonColor);
            LoadColor(configFile.config, "EditorCategoryVariantsButtonColor", ref EditorCategoryVariantsButtonColor);
            LoadColor(configFile.config, "EditorCategoryCustomButtonColor", ref EditorCategoryCustomButtonColor);
        }
    }

    static void LoadColor(ConfigNode config, string key, ref Color? field)
    {
        if (field.HasValue)
            return;

        string value = null;
        if (config.TryGetValue(key, ref value))
            field = value.ToRGBA();
    }
}
