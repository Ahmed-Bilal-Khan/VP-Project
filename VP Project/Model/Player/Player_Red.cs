﻿using System;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Player_Red : Player
    {
        public Player_Red(Control parent, int spawnX, int spawnY)
        {
            SPEED = 7;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;
            SetPlayerSprite();
        }

        protected override void SetPlayerSprite()
        {
            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.red_plane_temp;
            playerSprite.Size = new System.Drawing.Size(32, 32);
            //playerSprite.Parent = parent;
            parent.Controls.Add(playerSprite);
            playerSprite.Show();
            playerSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            playerSprite.BackColor = System.Drawing.Color.Transparent;
        }
        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}