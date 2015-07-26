﻿namespace DB_TeamCapri
{
    using SalesSystem.MySQL.Data;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Taxes.SQLite.Data;
    using static Problems.XmlWriter;

    public partial class MainForm : Form
    {
        public String ZipFilePath;
        public String xmlFilePath;
        public String outputDir;

        public MainForm()
        {
            InitializeComponent();
            SetVisualSettings();

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\DBs";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        private String createFileDialog(String fileFilter, TextBox textBox)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Choose File";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = fileFilter;
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = fdlg.FileName;
                return fdlg.FileName;
            }

            return "";
        }

        private String createFolderBrowserDialog(TextBox textBox)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = fbd.SelectedPath;
                return fbd.SelectedPath;
            }

            return "";
        }

        private void chooseDir_Click(object sender, EventArgs e)
        {
            outputDir = createFolderBrowserDialog(textBox3);
        }


        /*
         * --- Problem 2 ---
         */
        private void oracleToMssqlCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (oracleToMssqlCheckbox.Checked)
            {
                ZipToMssqlBrowse.Enabled = false;
            }
            else
            {
                ZipToMssqlBrowse.Enabled = true;
            }
        }        

        private void ZipToMssqlBrowse_Click(object sender, EventArgs e)
        {
            String fileFilter = "ZIP files (*.zip)|*.zip";
            ZipFilePath = createFileDialog(fileFilter, textBox1);
        }

        private void insertIntoMssql_Click(object sender, EventArgs e)
        {
            if (oracleToMssqlCheckbox.Checked)
            {

                //

            }
            else if (ZipFilePath != "")
            {

                //

            }
        }


        // Problem(s) 3, 4 XML/PDF GENERATORS
        private void exportPdfXml_Click(object sender, EventArgs e)
        {
            var startDate = startDatePdfXml.Value.ToString("dd-MM-yyyy");
            var endDate = endDatePdfXml.Value.ToString("dd-MM-yyyy");

            if (toPDF.Checked)
            {
                // TODO...GENERATE PDF
            }
            else if (ToXML.Checked)
            {
                // GENERATE XML REPORTS BY VENDORS IN RANGE START DATE - END DATE
                GenerateXmlReport(startDate, endDate);
            }
            else
            {
                MessageBox.Show(@"Please select PDF or XML before to generate a report.");
            }
        }


        /*
         *  --- Problem 5 ---
         */
        private void toJSONMongo_Click(object sender, EventArgs e)
        {
            String startDate = startDateJSON.Value.ToString("dd-MM-yyyy");
            String endDate = endDateJSON.Value.ToString("dd-MM-yyyy");

            //

        }


        /*
         * --- Problem 6 ---
         */
        private void XMLBrowse_Click(object sender, EventArgs e)
        {
            String fileFilter = "XML files (*.xml)|*.xml";
            xmlFilePath = createFileDialog(fileFilter, textBox2);
        }

        private void xmlToMssql_Click(object sender, EventArgs e)
        {
            if (xmlFilePath != "")
            {

                //

            }
        }


        /*
         * --- Problem 7 ---
         */
        private void mssqlToMysql_Click(object sender, EventArgs e)
        {

            //

        }

        private void SetVisualSettings()
        {
            if (this.BackgroundImage != null)
            {
                var bm = new Bitmap(this.BackgroundImage, new Size(this.Width, this.Height));
                this.BackgroundImage = bm;
            }
        }

        private void sqliteMysql_Click(object sender, EventArgs e)
        {
            var taxes = new TaxesEntities();
            var mysql = new MySQLContext(); 
            
            //var c1 = this.mysql.Towns.Count();
            var c = taxes.ProductTaxes.Count();
            var c2 = mysql.Towns.Count();
            textBox3.Text = (c+c2).ToString();
            //var sales = mysql.Sales.Select(s => new
            //{
                
            //});
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
