using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.DAL;
using DataBase.DATA.Models;

namespace DataBase
{
    internal class Manager
    {
      public  Menu menu = new Menu();


        public void start()
        {


            
            //People_DAL pp = new People_DAL();
            //Console.WriteLine();
            //Console.WriteLine( pp.CheckIfExistBySecret_code("chagay"));
            //IntelReport rr = new IntelReport.Builder().SetId(12).Build();
            //Console.WriteLine(rr.Id);

            //pp.CheckIfExistByName("eu", "232");
            menu.ShowMainMune();

            
        }
       

    }
}
