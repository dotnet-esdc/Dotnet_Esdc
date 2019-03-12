using Lesson5_MyStore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Lesson5_MyStore.Api
{
    public class ProductsController : ApiController
    {
        private StoreContext _db = new StoreContext();

        public ICollection<Product> Get()
        {
            return _db.Product.ToList();
        }

        public Product Get(int id)
        {
            return _db.Product.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            var values = form.Get("values");

            var item = new Product();
            JsonConvert.PopulateObject(values, item);

            _db.Product.Add(item);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, item);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");
            var category = _db.Product.First(o => o.Id == key);

            JsonConvert.PopulateObject(values, category);

            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpDelete]
        public IHttpActionResult Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var item = _db.Product.Find(key);

            _db.Product.Remove(item);
            _db.SaveChanges();

            return Ok();
        }
    }
}
