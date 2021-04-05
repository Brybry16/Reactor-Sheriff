using HarmonyLib;
using System;
using System.Linq;
using UnityEngine;


namespace ReactorSheriff
{
    [HarmonyPatch(typeof(HudManager))]
    public static class HudManagerPatch
    {
        // Methods
        
        
        static int counter = 0;

        public static KillButtonManager KillButton = null;
        static System.Random random = new System.Random();
        static string GameSettingsText = null;

        public static bool isMeetingHudActive;


      
        public static void UpdateGameSettingsText(HudManager __instance)
        {
            if (__instance.GameSettings.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Count() == 19)
            {
                GameSettingsText = __instance.GameSettings.Text;
            }
            
            if (GameSettingsText != null)
            {
                if (CustomGameOptions.ShowSheriff)
                    __instance.GameSettings.Text = GameSettingsText + "Show Sheriff: On" + "\n";
                else
                    __instance.GameSettings.Text = GameSettingsText + "Show Sheriff: Off" + "\n";
                
                __instance.GameSettings.Text += "Sheriff Kill Cooldown: " + CustomGameOptions.SheriffKillCD.ToString() + "s";
            }

        }
        public static void updateGameOptions(GameOptionsData options)
        {
            Il2CppSystem.Collections.Generic.List<PlayerControl> allplayer = PlayerControl.AllPlayerControls;

            foreach (PlayerControl player in allplayer)
            {
                player.RpcSyncSettings(options);

            }

        }

        public static void updateMeetingHud(MeetingHud __instance)
        {
            foreach (PlayerVoteArea playerVoteArea in __instance.playerStates)
            {
                if (PlayerControlPatch.Sheriff != null && playerVoteArea.NameText.Text == PlayerControlPatch.Sheriff.name)
                {
                    if (CustomGameOptions.ShowSheriff | PlayerControlPatch.isSheriff(PlayerControl.LocalPlayer))
                    {
                        playerVoteArea.NameText.Color = new Color(1, (float)(204.0 / 255.0), 0, 1);
                    }
                }
            }
        }

        [HarmonyPatch(nameof(HudManager.Update))]
        public static void Postfix(HudManager __instance)
        {
            KillButton = __instance.KillButton;
            isMeetingHudActive = MeetingHud.Instance != null;

            if (isMeetingHudActive)
            {
                updateMeetingHud(MeetingHud.Instance);
            }

            UpdateGameSettingsText(__instance);
      
            if (PlayerControl.AllPlayerControls.Count > 1 & PlayerControlPatch.Sheriff != null)
            {
                if (PlayerControlPatch.isSheriff(PlayerControl.LocalPlayer))
                {

                    PlayerControl.LocalPlayer.nameText.Color = new Color(1, (float)(204.0 / 255.0), 0, 1);
                    
                    
                    if (PlayerControl.LocalPlayer.Data.IsDead || PlayerControlPatch.sheriffInTask || isMeetingHudActive)
                    { 
                        KillButton.gameObject.SetActive(false);
                        KillButton.isActive = false;
                    }
                    else {
                        KillButton.gameObject.SetActive(true);
                        KillButton.isActive = true;
                        KillButton.SetCoolDown(PlayerControlPatch.SheriffKillTimer(), PlayerControl.GameOptions.KillCooldown + 15.0f);
                        PlayerControlPatch.closestPlayer = PlayerControlPatch.getClosestPlayer(PlayerControl.LocalPlayer);
                        double dist = PlayerControlPatch.getDistBetweenPlayers(PlayerControl.LocalPlayer, PlayerControlPatch.closestPlayer);
                        
                        if (dist < GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance])
                        {
                            KillButton.SetTarget(PlayerControlPatch.closestPlayer);
                        } 
                        
                        if (Input.GetKeyInt(KeyCode.Q) && !PlayerControlPatch.sheriffInAdmin)
                        {
                            KillButton.PerformKill();
                        }
                    }
                }
                else if (PlayerControl.LocalPlayer.Data.IsImpostor)
                {
                    if (PlayerControl.LocalPlayer.Data.IsDead)
                    {
                        KillButton.gameObject.SetActive(false);
                        KillButton.isActive = false;
                    }
                    else
                    {
                        KillButton.gameObject.SetActive(true);
                        KillButton.isActive = true;
                    }
                }
            }

            if (counter < 30)
            {
                counter++;
                return;
            }
            counter = 0;

            if (GameOptionsMenuPatch.ShowSheriffOption != null && GameOptionsMenuPatch.SheriffCooldown!=null)
            {
                var isOptionsMenuActive = GameObject.FindObjectsOfType<GameOptionsMenu>().Count != 0;
                GameOptionsMenuPatch.ShowSheriffOption.gameObject.SetActive(isOptionsMenuActive);
                GameOptionsMenuPatch.SheriffCooldown.gameObject.SetActive(isOptionsMenuActive);
            }
        }

    }

    [HarmonyPatch(typeof(MeetingHud))]
    public static class MeetingHudPatchClose
    {

        [HarmonyPatch(nameof(MeetingHud.Close))]
        public static void Postfix(MeetingHud __instance)
        {
            PlayerControlPatch.lastKilled = DateTime.UtcNow;
            PlayerControlPatch.lastKilled = PlayerControlPatch.lastKilled.AddSeconds(8);
        }
    }
}
