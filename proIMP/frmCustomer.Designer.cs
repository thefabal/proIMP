namespace proIMP {
    partial class frmCustomer {
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
            this.gbCustomerList = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvCustomer = new System.Windows.Forms.ListView();
            this.chCustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCustomerDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsCustomer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCustomerInfo = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblCustomerDesc = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbCustomerID = new System.Windows.Forms.TextBox();
            this.tbCustomerDesc = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.gbCustomerList.SuspendLayout();
            this.cmsCustomer.SuspendLayout();
            this.gbCustomerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCustomerList
            // 
            this.gbCustomerList.Controls.Add(this.btnEdit);
            this.gbCustomerList.Controls.Add(this.btnDelete);
            this.gbCustomerList.Controls.Add(this.lvCustomer);
            this.gbCustomerList.Location = new System.Drawing.Point(13, 151);
            this.gbCustomerList.Name = "gbCustomerList";
            this.gbCustomerList.Size = new System.Drawing.Size(369, 173);
            this.gbCustomerList.TabIndex = 10;
            this.gbCustomerList.TabStop = false;
            this.gbCustomerList.Text = "Customer List";
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
            // lvCustomer
            // 
            this.lvCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCustomerID,
            this.chCustomerName,
            this.chCustomerDesc});
            this.lvCustomer.ContextMenuStrip = this.cmsCustomer;
            this.lvCustomer.FullRowSelect = true;
            this.lvCustomer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCustomer.Location = new System.Drawing.Point(9, 19);
            this.lvCustomer.MultiSelect = false;
            this.lvCustomer.Name = "lvCustomer";
            this.lvCustomer.Size = new System.Drawing.Size(354, 112);
            this.lvCustomer.TabIndex = 0;
            this.lvCustomer.UseCompatibleStateImageBehavior = false;
            this.lvCustomer.View = System.Windows.Forms.View.Details;
            this.lvCustomer.SelectedIndexChanged += new System.EventHandler(this.lvCustomer_SelectedIndexChanged);
            this.lvCustomer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCustomer_MouseDoubleClick);
            // 
            // chCustomerID
            // 
            this.chCustomerID.Text = "ID";
            this.chCustomerID.Width = 0;
            // 
            // chCustomerName
            // 
            this.chCustomerName.Text = "Name";
            this.chCustomerName.Width = 140;
            // 
            // chCustomerDesc
            // 
            this.chCustomerDesc.Text = "Description";
            this.chCustomerDesc.Width = 180;
            // 
            // cmsCustomer
            // 
            this.cmsCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSupplierToolStripMenuItem,
            this.deleteSupplierToolStripMenuItem});
            this.cmsCustomer.Name = "cmsWarehouse";
            this.cmsCustomer.Size = new System.Drawing.Size(163, 48);
            this.cmsCustomer.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCustomer_Opening);
            // 
            // editSupplierToolStripMenuItem
            // 
            this.editSupplierToolStripMenuItem.Name = "editSupplierToolStripMenuItem";
            this.editSupplierToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editSupplierToolStripMenuItem.Text = "Edit Customer";
            this.editSupplierToolStripMenuItem.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // deleteSupplierToolStripMenuItem
            // 
            this.deleteSupplierToolStripMenuItem.Name = "deleteSupplierToolStripMenuItem";
            this.deleteSupplierToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.deleteSupplierToolStripMenuItem.Text = "Delete Customer";
            this.deleteSupplierToolStripMenuItem.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbCustomerInfo
            // 
            this.gbCustomerInfo.Controls.Add(this.btnClear);
            this.gbCustomerInfo.Controls.Add(this.lblCustomerID);
            this.gbCustomerInfo.Controls.Add(this.lblCustomerDesc);
            this.gbCustomerInfo.Controls.Add(this.btnCancel);
            this.gbCustomerInfo.Controls.Add(this.tbCustomerID);
            this.gbCustomerInfo.Controls.Add(this.tbCustomerDesc);
            this.gbCustomerInfo.Controls.Add(this.btnSave);
            this.gbCustomerInfo.Controls.Add(this.lblCustomerName);
            this.gbCustomerInfo.Controls.Add(this.tbCustomerName);
            this.gbCustomerInfo.Location = new System.Drawing.Point(13, 13);
            this.gbCustomerInfo.Name = "gbCustomerInfo";
            this.gbCustomerInfo.Size = new System.Drawing.Size(369, 132);
            this.gbCustomerInfo.TabIndex = 9;
            this.gbCustomerInfo.TabStop = false;
            this.gbCustomerInfo.Text = "Customer Info";
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
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(6, 21);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(71, 13);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "Customer ID :";
            // 
            // lblCustomerDesc
            // 
            this.lblCustomerDesc.AutoSize = true;
            this.lblCustomerDesc.Location = new System.Drawing.Point(6, 73);
            this.lblCustomerDesc.Name = "lblCustomerDesc";
            this.lblCustomerDesc.Size = new System.Drawing.Size(88, 13);
            this.lblCustomerDesc.TabIndex = 2;
            this.lblCustomerDesc.Text = "Customer Desc. :";
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
            // tbCustomerID
            // 
            this.tbCustomerID.BackColor = System.Drawing.SystemColors.Window;
            this.tbCustomerID.Location = new System.Drawing.Point(111, 18);
            this.tbCustomerID.Name = "tbCustomerID";
            this.tbCustomerID.ReadOnly = true;
            this.tbCustomerID.Size = new System.Drawing.Size(142, 20);
            this.tbCustomerID.TabIndex = 0;
            this.tbCustomerID.TabStop = false;
            // 
            // tbCustomerDesc
            // 
            this.tbCustomerDesc.Location = new System.Drawing.Point(111, 70);
            this.tbCustomerDesc.Multiline = true;
            this.tbCustomerDesc.Name = "tbCustomerDesc";
            this.tbCustomerDesc.Size = new System.Drawing.Size(142, 46);
            this.tbCustomerDesc.TabIndex = 1;
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
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(6, 47);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(88, 13);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Customer Name :";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Location = new System.Drawing.Point(111, 44);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(142, 20);
            this.tbCustomerName.TabIndex = 0;
            // 
            // frmCustomer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 336);
            this.Controls.Add(this.gbCustomerList);
            this.Controls.Add(this.gbCustomerInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Management";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.gbCustomerList.ResumeLayout(false);
            this.cmsCustomer.ResumeLayout(false);
            this.gbCustomerInfo.ResumeLayout(false);
            this.gbCustomerInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCustomerList;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvCustomer;
        private System.Windows.Forms.ColumnHeader chCustomerID;
        private System.Windows.Forms.ColumnHeader chCustomerName;
        private System.Windows.Forms.ColumnHeader chCustomerDesc;
        private System.Windows.Forms.GroupBox gbCustomerInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblCustomerDesc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbCustomerID;
        private System.Windows.Forms.TextBox tbCustomerDesc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.ContextMenuStrip cmsCustomer;
        private System.Windows.Forms.ToolStripMenuItem editSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSupplierToolStripMenuItem;
    }
}