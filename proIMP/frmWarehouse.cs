using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// SQLite
using System.Data.SQLite;

namespace proIMP {
    public partial class frmWarehouse : Form {
        public frmWarehouse() {
            InitializeComponent();

            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        private void frmWarehouse_Load( object sender, EventArgs e ) {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            switchLanguage();
            database.getWarehouseList( lvWarehouse );
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbWarehouseName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand = database.sqlCon.CreateCommand();

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

                database.getWarehouseList( lvWarehouse );
            }
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            tbWarehouseID.Text = "";
            tbWarehouseName.Text = "";
            tbWarehouseDesc.Text = "";

            lvWarehouse.SelectedItems.Clear();
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnEdit_Click( object sender, EventArgs e ) {
            if( lvWarehouse.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "SELECT warehouse_id, warehouse_name, warehouse_desc FROM warehouse WHERE warehouse_id = '{0}'",
                    lvWarehouse.SelectedItems[ 0 ].SubItems[ 0 ].Text
                );

                try {
                    SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                    if( dbReader.HasRows ) {
                        dbReader.Read();

                        tbWarehouseID.Text = dbReader[ 0 ].ToString();
                        tbWarehouseName.Text = dbReader[ 1 ].ToString();
                        tbWarehouseDesc.Text = dbReader[ 2 ].ToString();

                        lvWarehouse.SelectedItems.Clear();

                        dbReader.Close();
                    }
                } catch {

                }
            }
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            if( lvWarehouse.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "DELETE FROM warehouse WHERE warehouse_id = '{0}'",
                    lvWarehouse.SelectedItems[ 0 ].SubItems[ 0 ].Text
                );

                try {
                    dbCommand.ExecuteNonQuery();
                } catch {

                }

                database.getWarehouseList( lvWarehouse );
            }
        }

        private void lvWarehouse_SelectedIndexChanged( object sender, EventArgs e ) {
            if (lvWarehouse.SelectedItems.Count > 0) {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            } else {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void lvWarehouse_MouseDoubleClick( object sender, MouseEventArgs e ) {
            btnEdit_Click(sender, (EventArgs)e);
        }        

        private void cmsWarehouse_Opening( object sender, CancelEventArgs e ) {
            if (lvWarehouse.SelectedItems.Count == 0) {
                e.Cancel = true;
            }
        }

        private void switchLanguage() {
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
    }
}
