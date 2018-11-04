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
    public partial class frmSupplier : Form {
        public frmSupplier() {
            InitializeComponent();

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void frmSupplier_Load(object sender, EventArgs e) {
            tbSupplierID.Text = "";
            tbSupplierName.Text = "";
            tbSupplierDesc.Text = "";

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            getSupplierList();
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbSupplierName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand;
                    if( tbSupplierID.Text.Length == 0 ) {
                        dbCommand = new SQLiteCommand( "INSERT INTO supplier (supplier_id, supplier_name, supplier_desc) VALUES(NULL, '" + tbSupplierName.Text.Replace( "'", "''" ) + "', '" + tbSupplierDesc.Text.Replace( "'", "''" ) + "')", frmMain.sqlCon );
                    } else {
                        dbCommand = new SQLiteCommand( "UPDATE supplier SET supplier_name = '" + tbSupplierName.Text.Replace( "'", "''" ) + "', supplier_desc = '" + tbSupplierDesc.Text.Replace( "'", "''" ) + "' WHERE supplier_id = '" + tbSupplierID.Text + "'", frmMain.sqlCon );
                    }
                    dbCommand.ExecuteNonQuery();
                } catch {
                    MessageBox.Show( "Could not save supplier to database. Please try again." );

                    return;
                }

                this.DialogResult = DialogResult.OK;
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

        private void lvSupplier_SelectedIndexChanged( object sender, EventArgs e ) {
            if( lvSupplier.SelectedItems.Count > 0 ) {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            } else {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnEdit_Click( object sender, EventArgs e ) {
            if( lvSupplier.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT supplier_id, supplier_name, supplier_desc FROM supplier WHERE supplier_id = '" + lvSupplier.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbSupplierID.Text = dbReader[ 0 ].ToString();
                    tbSupplierName.Text = dbReader[ 1 ].ToString();
                    tbSupplierDesc.Text = dbReader[ 2 ].ToString();

                    lvSupplier.SelectedItems.Clear();

                    break;
                }
            }
        }

        private void lvSupplier_MouseDoubleClick( object sender, MouseEventArgs e ) {
            btnEdit_Click( sender, (EventArgs)e );
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            if( lvSupplier.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand("DELETE FROM supplier WHERE supplier_id = '" + lvSupplier.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                dbCommand.ExecuteNonQuery();

                lvSupplier.SelectedItems.Clear();

                getSupplierList();
            }
        }

        private void cmsSupplier_Opening( object sender, CancelEventArgs e ) {
            if( lvSupplier.SelectedItems.Count == 0 ) {
                e.Cancel = true;
            }
        }

        private void getSupplierList() {
            SQLiteCommand dbCommand = new SQLiteCommand("SELECT supplier_id, supplier_name, supplier_desc FROM supplier ORDER BY supplier_name", frmMain.sqlCon);
            SQLiteDataReader dbReader = dbCommand.ExecuteReader();

            lvSupplier.Items.Clear();
            while (dbReader.Read()) {
                ListViewItem lvi = new ListViewItem(new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() });

                lvSupplier.Items.Add(lvi);
            }
        }
    }
}
