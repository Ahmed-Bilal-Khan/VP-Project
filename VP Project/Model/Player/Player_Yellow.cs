using System.Collections.Generic;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Player_Yellow : Player
    {
        public Player_Yellow(Control parent, int spawnX, int spawnY)
        {
            SPEED = 8;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;
            bullets = new List<Bullet.Bullet>();

            bulletType = Bullet.BULLET_TYPE.YELLOW;

            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_yellow;

            SetPlayerSprite();
        }
    }
}
