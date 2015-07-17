using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace _03.GeneratePdfReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Sales_Report.pdf", FileMode.Create));
            doc.Open();
            PdfPTable table = new PdfPTable(5);
            PdfPCell cell = new PdfPCell(new Phrase("Aggregated Sales Report"));
            cell.Colspan = 5;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            PdfPCell Date = new PdfPCell(new Phrase("Date"));
            Date.Colspan = 5;
            Date.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(Date);
            table.AddCell("Product");
            table.AddCell("Quantity");
            table.AddCell("Unit Price");
            table.AddCell("Location");
            table.AddCell("Sum");
            PdfPCell TotalSum = new PdfPCell(new Phrase("TotalSum"));
            TotalSum.Colspan = 4;
            TotalSum.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(TotalSum);
            table.AddCell("Sum");
            doc.Add(table);
            doc.Close();
        }
    }
}