using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.DAL;
using DataBase.DATA.Models;

namespace DataBase
{
    public class Menu
    {
        public static People_DAL people_method = new People_DAL();
        public static IntelReport_DAL intel_report = new IntelReport_DAL();
        public void ShowMainMune()
        {
            Console.WriteLine("wellcome entere 1 for entere to the system" +
                "enter 2 to create new reorter ");
                


            switch (Console.ReadLine())//להסויף ןלידציה
            {
                case "1"://נכנס לפונקציה חמטרת הזדהות כל עוד לא הצליח להיכנס לא יוכל להמשיך הלאה
                  

                    if (!(EnterCheck())) //אם  קיבל אישור כניסה
                    {

                     
                        CreateNewReporter();
                        
                    }
                    Console.WriteLine("נכנס בהצלחה+++++++++++++++");
                    
                    intel_report.CreateNewIntel();
                    break;

                case "2":
                    CreateNewReporter();

                    
                    break;
                case "3":
                    Console.WriteLine();
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

                    checkSecretsode = people_method.CheckIfExistBySecret_code(secretCode);

                    break;
                default:
                    Console.WriteLine("please enter only 1 or 2");
                    EnterCheck();
                    break;
            }
            return checkSecretsode || checkName;//גישה אושרה אחד מהנתונים תקין

        }
        public void CreateNewReporter()
        {
            people_method.CreateNewReporter();

        }

    }
}
