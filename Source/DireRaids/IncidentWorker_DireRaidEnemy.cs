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
        if (DireRaidsMod.instance.Settings.noMechs && parms.faction == Faction.OfMechanoids)
        {
            Log.Message("[DireRaids] points not changed, mechanoid raid");
            return;
        }

        var points = parms.points;
        parms.points *= DireRaidsMod.instance.Settings.pointMult;
        Log.Message($"[DireRaids] points recalculated: {points} to {parms.points}");
    }

    protected override string GetLetterLabel(IncidentParms parms)
    {
        if (DireRaidsMod.instance.Settings.noMechs && parms.faction == Faction.OfMechanoids)
        {
            return base.GetLetterLabel(parms);
        }

        return "DireRaidEnemy.letterLabel".Translate();
    }

    protected override string GetLetterText(IncidentParms parms, List<Pawn> pawns)
    {
        if (DireRaidsMod.instance.Settings.noMechs && parms.faction == Faction.OfMechanoids)
        {
            return base.GetLetterText(parms, pawns);
        }

        return "DireRaidEnemy.letterText".Translate() + "\n\n" + base.GetLetterText(parms, pawns);
    }
}