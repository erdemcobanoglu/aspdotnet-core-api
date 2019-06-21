using CityInfo.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Controllers
{
    //[Route("api/Dummy")]
    public class DummyController :Controller
    {
        // 18-06-19  sql server object explorer
        

        private CityInfoContext _ctx;

        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }


        // Bu sorguyu gönderince database oluşacaktır  doğru postman'a gidelim 
        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
