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
    public partial class frmAlbumUpdate : Form
    {
        AlbumDal _albumDal = new AlbumDal();
        ArtistDal _artistDal = new ArtistDal();
        public frmAlbumUpdate()
        {
            InitializeComponent();
        }

        private void frmAlbumUpdate_Load(object sender, EventArgs e)
        {
            dgwAlbums.DataSource = _albumDal.GetDataList();

            cmbArtist.DisplayMember = "Name";
            cmbArtist.ValueMember = "ArtistId";
            cmbArtist.DataSource = _artistDal.GetAll();
            cmbArtist.SelectedIndex = -1;
        }

        private void dgwAlbums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgwAlbums.SelectedRows[0];
            int albumId = Convert.ToInt32(selectedRow.Cells["AlbumId"].Value);


            Album album = _albumDal.GetById(albumId);


            cmbArtist.SelectedValue = album.ArtistId;

            txtAlbum.Text = album.Name;
            dtpReleaseDate.Value = album.ReleaseDate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Artist selectedArtist = (Artist)cmbArtist.SelectedItem;


            if (selectedArtist != null)
            {
                Album album = new Album
                {
                    AlbumId = Convert.ToInt32(dgwAlbums.CurrentRow.Cells[0].Value),
                    Name = txtAlbum.Text,
                    ArtistId = selectedArtist.ArtistId,
                    ReleaseDate = Convert.ToDateTime(dgwAlbums.CurrentRow.Cells[3].Value)
                };
                _albumDal.Update(album);
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Please select an artist and an album.");
            }

            frmAlbum frm = new frmAlbum();
            frm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAlbum frm = new frmAlbum();
            frm.Show();
            this.Hide();
        }
    }
}
