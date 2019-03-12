using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson5_MyStore.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}