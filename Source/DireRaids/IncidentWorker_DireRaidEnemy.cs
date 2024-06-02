using System.Collections.Generic;
using RimWorld;
using Verse;

namespace DireRaids;

[StaticConstructorOnStartup]
public class IncidentWorker_DireRaidEnemy : IncidentWorker_RaidEnemy
{
    protected override void ResolveRaidPoints(IncidentParms parms)
    {
        base.ResolveRaidPoints(parms);
        var points = parms.points;
        parms.points *= DireRaidsMod.instance.Settings.pointMult;
        Log.Message($"[DireRaids] points recalculated: {points} to {parms.points}");
    }

    protected override string GetLetterLabel(IncidentParms parms)
    {
        return "DireRaidEnemy.letterLabel".Translate();
    }

    protected override string GetLetterText(IncidentParms parms, List<Pawn> pawns)
    {
        return "DireRaidEnemy.letterText".Translate() + "\n\n" + base.GetLetterText(parms, pawns);
    }
}