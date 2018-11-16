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
        public frmMain frmMain;

        private long lastID = -1;

        public frmCategory( frmMain frmMain ) {
            InitializeComponent();

            this.frmMain = frmMain;
            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        private void frmCategory_Load( object sender, EventArgs e ) {
            lastID = -1;

            tbCategoryID.Text = "";
            tbCategoryName.Text = "";
            tbCategoryDesc.Text = "";

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            switchLanguage();
            getCategoryList();
        }

        private void switchLanguage( ) {
            this.Text = frmMain.resMan.GetString( "frmCategory_Text", frmMain.culInfo );
            gbCategoryInfo.Text = frmMain.resMan.GetString( "gbCategoryInfo", frmMain.culInfo );
            gbCategoryList.Text = frmMain.resMan.GetString( "gbCategoryList", frmMain.culInfo );
            lblCategoryID.Text = frmMain.resMan.GetString( "lblCategoryID", frmMain.culInfo ) + " :";
            lblCategoryName.Text = frmMain.resMan.GetString( "lblCategoryName", frmMain.culInfo ) + " :";
            lblCategoryDesc.Text = frmMain.resMan.GetString( "lblCategoryDesc", frmMain.culInfo ) + " :";
            btnSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
            btnClear.Text = frmMain.resMan.GetString( "btnClear", frmMain.culInfo );
            btnCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnEdit.Text = frmMain.resMan.GetString( "btnEdit", frmMain.culInfo );
            btnDelete.Text = frmMain.resMan.GetString( "btnDelete", frmMain.culInfo );

            chCategoryName.Text = frmMain.resMan.GetString( "chName", frmMain.culInfo );
            chCategoryDesc.Text = frmMain.resMan.GetString( "chDescription", frmMain.culInfo );
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
                    MessageBox.Show( frmMain.resMan.GetString( "couldNotSaveCategory", frmMain.culInfo ) );

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
