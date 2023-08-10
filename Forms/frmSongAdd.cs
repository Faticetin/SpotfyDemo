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
    public partial class frmSongAdd : Form
    {
        AlbumDal albumDal = new AlbumDal();
        ArtistDal artistDal = new ArtistDal();

        public frmSongAdd()
        {
            InitializeComponent();
        }
        SongDal _songdal = new SongDal();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Artist selectedArtist = (Artist) cmbArtist.SelectedItem;
            Album selectedAlbum = (Album) cmbAlbum.SelectedItem;

            Song song = new Song
            {
                AlbumId = selectedAlbum.AlbumId,
                ArtistId = selectedArtist.ArtistId,
                Name = txtSong.Text,
                ReleaseDate = dtpReleaseDate.Value
            };

            _songdal.Add(song);
            MessageBox.Show("Song Added");
            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }

        private void frmSongAdd_Load(object sender, EventArgs e)
        {
            List<Artist> artists = artistDal.GetAll();

            foreach (Artist artist in artists)
            {
                cmbArtist.Items.Add(artist);

                cmbArtist.DisplayMember = "Name";
                cmbArtist.ValueMember = "ArtistId";
            }
        }

        private void cmbArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAlbum.Items.Clear();

            if (cmbArtist.SelectedItem is Artist selectedArtist)
            {
                List<Album> albums = albumDal.GetByArtistId(selectedArtist.ArtistId);

                foreach (Album album in albums)
                {
                    cmbAlbum.Items.Add(album);
         
                    cmbAlbum.DisplayMember = "Name";
                    cmbAlbum.ValueMember = "AlbumId";
                }
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
