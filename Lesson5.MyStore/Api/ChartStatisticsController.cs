using Lesson5_MyStore.Entities;
using Lesson5_MyStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson5_MyStore.Api
{
    public class ChartStatisticsController : ApiController
    {
        private StoreContext _db = new StoreContext();

        [HttpGet]
        public ICollection<SaleVM> Get()
        {
            var data = _db.Sale.Select(x => new
            {
                CategoryName = x.Product.Category.Name,
                ProductName = x.Product.Name,
                SalePrice = x.Price
            }).ToList();


            return data.Select(x => new SaleVM()
            {
                CategoryName = x.CategoryName,
                ProductName = x.ProductName,
                SalePrice = x.SalePrice
            }).ToList();
        }

    }
}
