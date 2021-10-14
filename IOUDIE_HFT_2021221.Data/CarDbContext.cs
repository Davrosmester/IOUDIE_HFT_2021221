using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOUDIE_HFT_2021221.Models
{
    public class CarDBContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Brand> Brand { get; set; }

        public virtual DbSet<Drivers> Driver { get; set; }

        public CarDBContext()
        {
            this.Database.EnsureCreated();
        }

        public CarDBContext(DbContextOptions<CarDBContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database1.mdf;integrated security=True;MultipleActiveResultsSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand toyota = new Brand() { Id = 1, Name = "Toyota" };
            Brand audi = new Brand() { Id = 1, Name = "Audi" };

            Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW 116d" };
            Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 50000, Model = "BMW X6" };
            Car toyota1 = new Car() { Id = 1, BrandId = toyota.Id, BasePrice = 100000, Model = "Toyota Celica" };
            Car toyota2= new Car() { Id = 2, BrandId = toyota.Id, BasePrice = 10000, Model = "Toyota Yaris" };
            Car audi1 = new Car() { Id = 1, BrandId = audi.Id, BasePrice = 25000, Model = "Audi A6" };
            Car audi2 = new Car() { Id = 1, BrandId = audi.Id, BasePrice = 55000, Model = "Audi RS6" };

            Drivers audidriver1 = new Drivers() { Id = 1, Age = 42, Name = "Jani", CarId = audi1.Id };
            Drivers audidriver2 = new Drivers() { Id = 2, Age = 30, Name = "Kristof", CarId = audi2.Id };
            Drivers toyotadriver1 = new Drivers() { Id = 3, Age = 18, Name = "Mark", CarId = toyota1.Id };
            Drivers toyotadriver2 = new Drivers() { Id = 4, Age = 22, Name = "Joseph", CarId = toyota2.Id };
            Drivers bmwdriver1 = new Drivers() { Id = 5, Age = 56, Name = "Achilles", CarId = bmw1.Id };
            Drivers bmwdriver2 = new Drivers() { Id = 6, Age = 48, Name = "Aurelio", CarId = bmw2.Id };

            modelBuilder.Entity<Car>(entity => 
            {
                entity.HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);
             
                
             });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.HasOne(car => car.Car)
                    .WithMany(car => car.Drivers)
                    .HasForeignKey(car => car.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Brand>().HasData(bmw, toyota, audi);
            modelBuilder.Entity<Car>().HasData(bmw1, bmw2, toyota1, toyota2, audi1, audi2);
            modelBuilder.Entity<Drivers>().HasData(bmwdriver1,bmwdriver2,audidriver1,audidriver2,toyotadriver1,toyotadriver2);





        }


    }
}
