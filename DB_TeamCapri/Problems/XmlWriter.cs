namespace DB_TeamCapri.Problems
{
    using System;
    using System.Globalization;
    using System.Text;
    using SalesSystem.Data;

    using System.Linq;
    using System.Collections.Generic;

    using System.Xml;
    using System.Windows.Forms;


    public static class XmlWriter
    {
        public static void GenerateXmlReport(string startDate, string endDate)
        {
            // INIT DB
            using (var db = new SalesSystemContext())
            {

                // PARSE INPUT DATES TO DATETIME
                DateTime fromDate = DateTime.ParseExact(startDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                          toDate = DateTime.ParseExact(endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);


                // QUERY
                var sales = db.Sales
                    .Where(s => s.Date >= fromDate && s.Date <= toDate)
                    .Select(sale => new
                    {
                        VendroName = sale.Product.Vendor.Name,
                        SaleDate = sale.Date,
                        Price = sale.Product.Price,
                        Quantity = sale.Quantity
                    }).GroupBy(r => r.VendroName).OrderBy(r => r.Key);

                // IF QUERY CANT RETURN DATA
                if (sales.ToList().Count < 1)
                {
                    MessageBox.Show(@"No data found.");
                }
                else
                {
                    var reports = new Dictionary<string, Dictionary<string, decimal>>();

                    // GET DATA FROM RETURNED QUERY
                    foreach (var report in sales)
                    {
                        // VENDOR NAME
                        string vendorName = report.Key;

                        // SALE INFO (DATE/PRICE)
                        var saleInfo = new Dictionary<string, decimal>();

                        foreach (var sale in report)
                        {
                            // SALE DATE [MONTH-YEAR]
                            string saleDate = String.Format("{0:MMM}-{0:yyyy}", sale.SaleDate);

                            // TOTAL PRICE [PRICE * QUANTITY]
                            decimal saleTotalPrice = sale.Price * sale.Quantity;

                            // IF SELL INFO DOES NOT CONTAIN THE DATE - ADD DATA
                            if (!saleInfo.ContainsKey(saleDate))
                            {
                                saleInfo.Add(saleDate, saleTotalPrice);
                            }
                            // ELSE UPDATE DATA
                            else
                            {
                                saleInfo[saleDate] += saleTotalPrice;
                            }
                        }

                        // ADD DATA TO REPORTS
                        reports.Add(vendorName, saleInfo);
                    }

                    // GENERATE XML
                    // XML CONFIGS

                    const string fileName = "../../sales-by-vendor.xml";
                    var encoding = Encoding.GetEncoding(@"Windows-1251");

                    using (var writer = new XmlTextWriter(fileName, encoding))
                    {
                        // WRITER CONFIGS
                        writer.Formatting = Formatting.Indented;
                        writer.IndentChar = '\t';
                        writer.Indentation = 1;

                        // DOCUMENT START
                        writer.WriteStartDocument();

                        // WRITE DOCUMENT
                        writer.WriteStartElement(@"expenses-by-month");

                        foreach (var report in reports)
                        {
                            // REPORT VENDOR
                            string vendor = report.Key;

                            writer.WriteStartElement(@"vendor");
                            writer.WriteAttributeString(@"name", vendor);

                            foreach (var data in report.Value)
                            {
                                // REPORT [DATE] - [TOTAL]
                                string reportDate = data.Key,
                                       reportTotal = data.Value.ToString("0.00");

                                writer.WriteStartElement(@"expenses");
                                writer.WriteAttributeString(@"month", reportDate);
                                writer.WriteString(reportTotal);
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();
                        }
                        // DOCUMENT END
                        writer.WriteEndDocument();
                    }
                    // ON COMPLETE
                    MessageBox.Show(@"Done generated reports in DB_TeamCapri/sales-by-vendor.xml");
                }
            }
        }
    }
}
