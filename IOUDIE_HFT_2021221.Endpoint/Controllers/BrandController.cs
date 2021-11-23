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
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;

        public BrandController(IBrandLogic bl)
        {
            this.bl = bl;
        }


        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return bl.GetAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return bl.GetOne(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            bl.Create(value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            bl.Update(value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Delete(id);
        }
    }
}
