using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;

namespace ReactorSheriff
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class SheriffReactorMod : BasePlugin
    {
        public const string Id = "ch.brybry.reactorsheriff";

        public Harmony Harmony { get; } = new Harmony(Id);

        public static BepInEx.Logging.ManualLogSource log;

        public SheriffReactorMod()
        {
            log = Log;
        }
        
        public override void Load()
        {
            log.LogMessage("Sheriff Mod loaded");

            Harmony.PatchAll();
        }
    }
}
