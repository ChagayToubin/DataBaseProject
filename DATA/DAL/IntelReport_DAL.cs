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
            Console.WriteLine("enter your  secret code ");
            int  reporterID = people.GetIdBySecretcode();

            Console.WriteLine("Enter a report into the system ");
            string TextReport = Console.ReadLine();

            Console.WriteLine("enter your target secret code");
            int targetID = people.GetIdBySecretcode();

            if (targetID != -1)
            {
                //people.CreateNewTarget();
                Console.WriteLine();
            }

            string Target_secretcode = Console.ReadLine();
        }


    }
}
