using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson12_MyCoolStore_Application.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}