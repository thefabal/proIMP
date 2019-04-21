namespace proIMP
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.scStock = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStockFlowAdd = new System.Windows.Forms.Button();
            this.cmsAddStockFlow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addStockInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStockFlowEdit = new System.Windows.Forms.Button();
            this.btnStockFlowDelete = new System.Windows.Forms.Button();
            this.lvStockFlow = new System.Windows.Forms.ListView();
            this.stockFlowType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockFlowID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockFlowDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockFlowSupplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockFlowDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockFlowQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockFlowTotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockFlowStockType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.btnStockProductAdd = new System.Windows.Forms.Button();
            this.btnStockProductEdit = new System.Windows.Forms.Button();
            this.btnStockProductDelete = new System.Windows.Forms.Button();
            this.lblGrandTotalPrice = new System.Windows.Forms.Label();
            this.lvStockProductList = new System.Windows.Forms.ListView();
            this.stockProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockProductID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockProductUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockProductQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockProductPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockProductTotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockProductTotalLocalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scReport_2 = new System.Windows.Forms.SplitContainer();
            this.lblReport_2Warehouse = new System.Windows.Forms.Label();
            this.cbReport_2Warehouse = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.dtReport_2To = new System.Windows.Forms.DateTimePicker();
            this.dtReport_2From = new System.Windows.Forms.DateTimePicker();
            this.lblReport_2Date = new System.Windows.Forms.Label();
            this.cbReport_2Category = new System.Windows.Forms.ComboBox();
            this.lblReport_2Category = new System.Windows.Forms.Label();
            this.btnReport_2Run = new System.Windows.Forms.Button();
            this.lblReport_2Product = new System.Windows.Forms.Label();
            this.cbReport_2Product = new System.Windows.Forms.ComboBox();
            this.cbReport_2OpenReport = new System.Windows.Forms.CheckBox();
            this.lvReport_2 = new System.Windows.Forms.ListView();
            this.chReport_2Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_2Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_2Unit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_2StockIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_2StockOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_2TotalStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReport_2Export = new System.Windows.Forms.Button();
            this.scReport_1 = new System.Windows.Forms.SplitContainer();
            this.cbReport_1Category = new System.Windows.Forms.ComboBox();
            this.lblReport_1Category = new System.Windows.Forms.Label();
            this.btnReport_1Run = new System.Windows.Forms.Button();
            this.cbReport_1FlowOut = new System.Windows.Forms.CheckBox();
            this.cbReport_1FlowIn = new System.Windows.Forms.CheckBox();
            this.lblReport_1StockFlowType = new System.Windows.Forms.Label();
            this.cbReport_1Customer = new System.Windows.Forms.ComboBox();
            this.btnReport_1Customer = new System.Windows.Forms.Label();
            this.cbReport_1Supplier = new System.Windows.Forms.ComboBox();
            this.lblReport_1Supplier = new System.Windows.Forms.Label();
            this.lblReport_1Product = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtReport_1To = new System.Windows.Forms.DateTimePicker();
            this.dtReport_1From = new System.Windows.Forms.DateTimePicker();
            this.cbReport_1Product = new System.Windows.Forms.ComboBox();
            this.lblReport_1Date = new System.Windows.Forms.Label();
            this.lvReport_1 = new System.Windows.Forms.ListView();
            this.chReport_1ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1Supplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1Unit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1TotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_1TotalLocalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbReport_1OpenReport = new System.Windows.Forms.CheckBox();
            this.btnReport_1Export = new System.Windows.Forms.Button();
            this.scReport_3 = new System.Windows.Forms.SplitContainer();
            this.cbReport_3Currency = new System.Windows.Forms.ComboBox();
            this.lblReport_3Currency = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtReport_3To = new System.Windows.Forms.DateTimePicker();
            this.dtReport_3From = new System.Windows.Forms.DateTimePicker();
            this.lblReport_3Date = new System.Windows.Forms.Label();
            this.btnReport_3Run = new System.Windows.Forms.Button();
            this.cbReport_3OpenReport = new System.Windows.Forms.CheckBox();
            this.lvReport_3 = new System.Windows.Forms.ListView();
            this.chReport_3Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_3CurrencyCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_3ForexBuying = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReport_3ForexSelling = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReport_3Export = new System.Windows.Forms.Button();
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.pnlMenuLeft = new System.Windows.Forms.Panel();
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
            this.tbCountCustomer = new System.Windows.Forms.TextBox();
            this.lblTotalCustomer = new System.Windows.Forms.Label();
            this.tbCountProduct = new System.Windows.Forms.TextBox();
            this.lblTotalProduct = new System.Windows.Forms.Label();
            this.tbCountCategory = new System.Windows.Forms.TextBox();
            this.lblTotalCategory = new System.Windows.Forms.Label();
            this.tbCountSupplier = new System.Windows.Forms.TextBox();
            this.lblTotalSupplier = new System.Windows.Forms.Label();
            this.tbCountWarehouse = new System.Windows.Forms.TextBox();
            this.lblTotalWarehouse = new System.Windows.Forms.Label();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.pnlReport_1 = new System.Windows.Forms.Panel();
            this.pnlReport_3 = new System.Windows.Forms.Panel();
            this.pnlReport_2 = new System.Windows.Forms.Panel();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.pnlProduct = new System.Windows.Forms.Panel();
            this.btnProductFilterClear = new System.Windows.Forms.Button();
            this.btnProductFilter = new System.Windows.Forms.Button();
            this.tbProductFilter = new System.Windows.Forms.TextBox();
            this.gbProductInfo = new System.Windows.Forms.GroupBox();
            this.lblProductBarcodeT = new System.Windows.Forms.Label();
            this.lblProductBarcode = new System.Windows.Forms.Label();
            this.lblProductUnitT = new System.Windows.Forms.Label();
            this.lblProductUnit = new System.Windows.Forms.Label();
            this.lblProductDescT = new System.Windows.Forms.Label();
            this.lblProductDesc = new System.Windows.Forms.Label();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.lblProductCategoryT = new System.Windows.Forms.Label();
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.lblProductNameT = new System.Windows.Forms.Label();
            this.lblProductIDT = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.btnProductEdit = new System.Windows.Forms.Button();
            this.btnProductDelete = new System.Windows.Forms.Button();
            this.lvProductList = new System.Windows.Forms.ListView();
            this.plProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plProductID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plProductCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plProductStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plProductPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ssBottomCurrency = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.scStock)).BeginInit();
            this.scStock.Panel1.SuspendLayout();
            this.scStock.Panel2.SuspendLayout();
            this.scStock.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsAddStockFlow.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReport_2)).BeginInit();
            this.scReport_2.Panel1.SuspendLayout();
            this.scReport_2.Panel2.SuspendLayout();
            this.scReport_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReport_1)).BeginInit();
            this.scReport_1.Panel1.SuspendLayout();
            this.scReport_1.Panel2.SuspendLayout();
            this.scReport_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReport_3)).BeginInit();
            this.scReport_3.Panel1.SuspendLayout();
            this.scReport_3.Panel2.SuspendLayout();
            this.scReport_3.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlMenuLeft.SuspendLayout();
            this.pnlMenuReport.SuspendLayout();
            this.pnlMenuStock.SuspendLayout();
            this.pnlMenuProduct.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.pnlReport_1.SuspendLayout();
            this.pnlReport_3.SuspendLayout();
            this.pnlReport_2.SuspendLayout();
            this.pnlStock.SuspendLayout();
            this.pnlProduct.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.cmsProduct.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scStock
            // 
            resources.ApplyResources(this.scStock, "scStock");
            this.scStock.Name = "scStock";
            // 
            // scStock.Panel1
            // 
            this.scStock.Panel1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.scStock.Panel1, "scStock.Panel1");
            // 
            // scStock.Panel2
            // 
            this.scStock.Panel2.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.scStock.Panel2, "scStock.Panel2");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStockFlowAdd);
            this.groupBox1.Controls.Add(this.btnStockFlowEdit);
            this.groupBox1.Controls.Add(this.btnStockFlowDelete);
            this.groupBox1.Controls.Add(this.lvStockFlow);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnStockFlowAdd
            // 
            resources.ApplyResources(this.btnStockFlowAdd, "btnStockFlowAdd");
            this.btnStockFlowAdd.ContextMenuStrip = this.cmsAddStockFlow;
            this.btnStockFlowAdd.Name = "btnStockFlowAdd";
            this.btnStockFlowAdd.UseVisualStyleBackColor = true;
            this.btnStockFlowAdd.Click += new System.EventHandler(this.btnStockFlowAdd_Click);
            this.btnStockFlowAdd.MouseLeave += new System.EventHandler(this.stockFlowAdd_MouseLeave);
            this.btnStockFlowAdd.MouseHover += new System.EventHandler(this.btnStockFlowAdd_MouseHover);
            // 
            // cmsAddStockFlow
            // 
            this.cmsAddStockFlow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAddStockFlow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStockInToolStripMenuItem,
            this.stockOutToolStripMenuItem1});
            this.cmsAddStockFlow.Name = "cmsAddStockFlow";
            resources.ApplyResources(this.cmsAddStockFlow, "cmsAddStockFlow");
            this.cmsAddStockFlow.MouseLeave += new System.EventHandler(this.stockFlowAdd_MouseLeave);
            // 
            // addStockInToolStripMenuItem
            // 
            this.addStockInToolStripMenuItem.Name = "addStockInToolStripMenuItem";
            resources.ApplyResources(this.addStockInToolStripMenuItem, "addStockInToolStripMenuItem");
            this.addStockInToolStripMenuItem.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // stockOutToolStripMenuItem1
            // 
            this.stockOutToolStripMenuItem1.Name = "stockOutToolStripMenuItem1";
            resources.ApplyResources(this.stockOutToolStripMenuItem1, "stockOutToolStripMenuItem1");
            this.stockOutToolStripMenuItem1.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // btnStockFlowEdit
            // 
            resources.ApplyResources(this.btnStockFlowEdit, "btnStockFlowEdit");
            this.btnStockFlowEdit.Name = "btnStockFlowEdit";
            this.btnStockFlowEdit.UseVisualStyleBackColor = true;
            this.btnStockFlowEdit.Click += new System.EventHandler(this.btnStockFlowEdit_Click);
            // 
            // btnStockFlowDelete
            // 
            resources.ApplyResources(this.btnStockFlowDelete, "btnStockFlowDelete");
            this.btnStockFlowDelete.Name = "btnStockFlowDelete";
            this.btnStockFlowDelete.UseVisualStyleBackColor = true;
            this.btnStockFlowDelete.Click += new System.EventHandler(this.btnStockFlowDelete_Click);
            // 
            // lvStockFlow
            // 
            resources.ApplyResources(this.lvStockFlow, "lvStockFlow");
            this.lvStockFlow.CheckBoxes = true;
            this.lvStockFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stockFlowType,
            this.stockFlowID,
            this.stockFlowDate,
            this.stockFlowSupplier,
            this.stockFlowDescription,
            this.stockFlowQuantity,
            this.stockFlowTotalPrice,
            this.stockFlowStockType});
            this.lvStockFlow.FullRowSelect = true;
            this.lvStockFlow.MultiSelect = false;
            this.lvStockFlow.Name = "lvStockFlow";
            this.lvStockFlow.OwnerDraw = true;
            this.lvStockFlow.UseCompatibleStateImageBehavior = false;
            this.lvStockFlow.View = System.Windows.Forms.View.Details;
            this.lvStockFlow.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewOrder_ColumnClick);
            this.lvStockFlow.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_DrawColumnHeader);
            this.lvStockFlow.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView_DrawItem);
            this.lvStockFlow.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvStockFlow_ItemChecked);
            this.lvStockFlow.SelectedIndexChanged += new System.EventHandler(this.lvStockFlow_SelectedIndexChanged);
            this.lvStockFlow.Enter += new System.EventHandler(this.ListViewFocus_Enter);
            this.lvStockFlow.Leave += new System.EventHandler(this.ListViewFocus_Leave);
            this.lvStockFlow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_MouseMove);
            // 
            // stockFlowType
            // 
            resources.ApplyResources(this.stockFlowType, "stockFlowType");
            // 
            // stockFlowID
            // 
            resources.ApplyResources(this.stockFlowID, "stockFlowID");
            // 
            // stockFlowDate
            // 
            resources.ApplyResources(this.stockFlowDate, "stockFlowDate");
            // 
            // stockFlowSupplier
            // 
            resources.ApplyResources(this.stockFlowSupplier, "stockFlowSupplier");
            // 
            // stockFlowDescription
            // 
            resources.ApplyResources(this.stockFlowDescription, "stockFlowDescription");
            // 
            // stockFlowQuantity
            // 
            resources.ApplyResources(this.stockFlowQuantity, "stockFlowQuantity");
            // 
            // stockFlowTotalPrice
            // 
            resources.ApplyResources(this.stockFlowTotalPrice, "stockFlowTotalPrice");
            // 
            // stockFlowStockType
            // 
            resources.ApplyResources(this.stockFlowStockType, "stockFlowStockType");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblGrandTotal);
            this.groupBox2.Controls.Add(this.btnStockProductAdd);
            this.groupBox2.Controls.Add(this.btnStockProductEdit);
            this.groupBox2.Controls.Add(this.btnStockProductDelete);
            this.groupBox2.Controls.Add(this.lblGrandTotalPrice);
            this.groupBox2.Controls.Add(this.lvStockProductList);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lblGrandTotal
            // 
            resources.ApplyResources(this.lblGrandTotal, "lblGrandTotal");
            this.lblGrandTotal.Name = "lblGrandTotal";
            // 
            // btnStockProductAdd
            // 
            resources.ApplyResources(this.btnStockProductAdd, "btnStockProductAdd");
            this.btnStockProductAdd.Name = "btnStockProductAdd";
            this.btnStockProductAdd.UseVisualStyleBackColor = true;
            this.btnStockProductAdd.Click += new System.EventHandler(this.btnStockProductAdd_Click);
            // 
            // btnStockProductEdit
            // 
            resources.ApplyResources(this.btnStockProductEdit, "btnStockProductEdit");
            this.btnStockProductEdit.Name = "btnStockProductEdit";
            this.btnStockProductEdit.UseVisualStyleBackColor = true;
            this.btnStockProductEdit.Click += new System.EventHandler(this.btnStockProductEdit_Click);
            // 
            // btnStockProductDelete
            // 
            resources.ApplyResources(this.btnStockProductDelete, "btnStockProductDelete");
            this.btnStockProductDelete.Name = "btnStockProductDelete";
            this.btnStockProductDelete.UseVisualStyleBackColor = true;
            this.btnStockProductDelete.Click += new System.EventHandler(this.btnStockProductDelete_Click);
            // 
            // lblGrandTotalPrice
            // 
            resources.ApplyResources(this.lblGrandTotalPrice, "lblGrandTotalPrice");
            this.lblGrandTotalPrice.Name = "lblGrandTotalPrice";
            // 
            // lvStockProductList
            // 
            resources.ApplyResources(this.lvStockProductList, "lvStockProductList");
            this.lvStockProductList.CheckBoxes = true;
            this.lvStockProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stockProductName,
            this.stockProductID,
            this.stockProductUnit,
            this.stockProductQuantity,
            this.stockProductPrice,
            this.stockProductTotalPrice,
            this.stockProductTotalLocalPrice});
            this.lvStockProductList.FullRowSelect = true;
            this.lvStockProductList.MultiSelect = false;
            this.lvStockProductList.Name = "lvStockProductList";
            this.lvStockProductList.OwnerDraw = true;
            this.lvStockProductList.UseCompatibleStateImageBehavior = false;
            this.lvStockProductList.View = System.Windows.Forms.View.Details;
            this.lvStockProductList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewOrder_ColumnClick);
            this.lvStockProductList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_DrawColumnHeader);
            this.lvStockProductList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView_DrawItem);
            this.lvStockProductList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvStockProductList_ItemChecked);
            this.lvStockProductList.Enter += new System.EventHandler(this.ListViewFocus_Enter);
            this.lvStockProductList.Leave += new System.EventHandler(this.ListViewFocus_Leave);
            this.lvStockProductList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_MouseMove);
            // 
            // stockProductName
            // 
            resources.ApplyResources(this.stockProductName, "stockProductName");
            // 
            // stockProductID
            // 
            resources.ApplyResources(this.stockProductID, "stockProductID");
            // 
            // stockProductUnit
            // 
            resources.ApplyResources(this.stockProductUnit, "stockProductUnit");
            // 
            // stockProductQuantity
            // 
            resources.ApplyResources(this.stockProductQuantity, "stockProductQuantity");
            // 
            // stockProductPrice
            // 
            resources.ApplyResources(this.stockProductPrice, "stockProductPrice");
            // 
            // stockProductTotalPrice
            // 
            resources.ApplyResources(this.stockProductTotalPrice, "stockProductTotalPrice");
            // 
            // stockProductTotalLocalPrice
            // 
            resources.ApplyResources(this.stockProductTotalLocalPrice, "stockProductTotalLocalPrice");
            // 
            // scReport_2
            // 
            resources.ApplyResources(this.scReport_2, "scReport_2");
            this.scReport_2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scReport_2.Name = "scReport_2";
            // 
            // scReport_2.Panel1
            // 
            this.scReport_2.Panel1.Controls.Add(this.lblReport_2Warehouse);
            this.scReport_2.Panel1.Controls.Add(this.cbReport_2Warehouse);
            this.scReport_2.Panel1.Controls.Add(this.label24);
            this.scReport_2.Panel1.Controls.Add(this.dtReport_2To);
            this.scReport_2.Panel1.Controls.Add(this.dtReport_2From);
            this.scReport_2.Panel1.Controls.Add(this.lblReport_2Date);
            this.scReport_2.Panel1.Controls.Add(this.cbReport_2Category);
            this.scReport_2.Panel1.Controls.Add(this.lblReport_2Category);
            this.scReport_2.Panel1.Controls.Add(this.btnReport_2Run);
            this.scReport_2.Panel1.Controls.Add(this.lblReport_2Product);
            this.scReport_2.Panel1.Controls.Add(this.cbReport_2Product);
            resources.ApplyResources(this.scReport_2.Panel1, "scReport_2.Panel1");
            // 
            // scReport_2.Panel2
            // 
            this.scReport_2.Panel2.Controls.Add(this.cbReport_2OpenReport);
            this.scReport_2.Panel2.Controls.Add(this.lvReport_2);
            this.scReport_2.Panel2.Controls.Add(this.btnReport_2Export);
            resources.ApplyResources(this.scReport_2.Panel2, "scReport_2.Panel2");
            // 
            // lblReport_2Warehouse
            // 
            resources.ApplyResources(this.lblReport_2Warehouse, "lblReport_2Warehouse");
            this.lblReport_2Warehouse.Name = "lblReport_2Warehouse";
            // 
            // cbReport_2Warehouse
            // 
            this.cbReport_2Warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_2Warehouse.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_2Warehouse, "cbReport_2Warehouse");
            this.cbReport_2Warehouse.Name = "cbReport_2Warehouse";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // dtReport_2To
            // 
            resources.ApplyResources(this.dtReport_2To, "dtReport_2To");
            this.dtReport_2To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReport_2To.Name = "dtReport_2To";
            // 
            // dtReport_2From
            // 
            resources.ApplyResources(this.dtReport_2From, "dtReport_2From");
            this.dtReport_2From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReport_2From.Name = "dtReport_2From";
            // 
            // lblReport_2Date
            // 
            resources.ApplyResources(this.lblReport_2Date, "lblReport_2Date");
            this.lblReport_2Date.Name = "lblReport_2Date";
            // 
            // cbReport_2Category
            // 
            this.cbReport_2Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_2Category.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_2Category, "cbReport_2Category");
            this.cbReport_2Category.Name = "cbReport_2Category";
            // 
            // lblReport_2Category
            // 
            resources.ApplyResources(this.lblReport_2Category, "lblReport_2Category");
            this.lblReport_2Category.Name = "lblReport_2Category";
            // 
            // btnReport_2Run
            // 
            resources.ApplyResources(this.btnReport_2Run, "btnReport_2Run");
            this.btnReport_2Run.Name = "btnReport_2Run";
            this.btnReport_2Run.UseVisualStyleBackColor = true;
            this.btnReport_2Run.Click += new System.EventHandler(this.btnReport_2Run_Click);
            // 
            // lblReport_2Product
            // 
            resources.ApplyResources(this.lblReport_2Product, "lblReport_2Product");
            this.lblReport_2Product.Name = "lblReport_2Product";
            // 
            // cbReport_2Product
            // 
            this.cbReport_2Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_2Product.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_2Product, "cbReport_2Product");
            this.cbReport_2Product.Name = "cbReport_2Product";
            // 
            // cbReport_2OpenReport
            // 
            resources.ApplyResources(this.cbReport_2OpenReport, "cbReport_2OpenReport");
            this.cbReport_2OpenReport.Name = "cbReport_2OpenReport";
            this.cbReport_2OpenReport.UseVisualStyleBackColor = true;
            // 
            // lvReport_2
            // 
            this.lvReport_2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chReport_2Product,
            this.chReport_2Category,
            this.chReport_2Unit,
            this.chReport_2StockIn,
            this.chReport_2StockOut,
            this.chReport_2TotalStock});
            this.lvReport_2.FullRowSelect = true;
            this.lvReport_2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReport_2.HideSelection = false;
            resources.ApplyResources(this.lvReport_2, "lvReport_2");
            this.lvReport_2.MultiSelect = false;
            this.lvReport_2.Name = "lvReport_2";
            this.lvReport_2.UseCompatibleStateImageBehavior = false;
            this.lvReport_2.View = System.Windows.Forms.View.Details;
            // 
            // chReport_2Product
            // 
            resources.ApplyResources(this.chReport_2Product, "chReport_2Product");
            // 
            // chReport_2Category
            // 
            resources.ApplyResources(this.chReport_2Category, "chReport_2Category");
            // 
            // chReport_2Unit
            // 
            resources.ApplyResources(this.chReport_2Unit, "chReport_2Unit");
            // 
            // chReport_2StockIn
            // 
            resources.ApplyResources(this.chReport_2StockIn, "chReport_2StockIn");
            // 
            // chReport_2StockOut
            // 
            resources.ApplyResources(this.chReport_2StockOut, "chReport_2StockOut");
            // 
            // chReport_2TotalStock
            // 
            resources.ApplyResources(this.chReport_2TotalStock, "chReport_2TotalStock");
            // 
            // btnReport_2Export
            // 
            resources.ApplyResources(this.btnReport_2Export, "btnReport_2Export");
            this.btnReport_2Export.Name = "btnReport_2Export";
            this.btnReport_2Export.UseVisualStyleBackColor = true;
            this.btnReport_2Export.Click += new System.EventHandler(this.btnReport_2Export_Click);
            // 
            // scReport_1
            // 
            resources.ApplyResources(this.scReport_1, "scReport_1");
            this.scReport_1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scReport_1.Name = "scReport_1";
            // 
            // scReport_1.Panel1
            // 
            this.scReport_1.Panel1.Controls.Add(this.cbReport_1Category);
            this.scReport_1.Panel1.Controls.Add(this.lblReport_1Category);
            this.scReport_1.Panel1.Controls.Add(this.btnReport_1Run);
            this.scReport_1.Panel1.Controls.Add(this.cbReport_1FlowOut);
            this.scReport_1.Panel1.Controls.Add(this.cbReport_1FlowIn);
            this.scReport_1.Panel1.Controls.Add(this.lblReport_1StockFlowType);
            this.scReport_1.Panel1.Controls.Add(this.cbReport_1Customer);
            this.scReport_1.Panel1.Controls.Add(this.btnReport_1Customer);
            this.scReport_1.Panel1.Controls.Add(this.cbReport_1Supplier);
            this.scReport_1.Panel1.Controls.Add(this.lblReport_1Supplier);
            this.scReport_1.Panel1.Controls.Add(this.lblReport_1Product);
            this.scReport_1.Panel1.Controls.Add(this.label16);
            this.scReport_1.Panel1.Controls.Add(this.dtReport_1To);
            this.scReport_1.Panel1.Controls.Add(this.dtReport_1From);
            this.scReport_1.Panel1.Controls.Add(this.cbReport_1Product);
            this.scReport_1.Panel1.Controls.Add(this.lblReport_1Date);
            resources.ApplyResources(this.scReport_1.Panel1, "scReport_1.Panel1");
            // 
            // scReport_1.Panel2
            // 
            this.scReport_1.Panel2.Controls.Add(this.lvReport_1);
            this.scReport_1.Panel2.Controls.Add(this.cbReport_1OpenReport);
            this.scReport_1.Panel2.Controls.Add(this.btnReport_1Export);
            resources.ApplyResources(this.scReport_1.Panel2, "scReport_1.Panel2");
            // 
            // cbReport_1Category
            // 
            this.cbReport_1Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_1Category.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_1Category, "cbReport_1Category");
            this.cbReport_1Category.Name = "cbReport_1Category";
            this.cbReport_1Category.SelectedIndexChanged += new System.EventHandler(this.cbReport_1Category_SelectedIndexChanged);
            // 
            // lblReport_1Category
            // 
            resources.ApplyResources(this.lblReport_1Category, "lblReport_1Category");
            this.lblReport_1Category.Name = "lblReport_1Category";
            // 
            // btnReport_1Run
            // 
            resources.ApplyResources(this.btnReport_1Run, "btnReport_1Run");
            this.btnReport_1Run.Name = "btnReport_1Run";
            this.btnReport_1Run.UseVisualStyleBackColor = true;
            this.btnReport_1Run.Click += new System.EventHandler(this.btnReport_1Run_Click);
            // 
            // cbReport_1FlowOut
            // 
            resources.ApplyResources(this.cbReport_1FlowOut, "cbReport_1FlowOut");
            this.cbReport_1FlowOut.Name = "cbReport_1FlowOut";
            this.cbReport_1FlowOut.UseVisualStyleBackColor = true;
            this.cbReport_1FlowOut.CheckedChanged += new System.EventHandler(this.cbReport_1FlowOut_CheckedChanged);
            // 
            // cbReport_1FlowIn
            // 
            resources.ApplyResources(this.cbReport_1FlowIn, "cbReport_1FlowIn");
            this.cbReport_1FlowIn.Name = "cbReport_1FlowIn";
            this.cbReport_1FlowIn.UseVisualStyleBackColor = true;
            this.cbReport_1FlowIn.CheckedChanged += new System.EventHandler(this.cbReport_1FlowIn_CheckedChanged);
            // 
            // lblReport_1StockFlowType
            // 
            resources.ApplyResources(this.lblReport_1StockFlowType, "lblReport_1StockFlowType");
            this.lblReport_1StockFlowType.Name = "lblReport_1StockFlowType";
            // 
            // cbReport_1Customer
            // 
            this.cbReport_1Customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_1Customer.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_1Customer, "cbReport_1Customer");
            this.cbReport_1Customer.Name = "cbReport_1Customer";
            // 
            // btnReport_1Customer
            // 
            resources.ApplyResources(this.btnReport_1Customer, "btnReport_1Customer");
            this.btnReport_1Customer.Name = "btnReport_1Customer";
            // 
            // cbReport_1Supplier
            // 
            this.cbReport_1Supplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_1Supplier.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_1Supplier, "cbReport_1Supplier");
            this.cbReport_1Supplier.Name = "cbReport_1Supplier";
            // 
            // lblReport_1Supplier
            // 
            resources.ApplyResources(this.lblReport_1Supplier, "lblReport_1Supplier");
            this.lblReport_1Supplier.Name = "lblReport_1Supplier";
            // 
            // lblReport_1Product
            // 
            resources.ApplyResources(this.lblReport_1Product, "lblReport_1Product");
            this.lblReport_1Product.Name = "lblReport_1Product";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // dtReport_1To
            // 
            resources.ApplyResources(this.dtReport_1To, "dtReport_1To");
            this.dtReport_1To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReport_1To.Name = "dtReport_1To";
            // 
            // dtReport_1From
            // 
            resources.ApplyResources(this.dtReport_1From, "dtReport_1From");
            this.dtReport_1From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReport_1From.Name = "dtReport_1From";
            // 
            // cbReport_1Product
            // 
            this.cbReport_1Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_1Product.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_1Product, "cbReport_1Product");
            this.cbReport_1Product.Name = "cbReport_1Product";
            this.cbReport_1Product.SelectedIndexChanged += new System.EventHandler(this.cbReport_1Product_SelectedIndexChanged);
            // 
            // lblReport_1Date
            // 
            resources.ApplyResources(this.lblReport_1Date, "lblReport_1Date");
            this.lblReport_1Date.Name = "lblReport_1Date";
            // 
            // lvReport_1
            // 
            resources.ApplyResources(this.lvReport_1, "lvReport_1");
            this.lvReport_1.AutoArrange = false;
            this.lvReport_1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chReport_1ID,
            this.chReport_1Date,
            this.chReport_1Supplier,
            this.chReport_1Product,
            this.chReport_1Unit,
            this.chReport_1Quantity,
            this.chReport_1Price,
            this.chReport_1TotalPrice,
            this.chReport_1TotalLocalPrice});
            this.lvReport_1.FullRowSelect = true;
            this.lvReport_1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReport_1.HideSelection = false;
            this.lvReport_1.MultiSelect = false;
            this.lvReport_1.Name = "lvReport_1";
            this.lvReport_1.UseCompatibleStateImageBehavior = false;
            this.lvReport_1.View = System.Windows.Forms.View.Details;
            // 
            // chReport_1ID
            // 
            resources.ApplyResources(this.chReport_1ID, "chReport_1ID");
            // 
            // chReport_1Date
            // 
            resources.ApplyResources(this.chReport_1Date, "chReport_1Date");
            // 
            // chReport_1Supplier
            // 
            resources.ApplyResources(this.chReport_1Supplier, "chReport_1Supplier");
            // 
            // chReport_1Product
            // 
            resources.ApplyResources(this.chReport_1Product, "chReport_1Product");
            // 
            // chReport_1Unit
            // 
            resources.ApplyResources(this.chReport_1Unit, "chReport_1Unit");
            // 
            // chReport_1Quantity
            // 
            resources.ApplyResources(this.chReport_1Quantity, "chReport_1Quantity");
            // 
            // chReport_1Price
            // 
            resources.ApplyResources(this.chReport_1Price, "chReport_1Price");
            // 
            // chReport_1TotalPrice
            // 
            resources.ApplyResources(this.chReport_1TotalPrice, "chReport_1TotalPrice");
            // 
            // chReport_1TotalLocalPrice
            // 
            resources.ApplyResources(this.chReport_1TotalLocalPrice, "chReport_1TotalLocalPrice");
            // 
            // cbReport_1OpenReport
            // 
            resources.ApplyResources(this.cbReport_1OpenReport, "cbReport_1OpenReport");
            this.cbReport_1OpenReport.Name = "cbReport_1OpenReport";
            this.cbReport_1OpenReport.UseVisualStyleBackColor = true;
            // 
            // btnReport_1Export
            // 
            resources.ApplyResources(this.btnReport_1Export, "btnReport_1Export");
            this.btnReport_1Export.Name = "btnReport_1Export";
            this.btnReport_1Export.UseVisualStyleBackColor = true;
            this.btnReport_1Export.Click += new System.EventHandler(this.btnReport_1Export_Click);
            // 
            // scReport_3
            // 
            resources.ApplyResources(this.scReport_3, "scReport_3");
            this.scReport_3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scReport_3.Name = "scReport_3";
            // 
            // scReport_3.Panel1
            // 
            this.scReport_3.Panel1.Controls.Add(this.cbReport_3Currency);
            this.scReport_3.Panel1.Controls.Add(this.lblReport_3Currency);
            this.scReport_3.Panel1.Controls.Add(this.label3);
            this.scReport_3.Panel1.Controls.Add(this.dtReport_3To);
            this.scReport_3.Panel1.Controls.Add(this.dtReport_3From);
            this.scReport_3.Panel1.Controls.Add(this.lblReport_3Date);
            this.scReport_3.Panel1.Controls.Add(this.btnReport_3Run);
            resources.ApplyResources(this.scReport_3.Panel1, "scReport_3.Panel1");
            // 
            // scReport_3.Panel2
            // 
            this.scReport_3.Panel2.Controls.Add(this.cbReport_3OpenReport);
            this.scReport_3.Panel2.Controls.Add(this.lvReport_3);
            this.scReport_3.Panel2.Controls.Add(this.btnReport_3Export);
            resources.ApplyResources(this.scReport_3.Panel2, "scReport_3.Panel2");
            // 
            // cbReport_3Currency
            // 
            this.cbReport_3Currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport_3Currency.FormattingEnabled = true;
            resources.ApplyResources(this.cbReport_3Currency, "cbReport_3Currency");
            this.cbReport_3Currency.Name = "cbReport_3Currency";
            // 
            // lblReport_3Currency
            // 
            resources.ApplyResources(this.lblReport_3Currency, "lblReport_3Currency");
            this.lblReport_3Currency.Name = "lblReport_3Currency";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // dtReport_3To
            // 
            resources.ApplyResources(this.dtReport_3To, "dtReport_3To");
            this.dtReport_3To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReport_3To.Name = "dtReport_3To";
            // 
            // dtReport_3From
            // 
            resources.ApplyResources(this.dtReport_3From, "dtReport_3From");
            this.dtReport_3From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReport_3From.Name = "dtReport_3From";
            // 
            // lblReport_3Date
            // 
            resources.ApplyResources(this.lblReport_3Date, "lblReport_3Date");
            this.lblReport_3Date.Name = "lblReport_3Date";
            // 
            // btnReport_3Run
            // 
            resources.ApplyResources(this.btnReport_3Run, "btnReport_3Run");
            this.btnReport_3Run.Name = "btnReport_3Run";
            this.btnReport_3Run.UseVisualStyleBackColor = true;
            this.btnReport_3Run.Click += new System.EventHandler(this.btnReport_3Run_Click);
            // 
            // cbReport_3OpenReport
            // 
            resources.ApplyResources(this.cbReport_3OpenReport, "cbReport_3OpenReport");
            this.cbReport_3OpenReport.Name = "cbReport_3OpenReport";
            this.cbReport_3OpenReport.UseVisualStyleBackColor = true;
            // 
            // lvReport_3
            // 
            resources.ApplyResources(this.lvReport_3, "lvReport_3");
            this.lvReport_3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chReport_3Date,
            this.chReport_3CurrencyCode,
            this.chReport_3ForexBuying,
            this.chReport_3ForexSelling});
            this.lvReport_3.FullRowSelect = true;
            this.lvReport_3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReport_3.HideSelection = false;
            this.lvReport_3.MultiSelect = false;
            this.lvReport_3.Name = "lvReport_3";
            this.lvReport_3.UseCompatibleStateImageBehavior = false;
            this.lvReport_3.View = System.Windows.Forms.View.Details;
            // 
            // chReport_3Date
            // 
            resources.ApplyResources(this.chReport_3Date, "chReport_3Date");
            // 
            // chReport_3CurrencyCode
            // 
            resources.ApplyResources(this.chReport_3CurrencyCode, "chReport_3CurrencyCode");
            // 
            // chReport_3ForexBuying
            // 
            resources.ApplyResources(this.chReport_3ForexBuying, "chReport_3ForexBuying");
            // 
            // chReport_3ForexSelling
            // 
            resources.ApplyResources(this.chReport_3ForexSelling, "chReport_3ForexSelling");
            // 
            // btnReport_3Export
            // 
            resources.ApplyResources(this.btnReport_3Export, "btnReport_3Export");
            this.btnReport_3Export.Name = "btnReport_3Export";
            this.btnReport_3Export.UseVisualStyleBackColor = true;
            this.btnReport_3Export.Click += new System.EventHandler(this.btnReport_3Export_Click);
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
            this.productCountToolStripMenuItem});
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
            // scMain
            // 
            resources.ApplyResources(this.scMain, "scMain");
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.pnlMenuLeft);
            this.scMain.Panel1.Controls.Add(this.tbCountCustomer);
            this.scMain.Panel1.Controls.Add(this.lblTotalCustomer);
            this.scMain.Panel1.Controls.Add(this.tbCountProduct);
            this.scMain.Panel1.Controls.Add(this.lblTotalProduct);
            this.scMain.Panel1.Controls.Add(this.tbCountCategory);
            this.scMain.Panel1.Controls.Add(this.lblTotalCategory);
            this.scMain.Panel1.Controls.Add(this.tbCountSupplier);
            this.scMain.Panel1.Controls.Add(this.lblTotalSupplier);
            this.scMain.Panel1.Controls.Add(this.tbCountWarehouse);
            this.scMain.Panel1.Controls.Add(this.lblTotalWarehouse);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pnlProduct);
            this.scMain.Panel2.Controls.Add(this.pnlReport);
            this.scMain.Panel2.Controls.Add(this.pnlStock);
            // 
            // pnlMenuLeft
            // 
            resources.ApplyResources(this.pnlMenuLeft, "pnlMenuLeft");
            this.pnlMenuLeft.Controls.Add(this.pnlMenuReport);
            this.pnlMenuLeft.Controls.Add(this.pnlMenuStock);
            this.pnlMenuLeft.Controls.Add(this.pnlMenuProduct);
            this.pnlMenuLeft.Name = "pnlMenuLeft";
            this.pnlMenuLeft.Resize += new System.EventHandler(this.pnlMenuLeft_Resize);
            // 
            // pnlMenuReport
            // 
            this.pnlMenuReport.Controls.Add(this.btnReportExchange);
            this.pnlMenuReport.Controls.Add(this.btnReportProductCount);
            this.pnlMenuReport.Controls.Add(this.btnReportProductFlow);
            this.pnlMenuReport.Controls.Add(this.btnReports);
            resources.ApplyResources(this.pnlMenuReport, "pnlMenuReport");
            this.pnlMenuReport.Name = "pnlMenuReport";
            // 
            // btnReportExchange
            // 
            resources.ApplyResources(this.btnReportExchange, "btnReportExchange");
            this.btnReportExchange.Name = "btnReportExchange";
            this.btnReportExchange.UseVisualStyleBackColor = true;
            this.btnReportExchange.Click += new System.EventHandler(this.btnReportExchange_Click);
            // 
            // btnReportProductCount
            // 
            resources.ApplyResources(this.btnReportProductCount, "btnReportProductCount");
            this.btnReportProductCount.Name = "btnReportProductCount";
            this.btnReportProductCount.UseVisualStyleBackColor = true;
            this.btnReportProductCount.Click += new System.EventHandler(this.btnReportProductCount_Click);
            // 
            // btnReportProductFlow
            // 
            resources.ApplyResources(this.btnReportProductFlow, "btnReportProductFlow");
            this.btnReportProductFlow.Name = "btnReportProductFlow";
            this.btnReportProductFlow.UseVisualStyleBackColor = true;
            this.btnReportProductFlow.Click += new System.EventHandler(this.btnReportProductFlow_Click);
            // 
            // btnReports
            // 
            resources.ApplyResources(this.btnReports, "btnReports");
            this.btnReports.Name = "btnReports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // pnlMenuStock
            // 
            this.pnlMenuStock.Controls.Add(this.btnStockOut);
            this.pnlMenuStock.Controls.Add(this.btnStockIn);
            this.pnlMenuStock.Controls.Add(this.btnStock);
            resources.ApplyResources(this.pnlMenuStock, "pnlMenuStock");
            this.pnlMenuStock.Name = "pnlMenuStock";
            // 
            // btnStockOut
            // 
            resources.ApplyResources(this.btnStockOut, "btnStockOut");
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.UseVisualStyleBackColor = true;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // btnStockIn
            // 
            resources.ApplyResources(this.btnStockIn, "btnStockIn");
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // btnStock
            // 
            resources.ApplyResources(this.btnStock, "btnStock");
            this.btnStock.Name = "btnStock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // pnlMenuProduct
            // 
            this.pnlMenuProduct.Controls.Add(this.btnCategory);
            this.pnlMenuProduct.Controls.Add(this.btnCustomer);
            this.pnlMenuProduct.Controls.Add(this.btnSupplier);
            this.pnlMenuProduct.Controls.Add(this.btnWarehouse);
            this.pnlMenuProduct.Controls.Add(this.btnProduct);
            resources.ApplyResources(this.pnlMenuProduct, "pnlMenuProduct");
            this.pnlMenuProduct.Name = "pnlMenuProduct";
            // 
            // btnCategory
            // 
            resources.ApplyResources(this.btnCategory, "btnCategory");
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCustomer
            // 
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnSupplier
            // 
            resources.ApplyResources(this.btnSupplier, "btnSupplier");
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnWarehouse
            // 
            resources.ApplyResources(this.btnWarehouse, "btnWarehouse");
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnProduct
            // 
            resources.ApplyResources(this.btnProduct, "btnProduct");
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // tbCountCustomer
            // 
            resources.ApplyResources(this.tbCountCustomer, "tbCountCustomer");
            this.tbCountCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.tbCountCustomer.Name = "tbCountCustomer";
            this.tbCountCustomer.ReadOnly = true;
            this.tbCountCustomer.TabStop = false;
            // 
            // lblTotalCustomer
            // 
            resources.ApplyResources(this.lblTotalCustomer, "lblTotalCustomer");
            this.lblTotalCustomer.Name = "lblTotalCustomer";
            // 
            // tbCountProduct
            // 
            resources.ApplyResources(this.tbCountProduct, "tbCountProduct");
            this.tbCountProduct.BackColor = System.Drawing.SystemColors.Window;
            this.tbCountProduct.Name = "tbCountProduct";
            this.tbCountProduct.ReadOnly = true;
            this.tbCountProduct.TabStop = false;
            // 
            // lblTotalProduct
            // 
            resources.ApplyResources(this.lblTotalProduct, "lblTotalProduct");
            this.lblTotalProduct.Name = "lblTotalProduct";
            // 
            // tbCountCategory
            // 
            resources.ApplyResources(this.tbCountCategory, "tbCountCategory");
            this.tbCountCategory.BackColor = System.Drawing.SystemColors.Window;
            this.tbCountCategory.Name = "tbCountCategory";
            this.tbCountCategory.ReadOnly = true;
            this.tbCountCategory.TabStop = false;
            // 
            // lblTotalCategory
            // 
            resources.ApplyResources(this.lblTotalCategory, "lblTotalCategory");
            this.lblTotalCategory.Name = "lblTotalCategory";
            // 
            // tbCountSupplier
            // 
            resources.ApplyResources(this.tbCountSupplier, "tbCountSupplier");
            this.tbCountSupplier.BackColor = System.Drawing.SystemColors.Window;
            this.tbCountSupplier.Name = "tbCountSupplier";
            this.tbCountSupplier.ReadOnly = true;
            this.tbCountSupplier.TabStop = false;
            // 
            // lblTotalSupplier
            // 
            resources.ApplyResources(this.lblTotalSupplier, "lblTotalSupplier");
            this.lblTotalSupplier.Name = "lblTotalSupplier";
            // 
            // tbCountWarehouse
            // 
            resources.ApplyResources(this.tbCountWarehouse, "tbCountWarehouse");
            this.tbCountWarehouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbCountWarehouse.Name = "tbCountWarehouse";
            this.tbCountWarehouse.ReadOnly = true;
            this.tbCountWarehouse.TabStop = false;
            // 
            // lblTotalWarehouse
            // 
            resources.ApplyResources(this.lblTotalWarehouse, "lblTotalWarehouse");
            this.lblTotalWarehouse.Name = "lblTotalWarehouse";
            // 
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.pnlReport_1);
            this.pnlReport.Controls.Add(this.pnlReport_3);
            this.pnlReport.Controls.Add(this.pnlReport_2);
            resources.ApplyResources(this.pnlReport, "pnlReport");
            this.pnlReport.Name = "pnlReport";
            // 
            // pnlReport_1
            // 
            this.pnlReport_1.Controls.Add(this.scReport_1);
            resources.ApplyResources(this.pnlReport_1, "pnlReport_1");
            this.pnlReport_1.Name = "pnlReport_1";
            // 
            // pnlReport_3
            // 
            this.pnlReport_3.Controls.Add(this.scReport_3);
            resources.ApplyResources(this.pnlReport_3, "pnlReport_3");
            this.pnlReport_3.Name = "pnlReport_3";
            // 
            // pnlReport_2
            // 
            this.pnlReport_2.Controls.Add(this.scReport_2);
            resources.ApplyResources(this.pnlReport_2, "pnlReport_2");
            this.pnlReport_2.Name = "pnlReport_2";
            // 
            // pnlStock
            // 
            this.pnlStock.Controls.Add(this.scStock);
            resources.ApplyResources(this.pnlStock, "pnlStock");
            this.pnlStock.Name = "pnlStock";
            // 
            // pnlProduct
            // 
            this.pnlProduct.Controls.Add(this.btnProductFilterClear);
            this.pnlProduct.Controls.Add(this.btnProductFilter);
            this.pnlProduct.Controls.Add(this.tbProductFilter);
            this.pnlProduct.Controls.Add(this.gbProductInfo);
            this.pnlProduct.Controls.Add(this.btnProductAdd);
            this.pnlProduct.Controls.Add(this.btnProductEdit);
            this.pnlProduct.Controls.Add(this.btnProductDelete);
            this.pnlProduct.Controls.Add(this.lvProductList);
            resources.ApplyResources(this.pnlProduct, "pnlProduct");
            this.pnlProduct.Name = "pnlProduct";
            // 
            // btnProductFilterClear
            // 
            resources.ApplyResources(this.btnProductFilterClear, "btnProductFilterClear");
            this.btnProductFilterClear.Name = "btnProductFilterClear";
            this.btnProductFilterClear.UseVisualStyleBackColor = true;
            this.btnProductFilterClear.Click += new System.EventHandler(this.btnProductFilterClear_Click);
            // 
            // btnProductFilter
            // 
            resources.ApplyResources(this.btnProductFilter, "btnProductFilter");
            this.btnProductFilter.Name = "btnProductFilter";
            this.btnProductFilter.UseVisualStyleBackColor = true;
            this.btnProductFilter.Click += new System.EventHandler(this.btnProductFilter_Click);
            // 
            // tbProductFilter
            // 
            resources.ApplyResources(this.tbProductFilter, "tbProductFilter");
            this.tbProductFilter.Name = "tbProductFilter";
            this.tbProductFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbProductFilter_KeyDown);
            // 
            // gbProductInfo
            // 
            resources.ApplyResources(this.gbProductInfo, "gbProductInfo");
            this.gbProductInfo.Controls.Add(this.lblProductBarcodeT);
            this.gbProductInfo.Controls.Add(this.lblProductBarcode);
            this.gbProductInfo.Controls.Add(this.lblProductUnitT);
            this.gbProductInfo.Controls.Add(this.lblProductUnit);
            this.gbProductInfo.Controls.Add(this.lblProductDescT);
            this.gbProductInfo.Controls.Add(this.lblProductDesc);
            this.gbProductInfo.Controls.Add(this.pbProductImage);
            this.gbProductInfo.Controls.Add(this.lblProductCategoryT);
            this.gbProductInfo.Controls.Add(this.lblProductCategory);
            this.gbProductInfo.Controls.Add(this.lblProductNameT);
            this.gbProductInfo.Controls.Add(this.lblProductIDT);
            this.gbProductInfo.Controls.Add(this.lblProductID);
            this.gbProductInfo.Controls.Add(this.lblProductName);
            this.gbProductInfo.Name = "gbProductInfo";
            this.gbProductInfo.TabStop = false;
            // 
            // lblProductBarcodeT
            // 
            resources.ApplyResources(this.lblProductBarcodeT, "lblProductBarcodeT");
            this.lblProductBarcodeT.Name = "lblProductBarcodeT";
            // 
            // lblProductBarcode
            // 
            resources.ApplyResources(this.lblProductBarcode, "lblProductBarcode");
            this.lblProductBarcode.Name = "lblProductBarcode";
            // 
            // lblProductUnitT
            // 
            resources.ApplyResources(this.lblProductUnitT, "lblProductUnitT");
            this.lblProductUnitT.Name = "lblProductUnitT";
            // 
            // lblProductUnit
            // 
            resources.ApplyResources(this.lblProductUnit, "lblProductUnit");
            this.lblProductUnit.Name = "lblProductUnit";
            // 
            // lblProductDescT
            // 
            resources.ApplyResources(this.lblProductDescT, "lblProductDescT");
            this.lblProductDescT.Name = "lblProductDescT";
            // 
            // lblProductDesc
            // 
            resources.ApplyResources(this.lblProductDesc, "lblProductDesc");
            this.lblProductDesc.Name = "lblProductDesc";
            // 
            // pbProductImage
            // 
            resources.ApplyResources(this.pbProductImage, "pbProductImage");
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.TabStop = false;
            // 
            // lblProductCategoryT
            // 
            resources.ApplyResources(this.lblProductCategoryT, "lblProductCategoryT");
            this.lblProductCategoryT.Name = "lblProductCategoryT";
            // 
            // lblProductCategory
            // 
            resources.ApplyResources(this.lblProductCategory, "lblProductCategory");
            this.lblProductCategory.Name = "lblProductCategory";
            // 
            // lblProductNameT
            // 
            resources.ApplyResources(this.lblProductNameT, "lblProductNameT");
            this.lblProductNameT.Name = "lblProductNameT";
            // 
            // lblProductIDT
            // 
            resources.ApplyResources(this.lblProductIDT, "lblProductIDT");
            this.lblProductIDT.Name = "lblProductIDT";
            // 
            // lblProductID
            // 
            resources.ApplyResources(this.lblProductID, "lblProductID");
            this.lblProductID.Name = "lblProductID";
            // 
            // lblProductName
            // 
            resources.ApplyResources(this.lblProductName, "lblProductName");
            this.lblProductName.Name = "lblProductName";
            // 
            // btnProductAdd
            // 
            resources.ApplyResources(this.btnProductAdd, "btnProductAdd");
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.UseVisualStyleBackColor = true;
            this.btnProductAdd.Click += new System.EventHandler(this.btnProductAdd_Click);
            // 
            // btnProductEdit
            // 
            resources.ApplyResources(this.btnProductEdit, "btnProductEdit");
            this.btnProductEdit.Name = "btnProductEdit";
            this.btnProductEdit.UseVisualStyleBackColor = true;
            this.btnProductEdit.Click += new System.EventHandler(this.btnProductEdit_Click);
            // 
            // btnProductDelete
            // 
            resources.ApplyResources(this.btnProductDelete, "btnProductDelete");
            this.btnProductDelete.Name = "btnProductDelete";
            this.btnProductDelete.UseVisualStyleBackColor = true;
            this.btnProductDelete.Click += new System.EventHandler(this.btnProductDelete_Click);
            // 
            // lvProductList
            // 
            resources.ApplyResources(this.lvProductList, "lvProductList");
            this.lvProductList.CheckBoxes = true;
            this.lvProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.plProductName,
            this.plProductID,
            this.plProductCategory,
            this.plProductStock,
            this.plProductPrice});
            this.lvProductList.ContextMenuStrip = this.cmsProduct;
            this.lvProductList.FullRowSelect = true;
            this.lvProductList.MultiSelect = false;
            this.lvProductList.Name = "lvProductList";
            this.lvProductList.UseCompatibleStateImageBehavior = false;
            this.lvProductList.View = System.Windows.Forms.View.Details;
            this.lvProductList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewOrder_ColumnClick);
            this.lvProductList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvProductList_ItemChecked);
            this.lvProductList.SelectedIndexChanged += new System.EventHandler(this.lvProductList_SelectedIndexChanged);
            this.lvProductList.Enter += new System.EventHandler(this.ListViewFocus_Enter);
            this.lvProductList.Leave += new System.EventHandler(this.ListViewFocus_Leave);
            // 
            // plProductName
            // 
            resources.ApplyResources(this.plProductName, "plProductName");
            // 
            // plProductID
            // 
            resources.ApplyResources(this.plProductID, "plProductID");
            // 
            // plProductCategory
            // 
            resources.ApplyResources(this.plProductCategory, "plProductCategory");
            // 
            // plProductStock
            // 
            resources.ApplyResources(this.plProductStock, "plProductStock");
            // 
            // plProductPrice
            // 
            resources.ApplyResources(this.plProductPrice, "plProductPrice");
            // 
            // cmsProduct
            // 
            this.cmsProduct.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editProductToolStripMenuItem,
            this.deleteProductToolStripMenuItem,
            this.duplicateProductToolStripMenuItem});
            this.cmsProduct.Name = "cmsWarehouse";
            resources.ApplyResources(this.cmsProduct, "cmsProduct");
            this.cmsProduct.Opening += new System.ComponentModel.CancelEventHandler(this.cmsProduct_Opening);
            // 
            // editProductToolStripMenuItem
            // 
            this.editProductToolStripMenuItem.Name = "editProductToolStripMenuItem";
            resources.ApplyResources(this.editProductToolStripMenuItem, "editProductToolStripMenuItem");
            this.editProductToolStripMenuItem.Click += new System.EventHandler(this.editProductToolStripMenuItem_Click);
            // 
            // deleteProductToolStripMenuItem
            // 
            this.deleteProductToolStripMenuItem.Name = "deleteProductToolStripMenuItem";
            resources.ApplyResources(this.deleteProductToolStripMenuItem, "deleteProductToolStripMenuItem");
            this.deleteProductToolStripMenuItem.Click += new System.EventHandler(this.deleteProductToolStripMenuItem_Click);
            // 
            // duplicateProductToolStripMenuItem
            // 
            this.duplicateProductToolStripMenuItem.Name = "duplicateProductToolStripMenuItem";
            resources.ApplyResources(this.duplicateProductToolStripMenuItem, "duplicateProductToolStripMenuItem");
            this.duplicateProductToolStripMenuItem.Click += new System.EventHandler(this.duplicateProductToolStripMenuItem_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Name = "panel1";
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
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ssBottomCurrency);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.scMain);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.scStock.Panel1.ResumeLayout(false);
            this.scStock.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scStock)).EndInit();
            this.scStock.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.cmsAddStockFlow.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.scReport_2.Panel1.ResumeLayout(false);
            this.scReport_2.Panel1.PerformLayout();
            this.scReport_2.Panel2.ResumeLayout(false);
            this.scReport_2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReport_2)).EndInit();
            this.scReport_2.ResumeLayout(false);
            this.scReport_1.Panel1.ResumeLayout(false);
            this.scReport_1.Panel1.PerformLayout();
            this.scReport_1.Panel2.ResumeLayout(false);
            this.scReport_1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReport_1)).EndInit();
            this.scReport_1.ResumeLayout(false);
            this.scReport_3.Panel1.ResumeLayout(false);
            this.scReport_3.Panel1.PerformLayout();
            this.scReport_3.Panel2.ResumeLayout(false);
            this.scReport_3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReport_3)).EndInit();
            this.scReport_3.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlMenuLeft.ResumeLayout(false);
            this.pnlMenuReport.ResumeLayout(false);
            this.pnlMenuStock.ResumeLayout(false);
            this.pnlMenuProduct.ResumeLayout(false);
            this.pnlReport.ResumeLayout(false);
            this.pnlReport_1.ResumeLayout(false);
            this.pnlReport_3.ResumeLayout(false);
            this.pnlReport_2.ResumeLayout(false);
            this.pnlStock.ResumeLayout(false);
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            this.gbProductInfo.ResumeLayout(false);
            this.gbProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.cmsProduct.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseToolStripMenuItem;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTotalWarehouse;
        private System.Windows.Forms.TextBox tbCountWarehouse;
        private System.Windows.Forms.TextBox tbCountSupplier;
        private System.Windows.Forms.Label lblTotalSupplier;
        private System.Windows.Forms.TextBox tbCountCategory;
        private System.Windows.Forms.Label lblTotalCategory;
        private System.Windows.Forms.TextBox tbCountProduct;
        private System.Windows.Forms.Label lblTotalProduct;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockOutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsProduct;
        private System.Windows.Forms.ToolStripMenuItem editProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.TextBox tbCountCustomer;
        private System.Windows.Forms.Label lblTotalCustomer;
        private System.Windows.Forms.ContextMenuStrip cmsAddStockFlow;
        private System.Windows.Forms.ToolStripMenuItem addStockInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockOutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCountToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMenuLeft;
        private System.Windows.Forms.Panel pnlMenuProduct;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Panel pnlMenuStock;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Panel pnlMenuReport;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.Button btnProductFilterClear;
        private System.Windows.Forms.Button btnProductFilter;
        private System.Windows.Forms.TextBox tbProductFilter;
        private System.Windows.Forms.GroupBox gbProductInfo;
        private System.Windows.Forms.Label lblProductBarcodeT;
        private System.Windows.Forms.Label lblProductBarcode;
        private System.Windows.Forms.Label lblProductUnitT;
        private System.Windows.Forms.Label lblProductUnit;
        private System.Windows.Forms.Label lblProductDescT;
        private System.Windows.Forms.Label lblProductDesc;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Label lblProductCategoryT;
        private System.Windows.Forms.Label lblProductCategory;
        private System.Windows.Forms.Label lblProductNameT;
        private System.Windows.Forms.Label lblProductIDT;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.Button btnProductEdit;
        private System.Windows.Forms.Button btnProductDelete;
        private System.Windows.Forms.ListView lvProductList;
        private System.Windows.Forms.ColumnHeader plProductName;
        private System.Windows.Forms.ColumnHeader plProductID;
        private System.Windows.Forms.ColumnHeader plProductCategory;
        private System.Windows.Forms.ColumnHeader plProductStock;
        private System.Windows.Forms.ColumnHeader plProductPrice;
        private System.Windows.Forms.SplitContainer scStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStockFlowAdd;
        private System.Windows.Forms.Button btnStockFlowEdit;
        private System.Windows.Forms.Button btnStockFlowDelete;
        private System.Windows.Forms.ListView lvStockFlow;
        private System.Windows.Forms.ColumnHeader stockFlowType;
        private System.Windows.Forms.ColumnHeader stockFlowID;
        private System.Windows.Forms.ColumnHeader stockFlowDate;
        private System.Windows.Forms.ColumnHeader stockFlowSupplier;
        private System.Windows.Forms.ColumnHeader stockFlowDescription;
        private System.Windows.Forms.ColumnHeader stockFlowQuantity;
        private System.Windows.Forms.ColumnHeader stockFlowTotalPrice;
        private System.Windows.Forms.ColumnHeader stockFlowStockType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Button btnStockProductAdd;
        private System.Windows.Forms.Button btnStockProductEdit;
        private System.Windows.Forms.Button btnStockProductDelete;
        private System.Windows.Forms.Label lblGrandTotalPrice;
        private System.Windows.Forms.ListView lvStockProductList;
        private System.Windows.Forms.ColumnHeader stockProductName;
        private System.Windows.Forms.ColumnHeader stockProductID;
        private System.Windows.Forms.ColumnHeader stockProductUnit;
        private System.Windows.Forms.ColumnHeader stockProductQuantity;
        private System.Windows.Forms.ColumnHeader stockProductPrice;
        private System.Windows.Forms.ColumnHeader stockProductTotalPrice;
        private System.Windows.Forms.Button btnStockOut;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.Button btnReportProductCount;
        private System.Windows.Forms.Button btnReportProductFlow;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turkishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateProductToolStripMenuItem;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Panel pnlReport_1;
        private System.Windows.Forms.Panel pnlReport_2;
        private System.Windows.Forms.SplitContainer scReport_2;
        private System.Windows.Forms.Label lblReport_2Warehouse;
        private System.Windows.Forms.ComboBox cbReport_2Warehouse;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dtReport_2To;
        private System.Windows.Forms.DateTimePicker dtReport_2From;
        private System.Windows.Forms.Label lblReport_2Date;
        private System.Windows.Forms.ComboBox cbReport_2Category;
        private System.Windows.Forms.Label lblReport_2Category;
        private System.Windows.Forms.Button btnReport_2Run;
        private System.Windows.Forms.Label lblReport_2Product;
        private System.Windows.Forms.ComboBox cbReport_2Product;
        private System.Windows.Forms.CheckBox cbReport_2OpenReport;
        private System.Windows.Forms.ListView lvReport_2;
        private System.Windows.Forms.ColumnHeader chReport_2Product;
        private System.Windows.Forms.ColumnHeader chReport_2Category;
        private System.Windows.Forms.ColumnHeader chReport_2Unit;
        private System.Windows.Forms.ColumnHeader chReport_2StockIn;
        private System.Windows.Forms.ColumnHeader chReport_2StockOut;
        private System.Windows.Forms.ColumnHeader chReport_2TotalStock;
        private System.Windows.Forms.Button btnReport_2Export;
        private System.Windows.Forms.SplitContainer scReport_1;
        private System.Windows.Forms.ComboBox cbReport_1Category;
        private System.Windows.Forms.Label lblReport_1Category;
        private System.Windows.Forms.Button btnReport_1Run;
        private System.Windows.Forms.CheckBox cbReport_1FlowOut;
        private System.Windows.Forms.CheckBox cbReport_1FlowIn;
        private System.Windows.Forms.Label lblReport_1StockFlowType;
        private System.Windows.Forms.ComboBox cbReport_1Customer;
        private System.Windows.Forms.Label btnReport_1Customer;
        private System.Windows.Forms.ComboBox cbReport_1Supplier;
        private System.Windows.Forms.Label lblReport_1Supplier;
        private System.Windows.Forms.Label lblReport_1Product;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtReport_1To;
        private System.Windows.Forms.DateTimePicker dtReport_1From;
        private System.Windows.Forms.ComboBox cbReport_1Product;
        private System.Windows.Forms.Label lblReport_1Date;
        private System.Windows.Forms.ListView lvReport_1;
        private System.Windows.Forms.ColumnHeader chReport_1ID;
        private System.Windows.Forms.ColumnHeader chReport_1Date;
        private System.Windows.Forms.ColumnHeader chReport_1Supplier;
        private System.Windows.Forms.ColumnHeader chReport_1Product;
        private System.Windows.Forms.ColumnHeader chReport_1Unit;
        private System.Windows.Forms.ColumnHeader chReport_1Quantity;
        private System.Windows.Forms.ColumnHeader chReport_1Price;
        private System.Windows.Forms.ColumnHeader chReport_1TotalPrice;
        private System.Windows.Forms.CheckBox cbReport_1OpenReport;
        private System.Windows.Forms.Button btnReport_1Export;
        private System.Windows.Forms.Button btnReportExchange;
        private System.Windows.Forms.Panel pnlReport_3;
        private System.Windows.Forms.SplitContainer scReport_3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtReport_3To;
        private System.Windows.Forms.DateTimePicker dtReport_3From;
        private System.Windows.Forms.Label lblReport_3Date;
        private System.Windows.Forms.Button btnReport_3Run;
        private System.Windows.Forms.CheckBox cbReport_3OpenReport;
        private System.Windows.Forms.ListView lvReport_3;
        private System.Windows.Forms.ColumnHeader chReport_3Date;
        private System.Windows.Forms.ColumnHeader chReport_3CurrencyCode;
        private System.Windows.Forms.ColumnHeader chReport_3ForexBuying;
        private System.Windows.Forms.ColumnHeader chReport_3ForexSelling;
        private System.Windows.Forms.Button btnReport_3Export;
        private System.Windows.Forms.StatusStrip ssBottomCurrency;
        private System.Windows.Forms.ComboBox cbReport_3Currency;
        private System.Windows.Forms.Label lblReport_3Currency;
        private System.Windows.Forms.ColumnHeader chReport_1TotalLocalPrice;
        private System.Windows.Forms.ColumnHeader stockProductTotalLocalPrice;
    }
}

