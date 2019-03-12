namespace Lesson5_MyStore.Entities
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    public class StoreContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }

        public StoreContext()
            : base("name=StoreContext")
        {
#if DEBUG
            this.Database.Log = log => Debug.WriteLine(log);
#endif
        }
    }
}