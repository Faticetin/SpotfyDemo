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
        private void frmSong_Load(object sender, EventArgs e)
        {
            dgwSongs.DataSource = _songService.GetAll();
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
