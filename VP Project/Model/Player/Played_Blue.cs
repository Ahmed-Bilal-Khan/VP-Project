using System;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Played_Blue : Player
    {
        Played_Blue()
        {
            SPEED = 7;
            playerHealth = 100;
            playerSprite = new PictureBox();
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        protected override void SetPlayerSprite()
        {
            throw new NotImplementedException();
        }
    }
}
