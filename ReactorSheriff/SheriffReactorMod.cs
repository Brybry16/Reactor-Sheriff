using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using Reactor.Patches;

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

            ReactorVersionShower.TextUpdated += (text) =>
            {
                int index = text.text.LastIndexOf('\n');
                text.text = text.text.Insert(index == -1 ? text.text.Length - 1 : index, 
                    "\nLoaded <color=#F7C600FF>Sheriff Mod v1.2.4-R</color> by Brybry");
            };
            
            Harmony.PatchAll();
        }
    }
}
