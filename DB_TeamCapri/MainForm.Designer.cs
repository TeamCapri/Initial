﻿namespace DB_TeamCapri
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.insertIntoMssql = new System.Windows.Forms.Button();
            this.oracleToMssqlCheckbox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ZipToMssqlBrowse = new System.Windows.Forms.Button();
            this.startDatePdfXml = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ToXML = new System.Windows.Forms.RadioButton();
            this.toPDF = new System.Windows.Forms.RadioButton();
            this.exportPdfXml = new System.Windows.Forms.Button();
            this.endDatePdfXml = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.xmlToMssql = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.XMLBrowse = new System.Windows.Forms.Button();
            this.mssqlToMysql = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sqliteMysql = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.toJSONMongo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endDateJSON = new System.Windows.Forms.DateTimePicker();
            this.startDateJSON = new System.Windows.Forms.DateTimePicker();
            this.chooseDir = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.toJSONReports = new System.Windows.Forms.CheckBox();
            this.toMongoDB = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.insertIntoMssql);
            this.groupBox1.Controls.Add(this.oracleToMssqlCheckbox);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.ZipToMssqlBrowse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Problem 2";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // insertIntoMssql
            // 
            this.insertIntoMssql.Location = new System.Drawing.Point(6, 90);
            this.insertIntoMssql.Name = "insertIntoMssql";
            this.insertIntoMssql.Size = new System.Drawing.Size(75, 23);
            this.insertIntoMssql.TabIndex = 4;
            this.insertIntoMssql.Text = "Execute";
            this.insertIntoMssql.UseVisualStyleBackColor = true;
            this.insertIntoMssql.Click += new System.EventHandler(this.insertIntoMssql_Click);
            // 
            // oracleToMssqlCheckbox
            // 
            this.oracleToMssqlCheckbox.AutoSize = true;
            this.oracleToMssqlCheckbox.Location = new System.Drawing.Point(6, 19);
            this.oracleToMssqlCheckbox.Name = "oracleToMssqlCheckbox";
            this.oracleToMssqlCheckbox.Size = new System.Drawing.Size(109, 17);
            this.oracleToMssqlCheckbox.TabIndex = 3;
            this.oracleToMssqlCheckbox.Text = "Oracle to MSSQL";
            this.oracleToMssqlCheckbox.UseVisualStyleBackColor = true;
            this.oracleToMssqlCheckbox.CheckedChanged += new System.EventHandler(this.oracleToMssqlCheckbox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 20);
            this.textBox1.TabIndex = 2;
            // 
            // ZipToMssqlBrowse
            // 
            this.ZipToMssqlBrowse.Location = new System.Drawing.Point(261, 46);
            this.ZipToMssqlBrowse.Name = "ZipToMssqlBrowse";
            this.ZipToMssqlBrowse.Size = new System.Drawing.Size(75, 22);
            this.ZipToMssqlBrowse.TabIndex = 1;
            this.ZipToMssqlBrowse.Text = "Browse ...";
            this.ZipToMssqlBrowse.UseVisualStyleBackColor = true;
            this.ZipToMssqlBrowse.Click += new System.EventHandler(this.ZipToMssqlBrowse_Click);
            // 
            // startDatePdfXml
            // 
            this.startDatePdfXml.Location = new System.Drawing.Point(87, 19);
            this.startDatePdfXml.Name = "startDatePdfXml";
            this.startDatePdfXml.Size = new System.Drawing.Size(220, 20);
            this.startDatePdfXml.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.ToXML);
            this.groupBox2.Controls.Add(this.toPDF);
            this.groupBox2.Controls.Add(this.exportPdfXml);
            this.groupBox2.Controls.Add(this.endDatePdfXml);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.startDatePdfXml);
            this.groupBox2.Location = new System.Drawing.Point(12, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 184);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Problems 3, 4";
            // 
            // ToXML
            // 
            this.ToXML.AutoSize = true;
            this.ToXML.Location = new System.Drawing.Point(32, 115);
            this.ToXML.Name = "ToXML";
            this.ToXML.Size = new System.Drawing.Size(275, 17);
            this.ToXML.TabIndex = 8;
            this.ToXML.TabStop = true;
            this.ToXML.Text = "Generate XML Sales by Vendor Report From MSSQL";
            this.ToXML.UseVisualStyleBackColor = true;
            // 
            // toPDF
            // 
            this.toPDF.AutoSize = true;
            this.toPDF.Location = new System.Drawing.Point(32, 92);
            this.toPDF.Name = "toPDF";
            this.toPDF.Size = new System.Drawing.Size(228, 17);
            this.toPDF.TabIndex = 7;
            this.toPDF.TabStop = true;
            this.toPDF.Text = "Generate PDF Sales Reports From MSSQL";
            this.toPDF.UseVisualStyleBackColor = true;
            // 
            // exportPdfXml
            // 
            this.exportPdfXml.Location = new System.Drawing.Point(6, 155);
            this.exportPdfXml.Name = "exportPdfXml";
            this.exportPdfXml.Size = new System.Drawing.Size(157, 23);
            this.exportPdfXml.TabIndex = 6;
            this.exportPdfXml.Text = "Generate";
            this.exportPdfXml.UseVisualStyleBackColor = true;
            this.exportPdfXml.Click += new System.EventHandler(this.exportPdfXml_Click);
            // 
            // endDatePdfXml
            // 
            this.endDatePdfXml.Location = new System.Drawing.Point(87, 58);
            this.endDatePdfXml.Name = "endDatePdfXml";
            this.endDatePdfXml.Size = new System.Drawing.Size(220, 20);
            this.endDatePdfXml.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.xmlToMssql);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.XMLBrowse);
            this.groupBox3.Location = new System.Drawing.Point(360, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 119);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Problem 6";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // xmlToMssql
            // 
            this.xmlToMssql.Location = new System.Drawing.Point(6, 90);
            this.xmlToMssql.Name = "xmlToMssql";
            this.xmlToMssql.Size = new System.Drawing.Size(75, 23);
            this.xmlToMssql.TabIndex = 2;
            this.xmlToMssql.Text = "Load";
            this.xmlToMssql.UseVisualStyleBackColor = true;
            this.xmlToMssql.Click += new System.EventHandler(this.xmlToMssql_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(247, 20);
            this.textBox2.TabIndex = 1;
            // 
            // XMLBrowse
            // 
            this.XMLBrowse.Location = new System.Drawing.Point(259, 48);
            this.XMLBrowse.Name = "XMLBrowse";
            this.XMLBrowse.Size = new System.Drawing.Size(75, 20);
            this.XMLBrowse.TabIndex = 0;
            this.XMLBrowse.Text = "Browse ...";
            this.XMLBrowse.UseVisualStyleBackColor = true;
            this.XMLBrowse.Click += new System.EventHandler(this.XMLBrowse_Click);
            // 
            // mssqlToMysql
            // 
            this.mssqlToMysql.Location = new System.Drawing.Point(6, 44);
            this.mssqlToMysql.Name = "mssqlToMysql";
            this.mssqlToMysql.Size = new System.Drawing.Size(156, 23);
            this.mssqlToMysql.TabIndex = 4;
            this.mssqlToMysql.Text = "MSSQL To MySQL";
            this.mssqlToMysql.UseVisualStyleBackColor = true;
            this.mssqlToMysql.Click += new System.EventHandler(this.mssqlToMysql_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mssqlToMysql);
            this.groupBox4.Location = new System.Drawing.Point(360, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 73);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Problem 7";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sqliteMysql);
            this.groupBox5.Location = new System.Drawing.Point(360, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(340, 104);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Problem 8";
            // 
            // sqliteMysql
            // 
            this.sqliteMysql.Location = new System.Drawing.Point(6, 75);
            this.sqliteMysql.Name = "sqliteMysql";
            this.sqliteMysql.Size = new System.Drawing.Size(75, 23);
            this.sqliteMysql.TabIndex = 0;
            this.sqliteMysql.Text = "Execute";
            this.sqliteMysql.UseVisualStyleBackColor = true;
            this.sqliteMysql.Click += new System.EventHandler(this.sqliteMysql_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.toMongoDB);
            this.groupBox6.Controls.Add(this.toJSONReports);
            this.groupBox6.Controls.Add(this.toJSONMongo);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.endDateJSON);
            this.groupBox6.Controls.Add(this.startDateJSON);
            this.groupBox6.Location = new System.Drawing.Point(12, 327);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(342, 148);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Problem 5";
            // 
            // toJSONMongo
            // 
            this.toJSONMongo.Location = new System.Drawing.Point(220, 113);
            this.toJSONMongo.Name = "toJSONMongo";
            this.toJSONMongo.Size = new System.Drawing.Size(103, 23);
            this.toJSONMongo.TabIndex = 4;
            this.toJSONMongo.Text = "Generate";
            this.toJSONMongo.UseVisualStyleBackColor = true;
            this.toJSONMongo.Click += new System.EventHandler(this.toJSONMongo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start Date";
            // 
            // endDateJSON
            // 
            this.endDateJSON.Location = new System.Drawing.Point(67, 57);
            this.endDateJSON.Name = "endDateJSON";
            this.endDateJSON.Size = new System.Drawing.Size(130, 20);
            this.endDateJSON.TabIndex = 1;
            // 
            // startDateJSON
            // 
            this.startDateJSON.Location = new System.Drawing.Point(67, 25);
            this.startDateJSON.Name = "startDateJSON";
            this.startDateJSON.Size = new System.Drawing.Size(130, 20);
            this.startDateJSON.TabIndex = 0;
            // 
            // chooseDir
            // 
            this.chooseDir.Location = new System.Drawing.Point(259, 74);
            this.chooseDir.Name = "chooseDir";
            this.chooseDir.Size = new System.Drawing.Size(75, 23);
            this.chooseDir.TabIndex = 8;
            this.chooseDir.Text = "Browse ...";
            this.chooseDir.UseVisualStyleBackColor = true;
            this.chooseDir.Click += new System.EventHandler(this.chooseDir_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(6, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(247, 20);
            this.textBox3.TabIndex = 9;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.chooseDir);
            this.groupBox7.Location = new System.Drawing.Point(360, 327);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(340, 115);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Choose Output Folder";
            // 
            // toJSONReports
            // 
            this.toJSONReports.AutoSize = true;
            this.toJSONReports.Checked = true;
            this.toJSONReports.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toJSONReports.Location = new System.Drawing.Point(11, 119);
            this.toJSONReports.Name = "toJSONReports";
            this.toJSONReports.Size = new System.Drawing.Size(203, 17);
            this.toJSONReports.TabIndex = 5;
            this.toJSONReports.Text = "Generate Reports to \"JSON-Reports\"";
            this.toJSONReports.UseVisualStyleBackColor = true;
            // 
            // toMongoDB
            // 
            this.toMongoDB.AutoSize = true;
            this.toMongoDB.Checked = true;
            this.toMongoDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toMongoDB.Location = new System.Drawing.Point(11, 94);
            this.toMongoDB.Name = "toMongoDB";
            this.toMongoDB.Size = new System.Drawing.Size(168, 17);
            this.toMongoDB.TabIndex = 6;
            this.toMongoDB.Text = "Generate reports to MongoDB";
            this.toMongoDB.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DB_TeamCapri.Properties.Resources.FormBackground;
            this.ClientSize = new System.Drawing.Size(712, 542);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Team Capri";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ZipToMssqlBrowse;
        private System.Windows.Forms.DateTimePicker startDatePdfXml;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ToXML;
        private System.Windows.Forms.RadioButton toPDF;
        private System.Windows.Forms.Button exportPdfXml;
        private System.Windows.Forms.DateTimePicker endDatePdfXml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button XMLBrowse;
        private System.Windows.Forms.Button mssqlToMysql;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button toJSONMongo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker endDateJSON;
        private System.Windows.Forms.DateTimePicker startDateJSON;
        private System.Windows.Forms.CheckBox oracleToMssqlCheckbox;
        private System.Windows.Forms.Button insertIntoMssql;
        private System.Windows.Forms.Button xmlToMssql;
        private System.Windows.Forms.Button sqliteMysql;
        private System.Windows.Forms.Button chooseDir;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox toMongoDB;
        private System.Windows.Forms.CheckBox toJSONReports;
    }
}

