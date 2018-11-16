namespace proIMP {
    partial class frmSupplier {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.deleteSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSupplier = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chSupplierDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSupplierName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSupplierID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvSupplier = new System.Windows.Forms.ListView();
            this.gbSupplierList = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbSupplierInfo = new System.Windows.Forms.GroupBox();
            this.lblSupplierID = new System.Windows.Forms.Label();
            this.lblSupplierDesc = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbSupplierID = new System.Windows.Forms.TextBox();
            this.tbSupplierDesc = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.cmsSupplier.SuspendLayout();
            this.gbSupplierList.SuspendLayout();
            this.gbSupplierInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteSupplierToolStripMenuItem
            // 
            this.deleteSupplierToolStripMenuItem.Name = "deleteSupplierToolStripMenuItem";
            this.deleteSupplierToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteSupplierToolStripMenuItem.Text = "Delete Supplier";
            this.deleteSupplierToolStripMenuItem.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmsSupplier
            // 
            this.cmsSupplier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSupplierToolStripMenuItem,
            this.deleteSupplierToolStripMenuItem});
            this.cmsSupplier.Name = "cmsWarehouse";
            this.cmsSupplier.Size = new System.Drawing.Size(154, 48);
            this.cmsSupplier.Opening += new System.ComponentModel.CancelEventHandler(this.cmsSupplier_Opening);
            // 
            // editSupplierToolStripMenuItem
            // 
            this.editSupplierToolStripMenuItem.Name = "editSupplierToolStripMenuItem";
            this.editSupplierToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editSupplierToolStripMenuItem.Text = "Edit Supplier";
            this.editSupplierToolStripMenuItem.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // chSupplierDesc
            // 
            this.chSupplierDesc.Text = "Description";
            this.chSupplierDesc.Width = 180;
            // 
            // chSupplierName
            // 
            this.chSupplierName.Text = "Name";
            this.chSupplierName.Width = 140;
            // 
            // chSupplierID
            // 
            this.chSupplierID.Text = "ID";
            this.chSupplierID.Width = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(149, 137);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 29);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(259, 137);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lvSupplier
            // 
            this.lvSupplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSupplierID,
            this.chSupplierName,
            this.chSupplierDesc});
            this.lvSupplier.ContextMenuStrip = this.cmsSupplier;
            this.lvSupplier.FullRowSelect = true;
            this.lvSupplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSupplier.Location = new System.Drawing.Point(9, 19);
            this.lvSupplier.MultiSelect = false;
            this.lvSupplier.Name = "lvSupplier";
            this.lvSupplier.Size = new System.Drawing.Size(354, 112);
            this.lvSupplier.TabIndex = 0;
            this.lvSupplier.UseCompatibleStateImageBehavior = false;
            this.lvSupplier.View = System.Windows.Forms.View.Details;
            this.lvSupplier.SelectedIndexChanged += new System.EventHandler(this.lvSupplier_SelectedIndexChanged);
            this.lvSupplier.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSupplier_MouseDoubleClick);
            // 
            // gbSupplierList
            // 
            this.gbSupplierList.Controls.Add(this.btnEdit);
            this.gbSupplierList.Controls.Add(this.btnDelete);
            this.gbSupplierList.Controls.Add(this.lvSupplier);
            this.gbSupplierList.Location = new System.Drawing.Point(13, 151);
            this.gbSupplierList.Name = "gbSupplierList";
            this.gbSupplierList.Size = new System.Drawing.Size(369, 173);
            this.gbSupplierList.TabIndex = 8;
            this.gbSupplierList.TabStop = false;
            this.gbSupplierList.Text = "Supplier List";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(259, 53);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 29);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gbSupplierInfo
            // 
            this.gbSupplierInfo.Controls.Add(this.btnClear);
            this.gbSupplierInfo.Controls.Add(this.lblSupplierID);
            this.gbSupplierInfo.Controls.Add(this.lblSupplierDesc);
            this.gbSupplierInfo.Controls.Add(this.btnCancel);
            this.gbSupplierInfo.Controls.Add(this.tbSupplierID);
            this.gbSupplierInfo.Controls.Add(this.tbSupplierDesc);
            this.gbSupplierInfo.Controls.Add(this.btnSave);
            this.gbSupplierInfo.Controls.Add(this.lblSupplierName);
            this.gbSupplierInfo.Controls.Add(this.tbSupplierName);
            this.gbSupplierInfo.Location = new System.Drawing.Point(13, 13);
            this.gbSupplierInfo.Name = "gbSupplierInfo";
            this.gbSupplierInfo.Size = new System.Drawing.Size(369, 132);
            this.gbSupplierInfo.TabIndex = 7;
            this.gbSupplierInfo.TabStop = false;
            this.gbSupplierInfo.Text = "Supplier Info";
            // 
            // lblSupplierID
            // 
            this.lblSupplierID.AutoSize = true;
            this.lblSupplierID.Location = new System.Drawing.Point(6, 21);
            this.lblSupplierID.Name = "lblSupplierID";
            this.lblSupplierID.Size = new System.Drawing.Size(65, 13);
            this.lblSupplierID.TabIndex = 0;
            this.lblSupplierID.Text = "Supplier ID :";
            // 
            // lblSupplierDesc
            // 
            this.lblSupplierDesc.AutoSize = true;
            this.lblSupplierDesc.Location = new System.Drawing.Point(6, 73);
            this.lblSupplierDesc.Name = "lblSupplierDesc";
            this.lblSupplierDesc.Size = new System.Drawing.Size(82, 13);
            this.lblSupplierDesc.TabIndex = 2;
            this.lblSupplierDesc.Text = "Supplier Desc. :";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(259, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbSupplierID
            // 
            this.tbSupplierID.BackColor = System.Drawing.SystemColors.Window;
            this.tbSupplierID.Location = new System.Drawing.Point(111, 18);
            this.tbSupplierID.Name = "tbSupplierID";
            this.tbSupplierID.ReadOnly = true;
            this.tbSupplierID.Size = new System.Drawing.Size(142, 20);
            this.tbSupplierID.TabIndex = 0;
            this.tbSupplierID.TabStop = false;
            // 
            // tbSupplierDesc
            // 
            this.tbSupplierDesc.Location = new System.Drawing.Point(111, 70);
            this.tbSupplierDesc.Multiline = true;
            this.tbSupplierDesc.Name = "tbSupplierDesc";
            this.tbSupplierDesc.Size = new System.Drawing.Size(142, 46);
            this.tbSupplierDesc.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(259, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(6, 47);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(82, 13);
            this.lblSupplierName.TabIndex = 1;
            this.lblSupplierName.Text = "Supplier Name :";
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.Location = new System.Drawing.Point(111, 44);
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.Size = new System.Drawing.Size(142, 20);
            this.tbSupplierName.TabIndex = 0;
            // 
            // frmSupplier
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 336);
            this.Controls.Add(this.gbSupplierList);
            this.Controls.Add(this.gbSupplierInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplier";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Supplier Management";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.cmsSupplier.ResumeLayout(false);
            this.gbSupplierList.ResumeLayout(false);
            this.gbSupplierInfo.ResumeLayout(false);
            this.gbSupplierInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem deleteSupplierToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsSupplier;
        private System.Windows.Forms.ToolStripMenuItem editSupplierToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chSupplierDesc;
        private System.Windows.Forms.ColumnHeader chSupplierName;
        private System.Windows.Forms.ColumnHeader chSupplierID;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvSupplier;
        private System.Windows.Forms.GroupBox gbSupplierList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbSupplierInfo;
        private System.Windows.Forms.Label lblSupplierID;
        private System.Windows.Forms.Label lblSupplierDesc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbSupplierID;
        private System.Windows.Forms.TextBox tbSupplierDesc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox tbSupplierName;
    }
}