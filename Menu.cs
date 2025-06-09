using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    static class Menu
    {
        public static void ShowMainMune()
        {

            switch (Console.ReadLine())//להסויף ןלידציה
            {
                case "1"://


                    Console.WriteLine();

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

    }
}
