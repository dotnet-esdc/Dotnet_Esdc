using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson5_MyStore.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}