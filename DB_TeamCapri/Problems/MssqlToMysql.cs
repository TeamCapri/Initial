using SalesSystem.MySQL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesSystem.Data;
using SalesSystem.Model;
using System.Data.Entity.Migrations;

namespace DB_TeamCapri.Problems
{
    class MssqlToMysql
    {
        private MySQLContext mysql;
        private SalesSystemContext mssql;

        public MssqlToMysql(MySQLContext mysql, SalesSystemContext mssql)
        {
            this.mssql = mssql;
            this.mysql = mysql;
        }

        public void Transferdata()
        {
            var smysql = this.mysql.Sales.Count();
            transferTowns();

            transfervendors();

            transferExpenses();

            transferproduts();

            transferSupermarket();

            trsnaferSales();
        }

        private void trsnaferSales()
        {
           
            var sales = this.mssql.Sales.ToList();
            foreach (var s in sales)
            {
                this.mysql.Sales.AddOrUpdate(sl=>new {sl.Date,sl.ProductId,sl.SupermarketId}, new Sale()
                {
                    Date = s.Date,
                    SupermarketId = this.mysql.Supermarkets.Where(t => t.Name == s.Supermarket.Name).Select(t => t.Id).FirstOrDefault(),
                    Quantity = s.Quantity,
                    ProductId = this.mysql.Products.Where(t => t.Name == s.Product.Name).Select(t => t.Id).FirstOrDefault(),
                    Price = s.Price,
                    ItemSum = s.ItemSum
                });
            }

            this.mysql.SaveChanges();
        }

        private void transferSupermarket()
        {
            var supermarkets = this.mssql.Supermarkets.ToList();
            foreach (var p in supermarkets)
            {
                this.mysql.Supermarkets.AddOrUpdate(pr => pr.Name, new Supermarket()
                {
                    Location = p.Location,
                    Name = p.Name,
                });
            }

            this.mysql.SaveChanges();
        }

        private void transferproduts()
        {
            var products = this.mssql.Products.ToList();
            foreach (var p in products)
            {
                this.mysql.Products.AddOrUpdate(pr => pr.Name, new Product()
                {
                    Name = p.Name,
                    Measure = p.Measure,
                    Price = p.Price,
                    VendorId = this.mysql.Vendors.Where(t => t.Name == p.Vendor.Name).Select(t => t.Id).FirstOrDefault()
                });
            }

            this.mysql.SaveChanges();
        }

        private void transferExpenses()
        {
            var expenses = this.mssql.Expenses.ToList();
            foreach (var e in expenses)
            {
                this.mysql.Expenses.AddOrUpdate(ex=>new {ex.Period,ex.VendorId}, new Expense()
                {
                    Period = e.Period,
                    Total = e.Total,
                    VendorId = this.mysql.Vendors.Where(t => t.Name == e.Vendor.Name).Select(t => t.Id).FirstOrDefault()
                });

            }

            this.mysql.SaveChanges();
        }

        private void transfervendors()
        {
            var vendors = this.mssql.Vendors.ToList();
            foreach (var v in vendors)
            {
                this.mysql.Vendors.AddOrUpdate(tw => tw.Name, new Vendor()
                {
                    Name = v.Name,
                    TownId = this.mysql.Towns.Where(t => t.Name == v.Town.Name).Select(t => t.Id).FirstOrDefault(),
                    Address = v.Address,
                    BulstratUI = v.BulstratUI
                });
            }

            this.mysql.SaveChanges();
        }

        private void transferTowns()
        {
            var towns = this.mssql.Towns.ToList();

            foreach (var t in towns)
            {
                this.mysql.Towns.AddOrUpdate(tw => tw.Name, new Town()
                {
                    Name = t.Name
                });
            }

            this.mysql.SaveChanges();
        }
    }
}
