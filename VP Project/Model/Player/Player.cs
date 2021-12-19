using System.Collections.Generic;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal abstract class Player
    {
        protected List<Bullet.Bullet> bullets;
        protected PictureBox playerSprite;
        protected Control parent;
        protected int SPEED;
        protected double playerHealth;
        protected int spawnX;
        protected int spawnY;

        public List<Bullet.Bullet> Bullets { get => bullets; set => bullets = value; }

        public abstract void Shoot();
        protected abstract void SetPlayerSprite();
        public void MoveForward()
        {
            this.playerSprite.Top -= SPEED;
        }
        public void MoveBackward()
        {
            this.playerSprite.Top += SPEED;
        }
        public void MoveLeft()
        {
            this.playerSprite.Left -= SPEED;
        }
        public void MoveRight()
        {
            this.playerSprite.Left += SPEED;
        }

        
    }
}
