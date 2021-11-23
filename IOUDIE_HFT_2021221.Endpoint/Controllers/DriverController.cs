using IOUDIE_HFT_2021221.Logic;
using IOUDIE_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOUDIE_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        IDriverLogic dl;

        public DriverController(IDriverLogic dl)
        {
            this.dl = dl;
        }

        // GET: api/<DriverController>
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return dl.GetAll();
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            return dl.GetOne(id);
        }

        // POST api/<DriverController>
        [HttpPost]
        public void Post([FromBody] Driver value)
        {
            dl.Create(value);
        }

        // PUT api/<DriverController>/5
        [HttpPut]
        public void Put([FromBody] Driver value)
        {
            dl.Update(value);
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dl.Delete(id);
        }
    }
}
