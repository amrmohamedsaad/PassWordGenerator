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
    public partial class FRM_USERS_LIST : Form
    {
        BL.CLS_LOGIN Login = new BL.CLS_LOGIN();
        public FRM_USERS_LIST()
        {
            
            InitializeComponent();
            //("") to retrieve all the users
            this.dgvUsers.DataSource = Login.SearchUsers("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.btnSave.Text = "Save User";
            frm.ShowDialog();
            this.dgvUsers.DataSource = Login.SearchUsers("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.txtID.Text = dgvUsers.CurrentRow.Cells[0].Value.ToString();
            frm.txtPWD.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            frm.txtPWDConfirm.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();   
            frm.cmbType.Text = dgvUsers.CurrentRow.Cells[3].Value.ToString();      
            frm.txtFullName.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();     
            frm.btnSave.Text = "Edit User";
            frm.ShowDialog();
            this.dgvUsers.DataSource = Login.SearchUsers(""); 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.dgvUsers.DataSource = Login.SearchUsers(txtSearch.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure Need To Delete This User ?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                Login.Delete_USER(dgvUsers.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Deleting Completed Successfully", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
                this.dgvUsers.DataSource = Login.SearchUsers("");

            }
        }
    }
}
