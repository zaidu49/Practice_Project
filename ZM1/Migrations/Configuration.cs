namespace ZM1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZM1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZM1.Data.ZmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZM1.Data.ZmContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            var employees = new List<Employee>
            {
                new Employee{Name="Employee", Salary="1000"},
                new Employee{Name="Employee1", Salary="1000"},
                new Employee{Name="Employee2", Salary="1000"},
                new Employee{Name="Employee3", Salary="1000"},
                new Employee{Name="Employee4", Salary="1000"}
            };
            employees.ForEach(u => context.Employees.Add(u));
            context.SaveChanges();
        }
    }
}
