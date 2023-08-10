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
    public partial class frmSongUpdate : Form
    {
        SongDal _songDal = new SongDal();
        AlbumDal _albumDal = new AlbumDal();
        ArtistDal _artistDal = new ArtistDal();

        public frmSongUpdate()
        {
            InitializeComponent();
        }

        private void frmSongUpdate_Load(object sender, EventArgs e)
        {
            dgwSongs.DataSource = _songDal.GetDataList();

            cmbArtist.DisplayMember = "Name";
            cmbArtist.ValueMember = "ArtistId";
            cmbArtist.DataSource = _artistDal.GetAll();
            cmbArtist.SelectedIndex = -1;
        }

        private void dgwSongs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow selectedRow = dgwSongs.SelectedRows[0];
            int songId = Convert.ToInt32(selectedRow.Cells["SongId"].Value);


            Song song = _songDal.GetById(songId);


            cmbArtist.SelectedValue = song.ArtistId;


            cmbAlbum.DisplayMember = "Name";
            cmbAlbum.ValueMember = "AlbumId";
            cmbAlbum.DataSource = _albumDal.GetByArtistId(song.ArtistId);

            cmbAlbum.SelectedValue = song.AlbumId;

            txtSong.Text = song.Name;
            dtpReleaseDate.Value = song.ReleaseDate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Artist selectedArtist = (Artist)cmbArtist.SelectedItem;
            Album selectedAlbum = (Album)cmbAlbum.SelectedItem;


            if (selectedArtist != null && selectedAlbum != null)
            {
                Song song = new Song
                {
                    SongId = Convert.ToInt32(dgwSongs.CurrentRow.Cells[0].Value),
                    Name = txtSong.Text,
                    AlbumId = selectedAlbum.AlbumId,
                    ArtistId = selectedArtist.ArtistId,
                    ReleaseDate = Convert.ToDateTime(dgwSongs.CurrentRow.Cells[4].Value)
                };
                _songDal.Update(song);
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Please select an artist and an album.");
            }

            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }

        private void cmbArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArtist.SelectedItem is Artist selectedArtist)
            {
                cmbAlbum.DisplayMember = "Name";
                cmbAlbum.ValueMember = "AlbumId";
                cmbAlbum.DataSource = _albumDal.GetByArtistId(selectedArtist.ArtistId);
                cmbAlbum.SelectedIndex = -1;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }
    }
}
