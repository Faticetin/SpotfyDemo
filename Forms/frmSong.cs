using Business.Abstract;
using Business.Concrete;
using Business.Concrete.EntityFramwork;
using DataAccess.Concrete;
using Entities.Concrete;
using SpotifyDemo.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyDemo
{

    public partial class frmSong : Form
    {
        //SongDal _songDal = new SongDal();
        public frmSong()
        {
            InitializeComponent();
            _songService = new SongManeger(new EfSongDal());
        }


        private ISongService _songService;
        SpotfyContext sp = new SpotfyContext();
        private void frmSong_Load(object sender, EventArgs e)
        {
            //var query = from song in sp.Songs
            //            join album in sp.Albums
            //            on song.AlbumId equals album.AlbumId
            //            join artis in sp.Artists
            //            on song.ArtistId equals artis.ArtistId
            //            select new
            //            {
            //                Album = album.Name,
            //                Artist = artis.Name,
            //                Song = song.Name,
            //                ReleaseDate = song.ReleaseDate
            //            };

            var query = sp.Songs
                .Join(
                    sp.Albums,
                    song => song.AlbumId,
                    album => album.AlbumId,
                    (song, album) => new
                    {
                        Song = song,
                        Album = album
                    }
                    )
                    .Join(sp.Artists,
                    combined => combined.Song.ArtistId,
                    artist => artist.ArtistId,
                    (combined, artist) => new
                    {
                        Song = combined.Song,
                        Album = combined.Album,
                        Artist = artist
                    }
                    )
                    .Select(result => new
                    {
                        Album = result.Album.Name,
                        Artist = result.Artist.Name,
                        Song = result.Song.Name,
                        ReleaseDate = result.Song.ReleaseDate
                    });



            dgwSongs.DataSource = query.ToList();
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
            _songService.Delete(new Song
            {
                SongId = Convert.ToInt32(dgwSongs.CurrentRow.Cells[0].Value)
            });

            dgwSongs.DataSource = _songService.GetAll();
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

        private void dgwSongs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
