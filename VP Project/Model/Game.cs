using System;
using System.Windows.Forms;

namespace VP_Project.Model
{
    enum GAME_TYPE { ENDLESS, STORY, PVP};
    
    internal class Game
    {
        Player.Player player;
        GAME_TYPE type;
        Control parent;

        // Input Checks
        Boolean rightPressed;
        Boolean leftPressed;
        Boolean upPressed;
        Boolean downPressed;
        Boolean shootPressed;

        public Game(GAME_TYPE type, Control parent)
        {
            this.type = type;
            this.parent = parent;
            switch(type)
            {
                case GAME_TYPE.ENDLESS:
                    player = new Player.Player_Yellow(this.parent, 400, 500);
                    break;
            }
        }

        public bool RightPressed { get => rightPressed; set => rightPressed = value; }
        public bool LeftPressed { get => leftPressed; set => leftPressed = value; }
        public bool UpPressed { get => upPressed; set => upPressed = value; }
        public bool DownPressed { get => downPressed; set => downPressed = value; }
        public bool ShootPressed { get => shootPressed; set => shootPressed = value; }

        public void CheckInput()
        {
            if (RightPressed && !LeftPressed)
            {
                player.MoveRight();
            }
            if (DownPressed && !UpPressed && !LeftPressed && !RightPressed)
            {
                player.MoveBackward();
            }
            if (UpPressed && !DownPressed && !LeftPressed && !RightPressed)
            {
                player.MoveForward();
            }
            if (LeftPressed && !RightPressed)
            {
                player.MoveLeft();
            }
            if(ShootPressed)
            {
                player.Shoot();
                ShootPressed = false;
            }
        }

        public void MoveBullet()
        {
            foreach (Control c in parent.Controls)
            {
                if (c is PictureBox)
                {
                    PictureBox bulletBox = (PictureBox)c;
                    if (c.Name == "BulletSimple")
                    {
                        bulletBox.Location = new System.Drawing.Point(bulletBox.Location.X, bulletBox.Location.Y - 32);

                    }
                    if (c.Name == "BulletMedium")
                    {
                        bulletBox.Location = new System.Drawing.Point(bulletBox.Location.X, bulletBox.Location.Y - 37);

                    }
                    if (bulletBox.Location.Y == 300)
                    {
                        bulletBox.Dispose();
                        bulletBox = null;
                    }
                }
            }
        }
    }
}
