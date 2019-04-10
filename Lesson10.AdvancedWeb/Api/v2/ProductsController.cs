using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson10.AdvancedWeb.Controllers2
{
    //[RoutePrefix("api/TopProduct")]
    [RoutePrefix("v2")]
    public class Products1Controller : ApiController
    {
        [Route("api/TopProducts/Get")]
        public ICollection<int> Get1()
        {
            throw new NotImplementedException();
        }
    }
}
