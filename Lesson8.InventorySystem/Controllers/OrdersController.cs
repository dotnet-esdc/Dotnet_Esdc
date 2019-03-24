using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lesson8_InventorySystem.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace Lesson8_InventorySystem.Controllers {
    public class OrdersController : ApiController {

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            return Request.CreateResponse(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }

    }
}