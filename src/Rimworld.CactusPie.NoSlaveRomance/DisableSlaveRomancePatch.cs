using HarmonyLib;
using RimWorld;
using Verse;

namespace Rimworld.CactusPie.NoSlaveRomance
{
    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), nameof(InteractionWorker_RomanceAttempt.RandomSelectionWeight))]
    internal class DisableSlaveRomancePatch
    {
        private static readonly NoSlaveRomanceSettings Settings = LoadedModManager.GetMod<NoSlaveRomanceMod>().GetSettings<NoSlaveRomanceSettings>();
        
        private static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
        {
            if (Settings.PreventRomanceWithColonists)
            {
                if (Settings.PreventRomanceWithSlaves)
                {
                    if (initiator.IsSlave || recipient.IsSlave)
                    {
                        __result = 0f;
                        return;
                    }
                }

                if (initiator.IsSlave ^ recipient.IsSlave)
                {
                    __result = 0f;
                    return;
                }
            }

            if (Settings.PreventRomanceWithSlaves && initiator.IsSlave && recipient.IsSlave)
            {
                __result = 0f;
            }
        }
    }
}