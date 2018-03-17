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
    public partial class FRM_CONFIG : Form
    {
        public FRM_CONFIG()
        {
            InitializeComponent();
            txtServer.Text = Properties.Settings.Default.Server;
            txtDatabase.Text = Properties.Settings.Default.Database;
            if (Properties.Settings.Default.Mode == "SQL")
            {
                rbSQL.Checked = true;
                txtID.Text = Properties.Settings.Default.ID;
                txtPWD.Text = Properties.Settings.Default.Password;
            }
            else
            {
                rbWindows.Checked = true;
                txtID.Clear();
                txtPWD.Clear();
                txtID.ReadOnly = true;
                txtPWD.ReadOnly = true;
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = txtServer.Text;
            Properties.Settings.Default.Database = txtDatabase.Text;
            Properties.Settings.Default.Mode = rbSQL.Checked==true? "SQL" : "Windows";
            Properties.Settings.Default.ID = txtID.Text;
            Properties.Settings.Default.Password = txtPWD.Text;
            Properties.Settings.Default.Save();
        }

        private void rbSQL_CheckedChanged(object sender, EventArgs e)
        {
            txtID.ReadOnly = false;
            txtPWD.ReadOnly = false;
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            txtPWD.ReadOnly = true;
        }
    }
}
