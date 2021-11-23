using IOUDIE_HFT_2021221.Logic;
using IOUDIE_HFT_2021221.Models;
using IOUDIE_HFT_2021221.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOUDIE_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICarLogic cl;
        IDriverLogic dl;

        public StatController(ICarLogic cl, IDriverLogic dl)
        {
            this.cl = cl;
            this.dl = dl;
        }

        [HttpGet]
        public double AveragePrice()
        {
            return cl.AveragePrice();
        }


        [HttpGet]
        public IEnumerable<AverageResult> AverageByBrands()
        {
            return cl.GetBrandAverages();
        }
        [HttpGet]
        public IEnumerable<Car> ExpensiveCars()
        {
            return cl.ExpensiveCars();
        }
        [HttpGet]
        public IEnumerable<Car> InexpensiveCars()
        {
            return cl.InExpensiveCars();
        }
        [HttpGet("{model}")]
        public IEnumerable<Car> GetByModel(string model)
        {
            return cl.GetByModel(model);
        }
        [HttpGet]
        public IEnumerable<Driver> ElderDrivers()
        {
            return dl.ElderDrivers();
        }
        [HttpGet]
        public IEnumerable<Driver> YoungDrivers()
        {
            return dl.YoungDrivers();
        }

    }
}
