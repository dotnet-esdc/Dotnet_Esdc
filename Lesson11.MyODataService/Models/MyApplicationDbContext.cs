namespace Lesson11.MyODataService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Diagnostics;

    public partial class MyApplicationDbContext : DbContext
    {
        public MyApplicationDbContext()
            : base("name=MyApplicationDbContext")
        {
#if DEBUG
            Database.Log = log => Debug.WriteLine(log);
#endif
        }

        public virtual DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
