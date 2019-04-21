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
        public frmMain frmMain;

        public frmWarehouse( frmMain frmMain ) {
            InitializeComponent();

            this.frmMain = frmMain;
            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        private void frmWarehouse_Load(object sender, EventArgs e) {
            tbWarehouseID.Text = "";
            tbWarehouseName.Text = "";
            tbWarehouseDesc.Text = "";

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            switchLanguage();
            getWarehouseList();
        }

        private void switchLanguage( ) {
            this.Text = frmMain.resMan.GetString( "frmWarehouse_Text", frmMain.culInfo );
            gbWarehouseInfo.Text = frmMain.resMan.GetString( "gbWarehouseInfo", frmMain.culInfo );
            gbWarehouseList.Text = frmMain.resMan.GetString( "gbWarehouseList", frmMain.culInfo );
            lblWarehouseID.Text = frmMain.resMan.GetString( "lblWarehouseID", frmMain.culInfo ) + " :";
            lblWarehouseName.Text = frmMain.resMan.GetString( "lblWarehouseName", frmMain.culInfo ) + " :";
            lblWarehouseDesc.Text = frmMain.resMan.GetString( "lblWarehouseDesc", frmMain.culInfo ) + " :";
            btnSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
            btnClear.Text = frmMain.resMan.GetString( "btnClear", frmMain.culInfo );
            btnCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnEdit.Text = frmMain.resMan.GetString( "btnEdit", frmMain.culInfo );
            btnDelete.Text = frmMain.resMan.GetString( "btnDelete", frmMain.culInfo );

            chWarehouseName.Text = frmMain.resMan.GetString( "chName", frmMain.culInfo );
            chWarehouseDesc.Text = frmMain.resMan.GetString( "chDescription", frmMain.culInfo );
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if( tbWarehouseName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand = new SQLiteCommand() {
                        Connection = frmMain.sqlCon
                    };

                    if( tbWarehouseID.Text.Length == 0 ) {
                        dbCommand.CommandText = "INSERT INTO warehouse (warehouse_name, warehouse_desc) VALUES(@warehouse_name, @warehouse_desc)";
                    } else {
                        dbCommand.CommandText = "UPDATE warehouse SET warehouse_name = @warehouse_name, warehouse_desc = @warehouse_desc WHERE warehouse_id = @warehouse_id";
                    }

                    dbCommand.Parameters.Add( new SQLiteParameter( "@warehouse_id", tbWarehouseID.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@warehouse_name", tbWarehouseName.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@warehouse_desc", tbWarehouseDesc.Text ) );

                    dbCommand.ExecuteNonQuery();
                } catch {
                    MessageBox.Show( frmMain.resMan.GetString( "couldNotSaveWarehouse", frmMain.culInfo ) );

                    return;
                }

                getWarehouseList();
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
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT warehouse_id, warehouse_name, warehouse_desc FROM warehouse WHERE warehouse_id = @warehouse_id", frmMain.sqlCon);
                dbCommand.Parameters.Add( new SQLiteParameter( "@warehouse_id", lvWarehouse.SelectedItems[ 0 ].SubItems[ 0 ].Text ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                if( dbReader.HasRows ) {
                    dbReader.Read();

                    tbWarehouseID.Text = dbReader[ 0 ].ToString();
                    tbWarehouseName.Text = dbReader[ 1 ].ToString();
                    tbWarehouseDesc.Text = dbReader[ 2 ].ToString();

                    lvWarehouse.SelectedItems.Clear();
                }
            }
        }

        private void lvWarehouse_MouseDoubleClick(object sender, MouseEventArgs e) {
            btnEdit_Click(sender, (EventArgs)e);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (lvWarehouse.SelectedItems.Count > 0) {
                SQLiteCommand dbCommand = new SQLiteCommand( "DELETE FROM warehouse WHERE warehouse_id = @warehouse_id", frmMain.sqlCon);
                dbCommand.Parameters.Add( new SQLiteParameter( "@warehouse_id", lvWarehouse.SelectedItems[ 0 ].SubItems[ 0 ].Text ) );

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
