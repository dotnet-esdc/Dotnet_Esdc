using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson3.WebApplication.Models
{
    public class ProductRepository
    {
        private static List<Product> _products;
        
        public static List<Product> GetProducts()
        {
            using (var context = new StoreContext())
            {
                var products = context.Products;
                return products.ToList();
            }
        }

        public static void CreateProduct(Product product)
        {
            using (var context = new StoreContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static void UpdateProduct(Product product)
        {
            using (var context = new StoreContext())
            {
                var elem = context.Products.First(x => x.Id == product.Id);
                elem.Name = product.Name;
                elem.Price = product.Price;

                context.SaveChanges();
            }
        }

        public static void DeleteProduct(Product product)
        {
            using (var context = new StoreContext())
            {
                var elem = context.Products.First(x => x.Id == product.Id);
                context.Products.Remove(elem);

                context.SaveChanges();
            }
        }

    }
}