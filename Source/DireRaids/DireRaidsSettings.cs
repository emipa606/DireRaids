using Verse;

namespace DireRaids;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class DireRaidsSettings : ModSettings
{
    public float baseChance = 1.8f;
    public int minPopulation = 1;
    public int minRefireDays = 60;
    public int minThreatPoints = 2000;
    public bool noMechs;
    public float pointMult = 3f;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref minThreatPoints, "minThreatPoints", 2000);
        Scribe_Values.Look(ref minRefireDays, "minRefireDays", 60);
        Scribe_Values.Look(ref minPopulation, "minPopulation", 1);
        Scribe_Values.Look(ref baseChance, "baseChance", 1.8f);
        Scribe_Values.Look(ref pointMult, "pointMult", 3f);
        Scribe_Values.Look(ref noMechs, "noMechs");
    }
}