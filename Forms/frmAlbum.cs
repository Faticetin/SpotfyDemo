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
    public partial class frmAlbum : Form
    {
        AlbumDal _albumDal = new AlbumDal();
        SongDal _songDal = new SongDal();
        public frmAlbum()
        {
            InitializeComponent();
        }

        private void songsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }

        private void frmAlbum_Load(object sender, EventArgs e)
        {
            dgwAlbums.DataSource = _albumDal.GetDataList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmAlbumAdd frm = new frmAlbumAdd();
            frm.Show();
            this.Hide();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgwAlbums.SelectedRows[0];
            int albumId = Convert.ToInt32(selectedRow.Cells["AlbumId"].Value);

            _songDal.RemoveSongByAlbumId(albumId);
            _albumDal.Remove(albumId);

            dgwAlbums.DataSource = _albumDal.GetDataList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmAlbumUpdate frm = new frmAlbumUpdate();
            frm.Show();
            this.Hide();
        }

        private void artistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtist frm = new frmArtist();
            frm.Show();
            this.Hide();
        }

    }
}
