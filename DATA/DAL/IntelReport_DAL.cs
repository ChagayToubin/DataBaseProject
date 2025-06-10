using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.Databace;
using DataBase.DATA.Models;
using MySql.Data.MySqlClient;

namespace DataBase.DATA.DAL
{

    public class IntelReport_DAL

    {

        MySqlConnection Connect = Connection.InitConnection();
        People_DAL people = new People_DAL();
        public void CreateNewIntel(Person reporter, Person target, string text)
        {
            Connection.Open(Connect);
            var conn = Connect;//יצרr את החיבור



            var quary = $"INSERT INTO intelreports ( reporter_id,target_id,text )" +
                   $"VALUES ('{reporter.Id}', '{target.Id}', '{text}')";
            new MySqlCommand(quary, conn).ExecuteNonQuery();

        }
        public List<IntelReport> FindAllReportsByID(int IDSerch,string signh)
        {
            List<IntelReport> ListIntel = new List<IntelReport>();
            Connection.Open(Connect);
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                if (signh == "t")
                {
                    cmd = new MySqlCommand($"SELECT * FROM intelreports where target_id={IDSerch} ORDER BY `timestamp` DESC ", Connect);
                }
                else
                {
                    cmd = new MySqlCommand($"SELECT * FROM intelreports where reporter_id={IDSerch} ORDER BY `timestamp` DESC ", Connect);
                }


                    reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    int reporterId = reader.GetInt32("reporter_id");
                    int targetId = reader.GetInt32("target_id");
                    string text = reader.GetString("text");
                    DateTime time = reader.GetDateTime("timestamp");
                    IntelReport intel = new IntelReport.Builder()
                        .SetId(id)
                        .SetReporterId(reporterId)
                        .SetTargetId(targetId)
                        .SetText(text)
                        .SetTimestamp(time)
                        .Build();
                    ListIntel.Add(intel);
                   



                }
                return ListIntel;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
                
            }
            finally
            {
                Connection.Close(Connect);

            }

        }
    }
}
