
namespace proIMP {
    partial class frmChildInventory {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChildInventory));
            this.scStock = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStockFlowAdd = new System.Windows.Forms.Button();
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
            this.pnlStock = new System.Windows.Forms.Panel();
            this.cmsAddStockFlow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addStockInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scStock)).BeginInit();
            this.scStock.Panel1.SuspendLayout();
            this.scStock.Panel2.SuspendLayout();
            this.scStock.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlStock.SuspendLayout();
            this.cmsAddStockFlow.SuspendLayout();
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
            this.btnStockFlowAdd.Name = "btnStockFlowAdd";
            this.btnStockFlowAdd.UseVisualStyleBackColor = true;
            this.btnStockFlowAdd.Click += new System.EventHandler(this.btnStockFlowAdd_Click);
            this.btnStockFlowAdd.MouseLeave += new System.EventHandler(this.btnStockFlowAdd_MouseLeave);
            this.btnStockFlowAdd.MouseHover += new System.EventHandler(this.btnStockFlowAdd_MouseHover);
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
            this.lvStockFlow.HideSelection = false;
            this.lvStockFlow.MultiSelect = false;
            this.lvStockFlow.Name = "lvStockFlow";
            this.lvStockFlow.OwnerDraw = true;
            this.lvStockFlow.UseCompatibleStateImageBehavior = false;
            this.lvStockFlow.View = System.Windows.Forms.View.Details;
            this.lvStockFlow.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvStockFlow.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_DrawColumnHeader);
            this.lvStockFlow.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView_DrawItem);
            this.lvStockFlow.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView_DrawSubItem);
            this.lvStockFlow.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvStockFlow_ItemChecked);
            this.lvStockFlow.SelectedIndexChanged += new System.EventHandler(this.lvStockFlow_SelectedIndexChanged);
            // 
            // stockFlowType
            // 
            this.stockFlowType.Tag = "string";
            resources.ApplyResources(this.stockFlowType, "stockFlowType");
            // 
            // stockFlowID
            // 
            resources.ApplyResources(this.stockFlowID, "stockFlowID");
            // 
            // stockFlowDate
            // 
            this.stockFlowDate.Tag = "DateTime";
            resources.ApplyResources(this.stockFlowDate, "stockFlowDate");
            // 
            // stockFlowSupplier
            // 
            this.stockFlowSupplier.Tag = "string";
            resources.ApplyResources(this.stockFlowSupplier, "stockFlowSupplier");
            // 
            // stockFlowDescription
            // 
            this.stockFlowDescription.Tag = "string";
            resources.ApplyResources(this.stockFlowDescription, "stockFlowDescription");
            // 
            // stockFlowQuantity
            // 
            this.stockFlowQuantity.Tag = "string";
            resources.ApplyResources(this.stockFlowQuantity, "stockFlowQuantity");
            // 
            // stockFlowTotalPrice
            // 
            this.stockFlowTotalPrice.Tag = "currency";
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
            this.lvStockProductList.HideSelection = false;
            this.lvStockProductList.MultiSelect = false;
            this.lvStockProductList.Name = "lvStockProductList";
            this.lvStockProductList.OwnerDraw = true;
            this.lvStockProductList.UseCompatibleStateImageBehavior = false;
            this.lvStockProductList.View = System.Windows.Forms.View.Details;
            this.lvStockProductList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvStockProductList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_DrawColumnHeader);
            this.lvStockProductList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView_DrawItem);
            this.lvStockProductList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView_DrawSubItem);
            this.lvStockProductList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvStockProductList_ItemChecked);
            // 
            // stockProductName
            // 
            resources.ApplyResources(this.stockProductName, "stockProductName");
            this.stockProductName.Tag = "string";
            // 
            // stockProductID
            // 
            resources.ApplyResources(this.stockProductID, "stockProductID");
            this.stockProductID.Tag = "int";
            // 
            // stockProductUnit
            // 
            this.stockProductUnit.Tag = "string";
            resources.ApplyResources(this.stockProductUnit, "stockProductUnit");
            // 
            // stockProductQuantity
            // 
            this.stockProductQuantity.Tag = "double";
            resources.ApplyResources(this.stockProductQuantity, "stockProductQuantity");
            // 
            // stockProductPrice
            // 
            this.stockProductPrice.Tag = "currency";
            resources.ApplyResources(this.stockProductPrice, "stockProductPrice");
            // 
            // stockProductTotalPrice
            // 
            this.stockProductTotalPrice.Tag = "currency";
            resources.ApplyResources(this.stockProductTotalPrice, "stockProductTotalPrice");
            // 
            // stockProductTotalLocalPrice
            // 
            this.stockProductTotalLocalPrice.Tag = "currency";
            resources.ApplyResources(this.stockProductTotalLocalPrice, "stockProductTotalLocalPrice");
            // 
            // pnlStock
            // 
            this.pnlStock.Controls.Add(this.scStock);
            resources.ApplyResources(this.pnlStock, "pnlStock");
            this.pnlStock.Name = "pnlStock";
            // 
            // cmsAddStockFlow
            // 
            this.cmsAddStockFlow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAddStockFlow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStockInToolStripMenuItem,
            this.stockOutToolStripMenuItem1});
            this.cmsAddStockFlow.Name = "cmsAddStockFlow";
            resources.ApplyResources(this.cmsAddStockFlow, "cmsAddStockFlow");
            // 
            // addStockInToolStripMenuItem
            // 
            this.addStockInToolStripMenuItem.Name = "addStockInToolStripMenuItem";
            resources.ApplyResources(this.addStockInToolStripMenuItem, "addStockInToolStripMenuItem");
            this.addStockInToolStripMenuItem.Click += new System.EventHandler(this.addStockInToolStripMenuItem_Click);
            // 
            // stockOutToolStripMenuItem1
            // 
            this.stockOutToolStripMenuItem1.Name = "stockOutToolStripMenuItem1";
            resources.ApplyResources(this.stockOutToolStripMenuItem1, "stockOutToolStripMenuItem1");
            this.stockOutToolStripMenuItem1.Click += new System.EventHandler(this.stockOutToolStripMenuItem1_Click);
            // 
            // frmChildInventory
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlStock);
            this.Name = "frmChildInventory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.scStock.Panel1.ResumeLayout(false);
            this.scStock.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scStock)).EndInit();
            this.scStock.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlStock.ResumeLayout(false);
            this.cmsAddStockFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStock;
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
        private System.Windows.Forms.ColumnHeader stockProductTotalLocalPrice;
        private System.Windows.Forms.ContextMenuStrip cmsAddStockFlow;
        private System.Windows.Forms.ToolStripMenuItem addStockInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockOutToolStripMenuItem1;
    }
}