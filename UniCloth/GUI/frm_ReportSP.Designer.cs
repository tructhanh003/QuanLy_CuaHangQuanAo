namespace GUI
{
    partial class frm_ReportSP
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.khohang1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyShopQuanAoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyShopQuanAoDataSet = new GUI.QuanLyShopQuanAoDataSet();
            this.reportSP = new Microsoft.Reporting.WinForms.ReportViewer();
            this.khohang1TableAdapter = new GUI.QuanLyShopQuanAoDataSetTableAdapters.khohang1TableAdapter();
            this.khohang1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.khohang1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyShopQuanAoDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyShopQuanAoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khohang1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // khohang1BindingSource
            // 
            this.khohang1BindingSource.DataMember = "khohang1";
            this.khohang1BindingSource.DataSource = this.quanLyShopQuanAoDataSetBindingSource;
            // 
            // quanLyShopQuanAoDataSetBindingSource
            // 
            this.quanLyShopQuanAoDataSetBindingSource.DataSource = this.quanLyShopQuanAoDataSet;
            this.quanLyShopQuanAoDataSetBindingSource.Position = 0;
            // 
            // quanLyShopQuanAoDataSet
            // 
            this.quanLyShopQuanAoDataSet.DataSetName = "QuanLyShopQuanAoDataSet";
            this.quanLyShopQuanAoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportSP
            // 
            this.reportSP.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "KhoHang";
            reportDataSource1.Value = this.khohang1BindingSource1;
            this.reportSP.LocalReport.DataSources.Add(reportDataSource1);
            this.reportSP.LocalReport.ReportEmbeddedResource = "GUI.Report1.rdlc";
            this.reportSP.Location = new System.Drawing.Point(0, 0);
            this.reportSP.Name = "reportSP";
            this.reportSP.ServerReport.BearerToken = null;
            this.reportSP.Size = new System.Drawing.Size(754, 515);
            this.reportSP.TabIndex = 0;
            // 
            // khohang1TableAdapter
            // 
            this.khohang1TableAdapter.ClearBeforeFill = true;
            // 
            // khohang1BindingSource1
            // 
            this.khohang1BindingSource1.DataMember = "khohang1";
            this.khohang1BindingSource1.DataSource = this.quanLyShopQuanAoDataSetBindingSource;
            // 
            // frm_ReportSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 515);
            this.Controls.Add(this.reportSP);
            this.Name = "frm_ReportSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ReportSP";
            this.Load += new System.EventHandler(this.frm_ReportSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.khohang1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyShopQuanAoDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyShopQuanAoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khohang1BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportSP;
        private System.Windows.Forms.BindingSource quanLyShopQuanAoDataSetBindingSource;
        private QuanLyShopQuanAoDataSet quanLyShopQuanAoDataSet;
        private System.Windows.Forms.BindingSource khohang1BindingSource;
        private QuanLyShopQuanAoDataSetTableAdapters.khohang1TableAdapter khohang1TableAdapter;
        private System.Windows.Forms.BindingSource khohang1BindingSource1;
    }
}