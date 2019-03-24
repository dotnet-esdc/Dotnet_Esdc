namespace Lesson8_InventorySystem.Entities
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    public class InventoryContext : DbContext
    {
        public virtual DbSet<Equipment> Equipments { get; set; }

        public virtual DbSet<EquipmentDetail> EquipmentDetail { get; set; }

        public virtual DbSet<InventoryFact> InventoryFact { get; set; }
        
        public InventoryContext()
            : base("name=InventoryContext")
        {
#if DEBUG
            Database.Log = log => Debug.WriteLine(log);
#endif
        }
    }
}