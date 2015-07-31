﻿namespace DB_TeamCapri
{
    using SalesSystem.MySQL.Data;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Taxes.SQLite.Data;
    using Problems;

    public partial class MainForm : Form
    {
        public string ZipFilePath;
        public string XmlFilePath;
        public string OutputDir;

        public MainForm()
        {
            InitializeComponent();
            SetVisualSettings();

            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null)
            {
                var path = directoryInfo.FullName + "\\DBs";
                AppDomain.CurrentDomain.SetData(@"DataDirectory", path);
            }
        }

        private static string CreateFileDialog(string fileFilter, Control textBox)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = @"Choose File";
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

        private static string CreateFolderBrowserDialog(Control textBox)
        {
            var browseDialog = new FolderBrowserDialog();
            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = browseDialog.SelectedPath;
                return browseDialog.SelectedPath;
            }

            return "";
        }

        private void chooseDir_Click(object sender, EventArgs e)
        {
            OutputDir = CreateFolderBrowserDialog(textBox3);
        }

        // Problem 2
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
            const string fileFilter = "ZIP files (*.zip)|*.zip";
            ZipFilePath = CreateFileDialog(fileFilter, textBox1);
        }

        private void insertIntoMssql_Click(object sender, EventArgs e)
        {
          if (string.IsNullOrWhiteSpace(ZipFilePath) && !oracleToMssqlCheckbox.Checked)
            {
                MessageBox.Show(@"Firstly check Oracle to MSSQL or Browse for ZIP file please.");
            }
            else
            {
                if (oracleToMssqlCheckbox.Checked)
                {
                    var repl = new OracleDbReplication();
                    repl.ExecuteReplication();
                    MessageBox.Show(@"Task complete.");
                }
                else
                {
                    ZipToSql.MigrateData(ZipFilePath);
					 MessageBox.Show(@"Task complete.");
                }
            }
        }

        // Problems 3 - 4
        private void exportPdfXml_Click(object sender, EventArgs e)
        {
            var startDate = startDatePdfXml.Value.ToString("dd-MM-yyyy");
            var endDate = endDatePdfXml.Value.ToString("dd-MM-yyyy");

            if (toPDF.Checked)
            {
                var pdfExp = new PDFExport();

                pdfExp.GeneratePDFReport(startDatePdfXml.Value, endDatePdfXml.Value);
				 MessageBox.Show(@"Task complete.");
            }
            else if (ToXML.Checked)
            {
                XmlWriter.GenerateXmlReport(startDate, endDate);
            }
            else
            {
                MessageBox.Show(@"Please select PDF or XML before to generate a report.");
            }
        }

        // Problem 5
        private void toJSONMongo_Click(object sender, EventArgs e)
        {
            var jExp = new JSONExport(toJSONReports.Checked, toMongoDB.Checked);

            jExp.exportJSONReports(startDateJSON.Value, endDateJSON.Value);
        }

        // Problem 6
        private void XMLBrowse_Click(object sender, EventArgs e)
        {
            const string fileFilter = "XML files (*.xml)|*.xml";
            XmlFilePath = CreateFileDialog(fileFilter, textBox2);
        }

        private void xmlToMssql_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(XmlFilePath))
            {
                MessageBox.Show(@"Please select the xml file firstly.");
            }
            else
            {
                XmlToSql.PushXmlToDb(XmlFilePath);
            }
        }

        // Problem 7
        private void mssqlToMysql_Click(object sender, EventArgs e)
        {
            try
            {
                var mssql = new SalesSystem.Data.SalesSystemContext();
                var mysql = new MySQLContext();

                var problem7 = new MssqlToMysql(mysql, mssql);
                problem7.Transferdata();
                MessageBox.Show(@"Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
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

            if (this.OutputDir == null)
            {
                MessageBox.Show(@"Select output directory first");
                return;
            }

            try
            {
                var export = new SQLiteMySQLExport(mysql, sqlite);
                export.exportXLSX(this.OutputDir);
                MessageBox.Show(@"Reports are succesfully exported in " + this.OutputDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
