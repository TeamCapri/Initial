using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using SalesSystem.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Migrations
    {
    public sealed class Configuration : DbMigrationsConfiguration<SalesSystemContext>
        {
        public Configuration()
            {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "SalesSystem.Data.SalesSystemContext";
            }

        protected override void Seed(SalesSystemContext context)
            {
           
            }

        }
    }
