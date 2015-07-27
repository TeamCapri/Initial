namespace SalesSystem.Data
{
    using Migrations;
    using System.Data.Entity;
    using Model;

    public class SalesSystemContext : DbContext
    {
        public SalesSystemContext(): base("SalesSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesSystemContext, Configuration>());
        }
        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supermarket> Supermarkets { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
    }
}