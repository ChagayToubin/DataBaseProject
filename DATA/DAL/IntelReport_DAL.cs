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
        public void CreateNewIntel(Person reporter, Person target,string text)
        {
            Connection.Open(Connect);
            var conn = Connect;//יצרr את החיבור

            

            var quary = $"INSERT INTO intelreports ( reporter_id,target_id,text )" +
                   $"VALUES ('{reporter.Id}', '{target.Id}', '{text}')";
            new MySqlCommand(quary, conn).ExecuteNonQuery();
            


           
        }
        public void FindAllReportsBySecretcid()
        {

        }


    }
}
