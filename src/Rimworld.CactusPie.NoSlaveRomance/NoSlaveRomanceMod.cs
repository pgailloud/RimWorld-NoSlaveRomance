using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace Rimworld.CactusPie.NoSlaveRomance
{
    public class NoSlaveRomanceMod : Mod
    {
        private readonly NoSlaveRomanceSettings _settings;
        
        public NoSlaveRomanceMod(ModContentPack content) : base(content)
        {
            _settings = GetSettings<NoSlaveRomanceSettings>();
            var harmony = new Harmony("Rimworld.CactusPie.NoSlaveRomance");
            
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("Prevent slaves from romancing colonists", ref _settings.PreventRomanceWithColonists);
            listingStandard.CheckboxLabeled("Prevent slaves from romancing slaves", ref _settings.PreventRomanceWithSlaves);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        
        public override string SettingsCategory()
        {
            return "No Slave Romance";
        }
    }
}