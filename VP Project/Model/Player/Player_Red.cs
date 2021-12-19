using System.Collections.Generic;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Player_Red : Player
    {
        public Player_Red(Control parent, int spawnX, int spawnY)
        {
            SPEED = 7;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;
            SetPlayerSprite();
            bullets = new List<Bullet.Bullet>();
        }

        protected override void SetPlayerSprite()
        {
            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_red;
            playerSprite.Size = new System.Drawing.Size(32, 32);
            parent.Controls.Add(playerSprite);
            playerSprite.Show();
            playerSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            playerSprite.BackColor = System.Drawing.Color.Transparent;
        }
        public override void Shoot()
        {
            Bullet.Bullet bullet = new Model.Bullet.BulletBasic(
                parent: parent,
                type: Bullet.BULLET_TYPE.RED,
                spawnX: playerSprite.Location.X+10,
                spawnY: playerSprite.Location.Y);
            bullets.Add(bullet);
        }
    }
}
