using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson6.MySecurityApplication.Api
{
    [Authorize]
    public class NewsController : ApiController
    {
        public List<string> Get()
        {
            return new List<string>() { "Hello", "world", "!" };
        }
    }
}
