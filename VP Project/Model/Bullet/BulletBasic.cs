using System.Windows.Forms;
namespace VP_Project.Model.Bullet
{
    internal class BulletBasic : Bullet
    {
        BULLET_TYPE type;
        int tries;
        public BulletBasic(Control parent, BULLET_TYPE type, int spawnX, int spawnY)
        {
            this.parent = parent;
            this.type = type;
            this.spawnX = spawnX;
            this.spawnY = spawnY;
            SPEED = 37;
            if(type == BULLET_TYPE.LASER)
            {
                tries = 2;
            }
            else
            {
                tries = 1;
            }
            CreateBullet();

            System.IO.Stream pew_pew = Properties.Resources.pew_pew;
            Game.Game.soundPlayer = new System.Media.SoundPlayer(pew_pew);
            Game.Game.soundPlayer.Play();
        }

        protected override void CreateBullet()
        {
            bulletSprite = new PictureBox();

            switch(type)
            {
                case BULLET_TYPE.RED:
                    bulletSprite.Image = Properties.Resources.bullet_red;
                    break;
                case BULLET_TYPE.GREEN:
                    bulletSprite.Image = Properties.Resources.bullet_green;
                    break;
                case BULLET_TYPE.YELLOW:
                    bulletSprite.Image = Properties.Resources.bullet_yellow;
                    break;
                case BULLET_TYPE.BLUE:
                    bulletSprite.Image = Properties.Resources.bullet_blue;
                    break;
                case BULLET_TYPE.LASER:
                    bulletSprite.Image = Properties.Resources.laser;
                    break;

            }

            bulletSprite.Size = new System.Drawing.Size(10, 20);
            bulletSprite.Parent = parent;
            bulletSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            bulletSprite.Show();
            bulletSprite.Name = "BulletSimple";
            bulletSprite.BackColor = System.Drawing.Color.Transparent;

            
        }

        public override void MoveBullet()
        {
            bulletSprite.Location = new System.Drawing.Point(bulletSprite.Location.X, bulletSprite.Location.Y - SPEED);
        }

        public override void CheckCollision()
        {
            foreach(Control control in parent.Controls)
            {
                if (control.Name == "BoundaryTop" || control.Name == "BoundaryBottom")
                {
                    if (bulletSprite.Bounds.IntersectsWith(control.Bounds))
                    {
                        bulletSprite.Dispose();
                        //GC.Collect();
                    }
                }
                if(control.Name == "ENEMY_1" || control.Name == "ENEMY_2")
                {
                    if(!bulletSprite.IsDisposed)
                    {
                        if (bulletSprite.Bounds.IntersectsWith(control.Bounds))
                        {
                            shotEnemy = true;
                            bulletSprite.Dispose();
                            control.Dispose();
                            //GC.Collect();
                        }
                    }
                }
            }
        }

        public override bool IsWasted()
        {
            return (bulletSprite.IsDisposed);
        }
    }
}
