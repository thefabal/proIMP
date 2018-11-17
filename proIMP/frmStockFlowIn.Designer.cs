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
            this.label7 = new System.Windows.Forms.Label();
            this.dtpStockDate = new System.Windows.Forms.DateTimePicker();
            this.cbStockSupplier = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStockProductWarehouse = new System.Windows.Forms.ComboBox();
            this.lblProductListNote = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbStockGrandTotal = new System.Windows.Forms.TextBox();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStockProductPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStockProductQuantity = new System.Windows.Forms.TextBox();
            this.tbStockProductUnit = new System.Windows.Forms.TextBox();
            this.cbStockProductID = new System.Windows.Forms.ComboBox();
            this.lvStockProductList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStockCancel = new System.Windows.Forms.Button();
            this.btnStockSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbStockDesc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpStockDate);
            this.groupBox1.Controls.Add(this.cbStockSupplier);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Description :";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Supplier :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbStockProductWarehouse);
            this.groupBox2.Controls.Add(this.lblProductListNote);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbStockGrandTotal);
            this.groupBox2.Controls.Add(this.btnProductAdd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbStockProductPrice);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Warehouse";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(439, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Grand Total Price :";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Product Price";
            // 
            // tbStockProductPrice
            // 
            this.tbStockProductPrice.Location = new System.Drawing.Point(452, 45);
            this.tbStockProductPrice.Name = "tbStockProductPrice";
            this.tbStockProductPrice.Size = new System.Drawing.Size(90, 20);
            this.tbStockProductPrice.TabIndex = 7;
            this.tbStockProductPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCheckForNumeric_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Product Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Product Unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product Name";
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
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader7,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
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
            // columnHeader1
            // 
            this.columnHeader1.Text = "FlowID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product Name";
            this.columnHeader2.Width = 153;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 7;
            this.columnHeader8.Text = "WarehouseID";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 2;
            this.columnHeader7.Text = "Warehouse";
            this.columnHeader7.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 3;
            this.columnHeader3.Text = "Product Unit";
            this.columnHeader3.Width = 96;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 4;
            this.columnHeader4.Text = "Product Quantity";
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 5;
            this.columnHeader5.Text = "Product Price";
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 6;
            this.columnHeader6.Text = "Total Price";
            this.columnHeader6.Width = 96;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStockProductPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStockProductQuantity;
        private System.Windows.Forms.TextBox tbStockProductUnit;
        private System.Windows.Forms.ComboBox cbStockProductID;
        private System.Windows.Forms.ListView lvStockProductList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox tbStockDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStockDate;
        private System.Windows.Forms.ComboBox cbStockSupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStockGrandTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStockCancel;
        private System.Windows.Forms.Button btnStockSave;
        private System.Windows.Forms.Label lblProductListNote;
        private System.Windows.Forms.ComboBox cbStockProductWarehouse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}