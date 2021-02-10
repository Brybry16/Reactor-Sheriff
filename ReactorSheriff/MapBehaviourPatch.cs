using HarmonyLib;

namespace ReactorSheriff
{
    [HarmonyPatch]
    public class MapBehaviourPatch
    {
        [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.ShowCountOverlay))]
        public static class ShowCountOverlayPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch]
            public static void Postfix()
            {
                PlayerControlPatch.changeAdminState(true);
            }
        }

        [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.Close))]
        public static class MinigameClosePatch
        {
            [HarmonyPostfix]
            [HarmonyPatch]
            public static void Postfix()
            {
                PlayerControlPatch.changeAdminState(false);
            }
        }
    }
}