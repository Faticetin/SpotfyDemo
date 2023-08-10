using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyDemo.Forms
{
    public partial class frmArtistAdd : Form
    {
        ArtistDal _artistDal = new ArtistDal();
        public frmArtistAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Artist artist = new Artist
            {
                Name = txtArtist.Text,
                Country = txtCountry.Text
            };

            _artistDal.Add(artist);
            MessageBox.Show("Artist Added");
            frmArtist frm = new frmArtist();
            frm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmArtist frm = new frmArtist();
            frm.Show();
            this.Hide();
        }
    }
}
