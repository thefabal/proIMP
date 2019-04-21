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
        private readonly frmMain frmMain;
        private SQLiteCommand dbCommand;

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

            dbCommand = new SQLiteCommand() {
                Connection = frmMain.sqlCon
            };

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
                    if( tbCategoryID.Text.Length == 0 ) {
                        dbCommand.CommandText = "INSERT INTO category (category_name, category_desc) VALUES(@category_name, @category_desc)";
                    } else {
                        dbCommand.CommandText = "UPDATE category SET category_name = @category_name, category_desc = @category_desc WHERE category_id = @category_id";

                        dbCommand.Parameters.Add( new SQLiteParameter( "@category_id", tbCategoryID.Text ) );
                    }

                    dbCommand.Parameters.Add( new SQLiteParameter( "@category_name", tbCategoryName.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@category_desc", tbCategoryDesc.Text ) );

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
                dbCommand.CommandText = "SELECT category_id, category_name, category_desc FROM category WHERE category_id = @category_id";
                dbCommand.Parameters.Add( new SQLiteParameter( "@category_id", lvCategory.SelectedItems[ 0 ].SubItems[ 0 ].Text ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                if( dbReader.HasRows ) {
                    dbReader.Read();

                    tbCategoryID.Text = dbReader[ "category_id" ].ToString();
                    tbCategoryName.Text = dbReader[ "category_name" ].ToString();
                    tbCategoryDesc.Text = dbReader[ "category_desc" ].ToString();

                    lvCategory.SelectedItems.Clear();
                }

                dbReader.Close();
            }
        }

        private void lvCategory_MouseDoubleClick( object sender, MouseEventArgs e ) {
            btnEdit_Click( sender, (EventArgs)e );
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            if( lvCategory.SelectedItems.Count > 0 ) {
                dbCommand.CommandText = "DELETE FROM category WHERE category_id = @category_id";
                dbCommand.Parameters.Add( new SQLiteParameter( "@category_id", lvCategory.SelectedItems[ 0 ].SubItems[ 0 ].Text ) );

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
            dbCommand.CommandText = "SELECT category_id, category_name, category_desc FROM category ORDER BY category_name";
            SQLiteDataReader dbReader = dbCommand.ExecuteReader();

            lvCategory.Items.Clear();
            while( dbReader.Read() ) {
                ListViewItem lvi = new ListViewItem(
                    new string[] {
                        dbReader[ "category_id" ].ToString(),
                        dbReader[ "category_name" ].ToString(),
                        dbReader[ "category_desc" ].ToString()
                    } 
                );

                lvCategory.Items.Add( lvi );
            }

            dbReader.Close();
        }

        public long getLastID() {
            return lastID;
        }
    }
}
