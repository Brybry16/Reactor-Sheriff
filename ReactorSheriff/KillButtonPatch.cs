using HarmonyLib;
using Hazel;
using Il2CppSystem.Reflection;
using System;

namespace ReactorSheriff
{
    [HarmonyPatch(typeof(KillButtonManager))]
    public static class KillButtonPatch
    {
        
        [HarmonyPatch(nameof(KillButtonManager.PerformKill))]
        static bool Prefix(MethodBase __originalMethod)
        {
            if (PlayerControlPatch.isSheriff(PlayerControl.LocalPlayer))
            {
                if (PlayerControlPatch.SheriffKillTimer() == 0)
                {
                    var dist = PlayerControlPatch.getDistBetweenPlayers(PlayerControl.LocalPlayer, PlayerControlPatch.closestPlayer);
                    
                    if (dist < GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance])
                    {
                        if (PlayerControlPatch.closestPlayer.Field_6.IsImpostor == false)
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SheriffKill, Hazel.SendOption.None, -1);
                            writer.Write(PlayerControl.LocalPlayer.PlayerId);
                            writer.Write(PlayerControl.LocalPlayer.PlayerId);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            PlayerControl.LocalPlayer.MurderPlayer(PlayerControl.LocalPlayer);
                        }
                        else
                        {
                            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SheriffKill, Hazel.SendOption.None, -1);
                            writer.Write(PlayerControl.LocalPlayer.PlayerId);
                            writer.Write(PlayerControlPatch.closestPlayer.PlayerId);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            PlayerControl.LocalPlayer.MurderPlayer(PlayerControlPatch.closestPlayer);
                        }
                        
                        PlayerControlPatch.lastKilled = DateTime.UtcNow;
                    }
                }
                
                return false;
            }
            
            return true;
        }
    }
}
