using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// SQLite
using System.Data.SQLite;

namespace proIMP {
    public partial class frmSupplier : Form {
        public frmSupplier() {
            InitializeComponent();

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void frmSupplier_Load( object sender, EventArgs e ) {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            switchLanguage();
            database.getSupplierList( lvSupplier );
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbSupplierName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand = database.sqlCon.CreateCommand();

                    if( tbSupplierID.Text.Length == 0 ) {
                        dbCommand.CommandText = "INSERT INTO supplier (supplier_name, supplier_desc) VALUES(@supplier_name, @supplier_desc)";
                    } else {
                        dbCommand.CommandText = "UPDATE supplier SET supplier_name = @supplier_name, supplier_desc = @supplier_desc WHERE supplier_id = @supplier_id";
                    }

                    dbCommand.Parameters.Add( new SQLiteParameter( "@supplier_id", tbSupplierID.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@supplier_name", tbSupplierName.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@supplier_desc", tbSupplierDesc.Text ) );

                    dbCommand.ExecuteNonQuery();
                } catch {
                    MessageBox.Show( frmMain.resMan.GetString( "couldNotSaveSupplier", frmMain.culInfo ) );

                    return;
                }

                database.getSupplierList( lvSupplier );
            }
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            tbSupplierID.Text = "";
            tbSupplierName.Text = "";
            tbSupplierDesc.Text = "";

            lvSupplier.SelectedItems.Clear();
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnEdit_Click( object sender, EventArgs e ) {
            if( lvSupplier.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "SELECT supplier_id, supplier_name, supplier_desc FROM supplier WHERE supplier_id = '{0}'",
                    lvSupplier.SelectedItems[ 0 ].SubItems[ 0 ].Text
                );

                try {
                    SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                    if( dbReader.HasRows ) {
                        dbReader.Read();

                        tbSupplierID.Text = dbReader[ 0 ].ToString();
                        tbSupplierName.Text = dbReader[ 1 ].ToString();
                        tbSupplierDesc.Text = dbReader[ 2 ].ToString();

                        lvSupplier.SelectedItems.Clear();

                        dbReader.Close();
                    }
                } catch {

                }
            }
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            if( lvSupplier.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "DELETE FROM supplier WHERE supplier_id = '{0}'",
                    lvSupplier.SelectedItems[ 0 ].SubItems[ 0 ].Text
                );

                dbCommand.ExecuteNonQuery();

                database.getSupplierList( lvSupplier );
            }
        }

        private void lvSupplier_SelectedIndexChanged( object sender, EventArgs e ) {
            if( lvSupplier.SelectedItems.Count > 0 ) {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            } else {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void lvSupplier_MouseDoubleClick( object sender, MouseEventArgs e ) {
            btnEdit_Click( sender, (EventArgs)e );
        }        

        private void cmsSupplier_Opening( object sender, CancelEventArgs e ) {
            if( lvSupplier.SelectedItems.Count == 0 ) {
                e.Cancel = true;
            }
        }

        private void switchLanguage() {
            this.Text = frmMain.resMan.GetString( "frmSupplier_Text", frmMain.culInfo );
            gbSupplierInfo.Text = frmMain.resMan.GetString( "gbSupplierInfo", frmMain.culInfo );
            gbSupplierList.Text = frmMain.resMan.GetString( "gbSupplierList", frmMain.culInfo );
            lblSupplierID.Text = frmMain.resMan.GetString( "lblSupplierID", frmMain.culInfo ) + " :";
            lblSupplierName.Text = frmMain.resMan.GetString( "lblSupplierName", frmMain.culInfo ) + " :";
            lblSupplierDesc.Text = frmMain.resMan.GetString( "lblSupplierDesc", frmMain.culInfo ) + " :";
            btnSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
            btnClear.Text = frmMain.resMan.GetString( "btnClear", frmMain.culInfo );
            btnCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnEdit.Text = frmMain.resMan.GetString( "btnEdit", frmMain.culInfo );
            btnDelete.Text = frmMain.resMan.GetString( "btnDelete", frmMain.culInfo );

            chSupplierName.Text = frmMain.resMan.GetString( "chName", frmMain.culInfo );
            chSupplierDesc.Text = frmMain.resMan.GetString( "chDescription", frmMain.culInfo );
        }
    }
}
