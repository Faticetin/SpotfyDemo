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

namespace SpotifyDemo.Forms
{
    public partial class frmSongUpdate : Form
    {

        public frmSongUpdate()
        {
            InitializeComponent();
            _albumService = new AlbumManeger(new EfAlbumDal());
            _artistService = new ArtistManeger(new EfArtistDal());
            _songService = new SongManeger(new EfSongDal());
        }

        private ISongService _songService;
        private IArtistService _artistService;
        private IAlbumService _albumService;
        private void frmSongUpdate_Load(object sender, EventArgs e)
        {
            dgwSongs.DataSource = _songService.GetAll();

            cmbAlbum.DataSource = _albumService.GetAll();
            cmbAlbum.DisplayMember = "Name";
            cmbAlbum.ValueMember = "AlbumId";
            cmbAlbum.SelectedIndex = -1;

            cmbArtist.DataSource = _artistService.GetAll();
            cmbArtist.DisplayMember = "Name";
            cmbArtist.ValueMember = "ArtistId";
            cmbArtist.SelectedIndex = -1;
        }

        private void dgwSongs_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var row = dgwSongs.CurrentRow;
            txtSong.Text = row.Cells[3].Value.ToString();
            cmbAlbum.SelectedValue = row.Cells[1].Value;
            cmbArtist.SelectedValue = row.Cells[2].Value;
            dtpReleaseDate.Value = Convert.ToDateTime(dgwSongs.CurrentRow.Cells[4].Value);


            //Song song = _songDal.GetById(songId);


            //cmbArtist.SelectedValue = song.ArtistId;


            //cmbAlbum.DisplayMember = "Name";
            //cmbAlbum.ValueMember = "AlbumId";
            //cmbAlbum.DataSource = _albumDal.GetByArtistId(song.ArtistId);

            //cmbAlbum.SelectedValue = song.AlbumId;

            //txtSong.Text = song.Name;
            //dtpReleaseDate.Value = song.ReleaseDate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Artist selectedArtist = (Artist)cmbArtist.SelectedItem;
            Album selectedAlbum = (Album)cmbAlbum.SelectedItem;

            _songService.Update(new Song
            {
                SongId = Convert.ToInt32(dgwSongs.CurrentRow.Cells[0].Value),
                Name = txtSong.Text,
                AlbumId = selectedAlbum.AlbumId,
                ArtistId = selectedArtist.ArtistId,
                ReleaseDate = Convert.ToDateTime(dgwSongs.CurrentRow.Cells[4].Value)
            });
            MessageBox.Show("Müzik Güncellendi");

            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }

        private void cmbArtist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }
    }
}
