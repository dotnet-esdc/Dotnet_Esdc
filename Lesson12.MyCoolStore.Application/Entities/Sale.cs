using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson12_MyCoolStore_Application.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public float PriceFact { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<SaleDetail> FactDetails { get; set; }
    }
}