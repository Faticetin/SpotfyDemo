using SpotifyDemo.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SpotifyDemo
{
    public partial class frmLogin : Form
    {
        UserDal users = new UserDal();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister frm =new frmRegister();
            frm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isExist = users.UserLogin(txtEmail.Text, txtPassword.Text);

            if (true)
            {
                frmSong frm = new frmSong();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email veya şifre hatalı!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAlbum frm = new frmAlbum();
            frm.Show();
            this.Hide();
        }
    }
}
