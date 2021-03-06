﻿using BepInEx;
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
                int index = text.Text.LastIndexOf('\n');
                text.Text = text.Text.Insert(index == -1 ? text.Text.Length - 1 : index, 
                    "\nLoaded [F7C600FF]Sheriff Mod v1.2.3-R[] by Brybry");
            };
            
            Harmony.PatchAll();
        }
    }
}
