using System.Windows.Forms;

namespace VP_Project.Model.Player
{
    internal abstract class Player
    {
        public enum PLAYER_LEVEL { WEAK, MEDIUM, STRONG };

        protected PictureBox playerSprite;
        protected int SPEED;
        PLAYER_LEVEL playerLevel;

        public abstract void Shoot(PictureBox parentSprite);

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
            this.playerSprite.Left += SPEED;
        }
    }
}
