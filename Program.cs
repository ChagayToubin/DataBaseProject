using DataBase.DATA.DAL;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Manager man = new Manager();
            man.start();
        }
        
    }
}
