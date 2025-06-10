using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.Databace;
using MySql.Data.MySqlClient;

namespace DataBase.DATA.DAL
{
    
    public class IntelReport_DAL

    {

        
        MySqlConnection Connect = Connection.InitConnection();
        People_DAL people = new People_DAL();
        public void CreateNewIntel()
        {

            if (targetID != -1)
            {
                //people.CreateNewTarget();
                Console.WriteLine();
            }

            string Target_secretcode = Console.ReadLine();
        }


    }
}
