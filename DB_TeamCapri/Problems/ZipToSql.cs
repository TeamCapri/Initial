namespace DB_TeamCapri.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using DB_TeamCapri.Properties;
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
    using SalesSystem.Data;
    using SalesSystem.Model;
    internal class ZipToSql
    {
        private const string TempFolderForExtract = @"../../Temp";

        // MIGRATE DATA
        public static void MigrateData(string zipFilePath)
        {
            ExtractZipFile(zipFilePath);
            using (var db = new SalesSystemContext())
            {
                IList<Sale> allSales = new List<Sale>();

                GetSales(TempFolderForExtract, db, allSales);

                foreach (var sale in allSales)
                {
                    db.Sales.Add(sale);
                }

                db.SaveChanges();
            }

            Directory.Delete(TempFolderForExtract, true);
        }

        // EXTRACT ZIP FILE
        private static void ExtractZipFile(string filePath)
        {
            var fileReadStram = File.OpenRead(filePath);
            var zipFile = new ZipFile(fileReadStram);

            // USING ZIP
            using (zipFile)
            {
                foreach (ZipEntry entry in zipFile)
                {
                    if (entry.IsFile)
                    {
                        var entryFileName = entry.Name;
                        var buffer = new byte[4096];
                        var zipStream = zipFile.GetInputStream(entry);

                        var zipToPath = Path.Combine(TempFolderForExtract, entryFileName);
                        var directoryName = Path.GetDirectoryName(zipToPath);

                        if (directoryName != null && directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        using (var streamWriter = File.Create(zipToPath))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
                    }
                }
            }
        }

        // GET SALES
        private static void GetSales(string directory, SalesSystemContext db, IList<Sale> sales)
        {
            foreach (var sale in GetSalesFromExcelFiles(directory, db))
            {
                sales.Add(sale);
            }

            string[] subDirectories = Directory.GetDirectories(directory);

            if (subDirectories.Length > 0)
            {
                foreach (var subDirectory in subDirectories)
                {
                    GetSales(subDirectory, db, sales);
                }
            }
        }

        // GET SALES FROM EXCEL FILES
        private static ICollection<Sale> GetSalesFromExcelFiles(string directory, SalesSystemContext db)
        {
            IList<Sale> sales = new List<Sale>();

            string[] excelFilePaths = Directory.GetFiles(directory, @"*.xls");

            foreach (var excelFilePath in excelFilePaths)
            {
                var excelConnectionString = String.Format(Settings.Default.ExcelReadConnectionString, excelFilePath);

                var excelConnection = new OleDbConnection(excelConnectionString);
                excelConnection.Open();
                DataSet dataSet = new DataSet();

                using (excelConnection)
                {
                    var selectAllRowsCommandString = "SELECT * FROM [Sales$]";

                    var selectAllRowsCommand = new OleDbCommand(selectAllRowsCommandString, excelConnection);

                    var excelAdapter = new OleDbDataAdapter(selectAllRowsCommand);
                    excelAdapter.Fill(dataSet, @"Sales");
                }

                var excelRows = dataSet.Tables[@"Sales"].Rows;
                var supermarketName = excelRows[0][0].ToString();

                if (!db.Supermarkets.Any(s => s.Name == supermarketName))
                {
                    db.Supermarkets.Add(new Supermarket()
                    {
                        Name = supermarketName,
                        Location = supermarketName.Replace("Supermarket", "").Trim()  // setwane na lokaciqta
                    });

                    db.SaveChanges();
                }

                var rowsCount = excelRows.Count;
                for (int i = 2; i < rowsCount - 1; i++) // rowsCount-1 - za da se izkliuchi totala
                {
                    var productName = excelRows[i][0].ToString();
                    var product = db.Products.FirstOrDefault(p => p.Name == productName);

                    // pepster's code        
                    bool isAdded = false;
                    string saleDateString = Path.GetFileName(Path.GetDirectoryName(excelFilePath));
                    int supermarketId = db.Supermarkets.First(s => s.Name == supermarketName).Id;

                    if (db.Sales.Any())
                    {
                        var addedsales = db.Sales.Select(s => new
                        {
                            Date = s.Date,
                            Spp = s.SupermarketId,
                        });
                        foreach (var addsale in addedsales)
                        {
                            if (addsale.Date == DateTime.Parse(saleDateString) && addsale.Spp == supermarketId)
                            {
                                isAdded = true;
                            }
                        }
                    }

                    // end pepster's code              


                    // IF PRODUCT EXIST

                    if (product != null && isAdded == false)
                    {
                        int productId = product.Id,
                            quantity;

                        int.TryParse(excelRows[i][1].ToString(), out quantity);

                        decimal price;
                        decimal.TryParse(excelRows[i][2].ToString(), out price);
                        //            string saleDateString = Path.GetFileName(Path.GetDirectoryName(excelFilePath)); premesteno na 141 red
                        //            int supermarketId = db.Supermarkets.First(s => s.Name == supermarketName).Id; premesteno 142 red

                        sales.Add(new Sale()
                        {
                            Date = DateTime.Parse(saleDateString),
                            Product = db.Products.Find(productId),
                            Quantity = quantity,
                            Supermarket = db.Supermarkets.Find(supermarketId),
                            Price = price
                        });
                    }
                    // ADD NEW PRODUCT
                    else
                    {
                        // todo add new product
                        db.Products.Add(new Product()
                        {
                            Name = productName,
                            VendorId = 1,
                            Measure = new Measure(),
                            Price = 1
                        });

                        db.SaveChanges();
                    }
                }
            }

            // RETURN VALUE
            return sales;
        }
    }
}
