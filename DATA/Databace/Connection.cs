using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataBase.DATA.Databace
{
    public static class Connection
    {
        public static MySqlConnection openConnection()
        {
            string connStr = "Server=localhost;Database=projectdb;User=root;Password=;Port=3306;";
            MySqlConnection _conn;
            try
            {
                _conn = new MySqlConnection(connStr);
               
                Console.WriteLine("Connection successful");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }




            return _conn;
        }
    }
}
