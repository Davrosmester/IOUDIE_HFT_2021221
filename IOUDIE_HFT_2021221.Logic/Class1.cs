using IOUDIE_HFT_2021221.Models;
using IOUDIE_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOUDIE_HFT_2021221.Logic
{
    public class AverageResult
    {
        public string BrandName { get; set; }
        public double AveragePrice { get; set; }
       // public double AverageAge { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is AverageResult)
            {
                var other = obj as AverageResult;
                return this.AveragePrice == other.AveragePrice && this.BrandName == other.BrandName;
                   /* && this.AverageAge==other.AverageAge;*/ //close
            }
            else
            {
                return false;
            }
            
        }
        public override int GetHashCode()
        {
            return this.BrandName.GetHashCode() + (int)this.AveragePrice/* + (int)this.AverageAge*/;
        }
        public override string ToString()
        {
            return $"BrandName={BrandName}, AveragePrice={AveragePrice},"; 
        }
    }

    public interface ICarLogic
    {
        Car GetOne(int id);
        IList<Car> GetAll();
        void ChangePrice(int id, int newPrice);
        IList<AverageResult> GetBrandAverages();
        void Create(Car newCar);
        void Delete(Car forDelete);
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
    }

    public interface IBrandLogic
    {
        IList<Brand> GetAll();
        Brand GetOne(int id);

        void ChangeBrandName(int id, string newBrandName);
        void Create(Brand newBrand);
        void Delete(Brand forDelete);

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

        public IList<Brand> GetAll()
        {
            return brandRepository.GetAll().ToList();
        }

        public Brand GetOne(int id)
        {
            return brandRepository.GetOne(id);
        }
    }

    public interface IDriverLogic
    {
        IList<Drivers> GetAll();
        Drivers GetOne(int id);
        void ChangeDriverName(int id,string newDriverName);
        //IList<AverageResult> GetDriverAgeAverages();
        void Create(Drivers newDriver);
        void Delete(Drivers forDelete);
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

        public void Create(Drivers newDriver)
        {
            if (newDriver.Id<1)
            {
                throw new ArgumentException(nameof(newDriver), "Driver id must be positive");
            }
            driversRepo.Create(newDriver);
        }

        public void Delete(Drivers forDelete)
        {
            driversRepo.Delete(forDelete);
        }

        public IList<Drivers> GetAll()
        {
            return driversRepo.GetAll().ToList();
        }

        //public IList<AverageResult> GetDriverAgeAverages()
        //{
        //    var q = from driver in driversRepo.GetAll()
        //            group driver by new { driver.Age } into g
        //            select new AverageResult()
        //            {
        //                AverageAge = g.Average(x => x.Age)
        //            };
        //    return q.ToList();
        //}

        public Drivers GetOne(int id)
        {
            return driversRepo.GetOne(id);
        }
    }

}
