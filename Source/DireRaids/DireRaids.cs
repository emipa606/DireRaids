using RimWorld;
using Verse;

namespace DireRaids;

[StaticConstructorOnStartup]
public static class DireRaids
{
    static DireRaids()
    {
        ApplySettings();
    }

    public static void ApplySettings()
    {
        var incidentDef = IncidentDef.Named("DireRaidEnemy");
        incidentDef.baseChance = DireRaidsMod.Instance.Settings.BaseChance;
        incidentDef.minRefireDays = DireRaidsMod.Instance.Settings.MinRefireDays;
        incidentDef.minThreatPoints = DireRaidsMod.Instance.Settings.MinThreatPoints;
        incidentDef.minPopulation = DireRaidsMod.Instance.Settings.MinPopulation;
    }
}