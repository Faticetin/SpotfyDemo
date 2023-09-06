using Business.Abstract;
using Business.Concrete;
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
    public partial class frmAlbum : Form
    {
        //AlbumDal _albumDal = new AlbumDal();
        //SongDal _songDal = new SongDal();
        public frmAlbum()
        {
            InitializeComponent();
            _albumservice = new AlbumManeger(new EfAlbumDal());
        }
        private IAlbumService _albumservice;
        private void songsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSong frm = new frmSong();
            frm.Show();
            this.Hide();
        }

        private void frmAlbum_Load(object sender, EventArgs e)
        {
            dgwAlbums.DataSource = _albumservice.GetAll();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmAlbumAdd frm = new frmAlbumAdd();
            frm.Show();
            this.Hide();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _albumservice.Delete(new Album
            {
                AlbumId = Convert.ToInt32(dgwAlbums.CurrentRow.Cells[0].Value)
            });

            dgwAlbums.DataSource = _albumservice.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmAlbumUpdate frm = new frmAlbumUpdate();
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
