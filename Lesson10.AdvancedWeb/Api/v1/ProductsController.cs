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
    public class ProductsController : ApiController
    {
        // api/Products/Get
        public ICollection<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetFavorit()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
