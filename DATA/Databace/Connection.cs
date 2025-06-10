using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;

namespace DataBase.DATA.Databace
{
    public static class Connection
    {
        public static MySqlConnection InitConnection()
        {
            string connStr = "Server=localhost;Database=projectdb;User=root;Password=;Port=3306;";
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connStr);
               
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }




            return conn;
        }
        public static void Open(MySqlConnection conn)
        {
            conn.Open();
        }
        public static void Close(MySqlConnection conn)
        {
            conn.Close();
        }
    }
}
