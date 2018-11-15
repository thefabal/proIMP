namespace proIMP
{
    partial class frmWarehouse
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.lblWarehouseDesc = new System.Windows.Forms.Label();
            this.tbWarehouseID = new System.Windows.Forms.TextBox();
            this.tbWarehouseName = new System.Windows.Forms.TextBox();
            this.tbWarehouseDesc = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvWarehouse = new System.Windows.Forms.ListView();
            this.chWarehouseID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWarehouseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWarehouseDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsWarehouse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmsWarehouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWarehouseID
            // 
            this.lblWarehouseID.AutoSize = true;
            this.lblWarehouseID.Location = new System.Drawing.Point(6, 21);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(82, 13);
            this.lblWarehouseID.TabIndex = 0;
            this.lblWarehouseID.Text = "Warehouse ID :";
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Location = new System.Drawing.Point(6, 47);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(99, 13);
            this.lblWarehouseName.TabIndex = 1;
            this.lblWarehouseName.Text = "Warehouse Name :";
            // 
            // lblWarehouseDesc
            // 
            this.lblWarehouseDesc.AutoSize = true;
            this.lblWarehouseDesc.Location = new System.Drawing.Point(6, 73);
            this.lblWarehouseDesc.Name = "lblWarehouseDesc";
            this.lblWarehouseDesc.Size = new System.Drawing.Size(99, 13);
            this.lblWarehouseDesc.TabIndex = 2;
            this.lblWarehouseDesc.Text = "Warehouse Desc. :";
            // 
            // tbWarehouseID
            // 
            this.tbWarehouseID.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouseID.Location = new System.Drawing.Point(111, 18);
            this.tbWarehouseID.Name = "tbWarehouseID";
            this.tbWarehouseID.ReadOnly = true;
            this.tbWarehouseID.Size = new System.Drawing.Size(142, 20);
            this.tbWarehouseID.TabIndex = 0;
            this.tbWarehouseID.TabStop = false;
            // 
            // tbWarehouseName
            // 
            this.tbWarehouseName.Location = new System.Drawing.Point(111, 44);
            this.tbWarehouseName.Name = "tbWarehouseName";
            this.tbWarehouseName.Size = new System.Drawing.Size(142, 20);
            this.tbWarehouseName.TabIndex = 1;
            // 
            // tbWarehouseDesc
            // 
            this.tbWarehouseDesc.Location = new System.Drawing.Point(111, 70);
            this.tbWarehouseDesc.Multiline = true;
            this.tbWarehouseDesc.Name = "tbWarehouseDesc";
            this.tbWarehouseDesc.Size = new System.Drawing.Size(142, 46);
            this.tbWarehouseDesc.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(259, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(259, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblWarehouseID);
            this.groupBox1.Controls.Add(this.lblWarehouseDesc);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.tbWarehouseID);
            this.groupBox1.Controls.Add(this.tbWarehouseDesc);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lblWarehouseName);
            this.groupBox1.Controls.Add(this.tbWarehouseName);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Warehouse Info";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(259, 53);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 29);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.lvWarehouse);
            this.groupBox2.Location = new System.Drawing.Point(13, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 173);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Warehouse List";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(149, 137);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 29);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(259, 137);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 29);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lvWarehouse
            // 
            this.lvWarehouse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWarehouseID,
            this.chWarehouseName,
            this.chWarehouseDescription});
            this.lvWarehouse.ContextMenuStrip = this.cmsWarehouse;
            this.lvWarehouse.FullRowSelect = true;
            this.lvWarehouse.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvWarehouse.Location = new System.Drawing.Point(9, 19);
            this.lvWarehouse.MultiSelect = false;
            this.lvWarehouse.Name = "lvWarehouse";
            this.lvWarehouse.Size = new System.Drawing.Size(354, 112);
            this.lvWarehouse.TabIndex = 6;
            this.lvWarehouse.UseCompatibleStateImageBehavior = false;
            this.lvWarehouse.View = System.Windows.Forms.View.Details;
            this.lvWarehouse.SelectedIndexChanged += new System.EventHandler(this.lvWarehouse_SelectedIndexChanged);
            this.lvWarehouse.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvWarehouse_MouseDoubleClick);
            // 
            // chWarehouseID
            // 
            this.chWarehouseID.Text = "ID";
            this.chWarehouseID.Width = 0;
            // 
            // chWarehouseName
            // 
            this.chWarehouseName.Text = "Name";
            this.chWarehouseName.Width = 140;
            // 
            // chWarehouseDescription
            // 
            this.chWarehouseDescription.Text = "Description";
            this.chWarehouseDescription.Width = 180;
            // 
            // cmsWarehouse
            // 
            this.cmsWarehouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editWarehouseToolStripMenuItem,
            this.deleteWarehouseToolStripMenuItem});
            this.cmsWarehouse.Name = "cmsWarehouse";
            this.cmsWarehouse.Size = new System.Drawing.Size(168, 48);
            this.cmsWarehouse.Opening += new System.ComponentModel.CancelEventHandler(this.cmsWarehouse_Opening);
            // 
            // editWarehouseToolStripMenuItem
            // 
            this.editWarehouseToolStripMenuItem.Name = "editWarehouseToolStripMenuItem";
            this.editWarehouseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.editWarehouseToolStripMenuItem.Text = "Edit warehouse";
            this.editWarehouseToolStripMenuItem.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // deleteWarehouseToolStripMenuItem
            // 
            this.deleteWarehouseToolStripMenuItem.Name = "deleteWarehouseToolStripMenuItem";
            this.deleteWarehouseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteWarehouseToolStripMenuItem.Text = "Delete warehouse";
            this.deleteWarehouseToolStripMenuItem.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 336);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWarehouse";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Warehouse Management";
            this.Load += new System.EventHandler(this.frmWarehouse_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.cmsWarehouse.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWarehouseID;
        private System.Windows.Forms.Label lblWarehouseName;
        private System.Windows.Forms.Label lblWarehouseDesc;
        private System.Windows.Forms.TextBox tbWarehouseID;
        private System.Windows.Forms.TextBox tbWarehouseName;
        private System.Windows.Forms.TextBox tbWarehouseDesc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvWarehouse;
        private System.Windows.Forms.ColumnHeader chWarehouseID;
        private System.Windows.Forms.ColumnHeader chWarehouseName;
        private System.Windows.Forms.ColumnHeader chWarehouseDescription;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ContextMenuStrip cmsWarehouse;
        private System.Windows.Forms.ToolStripMenuItem editWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteWarehouseToolStripMenuItem;
        private System.Windows.Forms.Button btnClear;
    }
}