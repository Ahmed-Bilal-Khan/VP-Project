using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using VP_Project.Model.Game;
using Microsoft.Data.Sqlite;

namespace VP_Project
{
    public enum GAME_STATE { GAME_START, GAME_END, GAME_PAUSE, GAME_WAIT };
    public partial class Menu : Form
    {
        Game game;
        public static GAME_STATE state;
        public static int count = 0;
        public static int countp2 = 0;
        public Menu()
        {
            InitializeComponent();
            state = GAME_STATE.GAME_WAIT;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void InitGame(GAME_TYPE gameType)
        {
            state = GAME_STATE.GAME_START;
            game = new Game(
                type: gameType,
                parent: this
                );
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO ... Well do something else here
            MENU_ENDLESS.Visible = true;
            MenuHolder.Visible = false;
            BtnBackToMenu.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BtnBackToMenu.Visible = true;
            BtnBackToMenu.Text = "Back";
            // Show SCORES
            SqliteConnection connection = new SqliteConnection("Data Source=records.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Endless";

            SqliteDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                ScoresBox.Items.Add($"Name: {dr.GetString(1)}  |  Score: {dr.GetInt32(2)}  |  Time: {dr.GetInt32(3)}");
            }
            ScoresBox.Visible = true;
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BtnBackToMenu.Visible = false;
            // TODO ... Well do something else here
            MenuPVP.Visible = true;
            MenuHolder.Visible = false;
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            
            if (state == GAME_STATE.GAME_START)
            {
                if (Game.Type == GAME_TYPE.ENDLESS)
                {
                    game.Update();
                }
                else
                {
                    game.UpdatePvP();
                }
            }
            if(state == GAME_STATE.GAME_END)
            {
                MenuGameOver.Visible = true;
            }
                
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.W))
            {
                game.UpPressed = true;
            }
            if(e.KeyCode.Equals(Keys.Up))
            {
                game.P2_upPressed = true;
            }

            if (e.KeyCode.Equals(Keys.D))
            {
                game.RightPressed = true;
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                game.P2_rightPressed = true;
            }

            if (e.KeyCode.Equals(Keys.S))
            {
                game.DownPressed = true;
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                game.P2_downPressed = true;
            }

            if (e.KeyCode.Equals(Keys.A))
            {
                game.LeftPressed = true;
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                game.P2_leftPressed = true;
            }
        }

        private void Menu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                game.RightPressed = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                game.P2_rightPressed = false;
            }

            if (e.KeyCode == Keys.S)
            {
                game.DownPressed = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                game.P2_downPressed = false;
            }

            if (e.KeyCode == Keys.A)
            {
                game.LeftPressed = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                game.P2_leftPressed = false;
            }

            if (e.KeyCode.Equals(Keys.W))
            {
                game.UpPressed = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                game.P2_upPressed = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                game.ShootPressed = true;
            }
            if (e.KeyCode == Keys.L)
            {
                game.P2_shootPressed = true;
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.Text = "Start";
            button1.ForeColor = Color.Silver;

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.Text = "Start";
            button2.ForeColor = Color.Silver;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.Text = "Start";
            button3.ForeColor = Color.Silver;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Silver;
            button1.Text = "Endless Mode";
            button1.ForeColor = Color.Black;

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Silver;
            button2.Text = "Story Mode";
            button2.ForeColor = Color.Black;

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Silver;
            button3.Text = "PvP Mode";
            button3.ForeColor = Color.Black;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            count++;
            if(count==4)
            {
                count = 0;
            }
            switch (count) {
                case 0:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_red;
                    break;
                case 1:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_green;
                    break;
                case 2:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_blue;
                    break;
                case 3:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_yellow;
                    break;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            MenuHolder.Visible = true;
            MENU_ENDLESS.Visible = false;
            BtnBackToMenu.Visible = true;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            MENU_ENDLESS.Visible = false;
            InitGame(GAME_TYPE.ENDLESS);
            this.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MENU_ENDLESS.Visible = false;
            MenuGameOver.Visible = false;
            MenuHolder.Visible = true;
            state = GAME_STATE.GAME_WAIT;

            SaveEndless();

            game.Dispose();
            game = null;
            GC.Collect();
            BtnBackToMenu.Visible = true;
        }
        private void SaveEndless()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=records.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO Endless(player_name, player_score, player_time) VALUES($PName, $PScore, $PTime)";
            command.Parameters.AddWithValue("$PName", textBox1.Text);
            command.Parameters.AddWithValue("$PScore", Game.SCORE1);
            command.Parameters.AddWithValue("$PTime", Game.Countdown);

            command.ExecuteNonQuery();
            connection.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MenuHolder.Visible = true;
            MenuPVP.Visible = false;
            BtnBackToMenu.Visible = true;
        }

        private void BtnPVPStart_Click(object sender, EventArgs e)
        {
            MenuPVP.Visible = false;
            InitGame(GAME_TYPE.PVP);
            this.Focus();
        }

        private void BtnP1Next_Click(object sender, EventArgs e)
        {
            count++;
            if (count == 4)
            {
                count = 0;
            }
            switch (count)
            {
                case 0:
                    P1Select.BackgroundImage = Properties.Resources.plane_red;
                    break;
                case 1:
                    P1Select.BackgroundImage = Properties.Resources.plane_green;
                    break;
                case 2:
                    P1Select.BackgroundImage = Properties.Resources.plane_blue;
                    break;
                case 3:
                    P1Select.BackgroundImage = Properties.Resources.plane_yellow;
                    break;
            }
        }

        private void BtnP2Next_Click(object sender, EventArgs e)
        {
            countp2++;
            if (countp2 == 4)
            {
                countp2 = 0;
            }
            switch (countp2)
            {
                case 0:
                    P2Select.BackgroundImage = Properties.Resources.plane_red;
                    break;
                case 1:
                    P2Select.BackgroundImage = Properties.Resources.plane_green;
                    break;
                case 2:
                    P2Select.BackgroundImage = Properties.Resources.plane_blue;
                    break;
                case 3:
                    P2Select.BackgroundImage = Properties.Resources.plane_yellow;
                    break;
            }
        }

        private void BtnP1Back_Click(object sender, EventArgs e)
        {
            
            if (count == 0)
            {
                count = 3;
            }
            else
            {
                count--;
            }
            switch (count)
            {
                case 0:
                    P1Select.BackgroundImage = Properties.Resources.plane_red;
                    break;
                case 1:
                    P1Select.BackgroundImage = Properties.Resources.plane_green;
                    break;
                case 2:
                    P1Select.BackgroundImage = Properties.Resources.plane_blue;
                    break;
                case 3:
                    P1Select.BackgroundImage = Properties.Resources.plane_yellow;
                    break;
            }
        }

        private void BtnP2Back_Click(object sender, EventArgs e)
        {
            if (countp2 == 0)
            {
                countp2 = 3;
            }
            else
            {
                countp2--;
            }
            switch (countp2)
            {
                case 0:
                    P2Select.BackgroundImage = Properties.Resources.plane_red;
                    break;
                case 1:
                    P2Select.BackgroundImage = Properties.Resources.plane_green;
                    break;
                case 2:
                    P2Select.BackgroundImage = Properties.Resources.plane_blue;
                    break;
                case 3:
                    P2Select.BackgroundImage = Properties.Resources.plane_yellow;
                    break;
            }
        }

        private void BtnPlaneBack_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count = 3;
            }
            else
            {
                count--;
            }
            switch (count)
            {
                case 0:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_red;
                    break;
                case 1:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_green;
                    break;
                case 2:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_blue;
                    break;
                case 3:
                    PlaneSelectBox.BackgroundImage = Properties.Resources.plane_yellow;
                    break;
            }
        }

        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            if(ScoresBox.Visible)
            {
                ScoresBox.Visible = false;
                BtnBackToMenu.Text = "Exit";
            }
            else
            {
                this.Close();
            }
        }
    }

}
