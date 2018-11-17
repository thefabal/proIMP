namespace proIMP {
    partial class frmCategory {
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
            this.deleteCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chCategoryDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategoryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvCategory = new System.Windows.Forms.ListView();
            this.gbCategoryList = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbCategoryInfo = new System.Windows.Forms.GroupBox();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.lblCategoryDesc = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbCategoryID = new System.Windows.Forms.TextBox();
            this.tbCategoryDesc = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.cmsCategory.SuspendLayout();
            this.gbCategoryList.SuspendLayout();
            this.gbCategoryInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteCategoryToolStripMenuItem
            // 
            this.deleteCategoryToolStripMenuItem.Name = "deleteCategoryToolStripMenuItem";
            this.deleteCategoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteCategoryToolStripMenuItem.Text = "Delete Category";
            this.deleteCategoryToolStripMenuItem.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmsCategory
            // 
            this.cmsCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCategoryToolStripMenuItem,
            this.deleteCategoryToolStripMenuItem});
            this.cmsCategory.Name = "cmsWarehouse";
            this.cmsCategory.Size = new System.Drawing.Size(159, 48);
            this.cmsCategory.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCategory_Opening);
            // 
            // editCategoryToolStripMenuItem
            // 
            this.editCategoryToolStripMenuItem.Name = "editCategoryToolStripMenuItem";
            this.editCategoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editCategoryToolStripMenuItem.Text = "Edit Category";
            this.editCategoryToolStripMenuItem.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // chCategoryDesc
            // 
            this.chCategoryDesc.Text = "Description";
            this.chCategoryDesc.Width = 180;
            // 
            // chCategoryName
            // 
            this.chCategoryName.Text = "Name";
            this.chCategoryName.Width = 140;
            // 
            // chCategoryID
            // 
            this.chCategoryID.Text = "ID";
            this.chCategoryID.Width = 0;
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
            // lvCategory
            // 
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCategoryID,
            this.chCategoryName,
            this.chCategoryDesc});
            this.lvCategory.ContextMenuStrip = this.cmsCategory;
            this.lvCategory.FullRowSelect = true;
            this.lvCategory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCategory.Location = new System.Drawing.Point(9, 19);
            this.lvCategory.MultiSelect = false;
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.Size = new System.Drawing.Size(354, 112);
            this.lvCategory.TabIndex = 0;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            this.lvCategory.SelectedIndexChanged += new System.EventHandler(this.lvCategory_SelectedIndexChanged);
            this.lvCategory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCategory_MouseDoubleClick);
            // 
            // gbCategoryList
            // 
            this.gbCategoryList.Controls.Add(this.btnEdit);
            this.gbCategoryList.Controls.Add(this.btnDelete);
            this.gbCategoryList.Controls.Add(this.lvCategory);
            this.gbCategoryList.Location = new System.Drawing.Point(13, 151);
            this.gbCategoryList.Name = "gbCategoryList";
            this.gbCategoryList.Size = new System.Drawing.Size(369, 173);
            this.gbCategoryList.TabIndex = 8;
            this.gbCategoryList.TabStop = false;
            this.gbCategoryList.Text = "Category List";
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
            // gbCategoryInfo
            // 
            this.gbCategoryInfo.Controls.Add(this.btnClear);
            this.gbCategoryInfo.Controls.Add(this.lblCategoryID);
            this.gbCategoryInfo.Controls.Add(this.lblCategoryDesc);
            this.gbCategoryInfo.Controls.Add(this.btnCancel);
            this.gbCategoryInfo.Controls.Add(this.tbCategoryID);
            this.gbCategoryInfo.Controls.Add(this.tbCategoryDesc);
            this.gbCategoryInfo.Controls.Add(this.btnSave);
            this.gbCategoryInfo.Controls.Add(this.lblCategoryName);
            this.gbCategoryInfo.Controls.Add(this.tbCategoryName);
            this.gbCategoryInfo.Location = new System.Drawing.Point(13, 13);
            this.gbCategoryInfo.Name = "gbCategoryInfo";
            this.gbCategoryInfo.Size = new System.Drawing.Size(369, 132);
            this.gbCategoryInfo.TabIndex = 7;
            this.gbCategoryInfo.TabStop = false;
            this.gbCategoryInfo.Text = "Category Info";
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.AutoSize = true;
            this.lblCategoryID.Location = new System.Drawing.Point(6, 21);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(69, 13);
            this.lblCategoryID.TabIndex = 0;
            this.lblCategoryID.Text = "Category ID :";
            // 
            // lblCategoryDesc
            // 
            this.lblCategoryDesc.AutoSize = true;
            this.lblCategoryDesc.Location = new System.Drawing.Point(6, 73);
            this.lblCategoryDesc.Name = "lblCategoryDesc";
            this.lblCategoryDesc.Size = new System.Drawing.Size(86, 13);
            this.lblCategoryDesc.TabIndex = 2;
            this.lblCategoryDesc.Text = "Category Desc. :";
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
            // tbCategoryID
            // 
            this.tbCategoryID.BackColor = System.Drawing.SystemColors.Window;
            this.tbCategoryID.Location = new System.Drawing.Point(111, 18);
            this.tbCategoryID.Name = "tbCategoryID";
            this.tbCategoryID.ReadOnly = true;
            this.tbCategoryID.Size = new System.Drawing.Size(142, 20);
            this.tbCategoryID.TabIndex = 0;
            this.tbCategoryID.TabStop = false;
            // 
            // tbCategoryDesc
            // 
            this.tbCategoryDesc.Location = new System.Drawing.Point(111, 70);
            this.tbCategoryDesc.Multiline = true;
            this.tbCategoryDesc.Name = "tbCategoryDesc";
            this.tbCategoryDesc.Size = new System.Drawing.Size(142, 46);
            this.tbCategoryDesc.TabIndex = 1;
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
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(6, 47);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(86, 13);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "Category Name :";
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Location = new System.Drawing.Point(111, 44);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(142, 20);
            this.tbCategoryName.TabIndex = 0;
            // 
            // frmCategory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 336);
            this.Controls.Add(this.gbCategoryList);
            this.Controls.Add(this.gbCategoryInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCategory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Category Management";
            this.Load += new System.EventHandler(this.frmCategory_Load);
            this.cmsCategory.ResumeLayout(false);
            this.gbCategoryList.ResumeLayout(false);
            this.gbCategoryInfo.ResumeLayout(false);
            this.gbCategoryInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem deleteCategoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsCategory;
        private System.Windows.Forms.ToolStripMenuItem editCategoryToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chCategoryDesc;
        private System.Windows.Forms.ColumnHeader chCategoryName;
        private System.Windows.Forms.ColumnHeader chCategoryID;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvCategory;
        private System.Windows.Forms.GroupBox gbCategoryList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbCategoryInfo;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.Label lblCategoryDesc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbCategoryID;
        private System.Windows.Forms.TextBox tbCategoryDesc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox tbCategoryName;
    }
}