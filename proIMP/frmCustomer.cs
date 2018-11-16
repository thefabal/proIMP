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
    public partial class frmCustomer:Form {
        public frmMain frmMain;

        public frmCustomer( frmMain frmMain ) {
            InitializeComponent();

            this.frmMain = frmMain;
            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        private void frmCustomer_Load( object sender, EventArgs e ) {
            tbCustomerID.Text = "";
            tbCustomerName.Text = "";
            tbCustomerDesc.Text = "";

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            switchLanguage();
            getCustomerList();
        }

        private void switchLanguage( ) {
            this.Text = frmMain.resMan.GetString( "frmCustomer_Text", frmMain.culInfo );
            gbCustomerInfo.Text = frmMain.resMan.GetString( "gbCustomerInfo", frmMain.culInfo );
            gbCustomerList.Text = frmMain.resMan.GetString( "gbCustomerList", frmMain.culInfo );
            lblCustomerID.Text = frmMain.resMan.GetString( "lblCustomerID", frmMain.culInfo ) + " :";
            lblCustomerName.Text = frmMain.resMan.GetString( "lblCustomerName", frmMain.culInfo ) + " :";
            lblCustomerDesc.Text = frmMain.resMan.GetString( "lblCustomerDesc", frmMain.culInfo ) + " :";
            btnSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
            btnClear.Text = frmMain.resMan.GetString( "btnClear", frmMain.culInfo );
            btnCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnEdit.Text = frmMain.resMan.GetString( "btnEdit", frmMain.culInfo );
            btnDelete.Text = frmMain.resMan.GetString( "btnDelete", frmMain.culInfo );

            chCustomerName.Text = frmMain.resMan.GetString( "chName", frmMain.culInfo );
            chCustomerDesc.Text = frmMain.resMan.GetString( "chDescription", frmMain.culInfo );
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbCustomerName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand;
                    if( tbCustomerID.Text.Length == 0 ) {
                        dbCommand = new SQLiteCommand( "INSERT INTO customer (customer_id, customer_name, customer_desc) VALUES(NULL, '" + tbCustomerName.Text.Replace( "'", "''" ) + "', '" + tbCustomerDesc.Text.Replace( "'", "''" ) + "')", frmMain.sqlCon );
                    } else {
                        dbCommand = new SQLiteCommand( "UPDATE customer SET customer_name = '" + tbCustomerName.Text.Replace( "'", "''" ) + "', customer_desc = '" + tbCustomerDesc.Text.Replace( "'", "''" ) + "' WHERE customer_id = '" + tbCustomerID.Text + "'", frmMain.sqlCon );
                    }
                    dbCommand.ExecuteNonQuery();
                } catch {
                    MessageBox.Show( frmMain.resMan.GetString( "couldNotSaveCustomer", frmMain.culInfo ) );

                    return;
                }
            }
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            tbCustomerID.Text = "";
            tbCustomerName.Text = "";
            tbCustomerDesc.Text = "";

            lvCustomer.SelectedItems.Clear();
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lvCustomer_SelectedIndexChanged( object sender, EventArgs e ) {
            if( lvCustomer.SelectedItems.Count > 0 ) {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            } else {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnEdit_Click( object sender, EventArgs e ) {
            if( lvCustomer.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT customer_id, customer_name, customer_desc FROM customer WHERE customer_id = '" + lvCustomer.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbCustomerID.Text = dbReader[ 0 ].ToString();
                    tbCustomerName.Text = dbReader[ 1 ].ToString();
                    tbCustomerDesc.Text = dbReader[ 2 ].ToString();

                    lvCustomer.SelectedItems.Clear();

                    break;
                }
            }
        }

        private void lvCustomer_MouseDoubleClick( object sender, MouseEventArgs e ) {
            btnEdit_Click( sender, (EventArgs)e );
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            if( lvCustomer.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand("DELETE FROM customer WHERE customer_id = '" + lvCustomer.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                dbCommand.ExecuteNonQuery();

                lvCustomer.SelectedItems.Clear();

                getCustomerList();
            }
        }

        private void cmsCustomer_Opening( object sender, CancelEventArgs e ) {
            if( lvCustomer.SelectedItems.Count == 0 ) {
                e.Cancel = true;
            }
        }

        private void getCustomerList() {
            SQLiteCommand dbCommand = new SQLiteCommand("SELECT customer_id, customer_name, customer_desc FROM customer ORDER BY customer_name", frmMain.sqlCon);
            SQLiteDataReader dbReader = dbCommand.ExecuteReader();

            lvCustomer.Items.Clear();
            while( dbReader.Read() ) {
                ListViewItem lvi = new ListViewItem(new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() });

                lvCustomer.Items.Add( lvi );
            }
        }
    }
}
