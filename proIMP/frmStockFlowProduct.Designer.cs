namespace proIMP {
    partial class frmStockFlowProduct {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockFlowProduct));
            this.tbStockProductPrice = new System.Windows.Forms.TextBox();
            this.tbStockProductQuantity = new System.Windows.Forms.TextBox();
            this.tbStockProductUnit = new System.Windows.Forms.TextBox();
            this.cbStockProductID = new System.Windows.Forms.ComboBox();
            this.lblProductUnit = new System.Windows.Forms.Label();
            this.lblProductQuantity = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCategoryAdd = new System.Windows.Forms.Button();
            this.lblProductWarehouse = new System.Windows.Forms.Label();
            this.cbStockProductWarehouse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbStockProductPrice
            // 
            this.tbStockProductPrice.Location = new System.Drawing.Point(130, 118);
            this.tbStockProductPrice.Name = "tbStockProductPrice";
            this.tbStockProductPrice.Size = new System.Drawing.Size(100, 20);
            this.tbStockProductPrice.TabIndex = 3;
            this.tbStockProductPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStockProductQuantity_KeyPress);
            // 
            // tbStockProductQuantity
            // 
            this.tbStockProductQuantity.Location = new System.Drawing.Point(130, 92);
            this.tbStockProductQuantity.Name = "tbStockProductQuantity";
            this.tbStockProductQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbStockProductQuantity.TabIndex = 2;
            this.tbStockProductQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStockProductQuantity_KeyPress);
            // 
            // tbStockProductUnit
            // 
            this.tbStockProductUnit.BackColor = System.Drawing.SystemColors.Window;
            this.tbStockProductUnit.Location = new System.Drawing.Point(130, 39);
            this.tbStockProductUnit.Name = "tbStockProductUnit";
            this.tbStockProductUnit.ReadOnly = true;
            this.tbStockProductUnit.Size = new System.Drawing.Size(100, 20);
            this.tbStockProductUnit.TabIndex = 2;
            this.tbStockProductUnit.TabStop = false;
            // 
            // cbStockProductID
            // 
            this.cbStockProductID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStockProductID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStockProductID.FormattingEnabled = true;
            this.cbStockProductID.Location = new System.Drawing.Point(12, 12);
            this.cbStockProductID.Name = "cbStockProductID";
            this.cbStockProductID.Size = new System.Drawing.Size(189, 21);
            this.cbStockProductID.TabIndex = 0;
            this.cbStockProductID.SelectedIndexChanged += new System.EventHandler(this.cbStockProductID_SelectedIndexChanged);
            // 
            // lblProductUnit
            // 
            this.lblProductUnit.AutoSize = true;
            this.lblProductUnit.Location = new System.Drawing.Point(12, 42);
            this.lblProductUnit.Name = "lblProductUnit";
            this.lblProductUnit.Size = new System.Drawing.Size(72, 13);
            this.lblProductUnit.TabIndex = 11;
            this.lblProductUnit.Text = "Product Unit :";
            // 
            // lblProductQuantity
            // 
            this.lblProductQuantity.AutoSize = true;
            this.lblProductQuantity.Location = new System.Drawing.Point(12, 95);
            this.lblProductQuantity.Name = "lblProductQuantity";
            this.lblProductQuantity.Size = new System.Drawing.Size(92, 13);
            this.lblProductQuantity.TabIndex = 12;
            this.lblProductQuantity.Text = "Product Quantity :";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(12, 121);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(77, 13);
            this.lblProductPrice.TabIndex = 13;
            this.lblProductPrice.Text = "Product Price :";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(74, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(155, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCategoryAdd
            // 
            this.btnCategoryAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCategoryAdd.FlatAppearance.BorderSize = 0;
            this.btnCategoryAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnCategoryAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnCategoryAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoryAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryAdd.Image")));
            this.btnCategoryAdd.Location = new System.Drawing.Point(207, 12);
            this.btnCategoryAdd.Name = "btnCategoryAdd";
            this.btnCategoryAdd.Size = new System.Drawing.Size(21, 21);
            this.btnCategoryAdd.TabIndex = 33;
            this.btnCategoryAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategoryAdd.UseVisualStyleBackColor = true;
            this.btnCategoryAdd.Click += new System.EventHandler(this.btnCategoryAdd_Click);
            // 
            // lblProductWarehouse
            // 
            this.lblProductWarehouse.AutoSize = true;
            this.lblProductWarehouse.Location = new System.Drawing.Point(12, 68);
            this.lblProductWarehouse.Name = "lblProductWarehouse";
            this.lblProductWarehouse.Size = new System.Drawing.Size(108, 13);
            this.lblProductWarehouse.TabIndex = 35;
            this.lblProductWarehouse.Text = "Product Warehouse :";
            // 
            // cbStockProductWarehouse
            // 
            this.cbStockProductWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStockProductWarehouse.FormattingEnabled = true;
            this.cbStockProductWarehouse.Location = new System.Drawing.Point(130, 65);
            this.cbStockProductWarehouse.Name = "cbStockProductWarehouse";
            this.cbStockProductWarehouse.Size = new System.Drawing.Size(100, 21);
            this.cbStockProductWarehouse.TabIndex = 1;
            // 
            // frmStockFlowProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(240, 178);
            this.Controls.Add(this.cbStockProductWarehouse);
            this.Controls.Add(this.lblProductWarehouse);
            this.Controls.Add(this.btnCategoryAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.lblProductQuantity);
            this.Controls.Add(this.lblProductUnit);
            this.Controls.Add(this.tbStockProductPrice);
            this.Controls.Add(this.tbStockProductQuantity);
            this.Controls.Add(this.tbStockProductUnit);
            this.Controls.Add(this.cbStockProductID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockFlowProduct";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Flow Product";
            this.Load += new System.EventHandler(this.frmStockFlowProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStockProductPrice;
        private System.Windows.Forms.TextBox tbStockProductQuantity;
        private System.Windows.Forms.TextBox tbStockProductUnit;
        private System.Windows.Forms.ComboBox cbStockProductID;
        private System.Windows.Forms.Label lblProductUnit;
        private System.Windows.Forms.Label lblProductQuantity;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCategoryAdd;
        private System.Windows.Forms.Label lblProductWarehouse;
        private System.Windows.Forms.ComboBox cbStockProductWarehouse;
    }
}