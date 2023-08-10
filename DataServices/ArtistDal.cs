using SpotifyDemo.DataServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyDemo
{
    internal class ArtistDal : BaseDal
    {
        public List<Artist> GetAll()
        {
            SqlCommand command = new SqlCommand("select * from Artists", _connection);
            ConnectionControl();

            SqlDataReader reader = command.ExecuteReader();

            List<Artist> artists = new List<Artist>();

            while (reader.Read())
            {
                Artist artist = new Artist
                {
                    ArtistId = Convert.ToInt32(reader["ArtistId"]),
                    Name = reader["Name"].ToString(),
                    Country = reader["Country"].ToString(),

                };
                artists.Add(artist);
            }

            reader.Close();
            _connection.Close();
            return artists;
        }


        public void Add(Artist artist)
        {
            SqlCommand command = new SqlCommand("insert into Artists (Name,Country) values (@name,@country)", _connection);
            ConnectionControl();

            command.Parameters.AddWithValue("@name", artist.Name);
            command.Parameters.AddWithValue("@country", artist.Country);

            command.ExecuteNonQuery();
        }

        public void Remove(int id)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("delete from Artists where ArtistId=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void Update(Artist artist)
        {
            SqlCommand command = new SqlCommand("Update Artists set Name=@name,Country=@country where ArtistId=@artistid", _connection);
            ConnectionControl();

            command.Parameters.AddWithValue("@artistid", artist.ArtistId);
            command.Parameters.AddWithValue("@name", artist.Name);
            command.Parameters.AddWithValue("@country", artist.Country);

            command.ExecuteNonQuery();

        }

        public Artist GetById(int artistid)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("select * from Artists where ArtistId=@artistid", _connection);
            command.Parameters.AddWithValue("@artistid", artistid);
            SqlDataReader reader = command.ExecuteReader();

            Artist artist = new Artist();

            while (reader.Read())
            {

                artist.ArtistId = Convert.ToInt32(reader["ArtistId"]);
                artist.Name = reader["Name"].ToString();
                artist.Country = reader["Country"].ToString();
            }

            reader.Close();
            _connection.Close();
            return artist;
        }

    }


}
