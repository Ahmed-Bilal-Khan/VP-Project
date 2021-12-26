using System.Windows.Forms;
using System;

namespace VP_Project.Model.Bullet
{
    enum BULLET_TYPE { RED, YELLOW, BLUE, GREEN, LASER };
    internal abstract class Bullet : IDisposable
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

        protected bool shotEnemy;

        public bool ShotEnemy { get => shotEnemy; }

        public virtual void SetName(string name)
        {
            bulletSprite.Name = name;

            if (name == "Player_2_Bullet")
            {
                bulletSprite.Image.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
                SPEED = -SPEED;
            }
        }

        public void Dispose()
        {
            bulletSprite.Dispose();
        }
    }
}
