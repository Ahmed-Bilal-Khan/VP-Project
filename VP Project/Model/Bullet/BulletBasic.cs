using System.Windows.Forms;

namespace VP_Project.Model.Bullet
{
    internal class BulletBasic : Bullet
    {
        BULLET_TYPE type;

        public BulletBasic(Control parent, BULLET_TYPE type, int spawnX, int spawnY)
        {
            this.parent = parent;
            this.type = type;
            this.spawnX = spawnX;
            this.spawnY = spawnY;

            CreateBullet();
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
            }

            bulletSprite.Size = new System.Drawing.Size(10, 20);
            bulletSprite.Parent = parent;
            bulletSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            bulletSprite.Show();
            bulletSprite.Name = "BulletSimple";
            bulletSprite.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
