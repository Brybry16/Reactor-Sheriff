using System;
using HarmonyLib;

namespace ReactorSheriff
{
    [HarmonyPatch]
    public static class MinigamePatch
    {
        [HarmonyPatch(typeof(Minigame), nameof(Minigame.Begin))]
        public static class MinigameBeginPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch]
            public static void Postfix()
            {
                PlayerControlPatch.changeTaskState(true);
            }
        }

        [HarmonyPatch(typeof(Minigame), nameof(Minigame.Close), new Type[] {})]
        public static class MinigameClosePatch
        {
            [HarmonyPostfix]
            [HarmonyPatch]
            public static void Postfix()
            {
                PlayerControlPatch.changeTaskState(false);
            }
        }
    }
}