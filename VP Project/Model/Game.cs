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
        static int countdown;
        static int appearTime;
        static int appearDelay;
        static int timeSinceAppearance;
        static int setPlayerToNormal;
        PictureBox laserBox;
        // Input Checks
        Boolean rightPressed;
        Boolean leftPressed;
        Boolean upPressed;
        Boolean downPressed;
        Boolean shootPressed;
        static Boolean pickupExists;
        static Boolean playerHasPickup;
        Random r = new Random();
        public Game(GAME_TYPE type, Control parent)
        {
            countdown = 0;
            appearTime = 0;
            appearDelay = r.Next(8, 13);
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
                else
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
            countdown++;
            appearTime++;
            if(pickupExists)
            {
                timeSinceAppearance++;
                if (laserBox.Bounds.IntersectsWith(player.PlayerSprite.Bounds))
                {
                    player.ShootsLaser = true;
                    playerHasPickup = true;
                    setPlayerToNormal = 6;
                }
            }
            if(playerHasPickup)
            {
                setPlayerToNormal++;
                if (setPlayerToNormal % 5 == 0)
                {
                    player.ShootsLaser = false;
                    setPlayerToNormal = 0;
                }
            }
            if(player != null)
            {
                int spawnY = 3;
                int spawnX = r.Next(10, 790);
                Player.Enemy enemy = new Player.Enemy(parent, (Player.ENEMY_TYPE)r.Next(0, 2), spawnX, spawnY);
                enemies.Add(enemy);

                player.CheckCollision();
                if (player.IsWasted())
                {
                    Menu.state = GAME_STATE.GAME_END;
                    DestroyGame();
                }

                if(appearTime == appearDelay)
                {
                    SpawnLaser();
                    appearDelay = r.Next(8, 13);
                    appearTime = 0;
                    timeSinceAppearance = 5;
                    pickupExists = true;
                }
                if(timeSinceAppearance % 4 == 0 && pickupExists)
                {
                    laserBox.Dispose();
                    pickupExists = false;
                }
            }
        }

        private void SpawnLaser()
        {
            int spawnX = r.Next(210, 650);
            int spawnY = r.Next(280, 530);

            laserBox = new PictureBox();

            laserBox.Location = new System.Drawing.Point(spawnX, spawnY);
            laserBox.Parent = parent;
            laserBox.Image = Properties.Resources.laser_pickup;
            laserBox.Size = new System.Drawing.Size(17, 17);
            laserBox.BackColor = System.Drawing.Color.Transparent;
            laserBox.Show();
            laserBox.Name = "Laser";
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
