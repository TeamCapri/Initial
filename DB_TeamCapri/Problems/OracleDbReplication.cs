namespace DB_TeamCapri.Problems
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ReplicateOracleDb;
    using SalesSystem.Data;
    using SalesSystem.Model;

    class OracleDbReplication
    {
        private SalesSystemContext context;
        public SalesSystemContext Context
        {
            get { return this.context; }
            set { this.context = new SalesSystemContext(); }
        }

        public void ExecuteReplication()
        {
            var context = new SalesSystemContext();
            int count = context.Towns.Count();
            ReplicateTowns(context);
            ReplicateVendors(context);
            ReplicateProducts(context);
        }


        private void ReplicateProducts(SalesSystemContext sqlContext)
        {
            var oracleDb = new OracleEntities();
            var products = oracleDb.PRODUCTS.Select(p => new
            {
                p.NAME,
                p.MESURE_ID,
                p.PRICE,
                p.VENDOR_ID,

            });
            
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

            
            sqlContext.SaveChanges();
        }

        private void ReplicateVendors(SalesSystem.Data.SalesSystemContext sqlContext)
        {
            var oracleDb = new OracleEntities();
            var vendors = oracleDb.VENDORS.Select(v => new
            {
                v.NAME,
                v.ADDRESS,
                v.BULSTAT,
                v.TOWN_ID
            });

            
                foreach (var vendor in vendors)
                {
                    sqlContext.Vendors.AddOrUpdate(v => v.BulstratUI,
                    new Vendor() { Name = vendor.NAME, Address = vendor.ADDRESS, TownId = (int)vendor.TOWN_ID, BulstratUI = vendor.BULSTAT });
                }
                sqlContext.SaveChanges();
            
        }

        private void ReplicateTowns(SalesSystem.Data.SalesSystemContext sqlContext)
        {
            var oracleDb = new OracleEntities();
            var towns = oracleDb.TOWNS.Select(t => t.NAME).ToList();

            
                foreach (var town in towns)
                {
                    sqlContext.Towns.AddOrUpdate(t => t.Name,
                    new Town() { Name = town });
                }
            
            sqlContext.SaveChanges();
        }

    }
}
