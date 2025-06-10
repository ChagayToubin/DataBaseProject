using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.Databace;
using DataBase.DATA.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace DataBase.DATA.DAL
{
    public class People_DAL
    {
        MySqlConnection Connect = Connection.InitConnection();


        public bool CheckIfExistBySecret_code(string secret_code)
        {
            Connection.Open(Connect);
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
            finally
            {
                Connection.Close(Connect);
            }
        }
        public bool CheckIfExistByName(string FirstName, string LastName)
        {
            Connection.Open(Connect);
            var conn = Connect;//יצרr את החיבור

            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand($"SELECT * FROM People where first_name='" +
                    $"{FirstName}'and last_name={LastName}", Connect);

                reader = cmd.ExecuteReader();

                return (reader.HasRows);


            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
               
                return false;

            }
            finally
            {
                Connection.Close(Connect);
            }

        }
        public void CreateNewReporter(string firstname, string lastname, string randomSecretCode)
        {
            try
            {
                Connection.Open(Connect);
                var conn = Connect;

                var quary = $"INSERT INTO People (first_name, last_name, secret_code, type, num_reports, num_mentions)" +
                    $"VALUES ('{firstname}', '{lastname}', '{randomSecretCode}', 'reporter', 0, 0)";
                new MySqlCommand(quary, conn).ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
                throw new Exception(ex.Message);

            }
            finally
            {
                Connection.Close(Connect);
            }
        }
        public void CreateNewTarget(string firstname, string lastname, string randomSecretCode)
        {
            try
            {
                Connection.Open(Connect);
                var conn = Connect;
                Console.WriteLine("enter his first name");
              

                Console.WriteLine("enter his last name");
               

                var quary = $"INSERT INTO People (first_name, last_name, secret_code, type, num_reports, num_mentions)" +
                    $"VALUES ('{firstname}', '{lastname}', '{randomSecretCode}', 'target', 0, 0)";
                new MySqlCommand(quary, conn).ExecuteNonQuery();

                Connect.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
                throw new Exception(ex.Message);

            }
            finally
            {
                Connection.Close(Connect);
            }
        }

        public int GetIdBySecretcode()
        {
            Connection.Open(Connect);
            var conn = Connect;//יצרr את החיבור

            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {


                string secretCode = Console.ReadLine();

                cmd = new MySqlCommand($"SELECT id FROM people WHERE secret_code='{secretCode}'", conn);
                reader = cmd.ExecuteReader();

                int id = -1;

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                    Console.WriteLine(id);
                }
                else
                {
                    Console.WriteLine("No match found try again");
                    GetIdBySecretcode();

                }

                return id;

            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
                Console.WriteLine("Error: " + ex.Message);
                return -1;

            }
            finally
            {
                Connection.Close(Connect);

            }
        }





        public string RandomSecretCode()
        {
            Random rnd = new Random();
            string random = "QWERTYUIOP[]ASDFGHJKL;'ZXCVBNM,./zxcvbnmasdfghjkl;'qwertyuiop!@#$%^&*()_+";
            string RandomleCode = "";
            for (int i = 0; i < 5; i++)
            {

                RandomleCode += random[rnd.Next(0, random.Length)];
            }
            return RandomleCode;
        }



    }
}
