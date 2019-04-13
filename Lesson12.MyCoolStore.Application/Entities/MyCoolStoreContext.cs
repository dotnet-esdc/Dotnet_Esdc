namespace Lesson12_MyCoolStore_Application.Entities
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    public class MyCoolStoreContext : DbContext
    {
        public MyCoolStoreContext()
            : base("name=MyCoolStoreContext")
        {
#if DEBUG
            Database.Log = l => Debug.WriteLine(l);
#endif
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
    }
    
}