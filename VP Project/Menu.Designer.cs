﻿
namespace VP_Project
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.MenuHolder = new System.Windows.Forms.Panel();
            this.Update_ = new System.Windows.Forms.Timer(this.components);
            this.BoundaryTop = new System.Windows.Forms.Panel();
            this.BoundaryBottom = new System.Windows.Forms.Panel();
            this.MENU_ENDLESS = new System.Windows.Forms.Panel();
            this.BtnStart = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlaneSelectBox = new System.Windows.Forms.PictureBox();
            this.BtnBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MenuGameOver = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MenuHolder.SuspendLayout();
            this.MENU_ENDLESS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneSelectBox)).BeginInit();
            this.MenuGameOver.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starship Battle";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(194, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 80);
            this.button1.TabIndex = 1;
            this.button1.Text = "Endless Mode";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(194, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 80);
            this.button2.TabIndex = 2;
            this.button2.Text = "Story Mode";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.MouseHover += new System.EventHandler(this.button2_MouseHover);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(194, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 80);
            this.button3.TabIndex = 3;
            this.button3.Text = "PvP Mode";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.button3.MouseHover += new System.EventHandler(this.button3_MouseHover);
            // 
            // MenuHolder
            // 
            this.MenuHolder.BackColor = System.Drawing.Color.Transparent;
            this.MenuHolder.Controls.Add(this.button3);
            this.MenuHolder.Controls.Add(this.button2);
            this.MenuHolder.Controls.Add(this.button1);
            this.MenuHolder.Controls.Add(this.label1);
            this.MenuHolder.Location = new System.Drawing.Point(114, 43);
            this.MenuHolder.Name = "MenuHolder";
            this.MenuHolder.Size = new System.Drawing.Size(566, 475);
            this.MenuHolder.TabIndex = 4;
            // 
            // Update_
            // 
            this.Update_.Enabled = true;
            this.Update_.Interval = 45;
            this.Update_.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // BoundaryTop
            // 
            this.BoundaryTop.BackColor = System.Drawing.Color.Transparent;
            this.BoundaryTop.Location = new System.Drawing.Point(0, 0);
            this.BoundaryTop.Name = "BoundaryTop";
            this.BoundaryTop.Size = new System.Drawing.Size(787, 10);
            this.BoundaryTop.TabIndex = 5;
            // 
            // BoundaryBottom
            // 
            this.BoundaryBottom.BackColor = System.Drawing.Color.Transparent;
            this.BoundaryBottom.Location = new System.Drawing.Point(0, 552);
            this.BoundaryBottom.Name = "BoundaryBottom";
            this.BoundaryBottom.Size = new System.Drawing.Size(787, 10);
            this.BoundaryBottom.TabIndex = 6;
            // 
            // MENU_ENDLESS
            // 
            this.MENU_ENDLESS.BackColor = System.Drawing.Color.Transparent;
            this.MENU_ENDLESS.Controls.Add(this.BtnStart);
            this.MENU_ENDLESS.Controls.Add(this.pictureBox2);
            this.MENU_ENDLESS.Controls.Add(this.pictureBox1);
            this.MENU_ENDLESS.Controls.Add(this.PlaneSelectBox);
            this.MENU_ENDLESS.Controls.Add(this.BtnBack);
            this.MENU_ENDLESS.Controls.Add(this.label2);
            this.MENU_ENDLESS.Location = new System.Drawing.Point(111, 43);
            this.MENU_ENDLESS.Name = "MENU_ENDLESS";
            this.MENU_ENDLESS.Size = new System.Drawing.Size(566, 475);
            this.MENU_ENDLESS.TabIndex = 7;
            this.MENU_ENDLESS.Visible = false;
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Silver;
            this.BtnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStart.Location = new System.Drawing.Point(180, 283);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(199, 80);
            this.BtnStart.TabIndex = 8;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(410, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 88);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::VP_Project.Properties.Resources.btn_left1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(85, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 88);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // PlaneSelectBox
            // 
            this.PlaneSelectBox.BackgroundImage = global::VP_Project.Properties.Resources.plane_red;
            this.PlaneSelectBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PlaneSelectBox.Location = new System.Drawing.Point(153, 156);
            this.PlaneSelectBox.Name = "PlaneSelectBox";
            this.PlaneSelectBox.Size = new System.Drawing.Size(251, 84);
            this.PlaneSelectBox.TabIndex = 4;
            this.PlaneSelectBox.TabStop = false;
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.Silver;
            this.BtnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBack.Location = new System.Drawing.Point(180, 381);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(199, 80);
            this.BtnBack.TabIndex = 3;
            this.BtnBack.Text = "Go Back";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(83, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 91);
            this.label2.TabIndex = 0;
            this.label2.Text = "ENDLESS";
            // 
            // MenuGameOver
            // 
            this.MenuGameOver.BackColor = System.Drawing.Color.Transparent;
            this.MenuGameOver.Controls.Add(this.button4);
            this.MenuGameOver.Controls.Add(this.label3);
            this.MenuGameOver.Location = new System.Drawing.Point(114, 29);
            this.MenuGameOver.Name = "MenuGameOver";
            this.MenuGameOver.Size = new System.Drawing.Size(566, 475);
            this.MenuGameOver.TabIndex = 9;
            this.MenuGameOver.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(127, 212);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(314, 80);
            this.button4.TabIndex = 8;
            this.button4.Text = "Retun to Menu";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(23, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(521, 91);
            this.label3.TabIndex = 0;
            this.label3.Text = "GAME OVER";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::VP_Project.Properties.Resources._1268183;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.MenuGameOver);
            this.Controls.Add(this.MENU_ENDLESS);
            this.Controls.Add(this.BoundaryBottom);
            this.Controls.Add(this.BoundaryTop);
            this.Controls.Add(this.MenuHolder);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyUp);
            this.MenuHolder.ResumeLayout(false);
            this.MenuHolder.PerformLayout();
            this.MENU_ENDLESS.ResumeLayout(false);
            this.MENU_ENDLESS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneSelectBox)).EndInit();
            this.MenuGameOver.ResumeLayout(false);
            this.MenuGameOver.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel MenuHolder;
        private System.Windows.Forms.Timer Update_;
        private System.Windows.Forms.Panel BoundaryTop;
        private System.Windows.Forms.Panel BoundaryBottom;
        private System.Windows.Forms.Panel MENU_ENDLESS;
        private System.Windows.Forms.PictureBox PlaneSelectBox;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Panel MenuGameOver;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
    }
}

