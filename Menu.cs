﻿using System;
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
            bool flag = true;
            Person MainReporter, MainTarget;



            if (!(EnterCheck())) //אם  קיבל אישור כניסה
            {
                Console.WriteLine("Dont found the name .\n lets creat new");

                MainReporter = CreateNewReporterM();

            }
            else
            {
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("The secure connection almost done  to make sure its u pleas enter your secret code again ");
                string secret = Console.ReadLine();
                MainReporter = people_method.GetPersonBySecretcode(secret);
                if (MainReporter == null)
                {
                    Console.WriteLine("dont found ");
                    ShowMainMune();
                }
                Console.WriteLine(MainReporter.Id);
            }



            Console.WriteLine("The secure connection was successful.");
            while (flag)
            {
                Console.WriteLine(" " +
                    "If u forgot your secret code press 2 \n " +
                    "To create intel reports prees 3\n " +
                    "To show intel reports press 4\n" +
                    "Log out of the system Press 9");
                switch (Console.ReadLine())
                {

                    case "2":
                        {
                            string secret = GetSecretCodeBynameM();
                        }
                        break;
                    case "3":
                        {
                            CreateNewIntelM(MainReporter);
                        }
                        break;
                    case "4":
                        {
                            SowAllData();

                        }
                        //יצירה של פונקציה שמראה לנו מה שורצה
                        break;
                    case "9":
                        {
                            flag = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid value or 'q' to exit the system.");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        break;
                }

            }
        }







        public bool EnterCheck()
        {

            bool checkSecretsode = false;


            Console.WriteLine("Identification system \n" +
                "To identify yourself using your  secret code");

            Console.WriteLine("enter your secret code");
            string secretCode = Console.ReadLine();

            checkSecretsode = people_method.CheckIfExistBySecretCode(secretCode);


            return checkSecretsode;

        }
        public Person CreateNewReporterM()//2
        {
            Console.WriteLine("Lets create new Repoerter");
            Console.WriteLine("enter your first name");
            string firstname = Console.ReadLine();
            Console.WriteLine("enter your last name");
            string lastname = Console.ReadLine();

            string randomSecretCode1 = RandomSecretCode();


            Console.WriteLine("--------------\n");
            Console.WriteLine("Created successfully \n These are your details, keep them safe");
            Console.WriteLine($"FirstName: {firstname}\n LastName: {lastname}\n SecretCode: {randomSecretCode1}\n Type: reporter");
            Console.WriteLine("--------------\n");



            return people_method.CreatPerson(firstname, lastname, randomSecretCode1, "reporter");



        }
        public Person CreateNewTargetM()//3
        {

            Console.WriteLine("enter his first name");
            string firstname = Console.ReadLine();

            Console.WriteLine("enter his last name");
            string lastname = Console.ReadLine();

            string randomSecretCode = RandomSecretCode();


            Console.WriteLine("--------------\n");
            Console.WriteLine("Created successfully \n These are your details, keep them safe");
            Console.WriteLine($"FirstName: {firstname}\n LastName: {lastname}\n SecretCode: {randomSecretCode}\n Type: target");
            Console.WriteLine("--------------\n");

            return people_method.CreatPerson(firstname, lastname, randomSecretCode, "target");
        }
        public void CreateNewIntelM(Person Mainreporter)//4
        {


            Console.WriteLine("enter your target secret code");
            string secretcodeTar = Console.ReadLine();

            Person target = people_method.GetPersonBySecretcode(secretcodeTar);

            if (target == null)
            {
                Console.WriteLine("secret code desent exisit letes create new taarget ");
                target = CreateNewTargetM();



            }


            Console.WriteLine("enter yout informtion");

            string TextReport = Console.ReadLine();



            people_method.UpdatePersonReportsOrMention(Mainreporter, "r");
            people_method.UpdatePersonReportsOrMention(target, "t");

            CheckUpdateType(Mainreporter, target, TextReport);


            intel_report.CreateNewIntel(Mainreporter, target, TextReport);
        }
        public void FindAllReportsByIDM()//5
        {
            Console.WriteLine("Press 'r' to check reporter or 't' to check target");
            string sign = Console.ReadLine();

            Console.WriteLine("Who do want to see enter id ");
            int IDSerch = int.Parse(Console.ReadLine());


            var reports = intel_report.FindAllReportsByID(IDSerch, sign);
            foreach (var report in reports)
            {
                report.PrintReport();
            }
        }

        public void CheckUpdateType(Person reporter, Person target, string textreport)//6
        {
            if (reporter.Id == target.Id)
            {
                people_method.UpdatePersonType(reporter.Id, "both", "type");

                people_method.UpdatePersonReportsOrMention(reporter, "r");
                people_method.UpdatePersonReportsOrMention(target, "t");

            }
            else
            {
                checkUpdatereporter(reporter, textreport);
                checkUpdateTarget(target);
            }

        }
        public void checkUpdatereporter(Person reporter, string txt)
        {


            int numberReporterReport = reporter.NumReports + 1;//add 1 beacuse the new intel
            double avgTextLength = AverageOfText();
            if (numberReporterReport > 1 || avgTextLength > 100)
            {

                people_method.UpdatePersonType(reporter.Id, "potential_agent", "type");
            }
            double AverageOfText()
            {
                int sum = 0;
                List<IntelReport> list = intel_report.FindAllReportsByID(reporter.Id, "r");
                foreach (var report in list)
                {
                    sum += report.Text.Replace(" ", "").Length;
                }
                sum += txt.Length;


                return sum / (list.Count + 1);
            }

        }//7

        public void checkUpdateTarget(Person target)//8
        {
            List<IntelReport> list = intel_report.FindAllReportsByID(target.Id, "t");

            int numOfMention = list.Count;
            bool timMention = findTimeRisk();
            if (numOfMention >= 20 || timMention)
            {
                //להפעיל התאה 
                PrintRed($"{target.FirstName} - {target.LastName}  vary danger");
                //לעדכן עכשיו אותו למסוכן
                people_method.UpdatePersonType(target.Id, "danger", "type_danger");
            }

            bool findTimeRisk()
            {

                if (list.Count >= 3)
                {
                    bool b = false;

                    TimeSpan timeCheck = list[0].Timestamp - list[2].Timestamp;
                    return timeCheck.TotalMinutes <= 15;
                }

                return false;
            }


        }
        public string GetSecretCodeBynameM()//9
        {

            string firstName, lastName, secretcode;

            Console.WriteLine("enter your first name ");
            firstName = Console.ReadLine();

            Console.WriteLine("enter your last name");
            lastName = Console.ReadLine();

            secretcode = people_method.GetSecretCodeByname(firstName, lastName);
            Console.WriteLine(secretcode);

            return secretcode;
        }

        public void SowAllData()
        {
            Console.WriteLine("To see all potential agents press 1");
            Console.WriteLine("To see all dangerous target press 2");
            Console.WriteLine("To see all reporter press 3");
            Console.WriteLine("To see all the danger target press 4");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowIPeopleByTypeM("potential_agent");
                    break;
                case "2":
                    ShowIPeopleByTypeM("target");
                    break;
                case "3":
                    ShowIPeopleByTypeM("reporter");
                    break;
                case "4":
                    ShowIPeopleByTypeM("danger");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2,  3, 4");
                    break;

            }
            void ShowIPeopleByTypeM(string type)
            {
                List<Person> people = people_method.ShowIPeopleByType(type);

                if (people == null)
                {
                    Console.WriteLine("No bady was found");
                }
                else
                {
                    foreach (var report in people)
                    {
                        report.PrintPersonInfo();
                        Console.WriteLine("--------------");
                    }
                }

            }


        }









        public string RandomSecretCode()
        {
            Random rnd = new Random();
            string random = "123456789qwertyuiop[]sdfghjkl!@#$%^&*";
            string RandomleCode = "";
            for (int i = 0; i < 2; i++)
            {

                RandomleCode += random[rnd.Next(0, random.Length)];
            }
            Console.WriteLine(RandomleCode);
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
