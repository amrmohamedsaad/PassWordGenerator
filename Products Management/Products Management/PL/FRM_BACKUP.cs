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
    public partial class FRM_BACKUP : Form
    {
        SqlConnection con = new SqlConnection("Server=AMR-PC;database=Product_DB;Integrated Security=true");
        SqlCommand cmd;
        public FRM_BACKUP()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Product_DB will be created inside the folder choosen  concatenated with the date and time and its extension is .bak
            string filename = txtFileName.Text + "\\Product_DB" + DateTime.Now.ToShortDateString().Replace('/','-')+" - "
                                                              + DateTime.Now.ToLongTimeString().Replace(':','-');
            //Query to backup file with .bak extension
            string strQuery = "Backup Database Product_DB to Disk ='" +filename + ".bak'";
            cmd = new SqlCommand(strQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            // message to be sure that backup succeded
            MessageBox.Show("Backup Completed Successfully", "Backup the file", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
