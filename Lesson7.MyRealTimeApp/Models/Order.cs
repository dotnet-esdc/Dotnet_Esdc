using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson7.MyRealTimeApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }
    }
}