using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TestPdf
{



    internal class TestPdf1
    {


        static void Main()
        {
            FileStream fs = new FileStream("Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Add(new Paragraph("Hello World"));
            doc.Add(new Paragraph("Hello World"));
            doc.Add(new Paragraph("Hello World"));
            doc.Close();

        }

    }
}