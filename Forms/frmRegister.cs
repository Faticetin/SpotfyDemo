using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyDemo
{
    public partial class frmRegister : Form
    {
        UserDal user = new UserDal();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool isRegistered = user.UserRegister(new User
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            });

            if (isRegistered)
            {
                MessageBox.Show(" User Registered ");

                frmLogin frm = new frmLogin();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bu Email kullanılıyor");
            }

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
