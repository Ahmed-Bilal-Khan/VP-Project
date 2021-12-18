using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal abstract class Player
    {

        protected PictureBox playerSprite;
        protected Control parent;
        protected int SPEED;
        protected double playerHealth;
        protected int spawnX;
        protected int spawnY;

        public abstract void Shoot();
        protected abstract void SetPlayerSprite();
        public void MoveForward()
        {
            this.playerSprite.Top -= SPEED;
        }
        public void MoveBackward()
        {
            this.playerSprite.Top += SPEED;
        }
        public void MoveLeft()
        {
            this.playerSprite.Left -= SPEED;
        }
        public void MoveRight()
        {
            //MessageBox.Show("Right PRessed");
            this.playerSprite.Left += SPEED;
        }
    }
}
