namespace proIMP {
    partial class frmProduct {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.msChangeImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblProductDesc = new System.Windows.Forms.Label();
            this.tbProductBarcode = new System.Windows.Forms.TextBox();
            this.lblProductBarcode = new System.Windows.Forms.Label();
            this.lblProductUnit = new System.Windows.Forms.Label();
            this.tbProductDesc = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCategoryAdd = new System.Windows.Forms.Button();
            this.cbProductCategory = new System.Windows.Forms.ComboBox();
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.cbProductUnit = new System.Windows.Forms.ComboBox();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.msChangeImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbProductImage
            // 
            this.pbProductImage.ContextMenuStrip = this.msChangeImage;
            this.pbProductImage.Image = global::proIMP.Properties.Resources.noimage_en;
            this.pbProductImage.Location = new System.Drawing.Point(12, 14);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(178, 178);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 37;
            this.pbProductImage.TabStop = false;
            // 
            // msChangeImage
            // 
            this.msChangeImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.msChangeImage.Name = "msChangeImage";
            this.msChangeImage.Size = new System.Drawing.Size(152, 48);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.changeToolStripMenuItem.Text = "Change Image";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.deleteToolStripMenuItem.Text = "Delete Image";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblProductDesc
            // 
            this.lblProductDesc.AutoSize = true;
            this.lblProductDesc.Location = new System.Drawing.Point(198, 94);
            this.lblProductDesc.Name = "lblProductDesc";
            this.lblProductDesc.Size = new System.Drawing.Size(81, 13);
            this.lblProductDesc.TabIndex = 36;
            this.lblProductDesc.Text = "Product Desc. :";
            // 
            // tbProductBarcode
            // 
            this.tbProductBarcode.Location = new System.Drawing.Point(301, 170);
            this.tbProductBarcode.Name = "tbProductBarcode";
            this.tbProductBarcode.Size = new System.Drawing.Size(155, 20);
            this.tbProductBarcode.TabIndex = 6;
            // 
            // lblProductBarcode
            // 
            this.lblProductBarcode.AutoSize = true;
            this.lblProductBarcode.Location = new System.Drawing.Point(198, 173);
            this.lblProductBarcode.Name = "lblProductBarcode";
            this.lblProductBarcode.Size = new System.Drawing.Size(93, 13);
            this.lblProductBarcode.TabIndex = 34;
            this.lblProductBarcode.Text = "Product Barcode :";
            // 
            // lblProductUnit
            // 
            this.lblProductUnit.AutoSize = true;
            this.lblProductUnit.Location = new System.Drawing.Point(198, 146);
            this.lblProductUnit.Name = "lblProductUnit";
            this.lblProductUnit.Size = new System.Drawing.Size(72, 13);
            this.lblProductUnit.TabIndex = 32;
            this.lblProductUnit.Text = "Product Unit :";
            // 
            // tbProductDesc
            // 
            this.tbProductDesc.Location = new System.Drawing.Point(301, 91);
            this.tbProductDesc.Multiline = true;
            this.tbProductDesc.Name = "tbProductDesc";
            this.tbProductDesc.Size = new System.Drawing.Size(155, 46);
            this.tbProductDesc.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(301, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(381, 196);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
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
            this.btnCategoryAdd.Location = new System.Drawing.Point(433, 64);
            this.btnCategoryAdd.Name = "btnCategoryAdd";
            this.btnCategoryAdd.Size = new System.Drawing.Size(21, 21);
            this.btnCategoryAdd.TabIndex = 3;
            this.btnCategoryAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategoryAdd.UseVisualStyleBackColor = true;
            this.btnCategoryAdd.Click += new System.EventHandler(this.btnCategoryAdd_Click);
            // 
            // cbProductCategory
            // 
            this.cbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductCategory.FormattingEnabled = true;
            this.cbProductCategory.Location = new System.Drawing.Point(301, 64);
            this.cbProductCategory.Name = "cbProductCategory";
            this.cbProductCategory.Size = new System.Drawing.Size(126, 21);
            this.cbProductCategory.TabIndex = 2;
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.AutoSize = true;
            this.lblProductCategory.Location = new System.Drawing.Point(198, 67);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(95, 13);
            this.lblProductCategory.TabIndex = 26;
            this.lblProductCategory.Text = "Product Category :";
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(301, 38);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(155, 20);
            this.tbProductName.TabIndex = 1;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(198, 41);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(81, 13);
            this.lblProductName.TabIndex = 24;
            this.lblProductName.Text = "Product Name :";
            // 
            // cbProductUnit
            // 
            this.cbProductUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductUnit.FormattingEnabled = true;
            this.cbProductUnit.Location = new System.Drawing.Point(301, 143);
            this.cbProductUnit.Name = "cbProductUnit";
            this.cbProductUnit.Size = new System.Drawing.Size(155, 21);
            this.cbProductUnit.TabIndex = 5;
            // 
            // tbProductID
            // 
            this.tbProductID.BackColor = System.Drawing.SystemColors.Window;
            this.tbProductID.Location = new System.Drawing.Point(301, 12);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.ReadOnly = true;
            this.tbProductID.Size = new System.Drawing.Size(155, 20);
            this.tbProductID.TabIndex = 39;
            this.tbProductID.TabStop = false;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(198, 15);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(64, 13);
            this.lblProductID.TabIndex = 38;
            this.lblProductID.Text = "Product ID :";
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(466, 232);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.pbProductImage);
            this.Controls.Add(this.lblProductDesc);
            this.Controls.Add(this.tbProductBarcode);
            this.Controls.Add(this.lblProductBarcode);
            this.Controls.Add(this.cbProductUnit);
            this.Controls.Add(this.lblProductUnit);
            this.Controls.Add(this.tbProductDesc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCategoryAdd);
            this.Controls.Add(this.cbProductCategory);
            this.Controls.Add(this.lblProductCategory);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.lblProductName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProduct";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add / Edit Product";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.msChangeImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Label lblProductDesc;
        private System.Windows.Forms.TextBox tbProductBarcode;
        private System.Windows.Forms.Label lblProductBarcode;
        private System.Windows.Forms.Label lblProductUnit;
        private System.Windows.Forms.TextBox tbProductDesc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCategoryAdd;
        private System.Windows.Forms.ComboBox cbProductCategory;
        private System.Windows.Forms.Label lblProductCategory;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.ComboBox cbProductUnit;
        private System.Windows.Forms.ContextMenuStrip msChangeImage;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lblProductID;
    }
}