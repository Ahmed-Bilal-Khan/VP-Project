using System.Windows.Forms;

namespace VP_Project.Model.Bullet
{
    enum BULLET_TYPE { RED, YELLOW, BLUE, GREEN, LASER };
    internal abstract class Bullet
    {
        protected PictureBox bulletSprite;
        protected Control parent;

        protected int spawnX;
        protected int spawnY;
        protected int SPEED;
        protected abstract void CreateBullet();
        public abstract void MoveBullet();
        public abstract void CheckCollision();
        public abstract bool IsWasted();
    }
}
