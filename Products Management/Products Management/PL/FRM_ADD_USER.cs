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
    public partial class FRM_ADD_USER : Form
    {
        public FRM_ADD_USER()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty || txtPWD.Text == string.Empty || txtFullName.Text == string.Empty || txtPWDConfirm.Text == string.Empty)
            {
                MessageBox.Show("Please Enter All Information","ALert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("The Passwords Are Not Same", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnSave.Text == "Save User")
            {
                //create object from CLS_LOGIN classthat contain methods for login / add /edit / delete users 
                //to use this methods
                BL.CLS_LOGIN user = new BL.CLS_LOGIN();
                //add user
                user.ADD_USER(txtID.Text, txtFullName.Text, txtPWD.Text, cmbType.Text);
                //message to to be sure that the user added
                MessageBox.Show("New User Created Successfully", "Adding New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (btnSave.Text == "Edit User")
            {
                //create object from CLS_LOGIN classthat contain methods for login / add /edit / delete users 
                //to use this methods
                BL.CLS_LOGIN user = new BL.CLS_LOGIN();
                //edit existing user
                user.Edit_USER(txtID.Text, txtFullName.Text, txtPWD.Text, cmbType.Text);
                //message to to be sure that the user edited 
                MessageBox.Show("New User Edited Successfully", "Editing New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //after finishing adding or editing clear the text boxes
            txtID.Clear();
            txtFullName.Clear();
            txtPWD.Clear();
            txtPWDConfirm.Clear();
            //focus the cursor on the txtid textbox
            txtID.Focus();
        }

        private void txtPWDConfirm_Validated(object sender, EventArgs e)
        {
            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("The Passwords Are Not Same", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
