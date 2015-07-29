using System.Data.Entity.Migrations;
using System.Linq;
using SalesSystem.Data;
using SalesSystem.Model;

namespace ReplicateOracleDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlContext = new SalesSystemContext();

            ReplicateTowns(sqlContext);
            ReplicateVendors(sqlContext);
            ReplicateProducts(sqlContext);
          
         /* TESTING THE CONNECTIONS
          * var sqlContext = new SalesSystemContext();
          var product = sqlContext.Towns.Select(p => p.Name);
          foreach (var p in product)
          {
              Console.WriteLine(p);
          }
          Console.WriteLine("end of sqldata print");
            
          var orcleContext = new OracleEntities();
          var mesurments = orcleContext.MEASURES.Select(m => m.NAME);
          foreach (var mes in mesurments)
          {
              Console.WriteLine(mes);
          }
            */
        }

        private static void ReplicateProducts(SalesSystem.Data.SalesSystemContext sqlContext)
        {
            var oracleDb = new OracleEntities();
            var products = oracleDb.PRODUCTS.Select(p => new
            {
                p.NAME,
                p.MESURE_ID,
                p.PRICE,
                p.VENDOR_ID,

            });
            if (!sqlContext.Products.Any())
            {
                foreach (var product in products)
                {
                    sqlContext.Products.AddOrUpdate(p => p.Name,
                    new Product()
                    {
                        Name = product.NAME,
                        Price = product.PRICE,
                        VendorId = (int)product.VENDOR_ID
                    });
                }

            }
            sqlContext.SaveChanges();
        }

        private static void ReplicateVendors(SalesSystem.Data.SalesSystemContext sqlContext)
        {
            var oracleDb = new OracleEntities();
            var vendors = oracleDb.VENDORS.Select(v => new
            {
                v.NAME,
                v.ADDRESS,
                v.BULSTAT,
                v.TOWN_ID
            });

            if (!sqlContext.Vendors.Any())
            {
                foreach (var vendor in vendors)
                {
                    sqlContext.Vendors.AddOrUpdate(v => v.BulstratUI,
                    new Vendor() { Name = vendor.NAME, Address = vendor.ADDRESS, TownId = (int)vendor.TOWN_ID, BulstratUI = vendor.BULSTAT });
                }
                sqlContext.SaveChanges();
            }
        }

        private static void ReplicateTowns(SalesSystem.Data.SalesSystemContext sqlContext)
        {
            var oracleDb = new OracleEntities();
            var towns = oracleDb.TOWNS.Select(t => t.NAME).ToList();

            if (!sqlContext.Towns.Any())
            {
                foreach (var town in towns)
                {
                    sqlContext.Towns.AddOrUpdate(t => t.Name,
                    new Town() { Name = town });
                }
            }
            sqlContext.SaveChanges();
        }
    }
}
