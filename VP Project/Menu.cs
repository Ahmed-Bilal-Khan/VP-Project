using System;
using System.Drawing;
using System.Windows.Forms;
using VP_Project.Model;

namespace VP_Project
{
    enum GAME_STATE { GAME_START, GAME_END, GAME_PAUSE };
    public partial class Menu : Form
    {
        Game game;
        GAME_STATE state;
        public Menu()
        {
            InitializeComponent();
            state = GAME_STATE.GAME_PAUSE;
            this.DoubleBuffered = true;
        }

        private void InitGame()
        {
            game = new Game(
                type: GAME_TYPE.ENDLESS,
                parent: this
                );
            state = GAME_STATE.GAME_START;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO ... Well do something else here
            InitGame();
            MenuHolder.Hide();
            this.Focus();
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            if (state == GAME_STATE.GAME_START)
            {
                game.CheckInput();
            }
                
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.W))
            {
                game.UpPressed = true;
            }

            if (e.KeyCode.Equals(Keys.D))
            {
                game.RightPressed = true;
            }
            if (e.KeyCode.Equals(Keys.S))
            {
                game.DownPressed = true;
            }
            if (e.KeyCode.Equals(Keys.A))
            {
                game.LeftPressed = true;
            }
        }

        private void Menu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                game.RightPressed = false;
            }
            if (e.KeyCode == Keys.S)
            {
                game.DownPressed = false;
            }
            if (e.KeyCode == Keys.A)
            {
                game.LeftPressed = false;
            }
            if (e.KeyCode.Equals(Keys.W))
            {
                game.UpPressed = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                // game.player.Shoot();
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
    }

}
