using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Timer = System.Windows.Forms.Timer;
using System.Media;

namespace VP_Project.Model.Game 
{
    enum GAME_TYPE { ENDLESS, STORY, PVP};
    internal class Game : IDisposable
    {
        Player.Player player;
        Player.Player player2;
        private static GAME_TYPE type;
        Control parent;
        public static Timer timer;
        List<Player.Enemy> enemies;
        static int countdown;
        static int appearCount;
        static int timeSinceAppearance;
        static int SCORE;
        PictureBox laserBox;
        Label scoreLabel;
        Label healthLabel;
        Label timeLabel;
        // Input Checks
        private Boolean rightPressed;
        private Boolean leftPressed;
        private Boolean upPressed;
        private Boolean downPressed;
        private Boolean shootPressed;

        private Boolean p2_rightPressed;
        private Boolean p2_leftPressed;
        private Boolean p2_upPressed;
        private Boolean p2_downPressed;
        private Boolean p2_shootPressed;

        private Boolean p1_won;
        private Boolean p2_won;


        // Misc
        static Boolean pickupExists;
        Random r = new Random();

        public static SoundPlayer soundPlayer = new SoundPlayer();

        public Game(GAME_TYPE type, Control parent)
        {
            countdown = 0;
            SCORE = 0;
            Game.type = type;
            this.parent = parent;
            
            switch (type)
            {
                case GAME_TYPE.ENDLESS:
                    Create_Endless();
                    break;
                case GAME_TYPE.PVP:
                    Create_PvP();
                    break;
            }

        }

        public bool RightPressed { get => rightPressed; set => rightPressed = value; }
        public bool LeftPressed { get => leftPressed; set => leftPressed = value; }
        public bool UpPressed { get => upPressed; set => upPressed = value; }
        public bool DownPressed { get => downPressed; set => downPressed = value; }
        public bool ShootPressed { get => shootPressed; set => shootPressed = value; }
        internal static GAME_TYPE Type { get => type; }
        public bool P2_rightPressed { get => p2_rightPressed; set => p2_rightPressed = value; }
        public bool P2_leftPressed { get => p2_leftPressed; set => p2_leftPressed = value; }
        public bool P2_upPressed { get => p2_upPressed; set => p2_upPressed = value; }
        public bool P2_downPressed { get => p2_downPressed; set => p2_downPressed = value; }
        public bool P2_shootPressed { get => p2_shootPressed; set => p2_shootPressed = value; }
        public static int Countdown { get => countdown; }
        public static int SCORE1 { get => SCORE; }
        public bool P2_won { get => p2_won; }
        public bool P1_won { get => p1_won; }

        public void CheckInput()
        {
            if (RightPressed && !LeftPressed)
            {
                player.MoveRight();
            }
            if(P2_rightPressed && !P2_leftPressed && type == GAME_TYPE.PVP)
            {
                player2.MoveRight();
            } 

            if (DownPressed && !UpPressed && !LeftPressed && !RightPressed)
            {
                player.MoveBackward();
            }
            if (P2_downPressed && !P2_leftPressed && !P2_rightPressed && type == GAME_TYPE.PVP)
            {
                player2.MoveBackward();
            }

            if (UpPressed && !DownPressed && !LeftPressed && !RightPressed)
            {
                player.MoveForward();
            }
            if (P2_upPressed && !P2_downPressed && !P2_leftPressed && !P2_rightPressed && type == GAME_TYPE.PVP)
            {
                player2.MoveForward();
            }

            if (LeftPressed && !RightPressed)
            {
                player.MoveLeft();
            }
            if (P2_leftPressed && !P2_rightPressed && type == GAME_TYPE.PVP)
            {
                player2.MoveLeft();
            }

            if (ShootPressed)
            {
                player.Shoot();
                ShootPressed = false;
            }
            if(P2_shootPressed)
            {
                player2.Shoot();
                P2_shootPressed = false;
            }
        }

        public void MoveBullet()
        {
            for(int i = 0; i < player.Bullets.Count; i++)
            {
                if(player.Bullets[i].IsWasted() && player.Bullets[i].ShotEnemy)
                {
                    player.Bullets.RemoveAt(i);
                    SCORE++;
                    scoreLabel.Text = $"SCORE: {SCORE}";
                }
                else if (player.Bullets[i].IsWasted())
                {
                    player.Bullets.RemoveAt(i);
                }
                else
                {
                    player.Bullets[i].MoveBullet();
                    player.Bullets[i].CheckCollision();
                }
            }

            if(type == GAME_TYPE.PVP)
            {
                for (int i = 0; i < player2.Bullets.Count; i++)
                {
                    if (!player2.Bullets[i].IsWasted())
                    {
                        player2.Bullets[i].MoveBullet();
                        player2.Bullets[i].CheckCollision();
                    }
                    else if (player2.Bullets[i].IsWasted() && player2.Bullets[i].ShotEnemy)
                    {
                        player2.Bullets.RemoveAt(i);
                        SCORE++;
                        scoreLabel.Text = $"SCORE: {SCORE}";
                    }
                    else
                    {
                        player2.Bullets.RemoveAt(i);
                    }
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
                //else if (enemies[i].IsWasted())
                //{
                //    enemies.RemoveAt(i);
                //}
                else
                {
                    enemies[i].MoveBackward();
                    enemies[i].CheckCollision();
                }
            }
        }
        private void Create_Endless()
        {
            if (Menu.state == GAME_STATE.GAME_END)
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

                CreateEndlessLabel();
            }
        }

        private void CreateEndlessLabel()
        {
            // Create Score Label
            scoreLabel = new Label();
            scoreLabel.Text = ($"SCORE: {SCORE}");
            scoreLabel.Parent = parent;
            scoreLabel.Location = new System.Drawing.Point(4, 17);
            scoreLabel.Size = new System.Drawing.Size(150, 24);
            scoreLabel.ForeColor = System.Drawing.Color.Silver;
            scoreLabel.Font = new System.Drawing.Font("Segoe UI Black", 16);
            scoreLabel.Show();
            scoreLabel.BackColor = System.Drawing.Color.Transparent;

            healthLabel = new Label();
            healthLabel.Text = ($"HEALTH: {player.PlayerHealth}");
            healthLabel.Parent = parent;
            healthLabel.Location = new System.Drawing.Point(4, 500);
            healthLabel.Size = new System.Drawing.Size(150, 24);
            healthLabel.ForeColor = System.Drawing.Color.Silver;
            healthLabel.Font = new System.Drawing.Font("Segoe UI Black", 13);
            healthLabel.Show();
            healthLabel.BackColor = System.Drawing.Color.Transparent;

            timeLabel = new Label();
            timeLabel.Text = ($"TIME: {countdown}");
            timeLabel.Parent = parent;
            timeLabel.Location = new System.Drawing.Point(650, 17);
            timeLabel.Size = new System.Drawing.Size(150, 24);
            timeLabel.ForeColor = System.Drawing.Color.Silver;
            timeLabel.Font = new System.Drawing.Font("Segoe UI Black", 13);
            timeLabel.Show();
            timeLabel.BackColor = System.Drawing.Color.Transparent;
        }
        public void Update()
        {
            if (Menu.state == GAME_STATE.GAME_START && player != null)
            {
                CheckInput();
                MoveBullet();
                player.CheckCollision();
                MoveEnemy();
                healthLabel.Text = $"HEALTH: {player.PlayerHealth}";
                timeLabel.Text = ($"TIME: {countdown}");
            }
            if (player.IsWasted())
            {
                timer.Stop();
                timer.Enabled = false;
                // timer = new Timer();
                DestroyGame();
            }

        }
        private void SpawnEnemy(object sender, EventArgs e)
        {
            countdown ++; // since tick interval is 2 sec
            
            if(player != null)
            {
                AddEnemy();
                if(SCORE == 50 && appearCount == 0)
                {
                    SpawnLaser();
                    timeSinceAppearance = 9;
                    pickupExists = true;
                    appearCount++;
                }
                if(SCORE == 100 && appearCount == 1)
                {
                    SpawnLaser();
                    timeSinceAppearance = 9;
                    pickupExists = true;
                    appearCount++;
                }
                if(timeSinceAppearance % 8 == 0 && pickupExists)
                {
                    laserBox.Dispose();
                    pickupExists = false;
                }

                if(SCORE >= 20 && SCORE < 45)
                {
                    AddEnemy();
                }
                if(SCORE >= 45)
                {
                    AddEnemy();
                    AddEnemy();
                }

                //if (countdown % 15 == 0)
                //{
                //    if (timer.Interval >= 500)
                //    {
                //        timer.Interval -= 300;
                //    }
                //    else
                //    {
                //        AddEnemy(); // spawn twice
                //    }

                //}

                //if (pickupExists)
                //{
                //    timeSinceAppearance++;
                //    if (player != null)
                //        if (laserBox.Bounds.IntersectsWith(player.PlayerSprite.Bounds))
                //        {
                //            player.ShootsLaser = true;
                //            playerHasPickup = true;
                //            setPlayerToNormal = 6;
                //            laserBox.Dispose();
                //        }
                //}
            }
        }
        private void AddEnemy ()
        {
            if(enemies.Count < 13)
            {
                int spawnY = 3;
                int spawnX = r.Next(40, 750);
                Player.Enemy enemy = new Player.Enemy(parent, (Player.ENEMY_TYPE)r.Next(0, 2), spawnX, spawnY);
                enemies.Add(enemy);
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
            Menu.state = GAME_STATE.GAME_END;
            player.DestroySelf();
            if(player2 != null)
            {
                player2.DestroySelf();
            }
            //player = null;
            if(enemies != null)
                foreach(Player.Enemy enemy in enemies)
                {
                    enemy.DestroySelf();
                }
            GC.Collect();
        }

        public void Dispose()
        {
            scoreLabel.Dispose();
            SCORE = 0;
            if(timer != null)
                timer.Dispose();
            if(enemies != null)
                enemies.Clear();
            if(laserBox != null)
                laserBox.Dispose();
            if(timeLabel != null)
                timeLabel.Dispose();
            if(healthLabel != null)
                healthLabel.Dispose();
        }

        private void Create_PvP()
        {
            if (Menu.state == GAME_STATE.GAME_END)
            {
                timer.Stop();
                timer.Enabled = false;
            }
            else if (Menu.state == GAME_STATE.GAME_START)
            {
                switch (Menu.countp2)
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
                switch (Menu.count)
                {
                    case 0:
                        player2 = new Player.Player_Red(this.parent, 400, 100);
                        break;
                    case 1:
                        player2 = new Player.Played_Green(this.parent, 300, 100);
                        break;
                    case 2:
                        player2 = new Player.Played_Blue(this.parent, 350, 100);
                        break;
                    case 3:
                        player2 = new Player.Player_Yellow(this.parent, 400, 100);
                        break;
                }
                player2.SetName("Player_2");
                player.SetName("Player_1");
                SetHealthLabels();
            }
        }

        private void SetHealthLabels()
        {
            scoreLabel = new Label();
            scoreLabel.Text = ($"HEALTH: {player.PlayerHealth}");
            scoreLabel.Parent = parent;
            scoreLabel.Location = new System.Drawing.Point(4, 17);
            scoreLabel.Size = new System.Drawing.Size(150, 24);
            scoreLabel.ForeColor = System.Drawing.Color.Silver;
            scoreLabel.Font = new System.Drawing.Font("Segoe UI Black", 13);
            scoreLabel.Show();
            scoreLabel.BackColor = System.Drawing.Color.Transparent;

            healthLabel = new Label();
            healthLabel.Text = ($"HEALTH: {player2.PlayerHealth}");
            healthLabel.Parent = parent;
            healthLabel.Location = new System.Drawing.Point(4, 500);
            healthLabel.Size = new System.Drawing.Size(150, 24);
            healthLabel.ForeColor = System.Drawing.Color.Silver;
            healthLabel.Font = new System.Drawing.Font("Segoe UI Black", 13);
            healthLabel.Show();
            healthLabel.BackColor = System.Drawing.Color.Transparent;
        }
        public void UpdatePvP()
        {
            if (Menu.state == GAME_STATE.GAME_START && (player != null && player2 != null))
            {
                CheckInput();
                MoveBullet();
                player.CheckPvPCollision();
                player2.CheckPvPCollision();
                healthLabel.Text = ($"HEALTH: {player.PlayerHealth}");
                scoreLabel.Text = ($"HEALTH: {player2.PlayerHealth}");
                CheckPvPWin();
            }
            
        }

        private void CheckPvPWin()
        {
            if(player.PlayerHealth <= 0)
            {
                p2_won = true;
                Menu.state = GAME_STATE.GAME_END;
                DestroyGame();
            }
            if(player2.PlayerHealth <= 0)
            {
                p1_won = true;
                Menu.state = GAME_STATE.GAME_END;
                DestroyGame();
            }
        }
    }
}
