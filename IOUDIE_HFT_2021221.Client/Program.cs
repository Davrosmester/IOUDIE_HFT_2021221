using ConsoleTools;
using IOUDIE_HFT_2021221.Models;
using IOUDIE_HFT_2021221.Models.Utilities;
using System;

namespace IOUDIE_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:4281");

            ConsoleMenu carMenu = new ConsoleMenu(args, level: 1); //crud+
            carMenu.Configure(config =>
            {
                config.Selector = "-";
            });
            carMenu.Add("GetAll", () =>
            {
                var res = restService.Get<Car>("/car");
                foreach (var item in res)
                {
                    Console.WriteLine(item.Model);
                }
                Console.ReadLine();
            });
            carMenu.Add("GetOne", () =>
             {
                 Console.WriteLine("Adjon meg egy id-t");
                 int id = int.Parse(Console.ReadLine());
                 var res = restService.GetSingle<Car>($"/car/{id}");
                 Console.WriteLine(res.Model);
                 Console.ReadLine();
             });
            carMenu.Add("Create", () =>
            {
                restService.Post<Car>(
                    new Car() {
                        Model = "Xc70", BrandId = 1 },
                    "/car");
                Console.WriteLine("Car created");
                Console.ReadLine();

            });
            carMenu.Add("Update", () =>
             {
                 Console.WriteLine("Give and Id");
                 int id = int.Parse(Console.ReadLine());
                 var car = restService.GetSingle<Car>($"/car/{id}");
                 car.Model = "Suzuki Swift";
                 restService.Put<Car>(car, $"/car");
                 Console.ReadLine();
             });
            carMenu.Add("Delete", () =>
            {
                Console.WriteLine("Give and Id");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, $"/car");
                Console.WriteLine("Car deleted");
                Console.ReadLine();
            });
            carMenu.Add("Exit", () =>
            {
                carMenu.CloseMenu();
            });


            ConsoleMenu brandMenu = new ConsoleMenu(args, level: 1); //crud
            brandMenu.Configure(config =>
            {
                config.Selector = "-";
            });
            brandMenu.Add("GetAll", () =>
            {
                var res = restService.Get<Brand>("/brand");
                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            });
            brandMenu.Add("GetOne", () =>
            {
                int id = int.Parse(Console.ReadLine());
                var res = restService.GetSingle<Brand>($"/brand/{id}");
                Console.WriteLine(res.Name);
                Console.ReadLine();

            });
            brandMenu.Add("Create", () =>
            {
                restService.Post<Brand>(
                    new Brand()
                    {
                        Name="Volkswagen Golf",Id=1
                    },
                    "/brand");
                Console.WriteLine("Brand created");
                Console.ReadLine();

            });
            brandMenu.Add("Update", () =>
            {
                Console.WriteLine("Give and Id");
                int id = int.Parse(Console.ReadLine());
                var brand = restService.GetSingle<Brand>($"/brand/{id}");
                brand.Name = "Volkswagen";
                restService.Put<Brand>(brand, $"/brand");
                Console.ReadLine();
            });
            brandMenu.Add("Delete", () =>
            {
                Console.WriteLine("Give and Id");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, $"/brand");
                Console.ReadLine();
            });
            brandMenu.Add("Exit", () =>
            {
                brandMenu.CloseMenu();
            });



            ConsoleMenu driverMenu = new ConsoleMenu(args, level: 1); //crud
            driverMenu.Configure(config =>
            {
                config.Selector = "-";
            });
            driverMenu.Add("GetAll", () =>
            {
                var res = restService.Get<Driver>("/driver");
                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            });
            driverMenu.Add("GetOne", () =>
            {
                int id = int.Parse(Console.ReadLine());
                var res = restService.GetSingle<Driver>($"/driver/{id}");
                Console.WriteLine(res.Name);
                Console.ReadLine();
            });
            driverMenu.Add("Create", () =>
            {
                restService.Post<Driver>(
                    new Driver()
                    {
                        Name="Muhammad Ali",Id=1
                    },
                    "/driver");
                Console.WriteLine("Driver created");
                Console.ReadLine();

            });
            driverMenu.Add("Update", () =>
            {
                Console.WriteLine("Give and Id");
                int id = int.Parse(Console.ReadLine());
                var driver = restService.GetSingle<Driver>($"/driver/{id}");
                driver.Name = "Kis Pista";
                restService.Put<Driver>(driver, $"/brand");
                Console.ReadLine();
            });
            driverMenu.Add("Delete", () =>
            {
                Console.WriteLine("Give and Id");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, $"/driver");
                Console.WriteLine("Driver deleted");
                Console.ReadLine();
            });
            driverMenu.Add("Exit", () =>
            {
                driverMenu.CloseMenu();
            });




            ConsoleMenu statmenu = new ConsoleMenu(args, level: 1); //non crud
            statmenu.Configure(config =>
            {
                config.Selector = "-";
            });
            statmenu.Add("Average By Brands", () => {
                var res = restService.Get<AverageResult>("/stat/averagebybrands");
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });
            statmenu.Add("Average Car Price", () => {
                var res = restService.GetSingle<double>("/stat/averageprice");
                Console.WriteLine($"Avg car price={res}");
                Console.ReadLine();
            });
            statmenu.Add("Expensive Cars", () =>
            {
                var res = restService.Get<Car>("/stat/expensivecars");
                foreach (var item in res)
                {
                    Console.WriteLine(item.Model);
                }
                Console.ReadLine();
            });
            statmenu.Add("InExpensive Cars", () =>
            {
                var res = restService.Get<Car>("/stat/inexpensivecars");
                foreach (var item in res)
                {
                    Console.WriteLine(item.Model);
                }
                Console.ReadLine();
            });
            statmenu.Add("Get By Model", () =>
             {
                 Console.WriteLine("Give a model");
                 string model = Console.ReadLine();
                 var res = restService.Get<Car>($"/stat/getbymodel/{model}");
                 foreach (var item in res)
                 {
                     Console.WriteLine($"Model by Car={item.Model}");
                 }
                 Console.ReadLine();
             });
            statmenu.Add("Young Drivers", () =>
            {
                var res = restService.Get<Driver>("/stat/youngdrivers");
                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            });
            statmenu.Add("Elder Drivers", () =>
            {
                var res = restService.Get<Driver>("/stat/elderdrivers");
                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            });
            statmenu.Add("Exit", () =>
            {
                statmenu.CloseMenu();
            });



            ConsoleMenu mainconsole = new ConsoleMenu(args, level: 0);
            mainconsole.Add("Car methods: ", carMenu.Show);
            mainconsole.Add("Brand methods: ", brandMenu.Show);
            mainconsole.Add("Driver methods: ", driverMenu.Show);
            mainconsole.Add("Statistics methods: ", statmenu.Show);
            mainconsole.Add("Exit: ", mainconsole.CloseMenu);

            mainconsole.Show();
            Console.ReadLine();
        }
    }
}
