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

        public Game(GAME_TYPE type, Control parent)
        {
            this.type = type;
            this.parent = parent;
            switch(type)
            {
                case GAME_TYPE.ENDLESS:
                    player = new Player.Player_Red(this.parent, 400, 500);
                    break;
            }
        }

        public bool RightPressed { get => rightPressed; set => rightPressed = value; }
        public bool LeftPressed { get => leftPressed; set => leftPressed = value; }
        public bool UpPressed { get => upPressed; set => upPressed = value; }
        public bool DownPressed { get => downPressed; set => downPressed = value; }

        public void CheckInput()
        {
            if (rightPressed && !leftPressed)
            {
                player.MoveRight();
            }
            if (DownPressed && !UpPressed)
            {
                player.MoveBackward();
            }
            if (UpPressed && !DownPressed)
            {
                player.MoveForward();
            }
            if (LeftPressed && !RightPressed)
            {
                player.MoveLeft();
            }
        }

        public void MoveBullet()
        {
            foreach (Control c in parent.Controls)
            {
                if (c is PictureBox)
                {
                    PictureBox bulletBox = (PictureBox)c;
                    if (c.Name == "Bullet")
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
