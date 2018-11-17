namespace proIMP {
    partial class frmStockFlowIn {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbStockDesc = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpStockDate = new System.Windows.Forms.DateTimePicker();
            this.cbStockSupplier = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cbStockProductWarehouse = new System.Windows.Forms.ComboBox();
            this.lblProductListNote = new System.Windows.Forms.Label();
            this.lblGrandTotalPrice = new System.Windows.Forms.Label();
            this.tbStockGrandTotal = new System.Windows.Forms.TextBox();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.tbStockProductPrice = new System.Windows.Forms.TextBox();
            this.lblProductQuantity = new System.Windows.Forms.Label();
            this.lblProductUnit = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.tbStockProductQuantity = new System.Windows.Forms.TextBox();
            this.tbStockProductUnit = new System.Windows.Forms.TextBox();
            this.cbStockProductID = new System.Windows.Forms.ComboBox();
            this.lvStockProductList = new System.Windows.Forms.ListView();
            this.chProductFlowID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductWarehouseID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductWarehouse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductTotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStockCancel = new System.Windows.Forms.Button();
            this.btnStockSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbStockDesc);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.dtpStockDate);
            this.groupBox1.Controls.Add(this.cbStockSupplier);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblSupplier);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbStockDesc
            // 
            this.tbStockDesc.Location = new System.Drawing.Point(89, 76);
            this.tbStockDesc.Multiline = true;
            this.tbStockDesc.Name = "tbStockDesc";
            this.tbStockDesc.Size = new System.Drawing.Size(200, 46);
            this.tbStockDesc.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 79);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description :";
            // 
            // dtpStockDate
            // 
            this.dtpStockDate.CustomFormat = "dd.MM.yyyy";
            this.dtpStockDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStockDate.Location = new System.Drawing.Point(89, 23);
            this.dtpStockDate.Name = "dtpStockDate";
            this.dtpStockDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStockDate.TabIndex = 1;
            // 
            // cbStockSupplier
            // 
            this.cbStockSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStockSupplier.FormattingEnabled = true;
            this.cbStockSupplier.Location = new System.Drawing.Point(89, 49);
            this.cbStockSupplier.Name = "cbStockSupplier";
            this.cbStockSupplier.Size = new System.Drawing.Size(200, 21);
            this.cbStockSupplier.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 29);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date :";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(6, 52);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(51, 13);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblWarehouse);
            this.groupBox2.Controls.Add(this.cbStockProductWarehouse);
            this.groupBox2.Controls.Add(this.lblProductListNote);
            this.groupBox2.Controls.Add(this.lblGrandTotalPrice);
            this.groupBox2.Controls.Add(this.tbStockGrandTotal);
            this.groupBox2.Controls.Add(this.btnProductAdd);
            this.groupBox2.Controls.Add(this.lblProductPrice);
            this.groupBox2.Controls.Add(this.tbStockProductPrice);
            this.groupBox2.Controls.Add(this.lblProductQuantity);
            this.groupBox2.Controls.Add(this.lblProductUnit);
            this.groupBox2.Controls.Add(this.lblProductName);
            this.groupBox2.Controls.Add(this.tbStockProductQuantity);
            this.groupBox2.Controls.Add(this.tbStockProductUnit);
            this.groupBox2.Controls.Add(this.cbStockProductID);
            this.groupBox2.Controls.Add(this.lvStockProductList);
            this.groupBox2.Location = new System.Drawing.Point(12, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 248);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(161, 29);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(62, 13);
            this.lblWarehouse.TabIndex = 15;
            this.lblWarehouse.Text = "Warehouse";
            // 
            // cbStockProductWarehouse
            // 
            this.cbStockProductWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStockProductWarehouse.FormattingEnabled = true;
            this.cbStockProductWarehouse.Location = new System.Drawing.Point(164, 45);
            this.cbStockProductWarehouse.Name = "cbStockProductWarehouse";
            this.cbStockProductWarehouse.Size = new System.Drawing.Size(90, 21);
            this.cbStockProductWarehouse.TabIndex = 5;
            // 
            // lblProductListNote
            // 
            this.lblProductListNote.AutoSize = true;
            this.lblProductListNote.Location = new System.Drawing.Point(3, 225);
            this.lblProductListNote.Name = "lblProductListNote";
            this.lblProductListNote.Size = new System.Drawing.Size(240, 13);
            this.lblProductListNote.TabIndex = 13;
            this.lblProductListNote.Text = "* Selected items will be deleted when form saved.";
            // 
            // lblGrandTotalPrice
            // 
            this.lblGrandTotalPrice.AutoSize = true;
            this.lblGrandTotalPrice.Location = new System.Drawing.Point(439, 225);
            this.lblGrandTotalPrice.Name = "lblGrandTotalPrice";
            this.lblGrandTotalPrice.Size = new System.Drawing.Size(96, 13);
            this.lblGrandTotalPrice.TabIndex = 12;
            this.lblGrandTotalPrice.Text = "Grand Total Price :";
            // 
            // tbStockGrandTotal
            // 
            this.tbStockGrandTotal.BackColor = System.Drawing.SystemColors.Window;
            this.tbStockGrandTotal.Location = new System.Drawing.Point(548, 222);
            this.tbStockGrandTotal.Name = "tbStockGrandTotal";
            this.tbStockGrandTotal.ReadOnly = true;
            this.tbStockGrandTotal.Size = new System.Drawing.Size(100, 20);
            this.tbStockGrandTotal.TabIndex = 11;
            this.tbStockGrandTotal.TabStop = false;
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.Location = new System.Drawing.Point(548, 43);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(100, 23);
            this.btnProductAdd.TabIndex = 8;
            this.btnProductAdd.Text = "Add";
            this.btnProductAdd.UseVisualStyleBackColor = true;
            this.btnProductAdd.Click += new System.EventHandler(this.btnProductAdd_Click);
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(449, 29);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(71, 13);
            this.lblProductPrice.TabIndex = 9;
            this.lblProductPrice.Text = "Product Price";
            // 
            // tbStockProductPrice
            // 
            this.tbStockProductPrice.Location = new System.Drawing.Point(452, 45);
            this.tbStockProductPrice.Name = "tbStockProductPrice";
            this.tbStockProductPrice.Size = new System.Drawing.Size(90, 20);
            this.tbStockProductPrice.TabIndex = 7;
            this.tbStockProductPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCheckForNumeric_KeyPress);
            // 
            // lblProductQuantity
            // 
            this.lblProductQuantity.AutoSize = true;
            this.lblProductQuantity.Location = new System.Drawing.Point(353, 29);
            this.lblProductQuantity.Name = "lblProductQuantity";
            this.lblProductQuantity.Size = new System.Drawing.Size(86, 13);
            this.lblProductQuantity.TabIndex = 7;
            this.lblProductQuantity.Text = "Product Quantity";
            // 
            // lblProductUnit
            // 
            this.lblProductUnit.AutoSize = true;
            this.lblProductUnit.Location = new System.Drawing.Point(257, 29);
            this.lblProductUnit.Name = "lblProductUnit";
            this.lblProductUnit.Size = new System.Drawing.Size(66, 13);
            this.lblProductUnit.TabIndex = 6;
            this.lblProductUnit.Text = "Product Unit";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(6, 29);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 5;
            this.lblProductName.Text = "Product Name";
            // 
            // tbStockProductQuantity
            // 
            this.tbStockProductQuantity.Location = new System.Drawing.Point(356, 45);
            this.tbStockProductQuantity.Name = "tbStockProductQuantity";
            this.tbStockProductQuantity.Size = new System.Drawing.Size(90, 20);
            this.tbStockProductQuantity.TabIndex = 6;
            this.tbStockProductQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCheckForNumeric_KeyPress);
            // 
            // tbStockProductUnit
            // 
            this.tbStockProductUnit.BackColor = System.Drawing.SystemColors.Window;
            this.tbStockProductUnit.Location = new System.Drawing.Point(260, 45);
            this.tbStockProductUnit.Name = "tbStockProductUnit";
            this.tbStockProductUnit.ReadOnly = true;
            this.tbStockProductUnit.Size = new System.Drawing.Size(90, 20);
            this.tbStockProductUnit.TabIndex = 2;
            this.tbStockProductUnit.TabStop = false;
            // 
            // cbStockProductID
            // 
            this.cbStockProductID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStockProductID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStockProductID.FormattingEnabled = true;
            this.cbStockProductID.Location = new System.Drawing.Point(6, 45);
            this.cbStockProductID.Name = "cbStockProductID";
            this.cbStockProductID.Size = new System.Drawing.Size(152, 21);
            this.cbStockProductID.TabIndex = 4;
            this.cbStockProductID.SelectedIndexChanged += new System.EventHandler(this.cbStockProductID_SelectedIndexChanged);
            // 
            // lvStockProductList
            // 
            this.lvStockProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProductFlowID,
            this.chProductName,
            this.chProductWarehouseID,
            this.chProductWarehouse,
            this.chProductUnit,
            this.chProductQuantity,
            this.chProductPrice,
            this.chProductTotalPrice});
            this.lvStockProductList.FullRowSelect = true;
            this.lvStockProductList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvStockProductList.Location = new System.Drawing.Point(6, 82);
            this.lvStockProductList.MultiSelect = false;
            this.lvStockProductList.Name = "lvStockProductList";
            this.lvStockProductList.Size = new System.Drawing.Size(642, 134);
            this.lvStockProductList.TabIndex = 0;
            this.lvStockProductList.TabStop = false;
            this.lvStockProductList.UseCompatibleStateImageBehavior = false;
            this.lvStockProductList.View = System.Windows.Forms.View.Details;
            // 
            // chProductFlowID
            // 
            this.chProductFlowID.Text = "FlowID";
            this.chProductFlowID.Width = 0;
            // 
            // chProductName
            // 
            this.chProductName.Text = "Product Name";
            this.chProductName.Width = 153;
            // 
            // chProductWarehouseID
            // 
            this.chProductWarehouseID.DisplayIndex = 7;
            this.chProductWarehouseID.Text = "WarehouseID";
            this.chProductWarehouseID.Width = 0;
            // 
            // chProductWarehouse
            // 
            this.chProductWarehouse.DisplayIndex = 2;
            this.chProductWarehouse.Text = "Warehouse";
            this.chProductWarehouse.Width = 96;
            // 
            // chProductUnit
            // 
            this.chProductUnit.DisplayIndex = 3;
            this.chProductUnit.Text = "Product Unit";
            this.chProductUnit.Width = 96;
            // 
            // chProductQuantity
            // 
            this.chProductQuantity.DisplayIndex = 4;
            this.chProductQuantity.Text = "Product Quantity";
            this.chProductQuantity.Width = 96;
            // 
            // chProductPrice
            // 
            this.chProductPrice.DisplayIndex = 5;
            this.chProductPrice.Text = "Product Price";
            this.chProductPrice.Width = 96;
            // 
            // chProductTotalPrice
            // 
            this.chProductTotalPrice.DisplayIndex = 6;
            this.chProductTotalPrice.Text = "Total Price";
            this.chProductTotalPrice.Width = 96;
            // 
            // btnStockCancel
            // 
            this.btnStockCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStockCancel.Location = new System.Drawing.Point(452, 400);
            this.btnStockCancel.Name = "btnStockCancel";
            this.btnStockCancel.Size = new System.Drawing.Size(104, 29);
            this.btnStockCancel.TabIndex = 9;
            this.btnStockCancel.Text = "Cancel";
            this.btnStockCancel.UseVisualStyleBackColor = true;
            this.btnStockCancel.Click += new System.EventHandler(this.btnStockCancel_Click);
            // 
            // btnStockSave
            // 
            this.btnStockSave.Location = new System.Drawing.Point(562, 400);
            this.btnStockSave.Name = "btnStockSave";
            this.btnStockSave.Size = new System.Drawing.Size(104, 29);
            this.btnStockSave.TabIndex = 10;
            this.btnStockSave.Text = "Save";
            this.btnStockSave.UseVisualStyleBackColor = true;
            this.btnStockSave.Click += new System.EventHandler(this.btnStockSave_Click);
            // 
            // frmStockFlowIn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnStockCancel;
            this.ClientSize = new System.Drawing.Size(678, 441);
            this.Controls.Add(this.btnStockSave);
            this.Controls.Add(this.btnStockCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockFlowIn";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Flow In";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStockFlowIn_FormClosing);
            this.Load += new System.EventHandler(this.frmStockFlowIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.TextBox tbStockProductPrice;
        private System.Windows.Forms.Label lblProductQuantity;
        private System.Windows.Forms.Label lblProductUnit;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox tbStockProductQuantity;
        private System.Windows.Forms.TextBox tbStockProductUnit;
        private System.Windows.Forms.ComboBox cbStockProductID;
        private System.Windows.Forms.ListView lvStockProductList;
        private System.Windows.Forms.ColumnHeader chProductFlowID;
        private System.Windows.Forms.ColumnHeader chProductName;
        private System.Windows.Forms.ColumnHeader chProductUnit;
        private System.Windows.Forms.ColumnHeader chProductQuantity;
        private System.Windows.Forms.ColumnHeader chProductPrice;
        private System.Windows.Forms.ColumnHeader chProductTotalPrice;
        private System.Windows.Forms.TextBox tbStockDesc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DateTimePicker dtpStockDate;
        private System.Windows.Forms.ComboBox cbStockSupplier;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox tbStockGrandTotal;
        private System.Windows.Forms.Label lblGrandTotalPrice;
        private System.Windows.Forms.Button btnStockCancel;
        private System.Windows.Forms.Button btnStockSave;
        private System.Windows.Forms.Label lblProductListNote;
        private System.Windows.Forms.ComboBox cbStockProductWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.ColumnHeader chProductWarehouse;
        private System.Windows.Forms.ColumnHeader chProductWarehouseID;
    }
}