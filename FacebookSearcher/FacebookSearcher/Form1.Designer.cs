namespace FacebookSearcher
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webFacebook = new System.Windows.Forms.WebBrowser();
            this.btn_signin = new System.Windows.Forms.Button();
            this.listfriendlist = new System.Windows.Forms.ListBox();
            this.btnGetList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webFacebook
            // 
            this.webFacebook.Location = new System.Drawing.Point(12, 2);
            this.webFacebook.MinimumSize = new System.Drawing.Size(20, 20);
            this.webFacebook.Name = "webFacebook";
            this.webFacebook.Size = new System.Drawing.Size(676, 404);
            this.webFacebook.TabIndex = 0;
            this.webFacebook.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webFacebook_DocumentCompleted);
            // 
            // btn_signin
            // 
            this.btn_signin.Location = new System.Drawing.Point(97, 412);
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Size = new System.Drawing.Size(198, 23);
            this.btn_signin.TabIndex = 1;
            this.btn_signin.Text = "SignIn";
            this.btn_signin.UseVisualStyleBackColor = true;
            this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
            // 
            // listfriendlist
            // 
            this.listfriendlist.FormattingEnabled = true;
            this.listfriendlist.Location = new System.Drawing.Point(715, -1);
            this.listfriendlist.Name = "listfriendlist";
            this.listfriendlist.Size = new System.Drawing.Size(211, 407);
            this.listfriendlist.TabIndex = 2;
            // 
            // btnGetList
            // 
            this.btnGetList.Location = new System.Drawing.Point(615, 412);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(125, 23);
            this.btnGetList.TabIndex = 3;
            this.btnGetList.Text = "Get";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 447);
            this.Controls.Add(this.btnGetList);
            this.Controls.Add(this.listfriendlist);
            this.Controls.Add(this.btn_signin);
            this.Controls.Add(this.webFacebook);
            this.Name = "Form1";
            this.Text = "SignIn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webFacebook;
        private System.Windows.Forms.Button btn_signin;
        private System.Windows.Forms.ListBox listfriendlist;
        private System.Windows.Forms.Button btnGetList;
    }
}

