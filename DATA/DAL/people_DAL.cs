using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.Databace;
using DataBase.DATA.Models;
using MySql.Data.MySqlClient;

namespace DataBase.DATA.DAL
{
    public class People_DAL
    {
        MySqlConnection Connect = Connection.openConnection();


        public bool CheckIfExistBySecret_code(string secret_code)
        {
            Connect.Open();
            var conn = Connect;//יצרr את החיבור

            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand($"SELECT * FROM People where secret_code='{secret_code}'", Connect);


                reader = cmd.ExecuteReader();
                return (reader.HasRows);
                


            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
                throw new Exception(ex.Message);

            }
        }
        public bool CheckIfExistByName(string FirstName,string LastName)
        {
            Connect.Open();
            var conn = Connect;//יצרr את החיבור
           
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand($"SELECT * FROM People where first_name='{FirstName}'and last_name={LastName}", Connect);
              

                reader = cmd.ExecuteReader();
                return (reader.HasRows);


            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
                throw new Exception(ex.Message);

            }
        }
        public void AddNewTarget()
        {

        }


    }
}
