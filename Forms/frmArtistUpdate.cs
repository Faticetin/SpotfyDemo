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
    public partial class frmArtistUpdate : Form
    {
        ArtistDal _artistDal = new ArtistDal();
        public frmArtistUpdate()
        {
            InitializeComponent();
        }

        private void frmArtistUpdate_Load(object sender, EventArgs e)
        {
            dgwArtists.DataSource = _artistDal.GetAll();

        }

        private void dgwArtists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgwArtists.SelectedRows[0];
            int artistId = Convert.ToInt32(selectedRow.Cells["ArtistId"].Value);


            Artist artist = _artistDal.GetById(artistId);

            txtArtist.Text = artist.Name;
            txtCountry.Text = artist.Country;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Artist artist = new Artist
            {
                ArtistId = (int)dgwArtists.CurrentRow.Cells[0].Value,
                Country = txtCountry.Text,
                Name = txtArtist.Text,
            };
            _artistDal.Update(artist);
            MessageBox.Show("Updated");


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
