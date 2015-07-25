using Supermarket.Data;

using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace Supermarket.Client
{
    class MSSQLtoMongo : SalesByProductReport
    {
        private static string JsonReports_FolderPath = @"../../../";
        private static string folderName = "Json-Reports";
        private static string databaseName_MongoDB = "Sales-Reports";
        private static string collectionName_MongoDB = "SalesByProductReports";
        static void Main()
        {
            DateTime startDate = new DateTime(2015, 04, 5, 12, 0, 56);
            DateTime endDate = new DateTime(2015, 05, 5, 0, 0, 0);

            string periodJSON = TimeSpanInJSON(startDate, endDate);
            DateTime[] dates = returnDatesFromJSONPeriod(periodJSON);

            string[] jsonReports = returnJSONSalesReports(dates[0], dates[1]);

            GenerateJSONFilesInGivenFolder(jsonReports);

            Load_JSONReports_into_MongoDB(jsonReports);
        }

        private static void Load_JSONReports_into_MongoDB(string[] jsonReports)
        {
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase(databaseName_MongoDB);

            var collection = db.GetCollection<BsonDocument>(collectionName_MongoDB);
            collection.RemoveAll();

            foreach (var report in jsonReports)
            {
                var mongoReport = BsonSerializer.Deserialize<BsonDocument>(report);
                collection.Save(mongoReport);
            }
        }

        private static void GenerateJSONFilesInGivenFolder(string[] jsonReports)
        {
            CreateFolerIfExists(folderName);
            string productID = null;
            foreach (var report in jsonReports)
            {
                productID = report.Substring("{\"product-id\":".Length, report.IndexOf(',') - "{\"product-id\":".Length);
                System.IO.File.WriteAllText(JsonReports_FolderPath + folderName + "//" + productID + ".json", report.Replace("\\", ""));
            }
        }
        private static string[] returnJSONSalesReports(DateTime startDate, DateTime endDate)
        {
            List<string> salesReportsJSON = new List<string>();

            using (var ctx = new SalesEntities())
            {
                var sales = ctx.Sales.Where(s => s.SaledOn >= startDate && s.SaledOn <= endDate).GroupBy(s => new { s.ProductId, s.Product.Name, VendorName = s.Product.Vendor.Name })
                    .Select(gr => new SalesByProductReport()
                    {
                        product_id = gr.Key.ProductId,
                        product_name = gr.Key.Name,
                        vendor_name = gr.Key.VendorName,
                        total_quantity_sold = gr.Sum(s => s.Quantity),
                        total_incomes = gr.Sum(s => s.Product.Price)
                    }).ToList();


                foreach (var sale in sales)
                {
                    string jsonReport = JsonConvert.SerializeObject(sale).Replace('_', '-');
                    salesReportsJSON.Add(jsonReport);                    
                }

                return salesReportsJSON.ToArray();
            }
        }

        private static void CreateFolerIfExists(string folderName)
        {
            System.IO.Directory.CreateDirectory(JsonReports_FolderPath + folderName);
        }

        private static string TimeSpanInJSON(DateTime startDate, DateTime endDate)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var startDateJSON = javaScriptSerializer.Serialize(startDate);
            var endDateJSON = javaScriptSerializer.Serialize(endDate);
            string period = "{\"start\":" + startDateJSON + ",\"end\":" + endDateJSON + "}";

            return period;
        }

        private static DateTime[] returnDatesFromJSONPeriod(string periodJSON)
        {
            string pattern = @"([0-9]+)";
            List<DateTime> dates = new List<DateTime>();

            foreach (Match m in Regex.Matches(periodJSON, pattern))
            {
                dates.Add(new DateTime(1970, 1, 1).AddMilliseconds(Int64.Parse(m.Value)));
            }

            return dates.ToArray();
        }                   
                
    }
}
