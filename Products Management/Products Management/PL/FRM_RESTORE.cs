using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Products_Management.PL
{
    public partial class FRM_RESTORE : Form
    {
        
        SqlConnection con = new SqlConnection("Server=AMR-PC;database=master;Integrated Security=true");
        SqlCommand cmd;
        public FRM_RESTORE()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
          //close database connection with other open connections before restore
            string strQuery = "ALTER Database Product_DB SET OFFLINE WITH ROLLBACK IMMEDIATE;Restore Database Product_DB From Disk ='" + txtFileName.Text + "'";
            cmd = new SqlCommand(strQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Restore Completed Successfully", "Restore the file", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
