using Lesson9.Core.Models;
using Lesson9.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson9.CoreTest.TestRepositories
{
    public class CategoryTestRepository : IRepository<Category>
    {
        public ICollection<Category> GetCollection()
        {
            return Enumerable.Range(1, 3).Select(x => new Category() { Id = x, Name = "Cat_" + x }).ToList();
        }
    }

    public class ProductTestRepository : IRepository<Product>
    {
        public ICollection<Product> GetCollection()
        {
            var res = new List<Product>();

            res.Add(new Product() { Id = 1, Name = "Prod_1", CategoryId = 1, ClientId = 1 });
            res.Add(new Product() { Id = 2, Name = "Prod_2", CategoryId = 2, ClientId = 1 });
            res.Add(new Product() { Id = 3, Name = "Prod_3", CategoryId = 3, ClientId = 1 });
            res.Add(new Product() { Id = 4, Name = "Prod_4", CategoryId = 1, ClientId = 2 });
            res.Add(new Product() { Id = 5, Name = "Prod_5", CategoryId = 2, ClientId = 2 });

            return res;
        }
    }

    public class ClientTestRepository : IRepository<Client>
    {
        public ICollection<Client> GetCollection()
        {
            return Enumerable.Range(1, 2).Select(x => new Client() { Id = x, Name = "Cl_" + x }).ToList();
        }
    }
}
