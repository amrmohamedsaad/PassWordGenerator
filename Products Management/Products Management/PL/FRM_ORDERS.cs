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
using System.Globalization;
namespace Products_Management.PL
{
    public partial class FRM_ORDERS : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();

        DataTable dt = new DataTable();
        void CalculateAmount()
        {
            if (txtPrice.Text != string.Empty && txtQty.Text != string.Empty)
            {
                txtamount.Text = (Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQty.Text)).ToString();
            }


        }
        void CalculateTotalAmount()
        {
            if (txtDiscount.Text != string.Empty && txtamount.Text != string.Empty)
            {
                double Discount = Convert.ToDouble(txtDiscount.Text);
                double Amount = Convert.ToDouble(txtamount.Text);
                double Totalamount = Amount - (Amount * (Discount / 100));

                txtTotalAmount.Text = Totalamount.ToString();
            }

        }
        //clears all boxes to let us add new product
        void ClearBoxes()
        {
            txtIDProduct.Clear();
            txtNameProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtamount.Clear();
            txtDiscount.Clear();
            txtTotalAmount.Clear();
            btnBrowse.Focus();
        }

        void ClearData()
        {
            txtOrderId.Clear();
            txtDesOrder.Clear();
            txtSalesMan.Clear();
            dtorder.ResetText();
            txtCustomerId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            ClearBoxes();
            dt.Clear();
            dgvProducts.DataSource = null;
            txtSumTotals.Clear();
            pictureBox1.Image = null;
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnPrint.Enabled = true;
        }
        //empty datasource to use as i like and enter whatever values to datagridview
        void CreateDataTable()
        {
            dt.Columns.Add("Product ID");
            dt.Columns.Add("PRODUCT Name");
            dt.Columns.Add("PRICE");
            dt.Columns.Add("QTE IN STOCK");
            dt.Columns.Add("Total Price");
            dt.Columns.Add("Discount Percent(%)");
            dt.Columns.Add("Total Price After Discount");
            dgvProducts.DataSource = dt;

            //add buttoncolumn to datagridview
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText="Choose Product";
            //btn.Text = "Search";
            //btn.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns.Insert(0, btn);
        }

        void ResizeDGV()
        {

            this.dgvProducts.RowHeadersWidth = 75;
            this.dgvProducts.Columns[0].Width = 111;
            this.dgvProducts.Columns[1].Width = 100;
            this.dgvProducts.Columns[2].Width = 127;
            this.dgvProducts.Columns[3].Width = 132;
            this.dgvProducts.Columns[4].Width = 115;
            this.dgvProducts.Columns[5].Width = 115;
            this.dgvProducts.Columns[6].Width = 109;


        }
        public FRM_ORDERS()
        {
            InitializeComponent();
            CreateDataTable();
            ResizeDGV();
            txtSalesMan.Text = Program.SalesMan;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //return to me one value and one cell
            this.txtOrderId.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST frm = new FRM_CUSTOMERS_LIST();
            frm.ShowDialog();
            if (frm.dgvCustomers.CurrentRow.Cells[5].Value is DBNull)
            {

                MessageBox.Show("This Client doesn't have Picture");
                this.txtCustomerId.Text = frm.dgvCustomers.CurrentRow.Cells[0].Value.ToString();
                this.txtFirstName.Text = frm.dgvCustomers.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = frm.dgvCustomers.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = frm.dgvCustomers.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = frm.dgvCustomers.CurrentRow.Cells[4].Value.ToString();
                //we must clear the picture place because not to display the picture of last different clickable client
                pictureBox1.Image = null;
                return;
            }
            else
            {
                //display the value of first cell of the specified row in the datagridview in the txtcustomerid
                this.txtCustomerId.Text = frm.dgvCustomers.CurrentRow.Cells[0].Value.ToString();
                this.txtFirstName.Text = frm.dgvCustomers.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = frm.dgvCustomers.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = frm.dgvCustomers.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = frm.dgvCustomers.CurrentRow.Cells[4].Value.ToString();
                byte[] custpicture = (byte[])frm.dgvCustomers.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(custpicture);
                pictureBox1.Image = Image.FromStream(ms);

            }


        }



        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it is not number and opposite to the back space
            //8 represents the ascii code that delete the value
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            //if the button pressed is not number  && correspond or against  Backspace
            // && and against the separator of money

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeparator)
            {
                //handled =true means reject
                e.Handled = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPrice.Text != string.Empty)
            {

                txtQty.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && txtQty.Text != string.Empty)
            {

                txtDiscount.Focus();
            }

        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (order.VerifyQty(txtIDProduct.Text, Convert.ToInt32(txtQty.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("This Quantity Doesn't Exists", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //before adding the line we must make loop
                //to check if the product already exists
                for (int i = 0; i < dgvProducts.Rows.Count - 1; i++)
                { //  if qty in stock smaller then the entered value 

                    if (dgvProducts.Rows[i].Cells[0].Value.ToString() == txtIDProduct.Text)
                    {
                        MessageBox.Show("This product Already exists", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                }
                //make the line go down to the dgv
                DataRow r = dt.NewRow();
                r[0] = txtIDProduct.Text;
                r[1] = txtNameProduct.Text;
                r[2] = txtPrice.Text;
                r[3] = txtQty.Text;
                r[4] = txtamount.Text;
                r[5] = txtDiscount.Text;
                r[6] = txtTotalAmount.Text;

                dt.Rows.Add(r);
                dgvProducts.DataSource = dt;
                ClearBoxes();
                //we can use query expression or we can make a loop to go throw all the values from 0 to 6
                txtSumTotals.Text = (from DataGridViewRow row in dgvProducts.Rows
                                     where row.Cells[6].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();

            }
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //assume that i entered long amount or anything 
                //so the datagrid view will return and put the product details again in the text boxes
                txtIDProduct.Text = this.dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtNameProduct.Text = this.dgvProducts.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = this.dgvProducts.CurrentRow.Cells[2].Value.ToString();
                txtQty.Text = this.dgvProducts.CurrentRow.Cells[3].Value.ToString();
                txtamount.Text = this.dgvProducts.CurrentRow.Cells[4].Value.ToString();
                txtDiscount.Text = this.dgvProducts.CurrentRow.Cells[5].Value.ToString();
                txtTotalAmount.Text = this.dgvProducts.CurrentRow.Cells[6].Value.ToString();

                //i must remove it because not to be duplicated and it will say to me 
                //this product already exists
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);

                txtQty.Focus();

            }
            catch
            {
                return;
            }

        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtSumTotals.Text = (from DataGridViewRow row in dgvProducts.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvProducts_DoubleClick(sender, e);
        }

        private void deleteCurrentRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
            }
            catch
            {
                return;
            }
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dgvProducts.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //check values
            if (txtOrderId.Text == string.Empty || txtCustomerId.Text == string.Empty || dgvProducts.Rows.Count < 1 || txtDesOrder.Text == string.Empty)
            {

                MessageBox.Show("Must Register the Important Information", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //adding recipt information 

            order.ADD_ORDER(Convert.ToInt32(txtOrderId.Text), dtorder.Value, Convert.ToInt32(txtCustomerId.Text), txtDesOrder.Text, txtSalesMan.Text);

            // adding the entering products from the user
            // -1 in the counter because the counting starts with 0
            for (int i = 0; i < dgvProducts.Rows.Count - 1; i++)
            {
                order.ADD_ORDER_DETAILS(dgvProducts.Rows[i].Cells[0].Value.ToString(),
                Convert.ToInt32(txtOrderId.Text),
                Convert.ToInt32(dgvProducts.Rows[i].Cells[3]),
                dgvProducts.Rows[i].Cells[2].Value.ToString(),
                Convert.ToInt32(dgvProducts.Rows[i].Cells[5].Value),
                dgvProducts.Rows[i].Cells[4].Value.ToString()
                , dgvProducts.Rows[i].Cells[6].Value.ToString());
            }
            MessageBox.Show("Saving Process Completed Successfully", "Saving Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //get the last order 
            //[0][0] get to me one line and one cell
            int order_ID = Convert.ToInt32(order.GET_LAST_ORDER_FOR_PRINT().Rows[0][0]);
            RPT.rpt_orders report = new RPT.rpt_orders();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            report.SetDataSource(order.GetOrderDetails(order_ID));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            frm.ShowDialog();
            txtIDProduct.Text = frm.dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtNameProduct.Text = frm.dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = frm.dgvProducts.CurrentRow.Cells[3].Value.ToString();
            txtQty.Focus();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
