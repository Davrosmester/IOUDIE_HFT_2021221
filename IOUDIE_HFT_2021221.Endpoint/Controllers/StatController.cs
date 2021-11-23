using IOUDIE_HFT_2021221.Logic;
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

        public StatController(ICarLogic cl)
        {
            this.cl = cl;
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

       
    }
}
