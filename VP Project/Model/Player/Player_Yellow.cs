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
            SetPlayerSprite();
            bullets = new List<Bullet.Bullet>();
        }
        public override void Shoot()
        {
            Bullet.Bullet bullet = new Model.Bullet.BulletBasic(
                parent: parent,
                type: Bullet.BULLET_TYPE.YELLOW,
                spawnX: playerSprite.Location.X + 10,
                spawnY: playerSprite.Location.Y);
        }

        protected override void SetPlayerSprite()
        {
            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_yellow;
            playerSprite.Size = new System.Drawing.Size(32, 32);
            parent.Controls.Add(playerSprite);
            playerSprite.Show();
            playerSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            playerSprite.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
