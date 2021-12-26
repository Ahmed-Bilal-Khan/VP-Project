using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace VP_Project.Model.Player
{
    enum SHOOTING_MODE { SINGLE, DOUBLE, TRIPLE };
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
        protected SHOOTING_MODE shootingMode;
        protected Bullet.BULLET_TYPE bulletType;
        public List<Bullet.Bullet> Bullets { get => bullets; set => bullets = value; }
        public bool ShootsLaser { get => shootsLaser; set => shootsLaser = value; }
        public PictureBox PlayerSprite { get => playerSprite; }
        public double PlayerHealth { get => playerHealth; }

        public virtual void Shoot()
        {
            if (bullets.Count == 0)
            {
                switch (shootingMode)
                {
                    case SHOOTING_MODE.SINGLE:
                        ShootSingle();
                        break;
                    case SHOOTING_MODE.DOUBLE:
                        ShootDouble();
                        break;
                    case SHOOTING_MODE.TRIPLE:
                        ShootTriple();
                        break;
                }
            }

        }
        public void ShootSingle()
        {
            Bullet.Bullet bullet = new Model.Bullet.BulletBasic(
                parent: parent,
                type: bulletType,
                spawnX: playerSprite.Location.X + 10,
                spawnY: playerSprite.Location.Y);
            if (playerSprite.Name == "Player_2")
            {
                bullet.SetName("Player_2_Bullet");
            }
            if (playerSprite.Name == "Player_1")
            {
                bullet.SetName("Player_1_Bullet");
            }
            bullets.Add(bullet);
        }

        public virtual void ShootDouble()
        {
            Bullet.Bullet bullet = new Model.Bullet.BulletBasic(
                parent: parent,
                type: bulletType,
                spawnX: playerSprite.Location.X - 10,
                spawnY: playerSprite.Location.Y);
            Bullet.Bullet bullet2 = new Model.Bullet.BulletBasic(
                parent: parent,
                type: bulletType,
                spawnX: playerSprite.Location.X + 25,
                spawnY: playerSprite.Location.Y);
            if (playerSprite.Name == "Player_2")
            {
                bullet.SetName("Player_2_Bullet");
                bullet2.SetName("Player_2_Bullet");
            }
            if (playerSprite.Name == "Player_1")
            {
                bullet.SetName("Player_1_Bullet");
                bullet2.SetName("Player_1_Bullet");
            }
            bullets.Add(bullet);
            bullets.Add(bullet2);
        }

        public virtual void ShootTriple()
        {
            Bullet.Bullet bullet = new Model.Bullet.BulletBasic(
                parent: parent,
                type: bulletType,
                spawnX: playerSprite.Location.X + 10,
                spawnY: playerSprite.Location.Y - 10);
            Bullet.Bullet bullet2 = new Model.Bullet.BulletBasic(
                parent: parent,
                type: bulletType,
                spawnX: playerSprite.Location.X - 20,
                spawnY: playerSprite.Location.Y);
            Bullet.Bullet bullet3 = new Model.Bullet.BulletBasic(
                parent: parent,
                type: bulletType,
                spawnX: playerSprite.Location.X + 35,
                spawnY: playerSprite.Location.Y);
            if (playerSprite.Name == "Player_2")
            {
                bullet.SetName("Player_2_Bullet");
            }
            if (playerSprite.Name == "Player_1")
            {
                bullet.SetName("Player_1_Bullet");
            }
            bullets.Add(bullet);
            bullets.Add(bullet2);
            bullets.Add(bullet3);
        }
        protected virtual void SetPlayerSprite()
        {
            playerSprite.Size = new System.Drawing.Size(32, 32);
            parent.Controls.Add(playerSprite);
            playerSprite.Show();
            playerSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            playerSprite.BackColor = System.Drawing.Color.Transparent;
        }
        public virtual void CheckCollision()
        {
            if (IsWasted())
            {
                DestroySelf();
            }
            else
            {
                foreach (Control control in parent.Controls)
                {
                    if (control.Name == "ENEMY_1" || control.Name == "ENEMY_2")
                    {
                        if (playerSprite.Bounds.IntersectsWith(control.Bounds))
                        {
                            control.Dispose();
                            playerHealth -= 50;
                        }
                    }
                    if (control.Name == "Laser")
                    {
                        if(control.Bounds.IntersectsWith(playerSprite.Bounds))
                        {
                            control.Dispose();
                            if(shootingMode == SHOOTING_MODE.SINGLE)
                            {
                                shootingMode = SHOOTING_MODE.DOUBLE;
                            }
                            else if(shootingMode == SHOOTING_MODE.DOUBLE)
                            {
                                shootingMode = SHOOTING_MODE.TRIPLE;
                            }
                        }
                    }
                }
            }
        }

        public void CheckPvPCollision()
        {
            if (IsWasted())
            {
                DestroySelf();
            }
            else
            {
                foreach (Control control in parent.Controls)
                {
                    if (control.Name == "Player_2_Bullet")
                    {
                        if (control.Bounds.IntersectsWith(playerSprite.Bounds) && playerSprite.Name == "Player_1")
                        {
                            control.Dispose();
                            playerHealth -= 20;
                        }
                    }
                    if (control.Name == "Player_1_Bullet")
                    {
                        if (control.Bounds.IntersectsWith(playerSprite.Bounds) && playerSprite.Name == "Player_2")
                        {
                            control.Dispose();
                            playerHealth -= 20;
                        }
                    }
                }
            }
        }
        public virtual void DestroySelf()
        {
            foreach(Bullet.Bullet bullet in bullets)
            {
                bullet.Dispose();
            }
            playerSprite.Dispose();
            playerDead = true;
            GC.Collect();
        }
        public virtual void SetName(String name)
        {
            playerSprite.Name = name;

            if(name == "Player_2")
            {
                playerSprite.Image.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
            }
        }

        public virtual bool IsWasted()
        {
            return playerHealth <= 0;
        }
        public void MoveForward()
        {
            if(playerSprite.Location.Y >= 20)
                playerSprite.Top -= SPEED;
        }
        public void MoveBackward()
        {
            if(playerSprite.Location.Y <= 530)
                playerSprite.Top += SPEED;
        }
        public void MoveLeft()
        {
            if (playerSprite.Location.X >= 30)
                playerSprite.Left -= SPEED;
        }
        public void MoveRight()
        {
            if(playerSprite.Location.X <= 750)
                playerSprite.Left += SPEED;
        }

        public void Dispose()
        {
            playerSprite.Dispose();
        }
    }
}
