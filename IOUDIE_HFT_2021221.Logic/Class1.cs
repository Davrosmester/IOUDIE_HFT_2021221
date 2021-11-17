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


        public override bool Equals(object obj)
        {
            if (obj is AverageResult)
            {
                var other = obj as AverageResult;
                return this.AveragePrice == other.AveragePrice && this.BrandName == other.BrandName;
            }
            else
            {
                return false;
            }
            
        }
        public override int GetHashCode()
        {
            return this.BrandName.GetHashCode() + (int)this.AveragePrice;
        }
        public override string ToString()
        {
            return $"BrandName={BrandName}, AveragePrice={AveragePrice}"; 
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

}
