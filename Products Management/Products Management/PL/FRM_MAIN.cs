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
    public partial class FRM_MAIN : Form
    {
        // initialize object from the form 
        private static FRM_MAIN frm;
        //make methodhandler  to be invoked after the formlogin is closed

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // when the form close destroy the object of the form
            frm = null;
        }
        public static FRM_MAIN getMainform
        {
            get
            {
                //check if the object is empty  create one

                if (frm == null)
                {
                    //create
                    frm = new FRM_MAIN();
                    //invoke the event when the form close
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                //if exist continue use it
                return frm;
            }
        }
        public FRM_MAIN()
        {

            InitializeComponent();
            //initialize the frm
            // the value of the frm is the object of this form
            if (frm == null)
                frm = this;
            this.productsToolStripMenuItem.Enabled = false;
            this.customersToolStripMenuItem.Enabled = false;
            this.usersToolStripMenuItem.Enabled = false;
            this.backupToolStripMenuItem.Enabled = false;
            this.restoreToolStripMenuItem.Enabled = false;
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN frm = new FRM_LOGIN();
            frm.ShowDialog();
        }

        private void addnewproductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCTS frm = new FRM_ADD_PRODUCTS();
            frm.ShowDialog();
        }

        private void productmanagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS frm = new FRM_PRODUCTS();
            frm.ShowDialog();
        }

        private void itemmanagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();
            frm.ShowDialog();
        }

        private void addnewcustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void customersmanagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
             FRM_CUSTOMERS frm = new FRM_CUSTOMERS();
             frm.ShowDialog();
        }

        private void addnewsoldoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void salesmanagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS_LIST frm = new FRM_ORDERS_LIST();
            frm.ShowDialog();
        }

        private void addnewuserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();
        }

        private void usersmanagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USERS_LIST frm = new FRM_USERS_LIST();
            frm.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_BACKUP frm = new FRM_BACKUP();
            frm.ShowDialog();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_RESTORE frm = new FRM_RESTORE();
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_MAIN.getMainform.productsToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainform.customersToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainform.usersToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainform.backupToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainform.restoreToolStripMenuItem.Enabled = false;
        }

        private void serverConnectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONFIG frm = new FRM_CONFIG();
            frm.ShowDialog();
        }
    }
}
