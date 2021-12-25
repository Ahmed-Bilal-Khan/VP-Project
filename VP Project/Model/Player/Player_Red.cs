using System.Collections.Generic;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Player_Red : Player
    {
        public Player_Red(Control parent, int spawnX, int spawnY)
        {
            SPEED = 11;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;
            bullets = new List<Bullet.Bullet>();

            bulletType = Bullet.BULLET_TYPE.RED;

            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_red;

            SetPlayerSprite();
        }
    }
}
