using HarmonyLib;

namespace ReactorSheriff
{
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionShowerPatch
    {
        // Methods
        public static void Postfix(VersionShower __instance)
        {
            __instance.text.Text += "\nLoaded [F7C600FF]Sheriff Mod v1.1-R[] by Brybry";
        }
    }

}
