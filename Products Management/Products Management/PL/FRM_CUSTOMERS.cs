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
    public partial class FRM_CUSTOMERS : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        int ID, Position;
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Picture;
                if (pbox.Image == null)
                {
                    //this is trick to pass it as argument to the picture parameter to remove the compile error
                    Picture = new byte[0];
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "without_image");
                    MessageBox.Show("Adding Completed Successfully", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();

                }
                else
                {
                    //create memory stream the img
                    MemoryStream ms = new MemoryStream();
                    //save the image in the memory
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    //convert it to bytes to be send to the database
                    Picture = ms.ToArray();
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image");
                    MessageBox.Show("Adding Completed Successfully", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();

                }
            }
            catch
            {
                return;
            }
            finally
            {
                btnAdd.Enabled = false;
                btnNew.Enabled = true;
            }
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            //if the user choosed a picture and pressed ok so display it
            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(op.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            pbox.Image = null;
            txtFirstName.Focus();
            btnAdd.Enabled = true;
            btnNew.Enabled = false;
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            //if the user pressed enter on this text box
            if (e.KeyCode == Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            //if the user pressed enter on this text box
            if (e.KeyCode == Keys.Enter)
            {
                txtTel.Focus();
            }
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            //if the user pressed enter on this text box
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            //if the user pressed enter on this text box
            if (e.KeyCode == Keys.Enter)
            {
                btnNew.Focus();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //every double click must clear the picture to display the new image
                pbox.Image = null;
                ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                this.txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //to retrieve the picture and convert to memory stream to display it in the picture box
                byte[] picture = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(picture);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                if (ID == 0)
                {

                    MessageBox.Show("the employee you want to edit doesn't exists");
                    return;
                }
                byte[] Picture;
                if (pbox.Image == null)
                {
                    //this is trick to pass it as argument to the picture parameter to remove the compile error
                    Picture = new byte[0];
                    // we update according to the selected row
                    //the user may doubleclick specific client on the datagrid view so its info will appear on the textboxes
                    //and if after that he select another client the update will be on the last client that selected not doubled clicked
                    //so we must get the selected row in the gridview and save it in a variable
                    //so we will declare a global variable
                    cust.EDIT_CUSTOMERS(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "without_image", ID);
                    MessageBox.Show("Editing Completed Successfully", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();

                }
                else
                {
                    //create memory stream the img
                    MemoryStream ms = new MemoryStream();
                    //save the image in the memory
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    //convert it to bytes to be send to the database
                    Picture = ms.ToArray();
                    cust.EDIT_CUSTOMERS(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image", ID);
                    MessageBox.Show("Editing Completed Successfully", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();

                }
            }
            catch
            {
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {

                MessageBox.Show("The Employee you want to Delete doesn't exists");
                return;
            }

            if (MessageBox.Show("Do you really want to delete this icon", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.DELETE_CUSTOMER(ID);
                MessageBox.Show("Deleting Completed Successfully", "deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();
            }              

             
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cust.Search_Customer(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if the button clicked was the enter button
            if (e.KeyCode == Keys.Enter)
            {
                button10_Click(sender, e);
            }
        }
        void Navigate(int index)
        {
            try
            {
                pbox.Image = null;
                //instead of wriiting 
                //DataTable dt = cust.GET_ALL_CUSTOMERS();
                //instead of writting dt.Rows
                DataRowCollection DRC = cust.GET_ALL_CUSTOMERS().Rows;
                ID = Convert.ToInt32(DRC[index][0]);
                txtFirstName.Text = DRC[index][1].ToString();
                txtLastName.Text = DRC[index][2].ToString();
                txtTel.Text = DRC[index][3].ToString();
                txtEmail.Text = DRC[index][4].ToString();
                byte[] picture = (byte[])DRC[index][5];
                MemoryStream ms = new MemoryStream(picture);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Position = cust.GET_ALL_CUSTOMERS().Rows.Count - 1;
            Navigate(Position);
    
        }
        BindingManagerBase bmb;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Position == 0)
            {
                MessageBox.Show("this is the first element");
                return;

            }
            Position -= 1;
            Navigate(Position);
            
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Position == cust.GET_ALL_CUSTOMERS().Rows.Count - 1)
            {
                MessageBox.Show("this is the last element");
                return;

            }
            Position += 1;
            Navigate(Position);
          

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }
    }
}
