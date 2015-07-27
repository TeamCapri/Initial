using OfficeOpenXml;
using OfficeOpenXml.Style;
using SalesSystem.MySQL.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.SQLite.Data;

namespace DB_TeamCapri.Problems
{
    class SQLiteMySQLExport
    {
        private MySQLContext mySql;
        private TaxesEntities sqlite;
        private int index = 2;
        private ExcelPackage pck;

        public SQLiteMySQLExport(MySQLContext mysqlContext, TaxesEntities sqliteCotext)
        {
            this.mySql = mysqlContext;
            this.sqlite = sqliteCotext;
        }

        public void exportXLSX(string filePath)
        {
            var taxes = this.sqlite.ProductTaxes.Select(t => new
            {
                t.ProductName,
                t.TaxPercent
            }).ToList();

            var sales = this.mySql.Sales.GroupBy(s => new { s.Product.Vendor.Name, product = s.Product.Name, s.Price }).Select(s => new
            {
                vendor = s.FirstOrDefault().Product.Vendor.Name,
                product = s.FirstOrDefault().Product.Name,
                price = s.FirstOrDefault().Price,
                quantity = s.Sum(a => a.Quantity)
            }).OrderBy(s => s.vendor).ToList();

            this.index = 2;
            string file = filePath + "\\report " + DateTime.Now.ToString("dd-MMM-yyyy HH-mm-ss") + ".xlsx";
            ExcelWorksheet ws = createXLSX(file);

            var vendors = sales.Select(s => s.vendor).Distinct();
            foreach (var v in vendors)
            {
                int startRow = createTableHeader(ws, v);

                var products = getSalesByVendor(v, sales);
                foreach (var product in products)
                {
                    var tax = taxes.Where(t => t.ProductName == product.product).Select(t => t.TaxPercent).FirstOrDefault();
                    addTableContent(ws, product, tax);
                }

                createTableFooter(ws, startRow);

                createTableBorder(ws, startRow);
                index += 2;
            }

            saveXLSX();
        }

        private void createTableBorder(ExcelWorksheet ws, int startRow)
        {
            ws.Cells["C" + startRow + ":H" + index].Style.Border.Top.Style = ExcelBorderStyle.Medium;
            ws.Cells["C" + startRow + ":H" + index].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
            ws.Cells["C" + startRow + ":H" + index].Style.Border.Left.Style = ExcelBorderStyle.Medium;
            ws.Cells["C" + startRow + ":H" + index].Style.Border.Right.Style = ExcelBorderStyle.Medium;
        }

        private void createTableFooter(ExcelWorksheet ws, int startRow)
        {
            ws.Cells["C" + index + ":E" + index].Merge = true;
            ws.Cells["C" + index].Value = "Total";
            ws.Cells["C" + index].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["F" + index].Formula = string.Format("=SUM(F" + (startRow + 2) + ":F" + (index - 1) + ")");
            ws.Cells["G" + index].Formula = string.Format("=SUM(G" + (startRow + 2) + ":G" + (index - 1) + ")");
            ws.Cells["H" + index].Formula = string.Format("=SUM(H" + (startRow + 2) + ":H" + (index - 1) + ")");
        }

        private void addTableContent(ExcelWorksheet ws, dynamic product, double tax)
        {
            ws.Cells[index, 3].Value = product.product;
            ws.Cells[index, 4].Value = product.quantity;
            ws.Cells[index, 5].Value = product.price;
            ws.Cells[index, 6].Formula = string.Format("={0}*{1}", ExcelCellBase.GetAddress(index, 4), ExcelCellBase.GetAddress(index, 5));

            ws.Cells[index, 7].Formula = string.Format("={0}*({1}/{2})", ExcelCellBase.GetAddress(index, 6), tax, 100);
            ws.Cells[index, 8].Formula = string.Format("={0}-{1}", ExcelCellBase.GetAddress(index, 6), ExcelCellBase.GetAddress(index, 7));
            index++;
        }

        private int createTableHeader(ExcelWorksheet ws, string v)
        {
            int startRow = index;
            ws.Cells["C" + index + ":H" + index].Merge = true;
            ws.Cells["C" + index].Value = v;
            ws.Cells["C" + index].Style.Font.Bold = true;
            ws.Cells["C" + index].Style.Font.Size = 16;
            ws.Cells["C" + index].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            index++;

            ws.Cells["C" + index].Value = "Product";
            ws.Cells["D" + index].Value = "Quantity";
            ws.Cells["E" + index].Value = "Price";
            ws.Cells["F" + index].Value = "Total Sum";
            ws.Cells["G" + index].Value = "Taxes";
            ws.Cells["H" + index].Value = "Profit";
            ws.Cells["C" + index + ":H" + index].Style.Font.Bold = true;
            index++;

            return startRow;
        }

        private void saveXLSX()
        {
            this.pck.Save();
        }

        private ExcelWorksheet createXLSX(string filePath)
        {
            FileInfo newFile = new FileInfo(filePath);
            this.pck = new ExcelPackage(newFile);

            var ws = this.pck.Workbook.Worksheets.Add("Reports");
            ws.View.ShowGridLines = true;

            return ws;
        }

        private List<dynamic> getSalesByVendor(string vendor, IEnumerable<dynamic> sales)
        {
            return sales.Where(s => s.vendor == vendor).ToList();
        }
    }
}
