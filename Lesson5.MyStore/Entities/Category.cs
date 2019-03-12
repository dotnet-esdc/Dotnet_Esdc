using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson5_MyStore.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}