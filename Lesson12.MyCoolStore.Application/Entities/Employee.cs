using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson12_MyCoolStore_Application.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}