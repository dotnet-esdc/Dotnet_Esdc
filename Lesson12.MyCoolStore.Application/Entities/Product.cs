using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson12_MyCoolStore_Application.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public virtual ICollection<SaleDetail> FactDetails { get; set; }
    }
}