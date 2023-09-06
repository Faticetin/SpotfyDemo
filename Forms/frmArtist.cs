using Business.Abstract;
using Business.Concrete;
using Business.Concrete.EntityFramwork;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyDemo.Forms
{
    public partial class frmArtist : Form
    {
        //ArtistDal _artistDal = new ArtistDal();
        //SongDal _songDal = new SongDal();
        //AlbumDal _albumDal = new AlbumDal();
        public frmArtist()
        {
            InitializeComponent();
            _artistService = new ArtistManeger(new EfArtistDal());
            _songService = new SongManeger(new EfSongDal());
            _albumService = new AlbumManeger(new EfAlbumDal());
        }
        private IArtistService _artistService;
        private IAlbumService _albumService;
        private ISongService _songService;
        private void frmArtist_Load(object sender, EventArgs e)
        {
            ;
            dgwArtists.DataSource = _artistService.GetAll();
            //dgwArtists.DataSource = _artistDal.GetAll();
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

            List<Song> songs = _songService.GetSongsByArtistId(artistId);

            foreach (Song song in songs)
            {
                _songService.Delete(song);
            }

            List<Album> albums = _albumService.GetAlbumsByArtistId(artistId);

            foreach (Album album in albums)
            {
                _albumService.Delete(album);
            }

            _artistService.Delete(new Artist
            {
                ArtistId = artistId
            });
            


            dgwArtists.DataSource = _artistService.GetAll();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmArtistUpdate frm = new frmArtistUpdate();
            frm.Show();
            this.Hide();
        }
    }
}
