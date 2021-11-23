using IOUDIE_HFT_2021221.Models;
using IOUDIE_HFT_2021221.Models.Utilities;
using IOUDIE_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOUDIE_HFT_2021221.Logic
{
    

    public interface ICarLogic
    {
        IEnumerable<Car> ExpensiveCars();
        IEnumerable<Car> InExpensiveCars();
        IEnumerable<Car> GetByModel(string model);
        Car GetOne(int id);
        void Update(Car updated);
        IList<Car> GetAll();
        void ChangePrice(int id, int newPrice);
        IList<AverageResult> GetBrandAverages();
        void Create(Car newCar);
        void Delete(Car forDelete);
        void Delete(int id);
        double AveragePrice();
    }

    public class CarLogic : ICarLogic
    {
        ICarShopRepository carRepo;

        public void Delete(Car forDelete)
        {
            carRepo.Delete(forDelete);
        }
        
        public void Create(Car newCar)
        {
            if (newCar.BrandId<1)
            {
                throw new ArgumentException(nameof(newCar),"Brand id must be positive");
            }
            carRepo.Create(newCar);
        }

        public CarLogic(ICarShopRepository carShopRepository)
        {
            this.carRepo = carShopRepository;
        }

        public void ChangePrice(int id, int newPrice)
        {
            carRepo.ChangePrice(id, newPrice);
        }


        public IList<Car> GetAll()
        {
            return carRepo.GetAll().ToList();
        }

        public IList<AverageResult> GetBrandAverages()
        {
            var q = from car in carRepo.GetAll()
                  group car by new { car.BrandId, car.Brand.Name } into g
                  select new AverageResult()
                  {
                      BrandName = g.Key.Name,
                      AveragePrice = g.Average(x => x.BasePrice) ?? 0
                  };
            return q.ToList();
        }

        public Car GetOne(int id)
        {
            return carRepo.GetOne(id);
        }

        public IEnumerable<Car> ExpensiveCars()=> carRepo.GetAll().Where(x => x.BasePrice >= 18500); //stat
        public IEnumerable<Car> InExpensiveCars() => carRepo.GetAll().Where(x => x.BasePrice < 18500);  //stat

        public IEnumerable<Car> GetByModel(string model) => carRepo.GetAll().Where(x => x.Model == model);

        public void Delete(int id)
        {
            carRepo.Delete(id);
        }

        public void Update(Car updated)
        {
            carRepo.Update(updated);
        }

        public double AveragePrice()
        {
            return (double)carRepo.GetAll().Average(x=>x.BasePrice);
        }
    }

    public interface IBrandLogic
    {
        IList<Brand> GetAll();
        Brand GetOne(int id);

        void ChangeBrandName(int id, string newBrandName);
        void Create(Brand newBrand);
        void Delete(Brand forDelete);
        void Delete(int id);
        void Update(Brand value);
    }
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository brandRepository;
        public BrandLogic(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public void ChangeBrandName(int id, string newBrandName)
        {
            brandRepository.ChangeBrandName(id, newBrandName);
        }

        public void Create(Brand newBrand)
        {
            brandRepository.Create(newBrand);
        }

        public void Delete(Brand forDelete)
        {
            brandRepository.Delete(forDelete);
        }

        public void Delete(int id)
        {
            brandRepository.Delete(id);
        }

        public IList<Brand> GetAll()
        {
            return brandRepository.GetAll().ToList();
        }

        public Brand GetOne(int id)
        {
            return brandRepository.GetOne(id);
        }

        public void Update(Brand value)
        {
            brandRepository.Update(value);
        }
    }

    public interface IDriverLogic
    {
        IEnumerable<Driver> ElderDrivers();
        IEnumerable<Driver> YoungDrivers();
        IList<Driver> GetAll();
        Driver GetOne(int id);
        void ChangeDriverName(int id,string newDriverName);
        void Create(Driver newDriver);
        void Delete(Driver forDelete);
        void Delete(int id);
        void Update(Driver value);
    }

    public class DriverLogic : IDriverLogic
    {
        IDriversRepository driversRepo;

        public DriverLogic(IDriversRepository driversRepo)
        {
            this.driversRepo = driversRepo;
        }

        public void ChangeDriverName(int id, string newDriverName)
        {
            driversRepo.ChangeDriverName(id, newDriverName);
        }

        public void Create(Driver newDriver)
        {
            if (newDriver.Id<1)
            {
                throw new ArgumentException(nameof(newDriver), "Driver id must be positive");
            }
            driversRepo.Create(newDriver);
        }

        public void Delete(Driver forDelete)
        {
            driversRepo.Delete(forDelete);
        }

        public void Delete(int id)
        {
            driversRepo.Delete(id);
        }

        public IEnumerable<Driver> ElderDrivers()=> driversRepo.GetAll().Where(x => x.Age >= 50);
        
            
        

        public IList<Driver> GetAll()
        {
            return driversRepo.GetAll().ToList();
        }

      

        public Driver GetOne(int id)
        {
            return driversRepo.GetOne(id);
        }

        public void Update(Driver value)
        {
            driversRepo.Update(value);
        }

        public IEnumerable<Driver> YoungDrivers()=> driversRepo.GetAll().Where(x => x.Age < 50);
        
    }

}
