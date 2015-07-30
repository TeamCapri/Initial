namespace SalesSystem.MySQL.Data
{
    using MySql.Data.Entity;
    using SalesSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySQLContext : DbContext
    {
        public MySQLContext()
            : base("name=MySQLContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MySQLContext, Migrations.Configuration>());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supermarket> Supermarkets { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
    }
}