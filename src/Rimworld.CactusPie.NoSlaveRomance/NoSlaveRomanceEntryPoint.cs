using System.Reflection;
using HarmonyLib;
using Verse;

namespace Rimworld.CactusPie.NoSlaveRomance
{
    [StaticConstructorOnStartup]
    public static class NoSlaveRomanceEntryPoint
    {
        static NoSlaveRomanceEntryPoint()
        {
            var harmony = new Harmony("Rimworld.CactusPie.NoSlaveRomance");
            
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}