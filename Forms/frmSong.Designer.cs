namespace SpotifyDemo
{
    partial class frmSong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.songsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.albumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgwSongs = new System.Windows.Forms.DataGridView();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSongs)).BeginInit();
            this.grpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songsToolStripMenuItem,
            this.albumsToolStripMenuItem,
            this.artistsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(917, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // songsToolStripMenuItem
            // 
            this.songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            this.songsToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.songsToolStripMenuItem.Text = "Songs";
            // 
            // albumsToolStripMenuItem
            // 
            this.albumsToolStripMenuItem.Name = "albumsToolStripMenuItem";
            this.albumsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.albumsToolStripMenuItem.Text = "Albums";
            this.albumsToolStripMenuItem.Click += new System.EventHandler(this.albumsToolStripMenuItem_Click);
            // 
            // artistsToolStripMenuItem
            // 
            this.artistsToolStripMenuItem.Name = "artistsToolStripMenuItem";
            this.artistsToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.artistsToolStripMenuItem.Text = "Artists";
            this.artistsToolStripMenuItem.Click += new System.EventHandler(this.artistsToolStripMenuItem_Click);
            // 
            // dgwSongs
            // 
            this.dgwSongs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSongs.Location = new System.Drawing.Point(12, 31);
            this.dgwSongs.Name = "dgwSongs";
            this.dgwSongs.RowHeadersWidth = 51;
            this.dgwSongs.RowTemplate.Height = 24;
            this.dgwSongs.Size = new System.Drawing.Size(856, 228);
            this.dgwSongs.TabIndex = 1;
            this.dgwSongs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwSongs_CellContentClick);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(71, 43);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(104, 45);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Add";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(457, 43);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 45);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnRemove);
            this.grpControl.Controls.Add(this.btnEkle);
            this.grpControl.Controls.Add(this.btnUpdate);
            this.grpControl.Location = new System.Drawing.Point(123, 283);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(617, 124);
            this.grpControl.TabIndex = 5;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Controls";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(260, 43);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 45);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 458);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.dgwSongs);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmSong";
            this.Text = "frmSong";
            this.Load += new System.EventHandler(this.frmSong_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSongs)).EndInit();
            this.grpControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem songsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem albumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artistsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgwSongs;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button btnRemove;
    }
}