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
    public class CategoriesController : ApiController
    {
        private StoreContext _db = new StoreContext();

        public ICollection<Category> Get()
        {
            return _db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _db.Categories.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            var values = form.Get("values");

            var item = new Category();
            JsonConvert.PopulateObject(values, item);

            _db.Categories.Add(item);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, item);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");
            var category = _db.Categories.First(o => o.Id == key);

            JsonConvert.PopulateObject(values, category);
            
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpDelete]
        public IHttpActionResult Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var item = _db.Categories.Find(key);

            _db.Categories.Remove(item);
            _db.SaveChanges();

            return Ok();
        }

    }
}
