
namespace proIMP {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turkishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ssBottomCurrency = new System.Windows.Forms.StatusStrip();
            this.pnlMenuMain = new System.Windows.Forms.Panel();
            this.pnlInfoCount = new System.Windows.Forms.Panel();
            this.lblCountWarehouse = new System.Windows.Forms.Label();
            this.lblCountSupplier = new System.Windows.Forms.Label();
            this.lblCountCustomer = new System.Windows.Forms.Label();
            this.lblCountCategory = new System.Windows.Forms.Label();
            this.lblCountProduct = new System.Windows.Forms.Label();
            this.lblTotalCustomer = new System.Windows.Forms.Label();
            this.lblTotalProduct = new System.Windows.Forms.Label();
            this.lblTotalCategory = new System.Windows.Forms.Label();
            this.lblTotalSupplier = new System.Windows.Forms.Label();
            this.lblTotalWarehouse = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuReport = new System.Windows.Forms.Panel();
            this.btnReportExchange = new System.Windows.Forms.Button();
            this.btnReportProductCount = new System.Windows.Forms.Button();
            this.btnReportProductFlow = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pnlMenuStock = new System.Windows.Forms.Panel();
            this.btnStockOut = new System.Windows.Forms.Button();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.pnlMenuProduct = new System.Windows.Forms.Panel();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.panelMenuSplitter = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.forexExchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMenuMain.SuspendLayout();
            this.pnlInfoCount.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuReport.SuspendLayout();
            this.pnlMenuStock.SuspendLayout();
            this.pnlMenuProduct.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Name = "mainMenu";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warehouseToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.categoryToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            resources.ApplyResources(this.productToolStripMenuItem, "productToolStripMenuItem");
            // 
            // warehouseToolStripMenuItem
            // 
            this.warehouseToolStripMenuItem.Name = "warehouseToolStripMenuItem";
            resources.ApplyResources(this.warehouseToolStripMenuItem, "warehouseToolStripMenuItem");
            this.warehouseToolStripMenuItem.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            resources.ApplyResources(this.supplierToolStripMenuItem, "supplierToolStripMenuItem");
            this.supplierToolStripMenuItem.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            resources.ApplyResources(this.customerToolStripMenuItem, "customerToolStripMenuItem");
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            resources.ApplyResources(this.categoryToolStripMenuItem, "categoryToolStripMenuItem");
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockInToolStripMenuItem,
            this.stockOutToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            resources.ApplyResources(this.stockToolStripMenuItem, "stockToolStripMenuItem");
            // 
            // stockInToolStripMenuItem
            // 
            this.stockInToolStripMenuItem.Name = "stockInToolStripMenuItem";
            resources.ApplyResources(this.stockInToolStripMenuItem, "stockInToolStripMenuItem");
            this.stockInToolStripMenuItem.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // stockOutToolStripMenuItem
            // 
            this.stockOutToolStripMenuItem.Name = "stockOutToolStripMenuItem";
            resources.ApplyResources(this.stockOutToolStripMenuItem, "stockOutToolStripMenuItem");
            this.stockOutToolStripMenuItem.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockFlowToolStripMenuItem,
            this.productCountToolStripMenuItem,
            this.forexExchangeToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            resources.ApplyResources(this.reportsToolStripMenuItem, "reportsToolStripMenuItem");
            // 
            // stockFlowToolStripMenuItem
            // 
            this.stockFlowToolStripMenuItem.Name = "stockFlowToolStripMenuItem";
            resources.ApplyResources(this.stockFlowToolStripMenuItem, "stockFlowToolStripMenuItem");
            this.stockFlowToolStripMenuItem.Click += new System.EventHandler(this.btnReportProductFlow_Click);
            // 
            // productCountToolStripMenuItem
            // 
            this.productCountToolStripMenuItem.Name = "productCountToolStripMenuItem";
            resources.ApplyResources(this.productCountToolStripMenuItem, "productCountToolStripMenuItem");
            this.productCountToolStripMenuItem.Click += new System.EventHandler(this.btnReportProductCount_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.turkishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // turkishToolStripMenuItem
            // 
            this.turkishToolStripMenuItem.Name = "turkishToolStripMenuItem";
            resources.ApplyResources(this.turkishToolStripMenuItem, "turkishToolStripMenuItem");
            this.turkishToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            resources.ApplyResources(this.preferencesToolStripMenuItem, "preferencesToolStripMenuItem");
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            resources.ApplyResources(this.helpToolStripMenuItem1, "helpToolStripMenuItem1");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlHeader.Controls.Add(this.lblMessage);
            this.pnlHeader.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.Name = "pnlHeader";
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Name = "lblMessage";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ssBottomCurrency
            // 
            resources.ApplyResources(this.ssBottomCurrency, "ssBottomCurrency");
            this.ssBottomCurrency.Name = "ssBottomCurrency";
            // 
            // pnlMenuMain
            // 
            this.pnlMenuMain.Controls.Add(this.pnlInfoCount);
            this.pnlMenuMain.Controls.Add(this.pnlMenu);
            resources.ApplyResources(this.pnlMenuMain, "pnlMenuMain");
            this.pnlMenuMain.Name = "pnlMenuMain";
            // 
            // pnlInfoCount
            // 
            this.pnlInfoCount.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlInfoCount.Controls.Add(this.lblCountWarehouse);
            this.pnlInfoCount.Controls.Add(this.lblCountSupplier);
            this.pnlInfoCount.Controls.Add(this.lblCountCustomer);
            this.pnlInfoCount.Controls.Add(this.lblCountCategory);
            this.pnlInfoCount.Controls.Add(this.lblCountProduct);
            this.pnlInfoCount.Controls.Add(this.lblTotalCustomer);
            this.pnlInfoCount.Controls.Add(this.lblTotalProduct);
            this.pnlInfoCount.Controls.Add(this.lblTotalCategory);
            this.pnlInfoCount.Controls.Add(this.lblTotalSupplier);
            this.pnlInfoCount.Controls.Add(this.lblTotalWarehouse);
            resources.ApplyResources(this.pnlInfoCount, "pnlInfoCount");
            this.pnlInfoCount.Name = "pnlInfoCount";
            // 
            // lblCountWarehouse
            // 
            resources.ApplyResources(this.lblCountWarehouse, "lblCountWarehouse");
            this.lblCountWarehouse.Name = "lblCountWarehouse";
            // 
            // lblCountSupplier
            // 
            resources.ApplyResources(this.lblCountSupplier, "lblCountSupplier");
            this.lblCountSupplier.Name = "lblCountSupplier";
            // 
            // lblCountCustomer
            // 
            resources.ApplyResources(this.lblCountCustomer, "lblCountCustomer");
            this.lblCountCustomer.Name = "lblCountCustomer";
            // 
            // lblCountCategory
            // 
            resources.ApplyResources(this.lblCountCategory, "lblCountCategory");
            this.lblCountCategory.Name = "lblCountCategory";
            // 
            // lblCountProduct
            // 
            resources.ApplyResources(this.lblCountProduct, "lblCountProduct");
            this.lblCountProduct.Name = "lblCountProduct";
            // 
            // lblTotalCustomer
            // 
            resources.ApplyResources(this.lblTotalCustomer, "lblTotalCustomer");
            this.lblTotalCustomer.Name = "lblTotalCustomer";
            // 
            // lblTotalProduct
            // 
            resources.ApplyResources(this.lblTotalProduct, "lblTotalProduct");
            this.lblTotalProduct.Name = "lblTotalProduct";
            // 
            // lblTotalCategory
            // 
            resources.ApplyResources(this.lblTotalCategory, "lblTotalCategory");
            this.lblTotalCategory.Name = "lblTotalCategory";
            // 
            // lblTotalSupplier
            // 
            resources.ApplyResources(this.lblTotalSupplier, "lblTotalSupplier");
            this.lblTotalSupplier.Name = "lblTotalSupplier";
            // 
            // lblTotalWarehouse
            // 
            resources.ApplyResources(this.lblTotalWarehouse, "lblTotalWarehouse");
            this.lblTotalWarehouse.Name = "lblTotalWarehouse";
            // 
            // pnlMenu
            // 
            resources.ApplyResources(this.pnlMenu, "pnlMenu");
            this.pnlMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlMenu.Controls.Add(this.pnlMenuReport);
            this.pnlMenu.Controls.Add(this.btnReports);
            this.pnlMenu.Controls.Add(this.pnlMenuStock);
            this.pnlMenu.Controls.Add(this.btnStock);
            this.pnlMenu.Controls.Add(this.pnlMenuProduct);
            this.pnlMenu.Controls.Add(this.btnProduct);
            this.pnlMenu.Controls.Add(this.panelMenuSplitter);
            this.pnlMenu.Name = "pnlMenu";
            // 
            // pnlMenuReport
            // 
            this.pnlMenuReport.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlMenuReport.Controls.Add(this.btnReportExchange);
            this.pnlMenuReport.Controls.Add(this.btnReportProductCount);
            this.pnlMenuReport.Controls.Add(this.btnReportProductFlow);
            resources.ApplyResources(this.pnlMenuReport, "pnlMenuReport");
            this.pnlMenuReport.Name = "pnlMenuReport";
            // 
            // btnReportExchange
            // 
            resources.ApplyResources(this.btnReportExchange, "btnReportExchange");
            this.btnReportExchange.FlatAppearance.BorderSize = 0;
            this.btnReportExchange.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnReportExchange.Name = "btnReportExchange";
            this.btnReportExchange.UseVisualStyleBackColor = true;
            this.btnReportExchange.Click += new System.EventHandler(this.btnReportExchange_Click);
            // 
            // btnReportProductCount
            // 
            resources.ApplyResources(this.btnReportProductCount, "btnReportProductCount");
            this.btnReportProductCount.FlatAppearance.BorderSize = 0;
            this.btnReportProductCount.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnReportProductCount.Name = "btnReportProductCount";
            this.btnReportProductCount.UseVisualStyleBackColor = true;
            this.btnReportProductCount.Click += new System.EventHandler(this.btnReportProductCount_Click);
            // 
            // btnReportProductFlow
            // 
            resources.ApplyResources(this.btnReportProductFlow, "btnReportProductFlow");
            this.btnReportProductFlow.FlatAppearance.BorderSize = 0;
            this.btnReportProductFlow.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnReportProductFlow.Name = "btnReportProductFlow";
            this.btnReportProductFlow.UseVisualStyleBackColor = true;
            this.btnReportProductFlow.Click += new System.EventHandler(this.btnReportProductFlow_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.btnReports, "btnReports");
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnReports.Name = "btnReports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // pnlMenuStock
            // 
            this.pnlMenuStock.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlMenuStock.Controls.Add(this.btnStockOut);
            this.pnlMenuStock.Controls.Add(this.btnStockIn);
            resources.ApplyResources(this.pnlMenuStock, "pnlMenuStock");
            this.pnlMenuStock.Name = "pnlMenuStock";
            // 
            // btnStockOut
            // 
            resources.ApplyResources(this.btnStockOut, "btnStockOut");
            this.btnStockOut.FlatAppearance.BorderSize = 0;
            this.btnStockOut.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.UseVisualStyleBackColor = true;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // btnStockIn
            // 
            resources.ApplyResources(this.btnStockIn, "btnStockIn");
            this.btnStockIn.FlatAppearance.BorderSize = 0;
            this.btnStockIn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.btnStock, "btnStock");
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnStock.Name = "btnStock";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // pnlMenuProduct
            // 
            this.pnlMenuProduct.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlMenuProduct.Controls.Add(this.btnCategory);
            this.pnlMenuProduct.Controls.Add(this.btnCustomer);
            this.pnlMenuProduct.Controls.Add(this.btnSupplier);
            this.pnlMenuProduct.Controls.Add(this.btnWarehouse);
            resources.ApplyResources(this.pnlMenuProduct, "pnlMenuProduct");
            this.pnlMenuProduct.Name = "pnlMenuProduct";
            // 
            // btnCategory
            // 
            resources.ApplyResources(this.btnCategory, "btnCategory");
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCustomer
            // 
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnSupplier
            // 
            resources.ApplyResources(this.btnSupplier, "btnSupplier");
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnWarehouse
            // 
            resources.ApplyResources(this.btnWarehouse, "btnWarehouse");
            this.btnWarehouse.FlatAppearance.BorderSize = 0;
            this.btnWarehouse.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.btnProduct, "btnProduct");
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // panelMenuSplitter
            // 
            resources.ApplyResources(this.panelMenuSplitter, "panelMenuSplitter");
            this.panelMenuSplitter.Name = "panelMenuSplitter";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Controls.Add(this.pnlMenuMain);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlForm
            // 
            resources.ApplyResources(this.pnlForm, "pnlForm");
            this.pnlForm.Name = "pnlForm";
            // 
            // forexExchangeToolStripMenuItem
            // 
            this.forexExchangeToolStripMenuItem.Name = "forexExchangeToolStripMenuItem";
            resources.ApplyResources(this.forexExchangeToolStripMenuItem, "forexExchangeToolStripMenuItem");
            this.forexExchangeToolStripMenuItem.Click += new System.EventHandler(this.btnReportExchange_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.ssBottomCurrency);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenuMain.ResumeLayout(false);
            this.pnlInfoCount.ResumeLayout(false);
            this.pnlInfoCount.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenuReport.ResumeLayout(false);
            this.pnlMenuStock.ResumeLayout(false);
            this.pnlMenuProduct.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turkishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip ssBottomCurrency;
        private System.Windows.Forms.Panel pnlMenuMain;
        private System.Windows.Forms.Panel pnlInfoCount;
        private System.Windows.Forms.Label lblTotalCustomer;
        private System.Windows.Forms.Label lblTotalProduct;
        private System.Windows.Forms.Label lblTotalCategory;
        private System.Windows.Forms.Label lblTotalSupplier;
        private System.Windows.Forms.Label lblTotalWarehouse;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMenuStock;
        private System.Windows.Forms.Button btnStockOut;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Panel pnlMenuProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Panel panelMenuSplitter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel pnlMenuReport;
        private System.Windows.Forms.Button btnReportExchange;
        private System.Windows.Forms.Button btnReportProductCount;
        private System.Windows.Forms.Button btnReportProductFlow;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblCountProduct;
        private System.Windows.Forms.Label lblCountWarehouse;
        private System.Windows.Forms.Label lblCountSupplier;
        private System.Windows.Forms.Label lblCountCustomer;
        private System.Windows.Forms.Label lblCountCategory;
        private System.Windows.Forms.ToolStripMenuItem forexExchangeToolStripMenuItem;
    }
}