﻿using HarmonyLib;
using UnityEngine;

namespace ReactorSheriff
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__11))]
    public static class IntroCutScenePatch
    {
        [HarmonyPatch(nameof(IntroCutscene._CoBegin_d__11.MoveNext))]
        public static void Postfix(IntroCutscene._CoBegin_d__11 __instance)
        {
            if (PlayerControlPatch.isSheriff(PlayerControl.LocalPlayer))
            {
                __instance.__this.Title.Text = "Sheriff";
                __instance.__this.Title.Color = new Color(1, (float)(204.0 / 255.0), 0, 1);
                __instance.__this.ImpostorText.Text = "Shoot the [FF0000FF]Impostor";
                __instance.__this.BackgroundBar.material.color = new Color(1, (float)(204.0 / 255.0), 0, 1);

            }
        }
    }
}
