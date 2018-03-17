namespace Sample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpToys = new System.Windows.Forms.GroupBox();
            this.chkTrike = new System.Windows.Forms.CheckBox();
            this.chkTop = new System.Windows.Forms.CheckBox();
            this.chkDoll = new System.Windows.Forms.CheckBox();
            this.chkWagon = new System.Windows.Forms.CheckBox();
            this.chkBear = new System.Windows.Forms.CheckBox();
            this.chkBlock = new System.Windows.Forms.CheckBox();
            this.picBlock = new System.Windows.Forms.PictureBox();
            this.picBear = new System.Windows.Forms.PictureBox();
            this.picWagon = new System.Windows.Forms.PictureBox();
            this.picDoll = new System.Windows.Forms.PictureBox();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.picTrike = new System.Windows.Forms.PictureBox();
            this.pnlBall = new System.Windows.Forms.Panel();
            this.picMyBall = new System.Windows.Forms.PictureBox();
            this.grpPick = new System.Windows.Forms.GroupBox();
            this.nudPick = new System.Windows.Forms.NumericUpDown();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.rdoBlack = new System.Windows.Forms.RadioButton();
            this.rdoGreen = new System.Windows.Forms.RadioButton();
            this.rdoBlue = new System.Windows.Forms.RadioButton();
            this.rdoRed = new System.Windows.Forms.RadioButton();
            this.txtSample = new System.Windows.Forms.TextBox();
            this.btnBeep = new System.Windows.Forms.Button();
            this.btnBall = new System.Windows.Forms.Button();
            this.timBall = new System.Windows.Forms.Timer(this.components);
            this.grpToys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWagon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrike)).BeginInit();
            this.pnlBall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMyBall)).BeginInit();
            this.grpPick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPick)).BeginInit();
            this.grpColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpToys
            // 
            this.grpToys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpToys.Controls.Add(this.chkTrike);
            this.grpToys.Controls.Add(this.chkTop);
            this.grpToys.Controls.Add(this.chkDoll);
            this.grpToys.Controls.Add(this.chkWagon);
            this.grpToys.Controls.Add(this.chkBear);
            this.grpToys.Controls.Add(this.chkBlock);
            this.grpToys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpToys.Location = new System.Drawing.Point(4, 4);
            this.grpToys.Name = "grpToys";
            this.grpToys.Size = new System.Drawing.Size(96, 187);
            this.grpToys.TabIndex = 0;
            this.grpToys.TabStop = false;
            this.grpToys.Text = "Toys";
            // 
            // chkTrike
            // 
            this.chkTrike.AutoSize = true;
            this.chkTrike.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrike.Location = new System.Drawing.Point(16, 157);
            this.chkTrike.Name = "chkTrike";
            this.chkTrike.Size = new System.Drawing.Size(57, 24);
            this.chkTrike.TabIndex = 5;
            this.chkTrike.Text = "Trike";
            this.chkTrike.CheckedChanged += new System.EventHandler(this.chkTrike_CheckedChanged);
            // 
            // chkTop
            // 
            this.chkTop.AutoSize = true;
            this.chkTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTop.Location = new System.Drawing.Point(16, 130);
            this.chkTop.Name = "chkTop";
            this.chkTop.Size = new System.Drawing.Size(50, 24);
            this.chkTop.TabIndex = 4;
            this.chkTop.Text = "Top";
            this.chkTop.CheckedChanged += new System.EventHandler(this.chkTop_CheckedChanged);
            // 
            // chkDoll
            // 
            this.chkDoll.AutoSize = true;
            this.chkDoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoll.Location = new System.Drawing.Point(16, 103);
            this.chkDoll.Name = "chkDoll";
            this.chkDoll.Size = new System.Drawing.Size(50, 24);
            this.chkDoll.TabIndex = 3;
            this.chkDoll.Text = "Doll";
            this.chkDoll.CheckedChanged += new System.EventHandler(this.chkDoll_CheckedChanged);
            // 
            // chkWagon
            // 
            this.chkWagon.AutoSize = true;
            this.chkWagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWagon.Location = new System.Drawing.Point(16, 76);
            this.chkWagon.Name = "chkWagon";
            this.chkWagon.Size = new System.Drawing.Size(74, 24);
            this.chkWagon.TabIndex = 2;
            this.chkWagon.Text = "Wagon";
            this.chkWagon.CheckedChanged += new System.EventHandler(this.chkWagon_CheckedChanged);
            // 
            // chkBear
            // 
            this.chkBear.AutoSize = true;
            this.chkBear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBear.Location = new System.Drawing.Point(16, 49);
            this.chkBear.Name = "chkBear";
            this.chkBear.Size = new System.Drawing.Size(57, 24);
            this.chkBear.TabIndex = 1;
            this.chkBear.Text = "Bear";
            this.chkBear.CheckedChanged += new System.EventHandler(this.chkBear_CheckedChanged);
            // 
            // chkBlock
            // 
            this.chkBlock.AutoSize = true;
            this.chkBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBlock.Location = new System.Drawing.Point(16, 22);
            this.chkBlock.Name = "chkBlock";
            this.chkBlock.Size = new System.Drawing.Size(62, 24);
            this.chkBlock.TabIndex = 0;
            this.chkBlock.Text = "Block";
            this.chkBlock.CheckedChanged += new System.EventHandler(this.chkBlock_CheckedChange);
            // 
            // picBlock
            // 
            this.picBlock.Image = Sample.Properties.Resources.block;
            this.picBlock.Location = new System.Drawing.Point(107, 15);
            this.picBlock.Name = "picBlock";
            this.picBlock.Size = new System.Drawing.Size(83, 81);
            this.picBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBlock.TabIndex = 1;
            this.picBlock.TabStop = false;
            this.picBlock.Visible = false;
            // 
            // picBear
            // 
            this.picBear.Image = Sample.Properties.Resources.bear;
            this.picBear.Location = new System.Drawing.Point(197, 15);
            this.picBear.Name = "picBear";
            this.picBear.Size = new System.Drawing.Size(83, 81);
            this.picBear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBear.TabIndex = 2;
            this.picBear.TabStop = false;
            this.picBear.Visible = false;
            // 
            // picWagon
            // 
            this.picWagon.Image = Sample.Properties.Resources.wagon;
            this.picWagon.Location = new System.Drawing.Point(287, 15);
            this.picWagon.Name = "picWagon";
            this.picWagon.Size = new System.Drawing.Size(83, 81);
            this.picWagon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWagon.TabIndex = 3;
            this.picWagon.TabStop = false;
            this.picWagon.Visible = false;
            // 
            // picDoll
            // 
            this.picDoll.Image = Sample.Properties.Resources.doll;
            this.picDoll.Location = new System.Drawing.Point(107, 107);
            this.picDoll.Name = "picDoll";
            this.picDoll.Size = new System.Drawing.Size(83, 81);
            this.picDoll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDoll.TabIndex = 4;
            this.picDoll.TabStop = false;
            this.picDoll.Visible = false;
            // 
            // picTop
            // 
            this.picTop.Image = Sample.Properties.Resources.top;
            this.picTop.Location = new System.Drawing.Point(197, 107);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(83, 81);
            this.picTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTop.TabIndex = 5;
            this.picTop.TabStop = false;
            this.picTop.Visible = false;
            // 
            // picTrike
            // 
            this.picTrike.Image = Sample.Properties.Resources.trike;
            this.picTrike.Location = new System.Drawing.Point(287, 107);
            this.picTrike.Name = "picTrike";
            this.picTrike.Size = new System.Drawing.Size(83, 81);
            this.picTrike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTrike.TabIndex = 6;
            this.picTrike.TabStop = false;
            this.picTrike.Visible = false;
            // 
            // pnlBall
            // 
            this.pnlBall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlBall.Controls.Add(this.picMyBall);
            this.pnlBall.Location = new System.Drawing.Point(388, 13);
            this.pnlBall.Name = "pnlBall";
            this.pnlBall.Size = new System.Drawing.Size(64, 295);
            this.pnlBall.TabIndex = 7;
            // 
            // picMyBall
            // 
            this.picMyBall.Image = Sample.Properties.Resources.ball;
            this.picMyBall.Location = new System.Drawing.Point(14, 165);
            this.picMyBall.Name = "picMyBall";
            this.picMyBall.Size = new System.Drawing.Size(36, 36);
            this.picMyBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMyBall.TabIndex = 0;
            this.picMyBall.TabStop = false;
            this.picMyBall.Visible = false;
            // 
            // grpPick
            // 
            this.grpPick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grpPick.Controls.Add(this.nudPick);
            this.grpPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPick.Location = new System.Drawing.Point(10, 201);
            this.grpPick.Name = "grpPick";
            this.grpPick.Size = new System.Drawing.Size(187, 72);
            this.grpPick.TabIndex = 8;
            this.grpPick.TabStop = false;
            this.grpPick.Text = "Pick a Number";
            // 
            // nudPick
            // 
            this.nudPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPick.Location = new System.Drawing.Point(22, 31);
            this.nudPick.Name = "nudPick";
            this.nudPick.Size = new System.Drawing.Size(144, 30);
            this.nudPick.TabIndex = 0;
            this.nudPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpColor
            // 
            this.grpColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpColor.Controls.Add(this.rdoBlack);
            this.grpColor.Controls.Add(this.rdoGreen);
            this.grpColor.Controls.Add(this.rdoBlue);
            this.grpColor.Controls.Add(this.rdoRed);
            this.grpColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpColor.Location = new System.Drawing.Point(207, 202);
            this.grpColor.Name = "grpColor";
            this.grpColor.Size = new System.Drawing.Size(162, 70);
            this.grpColor.TabIndex = 9;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "Color";
            // 
            // rdoBlack
            // 
            this.rdoBlack.AutoSize = true;
            this.rdoBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBlack.Location = new System.Drawing.Point(80, 44);
            this.rdoBlack.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.rdoBlack.Name = "rdoBlack";
            this.rdoBlack.Size = new System.Drawing.Size(61, 24);
            this.rdoBlack.TabIndex = 3;
            this.rdoBlack.Text = "Black";
            this.rdoBlack.CheckedChanged += new System.EventHandler(this.rdoBlack_CheckedChanged);
            // 
            // rdoGreen
            // 
            this.rdoGreen.AutoSize = true;
            this.rdoGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGreen.Location = new System.Drawing.Point(80, 22);
            this.rdoGreen.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.rdoGreen.Name = "rdoGreen";
            this.rdoGreen.Size = new System.Drawing.Size(67, 24);
            this.rdoGreen.TabIndex = 2;
            this.rdoGreen.Text = "Green";
            this.rdoGreen.CheckedChanged += new System.EventHandler(this.rdoGreen_CheckedChanged);
            // 
            // rdoBlue
            // 
            this.rdoBlue.AutoSize = true;
            this.rdoBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBlue.Location = new System.Drawing.Point(11, 44);
            this.rdoBlue.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.rdoBlue.Name = "rdoBlue";
            this.rdoBlue.Size = new System.Drawing.Size(54, 24);
            this.rdoBlue.TabIndex = 1;
            this.rdoBlue.Text = "Blue";
            this.rdoBlue.CheckedChanged += new System.EventHandler(this.rdoBlue_CheckedChanged);
            // 
            // rdoRed
            // 
            this.rdoRed.AutoSize = true;
            this.rdoRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRed.Location = new System.Drawing.Point(11, 22);
            this.rdoRed.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.rdoRed.Name = "rdoRed";
            this.rdoRed.Size = new System.Drawing.Size(52, 24);
            this.rdoRed.TabIndex = 0;
            this.rdoRed.Text = "Red";
            this.rdoRed.CheckedChanged += new System.EventHandler(this.rdoRed_CheckedChanged);
            // 
            // txtSample
            // 
            this.txtSample.AutoSize = false;
            this.txtSample.Location = new System.Drawing.Point(14, 284);
            this.txtSample.Multiline = true;
            this.txtSample.Name = "txtSample";
            this.txtSample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSample.Size = new System.Drawing.Size(216, 55);
            this.txtSample.TabIndex = 10;
            // 
            // btnBeep
            // 
            this.btnBeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeep.Location = new System.Drawing.Point(262, 284);
            this.btnBeep.Name = "btnBeep";
            this.btnBeep.Size = new System.Drawing.Size(107, 41);
            this.btnBeep.TabIndex = 11;
            this.btnBeep.Text = "Beep!";
            this.btnBeep.Click += new System.EventHandler(this.btnBeep_Click);
            // 
            // btnBall
            // 
            this.btnBall.Location = new System.Drawing.Point(388, 317);
            this.btnBall.Name = "btnBall";
            this.btnBall.Size = new System.Drawing.Size(63, 21);
            this.btnBall.TabIndex = 12;
            this.btnBall.Text = "Start";
            this.btnBall.Click += new System.EventHandler(this.btnBall_Click);
            // 
            // timBall
            // 
            this.timBall.Interval = 50;
            this.timBall.Tick += new System.EventHandler(this.timBall_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(466, 351);
            this.Controls.Add(this.btnBall);
            this.Controls.Add(this.btnBeep);
            this.Controls.Add(this.txtSample);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.grpPick);
            this.Controls.Add(this.pnlBall);
            this.Controls.Add(this.picTrike);
            this.Controls.Add(this.picTop);
            this.Controls.Add(this.picDoll);
            this.Controls.Add(this.picWagon);
            this.Controls.Add(this.picBear);
            this.Controls.Add(this.picBlock);
            this.Controls.Add(this.grpToys);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visual C# Express for Kids - Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.grpToys.ResumeLayout(false);
            this.grpToys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWagon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrike)).EndInit();
            this.pnlBall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMyBall)).EndInit();
            this.grpPick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPick)).EndInit();
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpToys;
        private System.Windows.Forms.CheckBox chkBlock;
        private System.Windows.Forms.CheckBox chkBear;
        private System.Windows.Forms.CheckBox chkWagon;
        private System.Windows.Forms.CheckBox chkDoll;
        private System.Windows.Forms.CheckBox chkTop;
        private System.Windows.Forms.CheckBox chkTrike;
        private System.Windows.Forms.PictureBox picBlock;
        private System.Windows.Forms.PictureBox picBear;
        private System.Windows.Forms.PictureBox picWagon;
        private System.Windows.Forms.PictureBox picDoll;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.PictureBox picTrike;
        private System.Windows.Forms.Panel pnlBall;
        private System.Windows.Forms.GroupBox grpPick;
        private System.Windows.Forms.NumericUpDown nudPick;
        private System.Windows.Forms.GroupBox grpColor;
        private System.Windows.Forms.RadioButton rdoRed;
        private System.Windows.Forms.RadioButton rdoBlue;
        private System.Windows.Forms.RadioButton rdoGreen;
        private System.Windows.Forms.RadioButton rdoBlack;
        private System.Windows.Forms.TextBox txtSample;
        private System.Windows.Forms.Button btnBeep;
        private System.Windows.Forms.PictureBox picMyBall;
        private System.Windows.Forms.Button btnBall;
        private System.Windows.Forms.Timer timBall;
    }
}

