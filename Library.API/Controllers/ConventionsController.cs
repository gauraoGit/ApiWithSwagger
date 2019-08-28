//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Library.API.ApiConventions;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Library.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    //Custom API Conventions at API level
//    //[ApiConventionType(typeof(CustomApiConventions))]
//    public class ConventionsController : ControllerBase
//    {
//        // GET: api/Conventions
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET: api/Conventions/5
//        //Custom Conventions at Method Level
//        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
//        [HttpGet("{id}", Name = "Get")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST: api/Conventions
//        [HttpPost]
//        public void InsertTest([FromBody] string value)
//        {
//        }

//        // PUT: api/Conventions/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
