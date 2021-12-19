using System.Windows.Forms;

namespace VP_Project.Model.Bullet
{
    enum BULLET_TYPE { RED, YELLOW, BLUE, GREEN };
    internal abstract class Bullet
    {
        protected PictureBox bulletSprite;
        protected Control parent;
        protected double bulletDamage;
        protected int spawnX;
        protected int spawnY;

        protected abstract void CreateBullet();
    }
}
