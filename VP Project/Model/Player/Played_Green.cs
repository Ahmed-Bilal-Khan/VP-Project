﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal class Played_Green : Player
    {
        public Played_Green(Control parent, int spawnX, int spawnY)
        {
            SPEED = 6;
            playerHealth = 100;
            base.parent = parent;
            base.spawnX = spawnX;
            base.spawnY = spawnY;
            SetPlayerSprite();
        }
        public override void Shoot()
        {
            Bullet.Bullet bullet = new Model.Bullet.BulletBasic(
                parent: parent,
                type: Bullet.BULLET_TYPE.GREEN,
                spawnX: playerSprite.Location.X + 10,
                spawnY: playerSprite.Location.Y);
        }

        protected override void SetPlayerSprite()
        {
            playerSprite = new PictureBox();
            playerSprite.Image = Properties.Resources.plane_green;
            playerSprite.Size = new System.Drawing.Size(32, 32);
            parent.Controls.Add(playerSprite);
            playerSprite.Show();
            playerSprite.Location = new System.Drawing.Point(spawnX, spawnY);
            playerSprite.BackColor = System.Drawing.Color.Transparent;
        }
    }
}