using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyDemo.DataServices
{
    internal class BaseDal
    {
        protected SqlConnection _connection = new SqlConnection("Data Source=DESKTOP-RH6TJ0Q\\SQLEXPRESS;Initial Catalog=SpotfyDB;Integrated Security=True");

        protected void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
