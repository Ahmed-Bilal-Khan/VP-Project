using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace VP_Project.Model.Player
{
    internal abstract class Player : IDisposable
    {
        protected List<Bullet.Bullet> bullets;
        protected PictureBox playerSprite;
        protected Control parent;
        protected int SPEED;
        protected double playerHealth;
        protected int spawnX;
        protected int spawnY;
        protected bool playerDead;
        private bool shootsLaser;
        public List<Bullet.Bullet> Bullets { get => bullets; set => bullets = value; }
        public bool ShootsLaser { get => shootsLaser; set => shootsLaser = value; }
        public PictureBox PlayerSprite { get => playerSprite; }

        public abstract void Shoot();
        protected abstract void SetPlayerSprite();
        public virtual void CheckCollision()
        {
            if (playerSprite.IsDisposed)
            {
                DestroySelf();
            }
            //foreach(Control control in parent.Controls)
            //{
            //    if(control.Name == "Laser")
            //    {
            //        if(control.Bounds.IntersectsWith(playerSprite.Bounds))
            //        {
            //            shootsLaser = true;
            //        }
            //    }
            //}
        }
        public virtual void DestroySelf()
        {
            playerSprite.Dispose();
            playerDead = true;
            GC.Collect();
        }
        public virtual void SetName(String name)
        {
            playerSprite.Name = name;
        }

        public virtual bool IsWasted()
        {
            return playerDead;
        }
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

        public void Dispose()
        {
            playerSprite.Dispose();

        }
    }
}
