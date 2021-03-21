using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// SQLite
using System.Data.SQLite;

namespace proIMP {
    public partial class frmCustomer:Form {
        public frmCustomer() {
            InitializeComponent();

            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        private void frmCustomer_Load( object sender, EventArgs e ) {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            switchLanguage();
            database.getCustomerList( lvCustomer );
        }        

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbCustomerName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand = database.sqlCon.CreateCommand();

                    if( tbCustomerID.Text.Length == 0 ) {
                        dbCommand.CommandText = "INSERT INTO customer (customer_name, customer_desc) VALUES(@customer_name, @customer_desc)";
                    } else {
                        dbCommand.CommandText = "UPDATE customer SET customer_name = @customer_name, customer_desc = @customer_desc WHERE customer_id = @customer_id";                        
                    }

                    dbCommand.Parameters.Add( new SQLiteParameter( "@customer_id", tbCustomerID.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@customer_name", tbCustomerName.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@customer_desc", tbCustomerDesc.Text ) );

                    dbCommand.ExecuteNonQuery();
                } catch {
                    MessageBox.Show( frmMain.resMan.GetString( "couldNotSaveCustomer", frmMain.culInfo ) );

                    return;
                }

                database.getCustomerList( lvCustomer );
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

        private void btnEdit_Click( object sender, EventArgs e ) {
            if( lvCustomer.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "SELECT customer_id, customer_name, customer_desc FROM customer WHERE customer_id = '{0}'",
                    lvCustomer.SelectedItems[ 0 ].SubItems[ 0 ].Text
                );

                try {
                    SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                    if( dbReader.HasRows ) {
                        dbReader.Read();

                        tbCustomerID.Text = dbReader[ "customer_id" ].ToString();
                        tbCustomerName.Text = dbReader[ "customer_name" ].ToString();
                        tbCustomerDesc.Text = dbReader[ "customer_desc" ].ToString();

                        lvCustomer.SelectedItems.Clear();

                        dbReader.Close();
                    }
                } catch {

                }

            }
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            if( lvCustomer.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "DELETE FROM customer WHERE customer_id = '{0}'",
                    lvCustomer.SelectedItems[ 0 ].SubItems[ 0 ].Text
                );

                try {
                    dbCommand.ExecuteNonQuery();
                } catch {

                }

                database.getCustomerList( lvCustomer );
            }
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

        private void lvCustomer_MouseDoubleClick( object sender, MouseEventArgs e ) {
            btnEdit_Click( sender, (EventArgs)e );
        }        

        private void cmsCustomer_Opening( object sender, CancelEventArgs e ) {
            if( lvCustomer.SelectedItems.Count == 0 ) {
                e.Cancel = true;
            }
        }

        private void switchLanguage() {
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
    }
}
