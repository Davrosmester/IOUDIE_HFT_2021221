using IOUDIE_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOUDIE_HFT_2021221.Repository
{
    public abstract class Repositories<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;

        public Repositories(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract T GetOne(int id);

    }
    public class CarRepository : Repositories<Car>, ICarShopRepository
    {

        public CarRepository(DbContext ctx) : base(ctx) { }

        public void ChangePrice(int id, int newPrice)
        {
            var car = GetOne(id);
            if (car == null)
            {
                throw new InvalidOperationException("Not Found");
            }
            car.BasePrice = newPrice;
            ctx.SaveChanges();
        }

        public override Car GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
    public class BrandRepository : Repositories<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }
        public void ChangeBrandName(int id, string newBrandName)
        {
            var brand = GetOne(id);
            if (brand == null)
            {
                throw new InvalidOperationException("Not Found");
            }
            brand.Name = newBrandName;
            ctx.SaveChanges();
        }

        public override Brand GetOne(int id)
        {
            return GetAll().SingleOrDefault(brand => brand.Id == id);
        }
    }
    public class DriversRepository : Repositories<Drivers>, IDriversRepository
    {
        public DriversRepository(DbContext ctx) : base(ctx) { }
        public void ChangeDriverName(int id, string newDriverName)
        {
            var drivers = GetOne(id);
            if (drivers == null)
            {
                throw new InvalidOperationException("Not Found");
            }
            drivers.Name = newDriverName;
            ctx.SaveChanges();
        }

        public override Drivers GetOne(int id)
        {
            return GetAll().SingleOrDefault(brand => brand.Id == id);
        }
    }
}
