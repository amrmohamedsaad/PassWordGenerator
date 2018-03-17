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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
namespace Products_Management.PL
{
    public partial class FRM_CATEGORIES : Form
    {
        SqlConnection sqlcon = new SqlConnection("Server=.; Database=Product_DB; Integrated Security=true");
        //sqldataadapter get the data from specific table and send data to specific table
        SqlDataAdapter da;

        //we need datatable to recieve the data that the dataadapter will get
        DataTable dt = new DataTable();
        //this class manages all binding objects that connected to the same data asource
        BindingManagerBase bmb;
        //will be used in add /  etc
        SqlCommandBuilder cmdb;
        public FRM_CATEGORIES()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select id_cat as ID , DESCRIPTION_CAT as Category from categories ", sqlcon);
            da.Fill(dt);
            dgList.DataSource = dt;
            txtID.DataBindings.Add("text", dt, "ID");
            txtDes.DataBindings.Add("text", dt, "Category");

            bmb = this.BindingContext[dt];

            lblPosition.Text = (bmb.Position+1) + "/" + bmb.Count;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //position property in the bindingmanagerbas class object initialized to zero means the first record
            bmb.Position = 0;
            //if clicked it will go to the first record and the label will be 1 / the number of the records 
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //set the position to the las record
            bmb.Position = bmb.Count;
            //the label text will last position plus one because
            //it zero indexed but we cant put the zero as the first record in the label  /  and the number o all the records
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //decrease the record one  from the selected position number
            bmb.Position -=1;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //increse the position one to the selected position number
            bmb.Position += 1;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //makes to you a new line in the datagrid to enter new product
            bmb.AddNew();
            //disables the new button and you can press on it 
            btnNew.Enabled = false;
            //enable add button and you can press on it
            btnAdd.Enabled = true;
            //i can't under stand this 
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count-1][0])+1;

            txtID.Text = id.ToString();

            txtDes.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            //end the current process
            bmb.EndCurrentEdit();
            //connect dataadapter to tell the command builder which server will work with 
            //and the table that needed to verify in 
            cmdb = new SqlCommandBuilder(da);
            //any change in datatable that connected with databind  will change in dataadapter
            da.Update(dt);

            MessageBox.Show("Added Successfuly","Add",MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            //end the current process
            bmb.EndCurrentEdit();
            //connect dataadapter to tell the command builder which server will work with 
            //and the table that needed to verify in 
            cmdb = new SqlCommandBuilder(da);
            //any change in datatable that connected with databind  will change in dataadapter
            da.Update(dt);

            MessageBox.Show("Deleteded Successfuly", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //end the current process
            bmb.EndCurrentEdit();
            //connect dataadapter to tell the command builder which server will work with 
            //and the table that needed to verify in 
            cmdb = new SqlCommandBuilder(da);
            //any change in datatable that connected with databind  will change in dataadapter
            da.Update(dt);

            MessageBox.Show("Edit Successfuly", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnPrintCurrent_Click(object sender, EventArgs e)
        {
            RPT.rpt_single_category rpt = new RPT.rpt_single_category();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            //set the parameter name and its value that u can get from the textbox or the datagridvireew
            rpt.SetParameterValue("@ID", Convert.ToInt32(txtID.Text));
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_categories rpt = new RPT.rpt_all_categories();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            //refresh the report because when we add new item  make it display in the report
            rpt.Refresh();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void ExportToPdfAll_Click(object sender, EventArgs e)
        {
            //make a copy of a report
            RPT.rpt_all_categories myReport = new RPT.rpt_all_categories();
            //this object allow us to store the report in the format that we want
            //create export options
            ExportOptions export = new ExportOptions();

            // this object allow us to determine the path that we will save the report in 
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            //excel file format
            PdfFormatOptions pdfformat = new PdfFormatOptions();
            //set the path
            dfoptions.DiskFileName = @"F:\CategoriesList.pdf";
            //report settings is now connected with the settings we are doing
            export = myReport.ExportOptions;
            //file will be saved on the disk
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            //it's type is excel 
            export.ExportFormatOptions = pdfformat;
            //settings of the file is the same that we declare above  
            //ExcelFormatOptions  excelformat = new ExcelFormatOptions();
            export.ExportFormatType = ExportFormatType.PortableDocFormat;

            //save that file in the destination path
            export.ExportDestinationOptions = dfoptions;
            
            myReport.Refresh();//bec if i changed the item with the arrows
            myReport.Export();

            MessageBox.Show("List Exported Successfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToPdfCurrent_Click(object sender, EventArgs e)
        {
            //make a copy of a report
            RPT.rpt_single_category myReport = new RPT.rpt_single_category();
            //this object allow us to store the report in the format that we want
            //create export options
            ExportOptions export = new ExportOptions();

            // this object allow us to determine the path that we will save the report in 
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            //excel file format
            PdfFormatOptions pdfformat = new PdfFormatOptions();
            //set the path
            dfoptions.DiskFileName = @"F:\CategoryDetails.pdf";
            //report settings is now connected with the settings we are doing
            export = myReport.ExportOptions;
            //file will be saved on the disk
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            //settings of the file is the same that we declare above  
            //ExcelFormatOptions  excelformat = new ExcelFormatOptions();
            export.ExportFormatType = ExportFormatType.PortableDocFormat;

            //it's type is excel 
            export.ExportFormatOptions = pdfformat;
            //save that file in the destination path
            export.ExportDestinationOptions = dfoptions;

            myReport.SetParameterValue("@id", Convert.ToInt32(txtID.Text));

            myReport.Export();

          

            MessageBox.Show("List Exported Successfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
