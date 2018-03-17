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
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Products_Management.PL
{
    public partial class FRM_PRODUCTS : Form
    {
        // initialize object from the form 
        private static FRM_PRODUCTS frm;
        //make methodhandler  to be invoked after the formlogin is closed

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // when the form close destroy the object of the form
            frm = null;
        }
        public static FRM_PRODUCTS getMainform
        {
            get
            {
                //check if the object is empty  create one

                if (frm == null)
                {
                    //create
                    frm = new FRM_PRODUCTS();
                    //invoke the event when the form close
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                //if exist continue use it
                return frm;
            }
        }
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        public FRM_PRODUCTS()
        {
            InitializeComponent();
            //we check for existance of the object after the initialize components because the 
            //initialize componenets puts the components like textbox and others on the form 
            //and build the form itself so we must check for building of the form first if it 
            //doesnt exists we must create it with getter
            if (frm == null)
                frm = this;
            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //To recieve the coming data
            DataTable Dt = new DataTable();
            Dt = prd.SearchProduct(txtSearch.Text);
            this.dataGridView1.DataSource = Dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCTS frm = new FRM_ADD_PRODUCTS();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure want to Delete this Product ?", "Deleting Process ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prd.DeleteProduct(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Deleting Process Completed Successfully", "Deleting Process ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
            }
            else
            {
                MessageBox.Show("Deleting Process Cancelled", "Deleting Process ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCTS frm = new FRM_ADD_PRODUCTS();
            frm.txtRef.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtDes.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtQte.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtPrice.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.cmbcategories.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.Text = "Product Update : " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.btnOk.Text = "Update";
            frm.state = "Update";
            frm.txtRef.ReadOnly = true;
            byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.pb.Image = Image.FromStream(ms);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRM_PREVIEW frm = new FRM_PREVIEW();
            byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.pictureBox1.Image = Image.FromStream(ms);
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //create copy from the report
            RPT.rpt_prd_single myReport = new RPT.rpt_prd_single();
            //enter the value of the paramtere to show one product report
            myReport.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //create copy from the form to achieve the crystal report tool

            RPT.FRM_RPT_PRODUCT myForm = new RPT.FRM_RPT_PRODUCT();
            //put the source of the report to the crystal report tool
            myForm.crystalReportViewer1.ReportSource=myReport;
            //display the report
            myForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_products myReport = new RPT.rpt_all_products();
            RPT.FRM_RPT_PRODUCT myForm = new RPT.FRM_RPT_PRODUCT() ;
            myForm.crystalReportViewer1.ReportSource = myReport;
            myForm.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //make a copy of a report
            RPT.rpt_all_products myReport = new RPT.rpt_all_products();
            //this object allow us to store the report in the format that we want
            //create export options
            ExportOptions export = new ExportOptions();

            // this object allow us to determine the path that we will save the report in 
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            //excel file format
            ExcelFormatOptions excelformat = new ExcelFormatOptions();
            //set the path
            dfoptions.DiskFileName = @"C:\ProductList.xls";
            //report settings is now connected with the settings we are doing
            export = myReport.ExportOptions;
            //file will be saved on the disk
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            //it's type is excel 
            export.ExportFormatOptions = excelformat;
            //settings of the file is the same that we declare above  
            //ExcelFormatOptions  excelformat = new ExcelFormatOptions();
            export.ExportFormatType = ExportFormatType.Excel;

            //save that file in the destination path
            export.ExportDestinationOptions = dfoptions;

            myReport.Export();

            MessageBox.Show("List Exported Successfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
