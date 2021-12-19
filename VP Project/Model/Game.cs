using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace VP_Project.Model.Game
{
    enum GAME_TYPE { ENDLESS, STORY, PVP};
    internal class Game
    {
        Player.Player player;
        GAME_TYPE type;
        Control parent;
        public static Timer timer;
        List<Player.Enemy> enemies;

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
                    Create_Endless();
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
            for(int i = 0; i < player.Bullets.Count; i++)
            {
                if(!player.Bullets[i].IsWasted())
                {
                    player.Bullets[i].MoveBullet();
                    player.Bullets[i].CheckCollision();

                }
                if(player.Bullets[i].IsWasted())
                {
                    player.Bullets.RemoveAt(i);
                }
            }
        }

        public void MoveEnemy()
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IsWasted())
                {
                    enemies.RemoveAt(i);
                }
                if (!enemies[i].IsWasted())
                {
                    enemies[i].MoveBackward();
                    enemies[i].CheckCollision();

                }
            }
        }
        private void Create_Endless()
        {
            if(Menu.state == GAME_STATE.GAME_END)
            {
                timer.Stop();
                timer.Enabled = false;
            }
            else if(Menu.state == GAME_STATE.GAME_START)
            {
                switch (Menu.count)
                {
                    case 0:
                        player = new Player.Player_Red(this.parent, 400, 500);
                        break;
                    case 1:
                        player = new Player.Played_Green(this.parent, 300, 500);
                        break;
                    case 2:
                        player = new Player.Played_Blue(this.parent, 350, 500);
                        break;
                    case 3:
                        player = new Player.Player_Yellow(this.parent, 400, 500);
                        break;
                }
                player.SetName("Player");
                enemies = new List<Player.Enemy>();

                timer = new Timer();
                timer.Interval = 1000;
                timer.Tick += new EventHandler(SpawnEnemy);
                timer.Enabled = true;
                timer.Start();
            }
        }
        public void Update()
        {
            if (Menu.state == GAME_STATE.GAME_START && player != null)
            {
                CheckInput();
                MoveBullet();
                MoveEnemy();
            }
            if(player == null)
            {
                timer.Stop();
                timer.Enabled = false;
                timer = new Timer();
            }
            
        }
        private void SpawnEnemy(object sender, EventArgs e)
        {
            if(player != null)
            {
                Random rand = new Random();
                Random rand2 = new Random();


                int spawnY = 3;
                int spawnX = rand.Next(10, 790);

                Player.Enemy enemy = new Player.Enemy(parent, (Player.ENEMY_TYPE)rand2.Next(0, 2), spawnX, spawnY);
                enemies.Add(enemy);

                player.CheckCollision();
                if (player.IsWasted())
                {
                    Menu.state = GAME_STATE.GAME_END;
                    DestroyGame();
                }
            }
        }

        private void DestroyGame()
        {
            player = null;
            foreach(Player.Enemy enemy in enemies)
            {
                enemy.DestroySelf();
            }
            GC.Collect();
        }
    }
}
