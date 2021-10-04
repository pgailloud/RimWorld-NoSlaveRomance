using Verse;

namespace Rimworld.CactusPie.NoSlaveRomance
{
    public class NoSlaveRomanceSettings : ModSettings
    {
        public bool PreventRomanceWithSlaves = true;

        public bool PreventRomanceWithColonists = true;

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref PreventRomanceWithSlaves, "PreventRomanceWithSlaves", defaultValue: true);
            Scribe_Values.Look(ref PreventRomanceWithColonists, "PreventRomanceWithColonists", defaultValue: true);
            base.ExposeData();
        }
    }
}