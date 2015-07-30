namespace DB_TeamCapri.Problems
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using SalesSystem.Data;
    using SalesSystem.Model;

    public static class XmlToSql
    {
        public static void PushXmlToDb(string filePath)
        {
            try
            {
                // LOAD XML
                XDocument xmlDocument = XDocument.Load(filePath);

                var vendors = xmlDocument.Descendants("vendor");

                if (vendors.Any() == false)
                {
                    throw new ArgumentException(@"No data found, ensure that the file contains any vendors reports.");
                }
                else
                {
                    using (var db = new SalesSystemContext())
                    {
                        foreach (var vendor in vendors)
                        {
                            // VENDRO NAME
                            var vendorName = vendor.FirstAttribute.Value;

                            var vendorExpenses = vendor.Descendants("expenses");

                            // VENDOR ID
                            var vendorId = db.Vendors.FirstOrDefault(v => v.Name == vendorName).Id;

                            foreach (var vendorExpense in vendorExpenses)
                            {
                                // EXPENSE PERIOD (MONTH - YEAR)
                                var vendorExpensePeriod = vendorExpense.FirstAttribute.Value;

                                // EXPENSE TOTAL (MONEY)
                                var vendorExpenseTotal = decimal.Parse(vendorExpense.Value);

                                // ADD EXPENSE
                                db.Expenses.Add(new Expense()
                                {
                                    VendorId = vendorId,
                                    Period = vendorExpensePeriod,
                                    Total = vendorExpenseTotal
                                });
                            }
                        }

                        // ON SUCCESS
                        db.SaveChanges();
                        MessageBox.Show(@"Xml data successiful imported in MSSQL database.");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
    }
}
