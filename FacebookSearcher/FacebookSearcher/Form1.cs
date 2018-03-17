using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace FacebookSearcher
{
    public partial class Form1 : Form
    {
        string access_token;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            string OAuthUrl = @"https://www.facebook.com/v2.10/dialog/oauth?client_id=1475321829257078&redirect_uri=https://www.facebook.com/connect/login_success.html&responsetype=token";
            webFacebook.Navigate(OAuthUrl);
        }

        private void webFacebook_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            if (webFacebook.Url.AbsoluteUri.Contains("access_token"))
            {
                string url1 = webFacebook.Url.AbsoluteUri;
                string url2 = url1.Substring(url1.IndexOf("access_token") + 13);
                access_token = url2.Substring(0, url2.IndexOf("&"));
                MessageBox.Show("access_token = " + access_token);
                FacebookClient fb = new FacebookClient(access_token);

                dynamic data = fb.Get("/me");

                MessageBox.Show("id" + data.id + Environment.NewLine + "Name" + data.name);
            }
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            FacebookClient fb2 = new FacebookClient(access_token);
            dynamic FriendList = fb2.Get("/me/firends");
            int count = (int)FriendList.data.count;
            for (int i = 0; i < count; i++)
            {
                listfriendlist.Items.Add(FriendList.data[i].name);
            }
        }
    }
}
