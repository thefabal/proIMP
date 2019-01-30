namespace proIMP {
    partial class frmPreferences {
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Visual", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Database");
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tvPreference = new System.Windows.Forms.TreeView();
            this.lblShortProduct = new System.Windows.Forms.Label();
            this.cbProductOrder = new System.Windows.Forms.ComboBox();
            this.gbVisual = new System.Windows.Forms.GroupBox();
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.btnDatabaseClean = new System.Windows.Forms.Button();
            this.lblCleanDatabase = new System.Windows.Forms.Label();
            this.lblCheckDatabase = new System.Windows.Forms.Label();
            this.btnDatabaseCheck = new System.Windows.Forms.Button();
            this.btnDatabaseCreate = new System.Windows.Forms.Button();
            this.lblNewDatabase = new System.Windows.Forms.Label();
            this.tbCurrentDB = new System.Windows.Forms.TextBox();
            this.btnDatabaseBrowse = new System.Windows.Forms.Button();
            this.lblExistingDatabase = new System.Windows.Forms.Label();
            this.gbVisual.SuspendLayout();
            this.gbDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(250, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(330, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tvPreference
            // 
            this.tvPreference.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvPreference.HideSelection = false;
            this.tvPreference.Location = new System.Drawing.Point(12, 12);
            this.tvPreference.Name = "tvPreference";
            treeNode1.Name = "nodeVisualGeneral";
            treeNode1.Text = "General";
            treeNode2.Name = "nodeVisual";
            treeNode2.Text = "Visual";
            treeNode3.Name = "nodeDatabase";
            treeNode3.Text = "Database";
            this.tvPreference.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.tvPreference.Size = new System.Drawing.Size(120, 230);
            this.tvPreference.TabIndex = 11;
            this.tvPreference.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvPreference_DrawNode);
            this.tvPreference.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPreference_AfterSelect);
            // 
            // lblShortProduct
            // 
            this.lblShortProduct.AutoSize = true;
            this.lblShortProduct.Location = new System.Drawing.Point(6, 29);
            this.lblShortProduct.Name = "lblShortProduct";
            this.lblShortProduct.Size = new System.Drawing.Size(85, 13);
            this.lblShortProduct.TabIndex = 12;
            this.lblShortProduct.Text = "Short product by";
            // 
            // cbProductOrder
            // 
            this.cbProductOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductOrder.FormattingEnabled = true;
            this.cbProductOrder.Location = new System.Drawing.Point(76, 48);
            this.cbProductOrder.Name = "cbProductOrder";
            this.cbProductOrder.Size = new System.Drawing.Size(182, 21);
            this.cbProductOrder.TabIndex = 13;
            // 
            // gbVisual
            // 
            this.gbVisual.Controls.Add(this.cbProductOrder);
            this.gbVisual.Controls.Add(this.lblShortProduct);
            this.gbVisual.Location = new System.Drawing.Point(141, 12);
            this.gbVisual.Name = "gbVisual";
            this.gbVisual.Size = new System.Drawing.Size(264, 230);
            this.gbVisual.TabIndex = 14;
            this.gbVisual.TabStop = false;
            this.gbVisual.Text = "Visual";
            // 
            // gbDatabase
            // 
            this.gbDatabase.Controls.Add(this.btnDatabaseClean);
            this.gbDatabase.Controls.Add(this.lblCleanDatabase);
            this.gbDatabase.Controls.Add(this.lblCheckDatabase);
            this.gbDatabase.Controls.Add(this.btnDatabaseCheck);
            this.gbDatabase.Controls.Add(this.btnDatabaseCreate);
            this.gbDatabase.Controls.Add(this.lblNewDatabase);
            this.gbDatabase.Controls.Add(this.tbCurrentDB);
            this.gbDatabase.Controls.Add(this.btnDatabaseBrowse);
            this.gbDatabase.Controls.Add(this.lblExistingDatabase);
            this.gbDatabase.Location = new System.Drawing.Point(141, 12);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Size = new System.Drawing.Size(264, 230);
            this.gbDatabase.TabIndex = 16;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Database";
            // 
            // btnDatabaseClean
            // 
            this.btnDatabaseClean.Location = new System.Drawing.Point(183, 147);
            this.btnDatabaseClean.Name = "btnDatabaseClean";
            this.btnDatabaseClean.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseClean.TabIndex = 11;
            this.btnDatabaseClean.Text = "Clean";
            this.btnDatabaseClean.UseVisualStyleBackColor = true;
            this.btnDatabaseClean.Click += new System.EventHandler(this.btnDatabaseClean_Click);
            // 
            // lblCleanDatabase
            // 
            this.lblCleanDatabase.Location = new System.Drawing.Point(6, 152);
            this.lblCleanDatabase.Name = "lblCleanDatabase";
            this.lblCleanDatabase.Size = new System.Drawing.Size(171, 30);
            this.lblCleanDatabase.TabIndex = 9;
            this.lblCleanDatabase.Text = "Clean database for unnecessary entries";
            // 
            // lblCheckDatabase
            // 
            this.lblCheckDatabase.Location = new System.Drawing.Point(6, 106);
            this.lblCheckDatabase.Name = "lblCheckDatabase";
            this.lblCheckDatabase.Size = new System.Drawing.Size(171, 30);
            this.lblCheckDatabase.TabIndex = 8;
            this.lblCheckDatabase.Text = "Check database (Tables, indexes and triggers)";
            // 
            // btnDatabaseCheck
            // 
            this.btnDatabaseCheck.Location = new System.Drawing.Point(183, 101);
            this.btnDatabaseCheck.Name = "btnDatabaseCheck";
            this.btnDatabaseCheck.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseCheck.TabIndex = 7;
            this.btnDatabaseCheck.Text = "Check";
            this.btnDatabaseCheck.UseVisualStyleBackColor = true;
            this.btnDatabaseCheck.Click += new System.EventHandler(this.btnDatabaseCheck_Click);
            // 
            // btnDatabaseCreate
            // 
            this.btnDatabaseCreate.Location = new System.Drawing.Point(183, 72);
            this.btnDatabaseCreate.Name = "btnDatabaseCreate";
            this.btnDatabaseCreate.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseCreate.TabIndex = 6;
            this.btnDatabaseCreate.Text = "Browse";
            this.btnDatabaseCreate.UseVisualStyleBackColor = true;
            this.btnDatabaseCreate.Click += new System.EventHandler(this.btnDatabaseCreate_Click);
            // 
            // lblNewDatabase
            // 
            this.lblNewDatabase.AutoSize = true;
            this.lblNewDatabase.Location = new System.Drawing.Point(6, 77);
            this.lblNewDatabase.Name = "lblNewDatabase";
            this.lblNewDatabase.Size = new System.Drawing.Size(117, 13);
            this.lblNewDatabase.TabIndex = 5;
            this.lblNewDatabase.Text = "Create a new database";
            // 
            // tbCurrentDB
            // 
            this.tbCurrentDB.BackColor = System.Drawing.SystemColors.Window;
            this.tbCurrentDB.Location = new System.Drawing.Point(6, 19);
            this.tbCurrentDB.Name = "tbCurrentDB";
            this.tbCurrentDB.ReadOnly = true;
            this.tbCurrentDB.Size = new System.Drawing.Size(252, 20);
            this.tbCurrentDB.TabIndex = 3;
            // 
            // btnDatabaseBrowse
            // 
            this.btnDatabaseBrowse.Location = new System.Drawing.Point(183, 43);
            this.btnDatabaseBrowse.Name = "btnDatabaseBrowse";
            this.btnDatabaseBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseBrowse.TabIndex = 2;
            this.btnDatabaseBrowse.Text = "Browse";
            this.btnDatabaseBrowse.UseVisualStyleBackColor = true;
            this.btnDatabaseBrowse.Click += new System.EventHandler(this.btnDatabaseBrowse_Click);
            // 
            // lblExistingDatabase
            // 
            this.lblExistingDatabase.AutoSize = true;
            this.lblExistingDatabase.Location = new System.Drawing.Point(6, 48);
            this.lblExistingDatabase.Name = "lblExistingDatabase";
            this.lblExistingDatabase.Size = new System.Drawing.Size(156, 13);
            this.lblExistingDatabase.TabIndex = 1;
            this.lblExistingDatabase.Text = "Change to an existing database";
            // 
            // frmPreferences
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(417, 283);
            this.Controls.Add(this.tvPreference);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbDatabase);
            this.Controls.Add(this.gbVisual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.gbVisual.ResumeLayout(false);
            this.gbVisual.PerformLayout();
            this.gbDatabase.ResumeLayout(false);
            this.gbDatabase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TreeView tvPreference;
        private System.Windows.Forms.Label lblShortProduct;
        private System.Windows.Forms.ComboBox cbProductOrder;
        private System.Windows.Forms.GroupBox gbVisual;
        private System.Windows.Forms.GroupBox gbDatabase;
        private System.Windows.Forms.Label lblExistingDatabase;
        private System.Windows.Forms.Button btnDatabaseBrowse;
        private System.Windows.Forms.TextBox tbCurrentDB;
        private System.Windows.Forms.Label lblNewDatabase;
        private System.Windows.Forms.Button btnDatabaseCreate;
        private System.Windows.Forms.Button btnDatabaseCheck;
        private System.Windows.Forms.Label lblCheckDatabase;
        private System.Windows.Forms.Button btnDatabaseClean;
        private System.Windows.Forms.Label lblCleanDatabase;
    }
}