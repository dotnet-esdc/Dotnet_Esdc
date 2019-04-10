using Lesson10.AdvancedWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson10.AdvancedWeb.Controllers
{
    [RoutePrefix("v3")]
    public class HighLevelTopDocumentsController : ApiController
    {
        public ICollection<HighLevelTopDocument> Get()
        {
            throw new NotImplementedException();
        }
    }
}
