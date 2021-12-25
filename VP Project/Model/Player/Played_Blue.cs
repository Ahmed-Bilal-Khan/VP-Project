using System.Collections.Generic;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Played_Blue : Player
    {
        public Played_Blue(Control parent, int spawnX, int spawnY)
        {
            SPEED = 9;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;

            bullets = new List<Bullet.Bullet>();

            bulletType = Bullet.BULLET_TYPE.BLUE;

            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_blue;

            SetPlayerSprite();
        }
    }
}
