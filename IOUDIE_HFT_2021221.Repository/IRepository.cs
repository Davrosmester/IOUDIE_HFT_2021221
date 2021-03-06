using IOUDIE_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOUDIE_HFT_2021221.Repository
{
    public interface IRepository<T> where T:class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
        void Delete(T entity);
        void Delete(int id);
        void Create(T entity); //only create not update
        void Update(T updated);
    }
    public interface ICarShopRepository : IRepository<Car>
    {
        void ChangePrice(int id, int newPrice); //update
        
    }
    public interface IBrandRepository : IRepository<Brand>
    {
        void ChangeBrandName(int id, string newBrandName);
    }

    public interface IDriversRepository : IRepository<Driver>
    {
        void ChangeDriverName(int id, string newDriverName);
    }
}
