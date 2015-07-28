using OfficeOpenXml;
using OfficeOpenXml.Style;
using SalesSystem.MySQL.Data;
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
using Taxes.SQLite.Data;

﻿namespace DB_TeamCapri
{
    using SalesSystem.MySQL.Data;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Taxes.SQLite.Data;
    using Problems;

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
                XmlWriter xml = new XmlWriter();
                xml.GenerateXmlReport(startDate, endDate, this.outputDir);
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
            JSONExport jExp = new JSONExport(toJSONReports.Checked, toMongoDB.Checked);

            jExp.exportJSONReports(startDateJSON.Value, endDateJSON.Value);
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
                var c = new SalesSystem.Data.SalesSystemContext();
                c.Towns.Add(new SalesSystem.Model.Town()
                {
                    Name = "aaaaaaaa"
                });
                c.SaveChanges();

                //textBox3.Text = c1.ToString();
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
            var sqlite = new TaxesEntities();
            var mysql = new MySQLContext();

            Problems.SQLiteMySQLExport export = new Problems.SQLiteMySQLExport(mysql, sqlite);
            export.exportXLSX(this.outputDir);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
