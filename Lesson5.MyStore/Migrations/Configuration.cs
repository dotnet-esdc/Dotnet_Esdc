namespace Lesson5_MyStore.Migrations
{
    using Lesson5_MyStore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lesson5_MyStore.Entities.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lesson5_MyStore.Entities.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categories.AddOrUpdate(new List<Category>()
            {
                new Category() { Id = 1, Name = "High" },
                new Category() { Id = 2, Name = "Medium" },
                new Category() { Id = 3, Name = "Low" },
            }.ToArray());

            context.Employee.AddOrUpdate(new List<Employee>()
            {
                new Employee() { Id = 1, FullName = "Manager" },
                new Employee() { Id = 2, FullName = "Officer" }
            }.ToArray());

        }
    }
}
