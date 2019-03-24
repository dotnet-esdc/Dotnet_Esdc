using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson8_InventorySystem.Entities
{
    public class EquipmentDetail
    {
        public int Id { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public string Name { get; set; }

        public EquipmentPropertyType PropertyType { get; set; }

        public double? DoubleVal { get; set; }

        public string StringVal { get; set; }

        public DateTime? DateTimeVal { get; set; }

        public bool? BoolVal { get; set; }
    }
}