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
    public partial class frmArtistAdd : Form
    {
        //ArtistDal _artistDal = new ArtistDal();
        public frmArtistAdd()
        {
            InitializeComponent();
            _artistService = new ArtistManeger(new EfArtistDal());
        }
        private IArtistService _artistService;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _artistService.Add(new Artist
            {
                Name = txtArtist.Text,
                Country = txtCountry.Text,
            });

            frmArtist frm = new frmArtist();
            frm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmArtist frm = new frmArtist();
            frm.Show();
            this.Hide();
        }

        private void frmArtistAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
