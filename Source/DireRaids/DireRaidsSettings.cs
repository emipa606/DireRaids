using Verse;

namespace DireRaids;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class DireRaidsSettings : ModSettings
{
    public float BaseChance = 1.8f;
    public int MinPopulation = 1;
    public int MinRefireDays = 60;
    public int MinThreatPoints = 2000;
    public bool NoMechs;
    public float PointMult = 3f;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref MinThreatPoints, "minThreatPoints", 2000);
        Scribe_Values.Look(ref MinRefireDays, "minRefireDays", 60);
        Scribe_Values.Look(ref MinPopulation, "minPopulation", 1);
        Scribe_Values.Look(ref BaseChance, "baseChance", 1.8f);
        Scribe_Values.Look(ref PointMult, "pointMult", 3f);
        Scribe_Values.Look(ref NoMechs, "noMechs");
    }
}