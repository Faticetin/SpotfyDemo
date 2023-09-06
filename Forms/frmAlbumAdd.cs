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
    public partial class frmAlbumAdd : Form
    {
        //ArtistDal _artistDal = new ArtistDal();
        //AlbumDal _albumDal = new AlbumDal();
        public frmAlbumAdd()
        {
            InitializeComponent();
            _artistService = new ArtistManeger(new EfArtistDal());
            _albumService = new AlbumManeger(new EfAlbumDal());
        }
        private IArtistService _artistService;
        private IAlbumService _albumService;
        private void frmAlbumAdd_Load(object sender, EventArgs e)
        {
            cmbArtist.DataSource = _artistService.GetAll();
            cmbArtist.DisplayMember = "Name";
            cmbArtist.ValueMember = "ArtistId";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Artist selectedArtist = (Artist)cmbArtist.SelectedItem;
            _albumService.Add(new Album
            {
                Name = txtAlbum.Text,
                ArtistId = selectedArtist.ArtistId,
                ReleaseDate = dtpReleaseDate.Value
            });
            MessageBox.Show("Album Eklendi");



            //Artist selectedArtist = (Artist)cmbArtist.SelectedItem;

            //Album album = new Album
            //{
            //    ArtistId = selectedArtist.ArtistId,
            //    Name = txtAlbum.Text,
            //    ReleaseDate = dtpReleaseDate.Value
            //};

            //_albumDal.Add(album);
            //MessageBox.Show("Album Added");
            //frmAlbum frm = new frmAlbum();
            //frm.Show();
            //this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAlbum frm = new frmAlbum();
            frm.Show();
            this.Hide();
        }
    }
}
