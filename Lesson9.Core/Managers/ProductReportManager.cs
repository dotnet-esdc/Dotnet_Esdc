using Lesson9.Core.DTOs;
using Lesson9.Core.Models;
using Lesson9.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9.Core.Managers
{
    public class ProductReportManager
    {
        IRepository<Product> prodRepo;
        IRepository<Client> clientRepo;
        IRepository<Category> categoryRepo;

        public ProductReportManager(IRepository<Product> prodRepo,
            IRepository<Client> clientRepo,
            IRepository<Category> categoryRepo)
        {
            this.prodRepo = prodRepo;
            this.clientRepo = clientRepo;
            this.categoryRepo = categoryRepo;
        }

        public ICollection<ProductReportDTO> GetDataVersion2(ICollection<Product> productsCollection,
            ICollection<Client> clientsCollection, 
            ICollection<Category> categoryCollection)
        {
            var res = new List<ProductReportDTO>();
            
            foreach (var prodItem in productsCollection)
            {
                var resItem = new ProductReportDTO();

                resItem.ProductId = prodItem.Id;
                resItem.ProductName = prodItem.Name;

                resItem.CategoryId = prodItem.CategoryId;
                resItem.ClientId = prodItem.ClientId;

                resItem.ClientName = clientsCollection
                    .First(x => x.Id == prodItem.ClientId).Name;

                resItem.CategoryName = categoryCollection
                        .First(x => x.Id == prodItem.CategoryId).Name;
            }

            return res;
        }

        public ICollection<ProductReportDTO> GetData()
        {
            var productsCollection = prodRepo.GetCollection();
            var clientsCollection = clientRepo.GetCollection();
            var categoryCollection = categoryRepo.GetCollection();

            var res = new List<ProductReportDTO>();

            res = productsCollection.Join(clientsCollection,
                    prod => prod.ClientId,
                    client => client.Id,
                    (prod, client) => new { prod, client })
                .Join(categoryCollection,
                    prod => prod.prod.CategoryId,
                    cat => cat.Id,
                    (prod, cat) => new { Product = prod.prod, Client = prod.client, Category = cat })
                .Select(x => new ProductReportDTO()
                {
                    ProductId = x.Product.Id,
                    ProductName = x.Product.Name,
                    CategoryId = x.Category.Id,
                    CategoryName = x.Category.Name,
                    ClientId = x.Client.Id,
                    ClientName = x.Client.Name
                }).ToList();
            
            return res;
        }
    }
}
