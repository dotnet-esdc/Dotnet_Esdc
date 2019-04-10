using Lesson10.AdvancedWeb.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson10.AdvancedWeb.Controllers
{
    [RoutePrefix("v3")]
    public class AccountController : ApiController
    {
        [MyCustomAttribute]
        public ICollection<object> Get()
        {
            throw new NotImplementedException();
        }
    }
}
