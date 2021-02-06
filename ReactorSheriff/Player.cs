using UnityEngine;

namespace ReactorSheriff
{
    public class Player
    {
        public PlayerControl playerdata;
        public bool isSheriff;

        public Player(PlayerControl playerdata)
        {
            this.playerdata = playerdata;
            isSheriff = false;
        }
        
        public void Update()
        {
            if (isSheriff & (CustomGameOptions.ShowSheriff | this == PlayerController.getLocalPlayer()))
            {
                playerdata.nameText.Color = new Color(48 / 255.0f, 223 / 255.0f, 48 / 255.0f);
            }
        }
    }
}
