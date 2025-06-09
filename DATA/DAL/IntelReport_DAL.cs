using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.Databace;
using MySql.Data.MySqlClient;

namespace DataBase.DATA.DAL
{
    internal class IntelReport_DAL
    {
        MySqlConnection Connect = Connection.openConnection();
    }
}
