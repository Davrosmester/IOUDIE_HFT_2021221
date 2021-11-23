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
    public class CarController : ControllerBase
    {

        ICarLogic cl;

        public CarController(ICarLogic cl)
        {
            this.cl = cl;
        }



        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cl.GetAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return cl.GetOne(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value) //create
        {
            cl.Create(value);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Put([FromBody] Car value) //update
        {
            cl.Update(value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) //törlés
        {
            cl.Delete(id);
        }
    }
}
