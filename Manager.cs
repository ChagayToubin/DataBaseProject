using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
      public static People_DAL people_method = new People_DAL();
        public static IntelReport_DAL intel_report = new IntelReport_DAL();




        public void start()
        {



            //People_DAL pp = new People_DAL();
            //Console.WriteLine();
            //Console.WriteLine( pp.CheckIfExistBySecret_code("chagay"));
            //IntelReport rr = new IntelReport.Builder().SetId(12).Build();
            //Console.WriteLine(rr.Id);

            //pp.CheckIfExistByName("eu", "232");
            //menu.SowAllData();
           
            menu.ShowMainMune();
            //var d = intel_report.FindAllReportsByID(13, "r");

            //foreach (var report in d)
            //{
            //    Console.WriteLine($"ID: {report.Id}, Reporter: {report.ReporterId}, Target: {report.TargetId}, Text: \"{report.Text}\", Time: {report.Timestamp:yyyy-MM-dd HH:mm:ss}");
            //}


            //people_method.CreateNewReporter();
            //people_method.GetIdBySecretcode();
            //intel_report.CreateNewIntel();
            //Person a = people_method.GetPersonBySecretcode("A129873");

            //people_method.UpdatePerson(a, "r");


        }



    }
}
