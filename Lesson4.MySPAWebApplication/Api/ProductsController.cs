using Lesson4.MySPAWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson4.MySPAWebApplication.Api
{
    public class ProductsController : ApiController
    {
        private ProductsReporistory _repository = new ProductsReporistory();

        public List<Product> GetProducts()
        {
            return _repository.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetProduct(id);
        }

        [HttpPost]
        public IHttpActionResult PostProduct(Product product)
        {
            _repository.CreateProduct(product);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            _repository.UpdateProduct(id, product);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);
            return Ok();
        }
    }
}
