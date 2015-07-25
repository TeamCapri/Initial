namespace SalesSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Model;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SalesSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true; // TO DISABLE IN PRODUCTION
            this.ContextKey = "SalesSystem.Data.SalesSystemContext";
        }

        protected override void Seed(SalesSystemContext context)
        {
            // ADD TOWNS
            if (!context.Towns.Any())
            {
                context.Towns.AddOrUpdate(t => t.Name,
                new Town() { Name = "Sofia" },
                new Town() { Name = "Stara Zagora" },
                new Town() { Name = "Varna" },
                new Town() { Name = "Veliko Tarnovo" });

                context.SaveChanges();
            }

            // ADD VENDORS
            if (!context.Vendors.Any())
            {
                context.Vendors.AddOrUpdate(v => v.BulstratUI,
                new Vendor() { Name = "Zagorka LTD.", Address = "Han Asparuh St 41", TownId = 2, BulstratUI = "123138680" },
                new Vendor() { Name = "Nestle Bulgaria AD", Address = "Europa Str.128", TownId = 1, BulstratUI = "831650349" });

                context.SaveChanges();
            }

            // ADD PRODUCTS
            if (!context.Products.Any())
            {
                context.Products.AddOrUpdate(p => p.Name,
                new Product() { Name = "Ice cream BOSS", Price = 2.5m, Measure = Measure.Pcs, VendorId = 2 },
                new Product() { Name = "Ice cream MAGNUM", Price = 2m, Measure = Measure.Pcs, VendorId = 2 },
                new Product() { Name = "Ice cream FAMILIA", Price = 1.5m, Measure = Measure.Pcs, VendorId = 2 },
                new Product() { Name = "Ice cream ALOMA", Price = 1.5m, Measure = Measure.Pcs, VendorId = 2 },
                new Product() { Name = "Ice cream NIRVANA", Price = 1.5m, Measure = Measure.Pcs, VendorId = 2 },
                new Product() { Name = "Heineken 0.33", Price = 1.51m, Measure = Measure.Pcs, VendorId = 1 },
                new Product() { Name = "Heineken 0.33 can", Price = 1.45m, Measure = Measure.Pcs, VendorId = 1 },
                new Product() { Name = "Zagorka 1.5", Price = 2.45m, Measure = Measure.Pcs, VendorId = 1 },
                new Product() { Name = "Zagorka 0.5", Price = 0.6m, Measure = Measure.Pcs, VendorId = 1 });

                context.SaveChanges();
            }

            // ADD SUPERMARKETS
            if (!context.Supermarkets.Any())
            {
                context.Supermarkets.AddOrUpdate(s => s.Id,
                new Supermarket() { Name = "Sp1", Location = "center" },        // TOWN ID 3
                new Supermarket() { Name = "Sp2", Location = "primorski" });    // TONW ID 3

                context.SaveChanges();
            }

            // ADD SALES
            if (!context.Sales.Any())
            {
                var products = context.Products.Select(p => new { p.Id, p.Price });

                var suppermarkets = context.Supermarkets.Select(supp => new { supp.Id });

                var date = new DateTime(2014, 07, 20);

                for (var i = 0; i < 10; i++)
                {
                    foreach (var supp in suppermarkets)
                    {
                        foreach (var pr in products)
                        {
                            context.Sales.AddOrUpdate(new Sale()
                            {
                                Date = date,
                                ProductId = pr.Id,
                                Price = pr.Price,
                                Quantity = 2,
                                SupermarketId = supp.Id,
                                ItemSum = 2 * pr.Price,
                                // Product = context.Products.Find(pr.Id),
                                // Supermarket = context.Supermarkets.Find(supp.Id)
                            });
                        }
                    }

                    date = date.AddDays(1);
                }

                // SAVE SALES
                context.SaveChanges();
            }
        }
    }
}
