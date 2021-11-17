using IOUDIE_HFT_2021221.Logic;
using IOUDIE_HFT_2021221.Models;
using IOUDIE_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
                        Brand=peugeot,
                        Model="306",
                        BasePrice=1000
                    },
                    new Car()
                    {
                        Brand=peugeot,
                        Model="406",
                        BasePrice=2000
                    }
                }.AsQueryable()
             );

            //driverLogic = new DriverLogic(mockDriverRepo.Object);

            //Drivers jani = new Drivers() { Name="Jani" };
            //mockDriverRepo.Setup(driverRepo => driverRepo.Create(It.IsAny<Drivers>()));

            //mockDriverRepo.Setup(driverRepo => driverRepo.GetAll()).Returns(
            //    new List<Drivers>
            //    {
            //        new Drivers()
            //        {
            //            Name=jani.Name,
            //            Age=100
            //        },
            //        new Drivers()
            //        {
            //            Name=jani.Name,
            //            Age=200
            //        }
            //    }.AsQueryable()
            //    );
        }


        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
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
        [TestCase(-100)]
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
        //[Test]
        //public void TestAgeAverage()
        //{
        //    Drivers jani = new Drivers() { Age = 45, Id = 1 };
        //    driverLogic.Create(
        //        new Drivers()
        //        {
        //            Id=1,
        //            Name = jani.Name,
        //            Age = 100
        //        }
        //        );
        //    driverLogic.Create(
        //        new Drivers()
        //        {
        //            Id=1,
        //            Name = jani.Name,
        //            Age = 200
        //        }
        //        );
        //    var res = driverLogic.GetDriverAgeAverages();
        //    Assert.That(res, Is.EquivalentTo(
        //        new List<AverageResult>
        //        {
        //            new AverageResult()
        //            {
        //                AverageAge=150
        //            }
        //        }
        //        ));
    }
}

