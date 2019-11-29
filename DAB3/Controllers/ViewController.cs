using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAB3.DAL;
using DAB3.Models;
using DAB3.Services;

namespace DAB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WallController : ControllerBase
    {
        // GET api/
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/view // Feed
        [HttpGet("{id}")]
        public ActionResult<string> Get(string name) //Done
        {
           
            
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        // GET api/
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/view // Feed
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)           //Done
        {
            
            return "value";
        }

        // POST api/values
        [HttpPost] 
        public void Post([FromBody] string value)          //Done
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)           //Done
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)           //Done
        {
        }
    }
}
