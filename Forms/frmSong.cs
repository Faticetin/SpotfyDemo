using SpotifyDemo.Forms;
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

    public partial class frmSong : Form
    {
        SongDal _songDal = new SongDal();
        public frmSong()
        {
            InitializeComponent();
        }

        private void frmSong_Load(object sender, EventArgs e)
        {
            dgwSongs.DataSource = _songDal.GetDataList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmSongAdd frm = new frmSongAdd();
            frm.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmSongUpdate frm = new frmSongUpdate();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgwSongs.SelectedRows[0];
            int songId = Convert.ToInt32(selectedRow.Cells["SongId"].Value);

            _songDal.Remove(songId);

            dgwSongs.DataSource = _songDal.GetDataList();
        }

        private void albumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlbum frm = new frmAlbum();
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
