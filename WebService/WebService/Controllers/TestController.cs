using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebService.Controllers
{
    [RoutePrefix("Test1")]
    public class TestController : System.Web.Http.ApiController
    {
        [HttpGet]
        [Route("get2")] //   /api/Test1/get2
        public string Get()
        {
            return "test";
        }
    }
}