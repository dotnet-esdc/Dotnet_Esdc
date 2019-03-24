using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson8_InventorySystem.Entities
{
    public class InventoryFact
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}