using Mlie;
using UnityEngine;
using Verse;

namespace DireRaids;

[StaticConstructorOnStartup]
internal class DireRaidsMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static DireRaidsMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public DireRaidsMod(ModContentPack content) : base(content)
    {
        Instance = this;
        Settings = GetSettings<DireRaidsSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal DireRaidsSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Dire Raids";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Label("DireRaids.DangerSetting".Translate(), -1,
            "DireRaids.DangerSettingDescription".Translate());
        Settings.PointMult = Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.PointMult, 0.1f, 10f,
            false, Settings.PointMult.ToStringDecimalIfSmall());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.BaseChance".Translate(), -1, "DireRaids.BaseChanceDescription".Translate());
        Settings.BaseChance = Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.BaseChance, 0.1f, 10f,
            false, Settings.BaseChance.ToStringDecimalIfSmall());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.MinRefire".Translate(), -1, "DireRaids.MinRefireDescription".Translate());
        Settings.MinRefireDays = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.MinRefireDays, 1f,
            300f,
            false, Settings.MinRefireDays.ToString());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.MinPopulation".Translate(), -1,
            "DireRaids.MinPopulationDescription".Translate());
        Settings.MinPopulation = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.MinPopulation, 1f,
            30f,
            false, Settings.MinPopulation.ToString());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.MinThreat".Translate(), -1, "DireRaids.MinThreatDescription".Translate());
        Settings.MinThreatPoints = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.MinThreatPoints,
            100f,
            10000f,
            false, Settings.MinThreatPoints.ToString());
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("DireRaids.NoMechs".Translate(), ref Settings.NoMechs);
        listing_Standard.Gap();
        if (listing_Standard.ButtonText("DireRaids.Reset".Translate()))
        {
            Settings.PointMult = 3f;
            Settings.BaseChance = 1.8f;
            Settings.MinRefireDays = 60;
            Settings.MinPopulation = 1;
            Settings.MinThreatPoints = 2000;
            Settings.NoMechs = false;
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("DireRaids.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        DireRaids.ApplySettings();
    }
}