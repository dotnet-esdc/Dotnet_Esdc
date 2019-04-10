namespace Lesson11.My3tierApplication.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyApplicationDbContext : DbContext
    {
        public MyApplicationDbContext()
            : base("name=MyApplicationDbContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
