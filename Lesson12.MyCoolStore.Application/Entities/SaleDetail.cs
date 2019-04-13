using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson12_MyCoolStore_Application.Entities
{
    public class SaleDetail
    {
        public int Id { get; set; }

        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}