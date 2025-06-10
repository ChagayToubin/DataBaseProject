using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.DAL;
using DataBase.DATA.Databace;
using DataBase.DATA.Models;
using Microsoft.VisualBasic;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;

namespace DataBase
{
    public class Menu
    {
        public static People_DAL people_method = new People_DAL();
        public static IntelReport_DAL intel_report = new IntelReport_DAL();
        public void ShowMainMune()
        {
            Console.WriteLine("wellcome entere 1 for entere to the system" +
                "enter 2 to create new reorter " +
                "enter 3 to see all the intel");



            switch (Console.ReadLine())//להסויף ןלידציה
            {
                case "1"://נכנס לפונקציה חמטרת הזדהות כל עוד לא הצליח להיכנס לא יוכל להמשיך הלאה


                    if (!(EnterCheck())) //אם  קיבל אישור כניסה
                    {
                        Console.WriteLine("Dont found the name .\n lets creat new");

                        CreateNewReporterM();
                        

                    }
                    
                    Console.WriteLine("Secure connection created!!!!");

                    CreateNewIntelM();
                    break;

                case "2":
                    CreateNewReporterM();


                    break;
                case "3":
                    FindAllReportsByIDM();

                    break;



                default:
                    Console.WriteLine("Please enter a valid value or 'q' to exit the system.");
                    ShowMainMune();
                    break;

            }

        }
        public bool EnterCheck()
        {
            bool checkName = false;
            bool checkSecretsode = false;


            Console.WriteLine("Identification system Click 1 to identify yourself using your name\n" +
                " 2 for identify yourself using your a secret code");
            switch (Console.ReadLine())
            {

                case "1":

                    Console.WriteLine("enter your first name");
                    string firstname = Console.ReadLine();

                    Console.WriteLine("enter your last name");
                    string lastname = Console.ReadLine();

                    checkName = people_method.CheckIfExistByName(firstname, lastname);

                    break;
                case "2":
                    Console.WriteLine("enter your secret code");
                    string secretCode = Console.ReadLine();

                    checkSecretsode = people_method.CheckIfExistBySecretCode(secretCode);

                    break;
                default:
                    Console.WriteLine("please enter only 1 or 2");
                    EnterCheck();
                    break;
            }
            return checkSecretsode || checkName;//גישה אושרה אחד מהנתונים תקין

        }
        public void CreateNewReporterM()
        {
            Console.WriteLine("Lets create new Repoerter");
            Console.WriteLine("enter your first name");
            string firstname = Console.ReadLine();
            Console.WriteLine("enter your last name");
            string lastname = Console.ReadLine();
            string randomSecretCode = RandomSecretCode();

            people_method.CreatPerson(firstname, lastname, randomSecretCode, "reporter");

        }
        public void CreateNewTargetM()
        {

            Console.WriteLine("enter his first name");
            string firstname = Console.ReadLine();

            Console.WriteLine("enter his last name");
            string lastname = Console.ReadLine();

            string randomSecretCode = RandomSecretCode();
            people_method.CreatPerson(firstname, lastname, randomSecretCode, "target");
        }
        public void CreateNewIntelM()
        {
            int targetId;
            Console.WriteLine("enter your target secret code");
            string secretcodeTar = Console.ReadLine();

            Person target1 = people_method.GetPersonBySecretcode(secretcodeTar);
            Person target2;
            if (target1 == null)
            {
                Console.WriteLine("secret code desent exisit letes create new taarget ");
                CreateNewTargetM();

                Console.WriteLine("enter target secret code ");
                secretcodeTar = Console.ReadLine();

                target2 = people_method.GetPersonBySecretcode(secretcodeTar);

                target1 = target2;

            }


            Console.WriteLine("reporter pleas enter your secret code");
            string secretCodeRep = Console.ReadLine();

            Person reporter = people_method.GetPersonBySecretcode(secretCodeRep);
           
            Console.WriteLine("enter yout informtion");

            string TextReport = Console.ReadLine();


            Console.WriteLine("---------------");
            people_method.UpdatePersonReportsOrMention(reporter,"r");
            people_method.UpdatePersonReportsOrMention(target1,"t");

            CheckUpdateType(reporter,target1);
           
       
            intel_report.CreateNewIntel(reporter, target1, TextReport);
        }
        public void FindAllReportsByIDM()
        {
            Console.WriteLine("Press 'r' to check reporter or 't' to check target");
            string sign = Console.ReadLine();

            Console.WriteLine("Who do want to see enter id ");
            int IDSerch = int.Parse(Console.ReadLine());


            var reports =intel_report.FindAllReportsByID(IDSerch, sign);
            foreach(var report in reports)
            {
                report.PrintReport();
            }
        }
        public void checkAlret(Person reporrter, Person target)//בדיקה של התראות
        {


        }
        public void CheckUpdateType(Person reporter, Person target)//שינוי של טייפ אם צריך בבן אדם
        {

            checkUpdatereporter(reporter);
            checkUpdateTarget(target);
        }
        public void checkUpdatereporter(Person reporter)
        {

            
            int numberReporterReport = reporter.NumReports + 1;//add 1 beacuse the new intel
            double avgTextLength = AverageOfText();
            if (numberReporterReport > 1 || avgTextLength > 100)
            {
               
                people_method.UpdatePersonType(reporter.Id, "potential_agent");
            }
            double AverageOfText()
            {
                int sum = 0;
                List<IntelReport> list = intel_report.FindAllReportsByID(reporter.Id, "r");
                foreach (var report in list)
                {
                    sum += report.Text.Replace(" ","").Length;
                }
                return sum / list.Count;
            }

        }
       
        public void checkUpdateTarget(Person target)
        {
            List<IntelReport> list = intel_report.FindAllReportsByID(target.Id, "t");

            int numOfMention = list.Count;
            bool timMention = findTimeRisk();
            if (numOfMention >= 20 ||timMention)
            {
               //להפעיל התראה 
            }
            
            bool findTimeRisk()
            {
               
                if (list.Count >= 3) {
                    bool b = false;
                    
                    TimeSpan timeCheck = list[0].Timestamp - list[2].Timestamp;
                    return timeCheck.TotalMinutes <= 15;
                }

                return false;
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

        public static void PrintRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }
}
