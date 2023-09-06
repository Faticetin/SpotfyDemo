using Business.Abstract;
using Business.Concrete.EntityFramwork;
using DataAccess.Concrete;
using Entities.Concrete;
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


        public frmSongAdd()
        {
            InitializeComponent();
            _albumService = new AlbumManeger(new EfAlbumDal());
            _artistService = new ArtistManeger(new EfArtistDal());
            _songService = new SongManeger(new EfSongDal());
        }
        private ISongService _songService;
        private IArtistService _artistService;
        private IAlbumService _albumService;
        private void btnAdd_Click(object sender, EventArgs e)
        {

            Artist selectedArtist = (Artist)cmbArtist.SelectedItem;
            Album selectedAlbum = (Album)cmbAlbum.SelectedItem;

            _songService.Add(new Song
            {
                AlbumId = selectedAlbum.AlbumId,
                ArtistId = selectedArtist.ArtistId,
                Name = txtSong.Text,
                ReleaseDate = dtpReleaseDate.Value
            });
            MessageBox.Show("Şarkı Eklendi");

            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }

        private void frmSongAdd_Load(object sender, EventArgs e)
        {

            cmbArtist.DataSource = _artistService.GetAll();
            cmbArtist.DisplayMember = "Name";
            cmbArtist.ValueMember = "ArtistId";

        }

        private void cmbArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Artist selectedArtist = (Artist)cmbArtist.SelectedItem;
            try
            {
                int artistId = selectedArtist.ArtistId;
                List<Album> albums = _albumService.GetAlbumsByArtistId(artistId);
                cmbAlbum.DataSource = albums;
                cmbAlbum.DisplayMember = "Name";
                cmbAlbum.ValueMember = "AlbumId";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Dönüşüm hatası: " + ex.Message);
            }



        }
    }
}
