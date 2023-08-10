using SpotifyDemo.DataServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyDemo
{
    internal class AlbumDal : BaseDal
    {
        public List<Album> GetAll()
        {
            SqlCommand command = new SqlCommand("select * from Albums", _connection);
            ConnectionControl();

            SqlDataReader reader = command.ExecuteReader();

            List<Album> albums = new List<Album>();

            while (reader.Read())
            {
                Album album = new Album
                {
                    AlbumId = Convert.ToInt32(reader["AlbumId"]),
                    ArtistId = Convert.ToInt32(reader["ArtistId"]),
                    Name = reader["Name"].ToString(),
                    ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"])
                };
                albums.Add(album);
            }

            reader.Close();
            _connection.Close();
            return albums;
        }

        public List<Album> GetByArtistId(int selectedArtistId)
        {
            SqlCommand command = new SqlCommand("select * from Albums where ArtistId = @artistıd", _connection);
            command.Parameters.AddWithValue("@artistıd", selectedArtistId);
            ConnectionControl();

            SqlDataReader reader = command.ExecuteReader();

            List<Album> albums = new List<Album>();

            while (reader.Read())
            {
                Album album = new Album
                {
                    AlbumId = Convert.ToInt32(reader["AlbumId"]),
                    ArtistId = Convert.ToInt32(reader["ArtistId"]),
                    Name = reader["Name"].ToString(),
                    ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"])
                };
                albums.Add(album);
            }
            reader.Close();
            _connection.Close();
            return albums;
        }

        public void Add(Album album)
        {
            SqlCommand command = new SqlCommand("insert into Albums (ArtistId,Name,ReleaseDate) values (@artistId,@name,@releaseDate)", _connection);
            ConnectionControl();

            command.Parameters.AddWithValue("@artistId", album.ArtistId);
            command.Parameters.AddWithValue("@name", album.Name);
            command.Parameters.AddWithValue("@releaseDate", album.ReleaseDate);

            command.ExecuteNonQuery();
        }


        public List<AlbumDataList> GetDataList()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("select a.AlbumId, ar.Name as ArtistName, a.Name as AlbumName, a.ReleaseDate from Albums a inner join Artists ar on a.ArtistId=ar.ArtistId", _connection);

            SqlDataReader reader = command.ExecuteReader();

            List<AlbumDataList> albumDataLists = new List<AlbumDataList>();



            while (reader.Read())
            {
                AlbumDataList albumDataList = new AlbumDataList
                {
                    AlbumId = Convert.ToInt32(reader["AlbumId"]),
                    Name = reader["AlbumName"].ToString(),
                    ArtistName = reader["ArtistName"].ToString(),
                    ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"])

                };
                albumDataLists.Add(albumDataList);
            }

            reader.Close();
            _connection.Close();
            return albumDataLists;
        }

        public void RemoveByAlbumId(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("delete from Albums where ArtistID=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void Remove(int id)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("delete from Albums where AlbumId=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void Update(Album album)
        {
            SqlCommand command = new SqlCommand("Update Albums set ArtistId=@artistid,Name=@name,ReleaseDate=@releasedate where AlbumId=@albumid", _connection);
            ConnectionControl();

            command.Parameters.AddWithValue("@artistid", album.ArtistId);
            command.Parameters.AddWithValue("@name", album.Name);
            command.Parameters.AddWithValue("@releaseDate", album.ReleaseDate);
            command.Parameters.AddWithValue("@albumid", album.AlbumId);

            command.ExecuteNonQuery();

        }

        public Album GetById(int albumid)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("select * from Albums where AlbumId=@albumid", _connection);
            command.Parameters.AddWithValue("@albumid", albumid);
            SqlDataReader reader = command.ExecuteReader();

            Album album = new Album();

            while (reader.Read())
            {

                album.AlbumId = Convert.ToInt32(reader["ALbumId"]);
                album.ArtistId = Convert.ToInt32(reader["ArtistId"]);
                album.Name = reader["Name"].ToString();
                album.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
            }

            reader.Close();
            _connection.Close();
            return album;
        }





    }
}
