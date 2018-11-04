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
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Visual", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Database");
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tvPreference = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProductOrder = new System.Windows.Forms.ComboBox();
            this.gbVisual = new System.Windows.Forms.GroupBox();
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.tbCurrentDB = new System.Windows.Forms.TextBox();
            this.btnDatabaseBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDatabaseCreate = new System.Windows.Forms.Button();
            this.btnDatabaseCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDatabaseClean = new System.Windows.Forms.Button();
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
            treeNode13.Name = "nodeVisualGeneral";
            treeNode13.Text = "General";
            treeNode14.Name = "nodeVisual";
            treeNode14.Text = "Visual";
            treeNode15.Name = "nodeDatabase";
            treeNode15.Text = "Database";
            this.tvPreference.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            this.tvPreference.Size = new System.Drawing.Size(120, 230);
            this.tvPreference.TabIndex = 11;
            this.tvPreference.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvPreference_DrawNode);
            this.tvPreference.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPreference_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Short product by : ";
            // 
            // cbProductOrder
            // 
            this.cbProductOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductOrder.FormattingEnabled = true;
            this.cbProductOrder.Items.AddRange(new object[] {
            "Product name and category",
            "Category and product name"});
            this.cbProductOrder.Location = new System.Drawing.Point(103, 26);
            this.cbProductOrder.Name = "cbProductOrder";
            this.cbProductOrder.Size = new System.Drawing.Size(155, 21);
            this.cbProductOrder.TabIndex = 13;
            // 
            // gbVisual
            // 
            this.gbVisual.Controls.Add(this.cbProductOrder);
            this.gbVisual.Controls.Add(this.label1);
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
            this.gbDatabase.Controls.Add(this.label5);
            this.gbDatabase.Controls.Add(this.label2);
            this.gbDatabase.Controls.Add(this.btnDatabaseCheck);
            this.gbDatabase.Controls.Add(this.btnDatabaseCreate);
            this.gbDatabase.Controls.Add(this.label4);
            this.gbDatabase.Controls.Add(this.tbCurrentDB);
            this.gbDatabase.Controls.Add(this.btnDatabaseBrowse);
            this.gbDatabase.Controls.Add(this.label3);
            this.gbDatabase.Location = new System.Drawing.Point(141, 12);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Size = new System.Drawing.Size(264, 230);
            this.gbDatabase.TabIndex = 16;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Database";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Change to an Existing Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Create a New Database";
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
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Check Database (Tables, Indexes and Triggers)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Clean Database for Unnecessary Entries";
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
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProductOrder;
        private System.Windows.Forms.GroupBox gbVisual;
        private System.Windows.Forms.GroupBox gbDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDatabaseBrowse;
        private System.Windows.Forms.TextBox tbCurrentDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDatabaseCreate;
        private System.Windows.Forms.Button btnDatabaseCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDatabaseClean;
        private System.Windows.Forms.Label label5;
    }
}