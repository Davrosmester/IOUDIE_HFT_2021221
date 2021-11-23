using IOUDIE_HFT_2021221.Models;
using System;

namespace IOUDIE_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:4281");
            //ConsoleMenu consoleMenu = new ConsoleMenu();
            var res = restService.Get<Car>("/car");
            foreach (var item in res)
            {
                Console.WriteLine(item.Model);
            }
            Console.ReadLine();
        }
    }
}
