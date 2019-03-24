using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson8_InventorySystem.Entities
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<EquipmentDetail> EquipmentDetails { get; set; }

        public virtual ICollection<InventoryFact> InventoryFacts { get; set; }
    }
}