using HarmonyLib;
using UnityEngine;

namespace ReactorSheriff
{
    [HarmonyPatch(typeof(IntroCutscene.CoBegin__d))]
    public static class IntroCutScenePatch
    {
        [HarmonyPatch(nameof(IntroCutscene.CoBegin__d.MoveNext))]
        public static void Postfix(IntroCutscene.CoBegin__d __instance)
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
