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
        incidentDef.baseChance = DireRaidsMod.instance.Settings.baseChance;
        incidentDef.minRefireDays = DireRaidsMod.instance.Settings.minRefireDays;
        incidentDef.minThreatPoints = DireRaidsMod.instance.Settings.minThreatPoints;
        incidentDef.minPopulation = DireRaidsMod.instance.Settings.minPopulation;
    }
}