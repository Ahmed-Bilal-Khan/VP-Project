using System.Collections.Generic;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Played_Green : Player
    {
        public Played_Green(Control parent, int spawnX, int spawnY)
        {
            SPEED = 15;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;
            bullets = new List<Bullet.Bullet>();
            bulletType = Bullet.BULLET_TYPE.GREEN;

            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_green;

            SetPlayerSprite();
        }
    }
}
