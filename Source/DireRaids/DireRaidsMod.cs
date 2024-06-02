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
    public static DireRaidsMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public DireRaidsMod(ModContentPack content) : base(content)
    {
        instance = this;
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
        Settings.pointMult = Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.pointMult, 0.1f, 10f,
            false, Settings.pointMult.ToStringDecimalIfSmall());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.BaseChance".Translate(), -1, "DireRaids.BaseChanceDescription".Translate());
        Settings.baseChance = Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.baseChance, 0.1f, 10f,
            false, Settings.baseChance.ToStringDecimalIfSmall());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.MinRefire".Translate(), -1, "DireRaids.MinRefireDescription".Translate());
        Settings.minRefireDays = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.minRefireDays, 1f,
            300f,
            false, Settings.minRefireDays.ToString());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.MinPopulation".Translate(), -1,
            "DireRaids.MinPopulationDescription".Translate());
        Settings.minPopulation = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.minPopulation, 1f,
            30f,
            false, Settings.minPopulation.ToString());
        listing_Standard.Gap();
        listing_Standard.Label("DireRaids.MinThreat".Translate(), -1, "DireRaids.MinThreatDescription".Translate());
        Settings.minThreatPoints = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(20), Settings.minThreatPoints,
            100f,
            10000f,
            false, Settings.minThreatPoints.ToString());
        listing_Standard.Gap();
        if (listing_Standard.ButtonText("DireRaids.Reset".Translate()))
        {
            Settings.pointMult = 3f;
            Settings.baseChance = 1.8f;
            Settings.minRefireDays = 60;
            Settings.minPopulation = 1;
            Settings.minThreatPoints = 2000;
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