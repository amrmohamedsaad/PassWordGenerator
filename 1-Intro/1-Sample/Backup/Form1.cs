#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Sample
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int ballY;
        static int ballDir;
        private void chkBlock_CheckedChange(object sender, EventArgs e)
        {
            // make block appear or disappear
            if (chkBlock.Checked)
            {
                picBlock.Visible = true;
            }
            else
            {
                picBlock.Visible = false;
            }
        }

        private void chkBear_CheckedChanged(object sender, EventArgs e)
        {
            // make bear appear or disappear
            if (chkBear.Checked)
            {
                picBear.Visible = true;
            }
            else
            {
                picBear.Visible = false;
            }
        }

        private void chkWagon_CheckedChanged(object sender, EventArgs e)
        {
            // make wagon appear or disappear
            if (chkWagon.Checked)
            {
                picWagon.Visible = true;
            }
            else
            {
                picWagon.Visible = false;
            }
        }

        private void chkDoll_CheckedChanged(object sender, EventArgs e)
        {
            // make doll appear or disappear
            if (chkDoll.Checked)
            {
                picDoll.Visible = true;
            }
            else
            {
                picDoll.Visible = false;
            }
        }

        private void chkTop_CheckedChanged(object sender, EventArgs e)
        {
            // make top appear or disappear
            if (chkTop.Checked)
            {
                picTop.Visible = true;
            }
            else
            {
                picTop.Visible = false;
            }
        }

        private void chkTrike_CheckedChanged(object sender, EventArgs e)
        {
            // make trike appear or disappear
            if (chkTrike.Checked)
            {
                picTrike.Visible = true;
            }
            else
            {
                picTrike.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize form color and ball position
            ballY = 0;
            rdoBlue.PerformClick();
            //picMyBall.Top = 0;
            ballDir = 1;
            // Draw ball
            Form1_Paint(null,null);
        }   

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraphics;
            Rectangle rectDest;
            myGraphics = pnlBall.CreateGraphics();
            rectDest = new Rectangle((int) (0.5 * (pnlBall.ClientSize.Width - picMyBall.Width)), ballY, picMyBall.Width, picMyBall.Height);
            myGraphics.Clear(pnlBall.BackColor);
            myGraphics.DrawImage(picMyBall.Image, rectDest);
            myGraphics.Dispose();
        }

        private void rdoRed_CheckedChanged(object sender, EventArgs e)
        {
            // change form color to red
            this.BackColor = Color.Red;
        }

        private void rdoBlue_CheckedChanged(object sender, EventArgs e)
        {
            // change form color to blue
            this.BackColor = Color.Blue;
        }

        private void rdoGreen_CheckedChanged(object sender, EventArgs e)
        {
            // change form color to green
            this.BackColor = Color.Green;
        }

        private void rdoBlack_CheckedChanged(object sender, EventArgs e)
        {
            // change form color to black
            this.BackColor = Color.Black;
        }

        private void btnBeep_Click(object sender, EventArgs e)
        {
            // Make beeping sound
            Console.Beep();
        }

        private void btnBall_Click(object sender, EventArgs e)
        {
            //Start/stop timer 
            if (timBall.Enabled)
            {
                timBall.Enabled = false;
                btnBall.Text = "Start";
            }
            else
            {
                timBall.Enabled = true;
                btnBall.Text = "Stop";
            }
        }

        private void timBall_Tick(object sender, EventArgs e)
        {
            // Position ball
            // compute ball position
            ballY = ballY + ballDir * pnlBall.ClientSize.Height / 50;
            // Check for bounce
            if (ballY < 0)
            {
                Console.Beep();
                ballY = 0;
                ballDir = 1;
            }
            else if (ballY > pnlBall.ClientSize.Height - picMyBall.Height)
            {
                Console.Beep();
                ballY = pnlBall.ClientSize.Height - picMyBall.Height;
                ballDir = -1;
            }
            // Draw ball
            Form1_Paint(null, null);
        }

      
    }
}