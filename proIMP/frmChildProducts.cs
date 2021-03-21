using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace proIMP {
    public partial class frmChildProducts : Form {
        readonly Func<bool> mainDBCheck;

        private readonly ListViewColumnSorter lvsProductList;

        public frmChildProducts( Func<bool> mainDBCheck ) {
            InitializeComponent();

            lvsProductList = new ListViewColumnSorter();
            lvProductList.ListViewItemSorter = lvsProductList;

            this.mainDBCheck = mainDBCheck;
            
            switchLanguage();
            getProductList();
        }

        private void frmChildProducts_Load( object sender, EventArgs e ) {
            lvProductList_SelectedIndexChanged( null, null );
        }        

        private void btnProductAdd_Click( object sender, EventArgs e ) {
            if( ( new frmProduct( ) ).ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void btnProductEdit_Click( object sender, EventArgs e ) {
            for( int i = 0; i < lvProductList.Items.Count; i++ ) {
                if( lvProductList.Items[ i ].Checked ) {
                    editProduct( lvProductList.Items[ i ].SubItems[ 1 ].Text );
                }
            }

            checkDB();
        }        

        private void btnProductDelete_Click( object sender, EventArgs e ) {
            for( int i = 0; i < lvProductList.Items.Count; i++ ) {
                if( lvProductList.Items[ i ].Checked ) {
                    deleteProduct( lvProductList.Items[ i ].SubItems[ 1 ].Text );
                }
            }

            checkDB();
        }

        private void lvProductList_ItemChecked( object sender, ItemCheckedEventArgs e ) {
            if( functions.checkListViewCheckbox( lvProductList ) ) {
                btnProductEdit.Enabled = true;
                btnProductDelete.Enabled = true;
            } else {
                btnProductEdit.Enabled = false;
                btnProductDelete.Enabled = false;
            }
        }

        private void lvProductList_SelectedIndexChanged( object sender, EventArgs e ) {
            if( lvProductList.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "SELECT t1.product_id, t1.product_name, t2.category_name, t1.product_desc, t1.product_unit, t1.product_barcode, t1.product_imageid, t3.image_binary FROM product AS t1 LEFT JOIN category AS t2 ON t1.product_catid = t2.category_id LEFT JOIN image AS t3 ON t1.product_imageid = t3.image_id WHERE t1.product_id = '{0}'",
                    lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text
                );

                try {
                    SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                    while( dbReader.Read() ) {
                        lblProductIDT.Text = ": " + dbReader[ "product_id" ].ToString();
                        lblProductNameT.Text = ": " + dbReader[ "product_name" ].ToString();
                        lblProductCategoryT.Text = ": " + dbReader[ "category_name" ].ToString();
                        lblProductDescT.Text = ": " + dbReader[ "product_desc" ].ToString();
                        lblProductUnitT.Text = ": " + frmMain.resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), frmMain.culInfo );
                        lblProductBarcodeT.Text = ": " + dbReader[ "product_barcode" ].ToString();

                        if( dbReader[ "product_imageid" ].ToString().Length != 0 ) {
                            pbProductImage.Visible = true;
                            pbProductImage.Image = functions.DeserializeImage( ( byte[ ] )dbReader[ "image_binary" ] );
                        } else {
                            pbProductImage.Visible = false;
                        }
                    }
                } catch {

                }
            } else {
                lblProductIDT.Text = ": ";
                lblProductNameT.Text = ": ";
                lblProductCategoryT.Text = ": ";
                lblProductDescT.Text = ": ";
                lblProductUnitT.Text = ": ";
                lblProductBarcodeT.Text = ": ";
                pbProductImage.Visible = false;
            }
        }

        #region contextMenuStrip
        private void cmsProduct_Opening( object sender, CancelEventArgs e ) {
            if( lvProductList.SelectedItems.Count == 0 ) {
                e.Cancel = true;
            }
        }

        private void editProductToolStripMenuItem_Click( object sender, EventArgs e ) {
            if( lvProductList.SelectedItems.Count > 0 ) {
                editProduct( lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text );
            }

            checkDB();
        }

        private void deleteProductToolStripMenuItem_Click( object sender, EventArgs e ) {
            if( lvProductList.SelectedItems.Count > 0 ) {
                deleteProduct( lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text );
            }

            checkDB();
        }

        private void duplicateProductToolStripMenuItem_Click( object sender, EventArgs e ) {
            string product_id;

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = string.Format( 
                "INSERT INTO product SELECT NULL, product_name || '(1)', product_catid, product_desc, product_unit, product_barcode, product_imageid FROM product WHERE product_id = '{0}'",
                lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text
            );

            dbCommand.Transaction = database.sqlCon.BeginTransaction();                        
            try {
                dbCommand.ExecuteNonQuery();

                dbCommand.CommandText = "SELECT last_insert_rowid()";
                product_id = ( ( long )dbCommand.ExecuteScalar() ).ToString();
            } catch(Exception ex) {
                MessageBox.Show( ex.Message );
                
                return;
            }

            if( editProduct( product_id ) ) {
                dbCommand.Transaction.Commit();
            } else {
                dbCommand.Transaction.Rollback();
            }

            checkDB();
        }
        #endregion

        #region listViewSorter
        private void lvProductList_ColumnClick( object sender, ColumnClickEventArgs e ) {
            frmMain.listView_ColumnClick( sender, e );
        }

        private void lvProductList_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e ) {
            frmMain.listView_DrawColumnHeader( sender, e );
        }

        private void lvProductList_DrawItem( object sender, DrawListViewItemEventArgs e ) {
            frmMain.listView_DrawItem( sender, e );
        }

        private void lvProductList_DrawSubItem( object sender, DrawListViewSubItemEventArgs e ) {
            frmMain.listView_DrawSubItem( sender, e );
        }
        #endregion

        #region productFilter
        private void btnProductFilter_Click( object sender, EventArgs e ) {
            getProductList( tbProductFilter.Text );
        }

        private void btnProductFilterClear_Click( object sender, EventArgs e ) {
            tbProductFilter.Clear();

            getProductList();
        }

        private void tbProductFilter_KeyDown( object sender, KeyEventArgs e ) {
            if( e.KeyCode == Keys.Enter ) {
                btnProductFilter_Click( this, new EventArgs() );
            } else if( e.KeyCode == Keys.Escape ) {
                btnProductFilterClear_Click( this, new EventArgs() );
            }
        }
        #endregion

        private bool getProductList( string filter = "" ) {
            string sql = string.Empty;
            if( filter.Length > 0 ) {
                sql = string.Format( "SELECT product_id, product_name, category_name, product_count, product_price FROM product_list WHERE product_name LIKE '%{0}%' ORDER BY ",
                    filter
                );
            } else {
                sql = "SELECT product_id, product_name, category_name, product_count, product_price FROM product_list ORDER BY ";
            }

            if( frmMain.setting.productOrder == 0 ) {
                sql += "product_name, category_name";
            } else {
                sql += "category_name, product_name";
            }

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = sql;

            try {
                lvProductList.Items.Clear();
                lvProductList.ItemChecked -= new ItemCheckedEventHandler( lvProductList_ItemChecked );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        dbReader[ "product_name" ].ToString(),
                        dbReader[ "product_id" ].ToString(),
                        dbReader[ "category_name" ].ToString(),
                        dbReader[ "product_count" ].ToString(),
                        ( dbReader[ "product_price" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "product_price" ].ToString() ).ToString( "0.000" ) ) :( "" )
                    } );

                    lvProductList.Items.Add( lvi );
                }

                lvProductList.ItemChecked += new ItemCheckedEventHandler( lvProductList_ItemChecked );
                lvProductList_ItemChecked( null, null );

                return true;
            } catch {
                MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );
            }

            return false;
        }

        private bool editProduct( string strProductID ) {
            if( ( new frmProduct( strProductID ) ).ShowDialog() == DialogResult.OK ) {
                return true;
            } else {
                return false;
            }
        }

        private void deleteProduct( string strProductID ) {
            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = string.Format( 
                "DELETE FROM product WHERE product_id = '{0}'",
                strProductID 
            );

            try {
                dbCommand.ExecuteNonQuery();
            } catch {

            }            
        }

        public void action(string act) {
            switch(act) {
                case "language": {
                    switchLanguage();
                }
                break;

                case "database": {
                    checkDB();
                }
                break;
            }
        }
        
        private void switchLanguage() {
            btnProductFilter.Text = frmMain.resMan.GetString( "btnProductFilter", frmMain.culInfo );
            btnProductFilterClear.Text = frmMain.resMan.GetString( "btnClear", frmMain.culInfo );

            plProductName.Text = frmMain.resMan.GetString( "plProductName", frmMain.culInfo );
            plProductID.Text = frmMain.resMan.GetString( "plProductID", frmMain.culInfo );
            plProductCategory.Text = frmMain.resMan.GetString( "plProductCategory", frmMain.culInfo );
            plProductStock.Text = frmMain.resMan.GetString( "plProductStock", frmMain.culInfo );
            plProductPrice.Text = frmMain.resMan.GetString( "plProductPrice", frmMain.culInfo ) + " (" + frmMain.setting.localExchange + ")";

            /**
             * Product Info
             **/
            lblProductID.Text = plProductID.Text;
            lblProductName.Text = plProductName.Text;
            lblProductCategory.Text = plProductCategory.Text;
            lblProductDesc.Text = frmMain.resMan.GetString( "lblProductDesc", frmMain.culInfo );
            lblProductUnit.Text = frmMain.resMan.GetString( "lblProductUnit", frmMain.culInfo );
            lblProductBarcode.Text = frmMain.resMan.GetString( "lblProductBarcode", frmMain.culInfo );

            btnProductAdd.Text = frmMain.resMan.GetString( "btnAdd", frmMain.culInfo );
            btnProductEdit.Text = frmMain.resMan.GetString( "btnEdit", frmMain.culInfo );
            btnProductDelete.Text = frmMain.resMan.GetString( "btnDelete", frmMain.culInfo );

            gbProductInfo.Text = frmMain.resMan.GetString( "gbProductInfo", frmMain.culInfo );

            /**
             * Product Info
             **/
            editProductToolStripMenuItem.Text = frmMain.resMan.GetString( "editProductToolStripMenuItem", frmMain.culInfo );
            deleteProductToolStripMenuItem.Text = frmMain.resMan.GetString( "deleteProductToolStripMenuItem", frmMain.culInfo );
            duplicateProductToolStripMenuItem.Text = frmMain.resMan.GetString( "duplicateProductToolStripMenuItem", frmMain.culInfo );
        }

        private bool checkDB() {
            if( getProductList( tbProductFilter.Text ) ) {
                if( mainDBCheck() ) {
                    return true;
                }
            }

            return false;
        }
    }
}
