using System.Collections.Generic;



namespace ReactorSheriff
{
    class PlayerController
    {
        public static List<Player> players;
        
        public static void Update()
        {
            if (players != null)
            {
                foreach (Player player in players)
                {
                    if(player.playerdata!=null) 
                        player.Update();
                }
            }
        }

        public static void InitPlayers()
        {
            players = new List<Player>();
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                players.Add(new Player(player));
            }
        }

        public static Player getPlayerById(byte id)
        {
            foreach (Player player in players)
            {
                if (player.playerdata.PlayerId == id)
                {
                    return player;
                }
            }
            return null;
        }
        
        public static Player getSheriff()
        {
            foreach (Player player in players)
            {
                if (player.isSheriff)
                {
                    return player;
                }
            }
            return null;
        }

        public static Player getLocalPlayer()
        {
            foreach (Player player in players)
            {
                if (player.playerdata == PlayerControl.LocalPlayer)
                {
                    return player;
                }
            }
            return null;
        }
    }
}


