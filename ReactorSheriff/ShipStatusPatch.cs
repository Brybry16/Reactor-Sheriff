using HarmonyLib;
using System;

namespace ReactorSheriff
{

    [HarmonyPatch(typeof(ShipStatus))]
    public static class ShipStatusPatch
    {

        [HarmonyPatch(nameof(ShipStatus.Start))]
        public static void Postfix(ShipStatus __instance)
        {
            PlayerControlPatch.lastKilled = DateTime.UtcNow;
            PlayerControlPatch.lastKilled = PlayerControlPatch.lastKilled.AddSeconds(-10);

        }
    }
}
