namespace SalesSystem.MySQL.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesSystem.MySQL.Data.MySQLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SalesSystem.MySQL.Data.MySQLContext context)
        {
            
        }
    }
}
