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
    public partial class frmArtist : Form
    {
        ArtistDal _artistDal = new ArtistDal();
        SongDal _songDal = new SongDal();
        AlbumDal _albumDal = new AlbumDal();
        public frmArtist()
        {
            InitializeComponent();
        }

        private void frmArtist_Load(object sender, EventArgs e)
        {
            dgwArtists.DataSource = _artistDal.GetAll();
        }

        private void songsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }

        private void albumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlbum frm = new frmAlbum();
            frm.Show();
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmArtistAdd frm = new frmArtistAdd();
            frm.Show();
            this.Hide();    
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            int artistId = Convert.ToInt32(dgwArtists.CurrentCell.OwningRow.Cells["ArtistId"].Value.ToString());



            _songDal.RemoveSongByArtistId(artistId);
            _albumDal.RemoveByAlbumId(artistId);
            _artistDal.Remove(artistId);

            dgwArtists.DataSource = _artistDal.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmArtistUpdate frm = new frmArtistUpdate();
            frm.Show();
            this.Hide();
        }
    }
}
