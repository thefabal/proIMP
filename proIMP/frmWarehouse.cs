using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// SQLite
using System.Data.SQLite;

namespace proIMP {
    public partial class frmWarehouse : Form {
        public frmWarehouse() {
            InitializeComponent();

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void frmWarehouse_Load(object sender, EventArgs e) {
            tbWarehouseID.Text = "";
            tbWarehouseName.Text = "";
            tbWarehouseDesc.Text = "";

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            getWarehouseList();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if( tbWarehouseName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand;
                    if( tbWarehouseID.Text.Length == 0 ) {
                        dbCommand = new SQLiteCommand("INSERT INTO warehouse (warehouse_id, warehouse_name, warehouse_desc) VALUES(NULL, '" + tbWarehouseName.Text.Replace("'", "''") + "', '" + tbWarehouseDesc.Text.Replace("'", "''") + "')", frmMain.sqlCon);
                    } else {
                        dbCommand = new SQLiteCommand("UPDATE warehouse SET warehouse_name = '" + tbWarehouseName.Text.Replace("'", "''") + "', warehouse_desc = '" + tbWarehouseDesc.Text.Replace("'", "''") + "' WHERE warehouse_id = '" + tbWarehouseID.Text + "'", frmMain.sqlCon);
                    }
                    dbCommand.ExecuteNonQuery();
                } catch {
                    MessageBox.Show( "Could not save warehouse to database. Please try again." );

                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {
            tbWarehouseID.Text = "";
            tbWarehouseName.Text = "";
            tbWarehouseDesc.Text = "";

            lvWarehouse.SelectedItems.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lvWarehouse_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvWarehouse.SelectedItems.Count > 0) {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            } else {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if( lvWarehouse.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT warehouse_id, warehouse_name, warehouse_desc FROM warehouse WHERE warehouse_id = '" + lvWarehouse.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbWarehouseID.Text = dbReader[0].ToString();
                    tbWarehouseName.Text = dbReader[1].ToString();
                    tbWarehouseDesc.Text = dbReader[2].ToString();

                    lvWarehouse.SelectedItems.Clear();

                    break;
                }
            }
        }

        private void lvWarehouse_MouseDoubleClick(object sender, MouseEventArgs e) {
            btnEdit_Click(sender, (EventArgs)e);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (lvWarehouse.SelectedItems.Count > 0) {
                SQLiteCommand dbCommand = new SQLiteCommand("DELETE FROM warehouse WHERE warehouse_id = '" + lvWarehouse.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                dbCommand.ExecuteNonQuery();

                lvWarehouse.SelectedItems.Clear();

                getWarehouseList();
            }
        }

        private void cmsWarehouse_Opening(object sender, CancelEventArgs e) {
            if (lvWarehouse.SelectedItems.Count == 0) {
                e.Cancel = true;
            }
        }

        private void getWarehouseList() {
            SQLiteCommand dbCommand = new SQLiteCommand("SELECT warehouse_id, warehouse_name, warehouse_desc FROM warehouse ORDER BY warehouse_name", frmMain.sqlCon);
            SQLiteDataReader dbReader = dbCommand.ExecuteReader();

            lvWarehouse.Items.Clear();
            while (dbReader.Read()) {
                ListViewItem lvi = new ListViewItem(new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() });

                lvWarehouse.Items.Add(lvi);
            }
        }
    }
}
