using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Test03
{
    class Program
    {
        
    
          static void Main()
        {
            using (FileStream fileStream = new FileStream("testpdf.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            using (Document pdfDocument = new Document())
            using (var mssqlContext = new SalesEntities())
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, fileStream);

                pdfDocument.Open();

                PdfPTable mainTable = new PdfPTable(5);
                PdfPCell mainHeaderCell = new PdfPCell(new Phrase("Aggregated Sales Report"));
                mainHeaderCell.Colspan = 5;
                mainHeaderCell.HorizontalAlignment = 1;
                mainTable.AddCell(mainHeaderCell);


                var saleReportsByDate = from Sale in mssqlContext.Sales
                    join product in mssqlContext.Products on Sale.ProductId equals product.Id
                    join supermarket in mssqlContext.Supermarkets on Sale.SupermarketId equals supermarket.Id
                    group Sale by Sale.Date;

                decimal grandTotalSum = 0;

                foreach (var date in saleReportsByDate)
                {
                    decimal totalSum = 0;

                    PdfPCell dateHeaderCell = new PdfPCell(new Phrase("Date: " + date.Key));
                    dateHeaderCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    dateHeaderCell.Colspan = 5;
                    dateHeaderCell.HorizontalAlignment = 0;

                    mainTable.AddCell(dateHeaderCell);

                    mainTable.AddCell(new PdfPCell(new Phrase("Product")));
                    mainTable.AddCell(new PdfPCell(new Phrase("Quantity")));
                    mainTable.AddCell(new PdfPCell(new Phrase("Unit Price")));
                    mainTable.AddCell(new PdfPCell(new Phrase("Location")));
                    mainTable.AddCell(new PdfPCell(new Phrase("Sum")));

                    foreach (var record in date)
                    {
                        mainTable.AddCell(new PdfPCell(new Phrase(record.Product.Name)));
                        mainTable.AddCell(new PdfPCell(new Phrase(record.Quantity.ToString())));
                        mainTable.AddCell(new PdfPCell(new Phrase(record.Price.ToString())));
                        mainTable.AddCell(new PdfPCell(new Phrase(record.Supermarket.Name)));
                        mainTable.AddCell(new PdfPCell(new Phrase((record.Quantity * record.Price).ToString())));

                        totalSum += record.Quantity * record.Price;
                    }

                    PdfPCell totalSumCellTitle = new PdfPCell(new Phrase("Total sum for " + date.Key + ":"));
                    totalSumCellTitle.Colspan = 4;
                    totalSumCellTitle.HorizontalAlignment = 1;

                    PdfPCell totalSumCell = new PdfPCell(new Phrase(totalSum.ToString()));
                    totalSumCell.HorizontalAlignment = 1;

                    mainTable.AddCell(totalSumCellTitle);
                    mainTable.AddCell(totalSumCell);

                    grandTotalSum += totalSum;
                }

                PdfPCell grandTotalCellTitle = new PdfPCell(new Phrase("Grand total:"));
                grandTotalCellTitle.Colspan = 4;
                grandTotalCellTitle.HorizontalAlignment = 1;
                grandTotalCellTitle.BackgroundColor = BaseColor.CYAN;

                PdfPCell grandTotalCell = new PdfPCell(new Phrase(grandTotalSum.ToString()));
                grandTotalCell.HorizontalAlignment = 1;
                grandTotalCell.BackgroundColor = BaseColor.CYAN;

                mainTable.AddCell(grandTotalCellTitle);
                mainTable.AddCell(grandTotalCell);

                pdfDocument.Add(mainTable);
                pdfDocument.Close();
                pdfDocument.Close();

                pdfWriter.Close();   
            }
        }
    }
}
