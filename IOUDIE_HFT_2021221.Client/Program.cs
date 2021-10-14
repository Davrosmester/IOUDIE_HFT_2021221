using IOUDIE_HFT_2021221.Models;
using System;

namespace IOUDIE_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CarDBContext test = new CarDBContext();
            foreach (var item in test.Brand)
            {
                foreach (var x in item.Cars)
                {
                    foreach (var y in x.Drivers)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(x.Model);
                        Console.WriteLine(y.Name);
                    }
                }
            }
        }
    }
}
