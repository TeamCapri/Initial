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
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "SalesSystem.Data.SalesSystemContext";
            }

        protected override void Seed(SalesSystemContext context)
            {
            //add towns
            
            if (!context.Towns.Any())
            {
                context.Towns.AddOrUpdate(new Town()
                    {
                    Name = "Sofia"
                    });
                context.Towns.AddOrUpdate(new Town()
                    {
                    Name = "Stara Zagora"
                    });
                context.Towns.AddOrUpdate(new Town()
                    {
                    Name = "Varna"
                    });
                context.Towns.AddOrUpdate(new Town()
                    {
                    Name = "Veliko Tarnovo"
                    });
                context.SaveChanges();
                }
            
            // add vendors
            if (!context.Vendors.Any())
            {
                context.Vendors.AddOrUpdate(new Vendor()
                    {
                    Name = "Zagorka LTD.",
                    Address = "Han Asparuh St 41",
                    TownId = 2,
                    BulstratUI = "123138680"
                    });
                context.Vendors.AddOrUpdate(new Vendor()
                    {
                    Name = "Nestle Bulgaria AD",
                    Address = "Europa Str.128",
                    TownId = 1,
                    BulstratUI = "831650349"
                    });
                context.SaveChanges();
                }
      
            //add products
            if (! context.Products.Any())
            {
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Ice cream BOSS",
                    Price = 2.5m,
                    Measure = Measure.pcs,
                    VendorId = 2
                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Ice cream MAGNUM",
                    Price = 2m,
                    Measure = Measure.pcs,
                    VendorId = 2
                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Ice cream FAMILIA",
                    Price = 1.5m,
                    Measure = Measure.pcs,
                    VendorId = 2
                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Ice cream ALOMA",
                    Price = 1.5m,
                    Measure = Measure.pcs,
                    VendorId = 2
                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Ice cream NIRVANA",
                    Price = 1.5m,
                    Measure = Measure.pcs,
                    VendorId = 2
                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Heineken 0.33",
                    Price = 1.51m,
                    Measure = Measure.pcs,
                    VendorId = 1

                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Heineken 0.33 can",
                    Price = 1.45m,
                    Measure = Measure.pcs,
                    VendorId = 1
                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Zagorka 1.5",
                    Price = 2.45m,
                    Measure = Measure.pcs,
                    VendorId = 1
                    });
                context.Products.AddOrUpdate(new Product()
                    {
                    Name = "Zagorka 0.5",
                    Price = 0.6m,
                    Measure = Measure.pcs,
                    VendorId = 1
                    });
                context.SaveChanges();
                }
           
            //add supermarkets
            if (!context.Supermarkets.Any())
            {
                context.Supermarkets.AddOrUpdate(new Supermarket()
                    {
                    Name = "Sp1",
                    Location = "center"
                    //TownId = 3
                    });
                context.Supermarkets.AddOrUpdate(new Supermarket()
                    {
                    Name = "Sp2",
                    Location = "primorski"
                    //TownId = 3
                    });
                context.SaveChanges();
                }
          
           
            //add sales
            if (! context.Sales.Any())
            {
                var products = context.Products.Select(p => new
                {
                    p.Id,
                    p.Price
                 });

                var suppermarkets = context.Supermarkets.Select(supp => new
                {
                    supp.Id
                });
                var date = new DateTime(2014, 07, 20);
                for (int i =  0; i < 10; i++)
                {
                    foreach (var supp in suppermarkets)
                    {
                        foreach (var pr in products)
                        {
                            context.Sales.AddOrUpdate( new Sale()
                            {
                                Date = date,
                                ProductId = pr.Id,
                                Price = pr.Price,
                                Quantity = 2,
                                SupermarketId = supp.Id,
                                ItemSum = 2*pr.Price,
                             //   Product = context.Products.Find(pr.Id),
                               // Supermarket = context.Supermarkets.Find(supp.Id)
                                });
                        }
                    }
                    date = date.AddDays(1);

                }
               

         
                context.SaveChanges();

            }
            
            }

        }
    }
