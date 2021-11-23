using IOUDIE_HFT_2021221.Logic;
using IOUDIE_HFT_2021221.Models;
using IOUDIE_HFT_2021221.Models.Utilities;
using IOUDIE_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IOUDIE_HFT_2021221.Test
{
    public class TestWithMock
    {
        Mock<ICarShopRepository> mockCarRepo = new Mock<ICarShopRepository>();
        CarLogic carLogic;

        Mock<IDriversRepository> mockDriverRepo = new Mock<IDriversRepository>();
        DriverLogic driverLogic;
        public TestWithMock()
        { 
            carLogic = new CarLogic(mockCarRepo.Object);

            Brand peugeot = new Brand() { Name = "Peugeot" };
            mockCarRepo.Setup(carRepo => carRepo.Create(It.IsAny<Car>()));

            mockCarRepo.Setup(carRepo => carRepo.GetAll()).Returns(
                new List<Car>
                {
                    new Car()
                    {
                        Id=1,
                        Brand=peugeot,
                        Model="306",
                        BasePrice=1000
                    },
                    new Car()
                    {
                        Id=2,
                        Brand=peugeot,
                        Model="406",
                        BasePrice=2000
                    }, 
                    
                }.AsQueryable()
             );

            driverLogic = new DriverLogic(mockDriverRepo.Object);
            mockDriverRepo.Setup(driverRepo => driverRepo.Create(It.IsAny<Driver>()));
            mockDriverRepo.Setup(driverRepo => driverRepo.GetAll()).Returns(
                new List<Driver>
                {
                    new Driver()
                    {
                        Age=42,
                        Name="janos",
                        Id=1,
                        Car=carLogic.GetOne(1)
                    },
                    new Driver()
                    {
                        Id=2,
                        Name="joska",
                        Age=66,
                        Car=carLogic.GetOne(2)
                    }
                }.AsQueryable()



                ) ;
        }


        [TestCase(1)]
        [TestCase(10)]
        public void TestCreateValid(int brandId)
        {
            Assert.That(
                () =>
            {
                carLogic.Create(new Car() { Model = "xxx", BrandId = brandId });
            },
                Throws.Nothing)
                ;

        }


        [TestCase(-1)]
        [TestCase(-10)]
        public void TestCreateInValid(int brandId)
        {
            Assert.That(
                () =>
                {
                    carLogic.Create(new Car() { Model = "xxx", BrandId = brandId });
                },
                Throws.Exception
                );
        }

        [Test]
        public void TestAverage()
        {
            Brand peugeot = new Brand() { Name = "Peugeot", Id = 1 };
            carLogic.Create(
                new Car()
                {
                    BrandId = 1,
                    Brand = peugeot,
                    Model = "306",
                    BasePrice = 1000
                }
            );
            carLogic.Create(new Car()
            {
                BrandId = 1,
                Brand = peugeot,
                Model = "406",
                BasePrice = 2000
            }
            );
            var res = carLogic.GetBrandAverages();
            Assert.That(res, Is.EquivalentTo(
                new List<AverageResult>
                {
                    new AverageResult()
                    {
                        BrandName="Peugeot",
                        AveragePrice=1500
                    }
                }
                ));
        }

        [Test]
        public void TestExpensiveCarModels()
        {
            carLogic.ExpensiveCars().ToList().ForEach(cars => Assert.That(cars.BasePrice >= 18500));

        }
        
        
        [Test]
         public void TestInExpensiveCarModels()
        {
            carLogic.InExpensiveCars().ToList().ForEach(cars => Assert.That(cars.BasePrice < 18500));
        }

        [Test]
        public void IsYoungDriver()
        {
            driverLogic.YoungDrivers().ToList().ForEach(drivers => Assert.That(drivers.Age < 50));
        }
        
        [Test]
        public void IsElderDriver()
        {
            driverLogic.ElderDrivers().ToList().ForEach(drivers => Assert.That(drivers.Age >= 50));
        }
        [TestCase("306")]
        [TestCase("406")]
        
        public void TestGetByModel(string model)
        {
            Assert.That(carLogic.GetByModel(model).All(x=>x.Model==model));
        }

        [TestCase("4006")]
        [TestCase("206")]
        public void TestGetByModelInvalid(string model)
        {
            Assert.That(carLogic.GetByModel(model).All(x => x.Model != model));
        }

    }
}

