using HarmonyLib;
using RimWorld;
using Verse;

namespace Rimworld.CactusPie.NoSlaveRomance
{
    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), nameof(InteractionWorker_RomanceAttempt.RandomSelectionWeight))]
    internal class DisableSlaveRomancePatch
    {
        private static bool Prefix(ref float __result, Pawn initiator, Pawn recipient)
        {
            if (initiator.IsSlave || recipient.IsSlave)
            {
                __result = 0f;
                return false;
            }
            
            return true; 
        }
    }
}