using System;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    enum ENEMY_TYPE { ENEMY_1, ENEMY_2};
    internal class Enemy : Player
    {
        ENEMY_TYPE enemyType;
        public Enemy(Control parent, ENEMY_TYPE enemyType, int spawnX, int spawnY)
        {
            SPEED = 8;
            this.enemyType = enemyType;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;
            SetPlayerSprite();
        }


        public override void CheckCollision()
        {
            foreach (Control control in parent.Controls)
            {
                if (control.Name == "BoundaryBottom")
                {
                    if (playerSprite.Bounds.IntersectsWith(control.Bounds))
                    {
                        DestroySelf();
                    }
                }
                //if (control.Name == "Player")
                //{
                //    if (!playerSprite.IsDisposed && !playerSprite.IsDisposed)
                //        if (playerSprite.Bounds.IntersectsWith(control.Bounds))
                //        {
                //            hitPlayer = true;
                //            //control.Dispose();
                //            DestroySelf();
                //        }
                //}
            }
        }

        public override void DestroySelf()
        {
            //playerSprite.Location = new System.Drawing.Point(playerSprite.Location.X, 580);
            playerSprite.Dispose();
            //GC.Collect();
        }
        public override bool IsWasted()
        {
            return playerSprite.IsDisposed;
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        protected override void SetPlayerSprite()
        {
            playerSprite = new PictureBox();
            
            switch(enemyType)
            {
                case ENEMY_TYPE.ENEMY_1:
                    playerSprite.Image = Properties.Resources.enemy_1;
                    playerSprite.Name = "ENEMY_1";
                    break;
                case ENEMY_TYPE.ENEMY_2:
                    playerSprite.Image = Properties.Resources.enemy_2;
                    playerSprite.Name = "ENEMY_2";
                    break;
            }
            playerSprite.Size = new System.Drawing.Size(32, 32);
            parent.Controls.Add(playerSprite);
            playerSprite.Show();
            playerSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            playerSprite.BackColor = System.Drawing.Color.Transparent;
            playerSprite.Image.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
        }
    }
}
