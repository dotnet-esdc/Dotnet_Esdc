using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson4.MySPAWebApplication.Models
{
    public class ProductsReporistory
    {
        private static List<Product> _collection = new List<Product>();

        public List<Product> GetProducts()
        {
            return _collection;
        }

        public Product GetProduct(int id)
        {
            return _collection.First(x => x.Id == id);
        }
        
        public void CreateProduct(Product product)
        {
            var maxId = _collection.Any() ? _collection.Max(x => x.Id) + 1 : 1;
            product.Id = maxId;
            _collection.Add(product);
        }

        public void UpdateProduct(int id, Product product)
        {
            var elem = _collection.First(x => x.Id == id);
            elem.Name = product.Name;
            elem.Price = product.Price;
        }

        public void DeleteProduct(int id)
        {
            var elem = _collection.First(x => x.Id == id);
            _collection.Remove(elem);
        }

    }
}