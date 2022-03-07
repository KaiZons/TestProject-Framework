using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestProject_Framework.Controllers
{ 
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        [Route("{name}/{type:int}")]
        public string Get(string name, int type)
        {
            return "valuestring77777";
        }

        [Route("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
