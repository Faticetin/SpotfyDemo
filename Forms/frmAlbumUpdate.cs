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
    public partial class frmAlbumUpdate : Form
    {
        //AlbumDal _albumDal = new AlbumDal();
        //ArtistDal _artistDal = new ArtistDal();
        public frmAlbumUpdate()
        {
            InitializeComponent();
            _artistService = new ArtistManeger(new EfArtistDal());
            _albumService = new AlbumManeger(new EfAlbumDal());
        }
        private IArtistService _artistService;
        private IAlbumService _albumService;
        private void frmAlbumUpdate_Load(object sender, EventArgs e)
        {
            dgwAlbums.DataSource = _albumService.GetAll();

            cmbArtist.DataSource = _artistService.GetAll();
            cmbArtist.DisplayMember = "Name";
            cmbArtist.ValueMember = "ArtistId";
            cmbArtist.SelectedIndex = -1;
        }

        private void dgwAlbums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwAlbums.CurrentRow;
            cmbArtist.SelectedValue = row.Cells[1].Value;
            txtAlbum.Text = row.Cells[2].Value.ToString();
            dtpReleaseDate.Value = Convert.ToDateTime(dgwAlbums.CurrentRow.Cells[3].Value);


            //DataGridViewRow selectedRow = dgwAlbums.SelectedRows[0];
            //int albumId = Convert.ToInt32(selectedRow.Cells["AlbumId"].Value);


            //Album album = _albumDal.GetById(albumId);


            //cmbArtist.SelectedValue = album.ArtistId;

            //txtAlbum.Text = album.Name;
            //dtpReleaseDate.Value = album.ReleaseDate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Artist selectedArtist = (Artist)cmbArtist.SelectedItem;
            _albumService.Update(new Album
            {
                AlbumId = Convert.ToInt32(dgwAlbums.CurrentRow.Cells[0].Value),
                Name = txtAlbum.Text,
                ArtistId = selectedArtist.ArtistId,
                ReleaseDate = dtpReleaseDate.Value
            });
            MessageBox.Show("Album Güncellendi");




            //Artist selectedArtist = (Artist)cmbArtist.SelectedItem;


            //if (selectedArtist != null)
            //{
            //    Album album = new Album
            //    {
            //        AlbumId = Convert.ToInt32(dgwAlbums.CurrentRow.Cells[0].Value),
            //        Name = txtAlbum.Text,
            //        ArtistId = selectedArtist.ArtistId,
            //        ReleaseDate = Convert.ToDateTime(dgwAlbums.CurrentRow.Cells[3].Value)
            //    };
            //    _albumDal.Update(album);
            //    MessageBox.Show("Updated");
            //}
            //else
            //{
            //    MessageBox.Show("Please select an artist and an album.");
            //}

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
