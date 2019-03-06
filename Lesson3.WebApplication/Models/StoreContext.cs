namespace Lesson3.WebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    public class StoreContext : DbContext
    {
        // Your context has been configured to use a 'StoreContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Lesson3.WebApplication.Models.StoreContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StoreContext' 
        // connection string in the application configuration file.
        public StoreContext()
            : base("name=StoreContext")
        {
#if DEBUG
            this.Database.Log = log => Debug.WriteLine("From EF query", log);
#endif
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Product> Products { get; set; }
    }
}