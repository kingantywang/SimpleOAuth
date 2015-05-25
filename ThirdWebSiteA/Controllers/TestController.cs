using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThirdWebSiteA.Filters;

namespace ThirdWebSiteA.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public KeyValue GetOne()
        {
            return new KeyValue { Key = "name", Value = "xiongkailing" };
        }

        [HttpGet]
        public KeyValue GetTwo()
        {
            return new KeyValue { Key = "name", Value = "zzq" };
        }
    }

    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
