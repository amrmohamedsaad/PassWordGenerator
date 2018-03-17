using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Products_Management.PL
{
    public partial class FRM_ADD_PRODUCTS : Form
    {
        public string state = "add";
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        public FRM_ADD_PRODUCTS()
        {
            InitializeComponent();

            cmbcategories.DataSource = prd.GET_ALL_CATEGORIES();
            //gets the properties which is the column name of the database
            cmbcategories.DisplayMember = "DESCRIPTION_CAT";
            //gets the properties which is the column name of the database
            cmbcategories.ValueMember = "ID_CAT";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            //if the user choosed the file and pressed ok then
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //open file dialoge returns to me the file path with fromfile method

                pb.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                //let us to save data in a certain space on the memory
                MemoryStream ms = new MemoryStream();
                //we will save the image in it
                //rowformat returns to us the type of the image 
                pb.Image.Save(ms, pb.Image.RawFormat);
                //sotre in byte array
                byte[] byteImage = ms.ToArray();
                //selected value returns to me the value of the primary key
                prd.ADD_PRODUCT(Convert.ToInt32(cmbcategories.SelectedValue), txtDes.Text
                    , txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);

                MessageBox.Show("ADD Completed Successfully", "Adding Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //let us to save data in a certain space on the memory
                MemoryStream ms = new MemoryStream();
                //we will save the image in it
                //rowformat returns to us the type of the image 
                pb.Image.Save(ms, pb.Image.RawFormat);
                //sotre in byte array
                byte[] byteImage = ms.ToArray();
                //selected value returns to me the value of the primary key
                prd.UPDATE_PRODUCT(Convert.ToInt32(cmbcategories.SelectedValue), txtDes.Text
                    , txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);


                MessageBox.Show("Update Completed Successfully", "Updating Process", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
            }
                  FRM_PRODUCTS.getMainform.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void txtRef_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable dt = new DataTable();
                dt = prd.VerifyProductID(txtRef.Text);
                //check if the product is already exists
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("this product already exists", "alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRef.Focus();
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.TextLength;
                }
            }
        }
    }
}
