using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DATA.DAL;

namespace DataBase
{
    public class Menu
    {
        public static People_DAL people_method= new People_DAL();
        public  void ShowMainMune()
        {
            Console.WriteLine("wellcome entere 1 for entere to the system");
           
           
            switch (Console.ReadLine())//להסויף ןלידציה
            {
                case "1"://נכנס לפונקציה חמטרת הזדהות כל עוד לא הצליח להיכנס לא יוכל להמשיך הלאה

                    if !(EnterCheck())//אם לא קיבל אישור כניסה
                    {
                        //קורא לפונקציה שמכניסה חדש
                    }


                    break;
                case "2":
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine();
                    break;
                case "4":
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
            bool checkName;
            bool checkSecretsode = false;


            Console.WriteLine("Identification system Click 1 to identify yourself using your name\n" +
                " 2 for a secret code");
            switch (Console.ReadLine())
            {

                case "1":
                   

                    Console.WriteLine("enter your first name");
                    
                    string firstname = Console.ReadLine();
                    Console.WriteLine("enter your last name");

                    string lastname  = Console.ReadLine();

                    checkName = people_method.CheckIfExistByName(firstname, lastname);
                    
                    break;
                case "2":
                    Console.WriteLine("enter your secret code");
                    string secretCode = Console.ReadLine();
                    checkSecretsode = people_method.CheckIfExistBySecret_code(secretCode);

                    break;
                default:
                    EnterCheck();
                    break;
            }
            return checkSecretsode && checkName;

        }

    }
}
