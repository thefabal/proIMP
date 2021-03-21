
namespace proIMP {
    partial class frmChildProducts {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChildProducts));
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
            this.pnlProduct.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.cmsProduct.SuspendLayout();
            this.SuspendLayout();
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
            this.lvProductList.HideSelection = false;
            this.lvProductList.MultiSelect = false;
            this.lvProductList.Name = "lvProductList";
            this.lvProductList.OwnerDraw = true;
            this.lvProductList.UseCompatibleStateImageBehavior = false;
            this.lvProductList.View = System.Windows.Forms.View.Details;
            this.lvProductList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProductList_ColumnClick);
            this.lvProductList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvProductList_DrawColumnHeader);
            this.lvProductList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvProductList_DrawItem);
            this.lvProductList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvProductList_DrawSubItem);
            this.lvProductList.SelectedIndexChanged += new System.EventHandler(this.lvProductList_SelectedIndexChanged);
            // 
            // plProductName
            // 
            this.plProductName.Tag = "string";
            resources.ApplyResources(this.plProductName, "plProductName");
            // 
            // plProductID
            // 
            this.plProductID.Tag = "int";
            resources.ApplyResources(this.plProductID, "plProductID");
            // 
            // plProductCategory
            // 
            this.plProductCategory.Tag = "string";
            resources.ApplyResources(this.plProductCategory, "plProductCategory");
            // 
            // plProductStock
            // 
            this.plProductStock.Tag = "int";
            resources.ApplyResources(this.plProductStock, "plProductStock");
            // 
            // plProductPrice
            // 
            this.plProductPrice.Tag = "double";
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
            // frmChildProducts
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlProduct);
            this.Name = "frmChildProducts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmChildProducts_Load);
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            this.gbProductInfo.ResumeLayout(false);
            this.gbProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.cmsProduct.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.ContextMenuStrip cmsProduct;
        private System.Windows.Forms.ToolStripMenuItem editProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateProductToolStripMenuItem;
    }
}