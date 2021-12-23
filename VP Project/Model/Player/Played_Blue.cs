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
            SetPlayerSprite();
            bullets = new List<Bullet.Bullet>();
        }

        public override void Shoot()
        {
            Bullet.BULLET_TYPE bulletType = Bullet.BULLET_TYPE.BLUE;
            if (ShootsLaser)
            {
                bulletType = Bullet.BULLET_TYPE.LASER;
            }
            Bullet.Bullet bullet = new Model.Bullet.BulletBasic(
                parent: parent,
                type: bulletType,
                spawnX: playerSprite.Location.X + 10,
                spawnY: playerSprite.Location.Y);
            bullets.Add(bullet);
        }

        protected override void SetPlayerSprite()
        {
            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_blue;
            playerSprite.Size = new System.Drawing.Size(32, 32);
            parent.Controls.Add(playerSprite);
            playerSprite.Show();
            playerSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            playerSprite.BackColor = System.Drawing.Color.Transparent;


        }
    }
}
