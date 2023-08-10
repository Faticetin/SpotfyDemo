using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using SpotifyDemo.DataServices;

namespace SpotifyDemo
{
    internal class UserDal : BaseDal
    {
        public bool UserRegister(User user)
        {
            bool isEmailExist = false;
            ConnectionControl();
            SqlCommand command = new SqlCommand("select Email from Users where Email = @email", _connection);
            command.Parameters.AddWithValue("@email", user.Email);
            SqlDataReader reader = command.ExecuteReader();

            if (! reader.Read())
            {
                command = new SqlCommand("insert into Users values (@name, @surname, @email, @password)", _connection);

                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);

                reader.Close();
                command.ExecuteNonQuery();
                isEmailExist = true;
            }

            _connection.Close();
            return isEmailExist;
        }

        public bool UserLogin(string email, string password)
        {
            bool isLogin = false;
            ConnectionControl();
            SqlCommand command = new SqlCommand("select * from Users where Email = @email AND Password = @password", _connection);

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isLogin = true;
            }

            reader.Close();
            _connection.Close();

            return isLogin;
        }
    }
}
