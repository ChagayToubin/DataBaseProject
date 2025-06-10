using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.Databace;
using DataBase.DATA.Models;
using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace DataBase.DATA.DAL
{
    public class People_DAL
    {
        MySqlConnection Connect = Connection.InitConnection();

        public void CreatPerson(string firstName, string lastName, string secretCode, string type)
        {
            try
            {
                Connection.Open(Connect);
                var conn = Connect;

                var quary = $"INSERT INTO People (first_name, last_name, secret_code, type, num_reports, num_mentions)" +
                    $"VALUES ('{firstName}', '{lastName}', '{secretCode}', '{type}', 0, 0)";
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

        public bool CheckIfExistBySecretCode(string secret_code)
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
                return false;

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
        public Person GetPersonBySecretcode(string secretcode)
        {
            Connection.Open(Connect);
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand($"SELECT * FROM people where secret_code='{secretcode}' ", Connect);


                reader = cmd.ExecuteReader();
                reader.Read();

                int ID = reader.GetInt32("id");
                string firstName = reader.GetString("first_name");
                string lastName = reader.GetString("last_name");
                string secreCode = reader.GetString("secret_code");
                string type = reader.GetString("type");
                int namReport = reader.GetInt32("num_reports");
                int numMentions = reader.GetInt32("num_mentions");


                Person a = new Person.Builder().SetFirstName(firstName)
                .SetId(ID)
                    .SetLastName(lastName)
                    .SetSecretCode(secreCode)
                    .SetType(type)
                    .SetNumReports(namReport)
                    .SetNumMentions(numMentions)
                    .Build();


                return a;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("dont found");
                return null;

            }
            finally
            {
                Connection.Close(Connect);

            }
        }
        public void UpdatePersonReportsOrMention(Person person, string sighn)
        {

            try
            {
                Connection.Open(Connect);
                var conn = Connect;
                if (sighn == "r")
                {
                    var quary = $"UPDATE people SET num_reports = {person.NumReports + 1} WHERE id={person.Id}";
                    new MySqlCommand(quary, conn).ExecuteNonQuery();
                }
                else
                {
                    var quary = $"UPDATE people SET num_mentions = {person.NumMentions + 1} WHERE id={person.Id}";
                    new MySqlCommand(quary, conn).ExecuteNonQuery();

                }

                

            }
            catch (Exception ex)
            {
                //Console.WriteLine("!@#$%^&*(*&^%$#@");
                Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                Connection.Close(Connect);

            }

        }

        public void UpdatePersonType(int personId, string newtype)
        {
            try
            {
                Connection.Open(Connect);
                var conn = Connect;

                {
                    var quary = $"UPDATE people SET type = '{newtype}' WHERE id={personId}";
                    new MySqlCommand(quary, conn).ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

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
/*  public void CreateNewReporter(string firstname, string lastname, string randomSecretCode)
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
        }\\
*\/8/*/