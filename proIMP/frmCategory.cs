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
    public partial class frmCategory:Form {
        private long lastID = -1;

        public frmCategory() {
            InitializeComponent();

            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        private void frmCategory_Load( object sender, EventArgs e ) {
            lastID = -1;

            tbCategoryID.Text = "";
            tbCategoryName.Text = "";
            tbCategoryDesc.Text = "";

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            getCategoryList();
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbCategoryName.Text.Length > 0 ) {
                try {
                    SQLiteCommand dbCommand;
                    if( tbCategoryID.Text.Length == 0 ) {
                        dbCommand = new SQLiteCommand( "INSERT INTO category (category_id, category_name, category_desc) VALUES(NULL, '" + tbCategoryName.Text.Replace( "'", "''" ) + "', '" + tbCategoryDesc.Text.Replace( "'", "''" ) + "')", frmMain.sqlCon );
                    } else {
                        dbCommand = new SQLiteCommand( "UPDATE category SET category_name = '" + tbCategoryName.Text.Replace( "'", "''" ) + "', category_desc = '" + tbCategoryDesc.Text.Replace( "'", "''" ) + "' WHERE category_id = '" + tbCategoryID.Text + "'", frmMain.sqlCon );
                    }
                    dbCommand.ExecuteNonQuery();

                    dbCommand.CommandText = "SELECT last_insert_rowid()";

                    lastID = (long)dbCommand.ExecuteScalar();
                } catch {
                    MessageBox.Show( "Could not save warehouse to database. Please try again." );

                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            tbCategoryID.Text = "";
            tbCategoryName.Text = "";
            tbCategoryDesc.Text = "";

            lvCategory.SelectedItems.Clear();
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lvCategory_SelectedIndexChanged( object sender, EventArgs e ) {
            if( lvCategory.SelectedItems.Count > 0 ) {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            } else {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnEdit_Click( object sender, EventArgs e ) {
            if( lvCategory.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT category_id, category_name, category_desc FROM category WHERE category_id = '" + lvCategory.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbCategoryID.Text = dbReader[ 0 ].ToString();
                    tbCategoryName.Text = dbReader[ 1 ].ToString();
                    tbCategoryDesc.Text = dbReader[ 2 ].ToString();

                    lvCategory.SelectedItems.Clear();

                    break;
                }
            }
        }

        private void lvCategory_MouseDoubleClick( object sender, MouseEventArgs e ) {
            btnEdit_Click( sender, (EventArgs)e );
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            if( lvCategory.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand("DELETE FROM category WHERE category_id = '" + lvCategory.SelectedItems[0].SubItems[0].Text + "'", frmMain.sqlCon);
                dbCommand.ExecuteNonQuery();

                lvCategory.SelectedItems.Clear();

                getCategoryList();
            }
        }

        private void cmsCategory_Opening( object sender, CancelEventArgs e ) {
            if( lvCategory.SelectedItems.Count == 0 ) {
                e.Cancel = true;
            }
        }

        private void getCategoryList() {
            SQLiteCommand dbCommand = new SQLiteCommand("SELECT category_id, category_name, category_desc FROM category ORDER BY category_name", frmMain.sqlCon);
            SQLiteDataReader dbReader = dbCommand.ExecuteReader();

            lvCategory.Items.Clear();
            while( dbReader.Read() ) {
                ListViewItem lvi = new ListViewItem(new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() });

                lvCategory.Items.Add( lvi );
            }
        }

        public long getLastID() {
            return lastID;
        }
    }
}
