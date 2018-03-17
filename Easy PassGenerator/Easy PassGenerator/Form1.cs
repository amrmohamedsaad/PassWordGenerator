using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EasyPasswordGenerator;

namespace Easy_PassGenerator
{
    public partial class Form1 : Form
    {
        // members
        private Int32 lenth;
        private Int32 nbrPassword;
        private string template;
        private string prefix;
        private long size;
        private IEnumerable<string> q;
        int j;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Timers.Timer time = new System.Timers.Timer();
        }

        private void GeneratePassword_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            prefix = txtPrefix.Text;
            template = "";
            if (chckBUpper.Checked)
                template += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (chckBLower.Checked)
                template += "abcdefghijklmnopqrstuvwxyz";
            if (chckBNumber.Checked)
                template += "0123456789";
            if (chckSymbols.Checked)
                template += "#%^&)(-_}{[];,./\\~`!@$*+=?\"'|:";

            lenth = Int32.Parse(string.IsNullOrEmpty(txtLength.Text) ? "0" : txtLength.Text);
            nbrPassword = Int32.Parse(string.IsNullOrEmpty(txtNbrPassword.Text) ? "0" : txtNbrPassword.Text);


            if (lenth < 6)
            {
                MessageBox.Show("Please Don't enter less Than 6 Numbers or Characters");
                return;
            }

            if (!chckBLower.Checked && !chckBUpper.Checked && !chckSymbols.Checked && !chckBNumber.Checked)
            {

                MessageBox.Show("please choose Template");
                return;

            }  //combinition
            if (chckBMax.Checked)
            {
                q = template.Select(element => element.ToString());//a b c ....
                for (int i = 0; i < lenth - 1; i++)
                    q = q.SelectMany(x => template, (y, x) => y + x);
                if (nbrPassword == 0)
                {

                    nbrPassword = q.Count();
                }
            }
            else
            {
                //random
                if (nbrPassword < 10)
                {
                    MessageBox.Show("please Don't enter less then 10 numbers or Password");
                    return;
                }

            }



            progressBar1.Maximum = nbrPassword;
            GeneratePassword.Enabled = false;
            btnStop.Enabled = true;
            backgroundWorker1.RunWorkerAsync();


            j += nbrPassword;

            label13.Text = Convert.ToString(j);
            label9.Text = txtNbrPassword.Text;
            size = Encoding.Default.GetByteCount(textBox1.Text);
            label14.Text = Convert.ToString(Generator.FormatBytes(size));
            timer1.Start();
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            SaveFileDialog o1 = new SaveFileDialog();
            o1.Filter = "Text file|*.txt";
            o1.FileName = "My Text File";
            o1.Title = "Save Text file. ";
            if (o1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = o1.FileName;
                BinaryWriter br = new BinaryWriter(File.Create(path));
                br.Write(textBox1.Text);
                br.Dispose();
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            progressBar1.Value = 0;
            label13.Text = Convert.ToString(j = 0);
            label10.Text = (0).ToString();
            label9.Text = (0).ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                GeneratePassword.Enabled = true;
                btnStop.Enabled = false;
                timer1.Stop();
                label10.Text = (0).ToString();
                label9.Text = (0).ToString();
            }
        }

        void getText(string str)
        {
            try
            {
                if (InvokeRequired)
                {

                    this.Invoke(new Action<string>(getText), str);
                    return;
                }
                textBox1.AppendText(str);
                textBox1.ScrollToCaret();
            }
            catch (Exception)
            {
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //combinas
            if (chckBMax.Checked)
            {
                Int32 index = 0;
                foreach (var item in q)
                {
                    getText(prefix + item + "\r\n");
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        backgroundWorker1.ReportProgress(i);
                        index++;
                        if (index == nbrPassword)
                            return;
                        return;
                    }
                }
            }
            else
            {
                //random

                for (int i = 0; i < nbrPassword; i++)
                {
                    Thread.Sleep(1);

                    getText(prefix + Generator.GetRandomPassword(lenth, template) + "\r\n");

                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        backgroundWorker1.ReportProgress(i);
                        return;
                    }
                }

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GeneratePassword.Enabled = true;
            btnStop.Enabled = false;
            progressBar1.Value = nbrPassword;
            timer1.Stop();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            label10.Text = i.ToString();
        }

        private void txtLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chckBMax_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBMax.Checked == true)
            {
                chckBLower.Enabled = false;
                chckBUpper.Enabled = false;
                chckBNumber.Enabled = false;
                chckSymbols.Enabled = false;
                txtNbrPassword.Enabled = false;
            }
            else
            {
                chckBLower.Enabled = true;
                chckBUpper.Enabled = true;
                chckBNumber.Enabled = true;
                chckSymbols.Enabled = true;
                txtNbrPassword.Enabled = true;
            }
        }
    }
}
