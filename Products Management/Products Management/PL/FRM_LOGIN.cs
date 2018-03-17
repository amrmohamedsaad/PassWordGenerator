using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Management.PL
{
    public partial class FRM_LOGIN : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();

        public FRM_LOGIN()
        {
            InitializeComponent();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(txtID.Text, txtPWD.Text);
          
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][2].ToString() == "admin")
                {
                    FRM_MAIN.getMainform.productsToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainform.customersToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainform.usersToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainform.backupToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainform.restoreToolStripMenuItem.Enabled = true;
                    //because he can register as user while the window is open
                    FRM_MAIN.getMainform.usersToolStripMenuItem.Visible = true;
                    //it will get the name os the user and save it in this variable 
                    //Fullname is the column name
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
                }
                else if (Dt.Rows[0][2].ToString() == "user")
                {

                    FRM_MAIN.getMainform.productsToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainform.customersToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainform.usersToolStripMenuItem.Visible = false;
                    FRM_MAIN.getMainform.backupToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainform.restoreToolStripMenuItem.Enabled = true;
                    //it will get the name os the user and save it in this variable 
                    //Fullname is the column name
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
                }
            
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
         
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }

}
