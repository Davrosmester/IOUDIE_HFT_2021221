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

        public virtual DbSet<Driver> Driver { get; set; }

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
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;attachDbFilename=|DataDirectory|\Database1.mdf;Integrated security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand toyota = new Brand() { Id = 2, Name = "Toyota" };
            Brand audi = new Brand() { Id = 3, Name = "Audi" };

            Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW 116d" };
            Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 50000, Model = "BMW X6" };
            Car toyota1 = new Car() { Id = 3, BrandId = toyota.Id, BasePrice = 100000, Model = "Toyota Celica" };
            Car toyota2= new Car() { Id = 4, BrandId = toyota.Id, BasePrice = 10000, Model = "Toyota Yaris" };
            Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 25000, Model = "Audi A6" };
            Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 55000, Model = "Audi RS6" };

            Driver audidriver1 = new Driver() { Id = 1, Age = 42, Name = "Jani", CarId = audi1.Id };
            Driver audidriver2 = new Driver() { Id = 2, Age = 30, Name = "Kristof", CarId = audi2.Id };
            Driver toyotadriver1 = new Driver() { Id = 3, Age = 18, Name = "Mark", CarId = toyota1.Id };
            Driver toyotadriver2 = new Driver() { Id = 4, Age = 22, Name = "Joseph", CarId = toyota2.Id };
            Driver bmwdriver1 = new Driver() { Id = 5, Age = 56, Name = "Achilles", CarId = bmw1.Id };
            Driver bmwdriver2 = new Driver() { Id = 6, Age = 48, Name = "Aurelio", CarId = bmw2.Id };

            modelBuilder.Entity<Car>(entity => 
            {
                entity.HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                //.OnDelete(DeleteBehavior.ClientSetNull);
                .OnDelete(DeleteBehavior.Cascade);
             
             });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasOne(car => car.Car)
                    .WithMany(car => car.Drivers)
                    .HasForeignKey(car => car.CarId)
                    //.OnDelete(DeleteBehavior.ClientSetNull);
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Brand>().HasData(bmw, toyota, audi);
            modelBuilder.Entity<Car>().HasData(bmw1, bmw2, toyota1, toyota2, audi1, audi2);
            modelBuilder.Entity<Driver>().HasData(bmwdriver1,bmwdriver2,audidriver1,audidriver2,toyotadriver1,toyotadriver2);

        }


    }
}
