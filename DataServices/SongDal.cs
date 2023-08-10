using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyDemo.DataServices;

namespace SpotifyDemo
{
    internal class SongDal : BaseDal
    {
        public List<Song> GetAll()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("select * from Songs", _connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Song> songs = new List<Song>();



            while (reader.Read())
            {
                Song song = new Song
                {
                    SongId = Convert.ToInt32(reader["SongId"]),
                    AlbumId = Convert.ToInt32(reader["ALbumId"]),
                    ArtistId = Convert.ToInt32(reader["ArtistId"]),
                    Name = reader["Name"].ToString(),
                    ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"])

                };
                songs.Add(song);
            }

            reader.Close();
            _connection.Close();
            return songs;
        }

        public void Add(Song song)
        {
            SqlCommand command = new SqlCommand("insert into Songs (AlbumId,ArtistId,Name,ReleaseDate) values (@albumId,@artistId,@name,@releaseDate)", _connection);
            ConnectionControl();

            command.Parameters.AddWithValue("@albumId", song.AlbumId);
            command.Parameters.AddWithValue("@artistId", song.ArtistId);
            command.Parameters.AddWithValue("@name", song.Name);
            command.Parameters.AddWithValue("@releaseDate", song.ReleaseDate);

            command.ExecuteNonQuery();

        }

        public List<SongDataList> GetDataList()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("select s.SongId, a.Name as AlbumName, ar.Name as ArtistName, s.Name as SongName, s.ReleaseDate from Songs s inner join Albums a on s.AlbumId = a.AlbumId inner join Artists ar on a.ArtistId=ar.ArtistId", _connection);

            SqlDataReader reader = command.ExecuteReader();

            List<SongDataList> songDataLists = new List<SongDataList>();



            while (reader.Read())
            {
                SongDataList songDataList = new SongDataList
                {
                    SongId = Convert.ToInt32(reader["SongId"]),
                    ALbumName = reader["AlbumName"].ToString(),
                    ArtistName = reader["ArtistName"].ToString(),
                    SongName = reader["SongName"].ToString(),
                    ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"])

                };
                songDataLists.Add(songDataList);
            }

            reader.Close();
            _connection.Close();
            return songDataLists;
        }


        public void RemoveSongByAlbumId(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("delete from Songs where AlbumId=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        public void RemoveSongByArtistId(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("delete from Songs where ArtistId=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }


        public void Remove(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("delete from Songs where SongId=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

        }

        public void Update(Song song)
        {
            SqlCommand command = new SqlCommand("Update Songs set AlbumId=@albumıd,ArtistId=@artistıd,Name=@name,ReleaseDate=@releasedate where SongId=@songid", _connection);
            ConnectionControl();

            command.Parameters.AddWithValue("@albumId", song.AlbumId);
            command.Parameters.AddWithValue("@artistId", song.ArtistId);
            command.Parameters.AddWithValue("@name", song.Name);
            command.Parameters.AddWithValue("@releaseDate", song.ReleaseDate);
            command.Parameters.AddWithValue("@songid", song.SongId);

            command.ExecuteNonQuery();

        }

        public Song GetById(int songId)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("select * from Songs where SongId=@songid", _connection);
            command.Parameters.AddWithValue("@songid", songId);
            SqlDataReader reader = command.ExecuteReader();

            Song song = new Song();

            while (reader.Read())
            {
                song.SongId = Convert.ToInt32(reader["SongId"]);
                song.AlbumId = Convert.ToInt32(reader["ALbumId"]);
                song.ArtistId = Convert.ToInt32(reader["ArtistId"]);
                song.Name = reader["Name"].ToString();
                song.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
            }

            reader.Close();
            _connection.Close();
            return song;
        }

    }
}
