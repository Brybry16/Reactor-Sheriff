using HarmonyLib;
using UnityEngine;

namespace ReactorSheriff
{
    [HarmonyPatch(typeof(IntroCutscene.Nested_0))]
    public static class IntroCutScenePatch
    {
        [HarmonyPatch(nameof(IntroCutscene.Nested_0.MoveNext))]
        public static void Postfix(IntroCutscene.Nested_0 __instance)
        {
            if (PlayerControlPatch.isSheriff(PlayerControl.LocalPlayer))
            {
                __instance.__this.Title.text = "Sheriff";
                __instance.__this.Title.color = new Color(1, (float)(204.0 / 255.0), 0, 1);
                __instance.__this.ImpostorText.text = "Shoot the <color=#FF0000FF>Impostor</color>";
                __instance.__this.BackgroundBar.material.color = new Color(1, (float)(204.0 / 255.0), 0, 1);

            }
        }
    }
}
