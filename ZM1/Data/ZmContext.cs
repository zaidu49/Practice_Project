using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ZM1.Models;

namespace ZM1.Data
{
    public class ZmContext : DbContext
    {
        public ZmContext() : base("ZmContext")
        { }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // For preventing table names from being pluralized in database

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}