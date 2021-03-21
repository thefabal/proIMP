using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace proIMP {
    public partial class frmChildInventory : Form {
        readonly Func<bool> mainDBCheck;

        private readonly ListViewColumnSorter lvsStockFlow;
        private readonly ListViewColumnSorter lvsStockProductList;

        public frmChildInventory( Func<bool> mainDBCheck ) {
            InitializeComponent();

            lvsStockFlow = new ListViewColumnSorter();
            lvStockFlow.ListViewItemSorter = lvsStockFlow;
            lvsStockProductList = new ListViewColumnSorter();
            lvStockProductList.ListViewItemSorter = lvsStockProductList;

            this.mainDBCheck = mainDBCheck;

            switchLanguage();
            getStockFlowList();
        }

        #region StockFlow
        private void btnStockFlowAdd_Click( object sender, EventArgs e ) {
            btnStockFlowAdd_MouseHover( sender, e );
        }

        private void btnStockFlowEdit_Click( object sender, EventArgs e ) {
            for( int i = 0; i < lvStockFlow.Items.Count; i++ ) {
                if( lvStockFlow.Items[ i ].Checked ) {
                    editStockFlow( lvStockFlow.Items[ i ].SubItems[ 1 ].Text, lvStockFlow.Items[ i ].SubItems[ 7 ].Text );
                }
            }

            checkDB();
        }

        private void btnStockFlowDelete_Click( object sender, EventArgs e ) {
            for( int i = 0; i < lvStockFlow.Items.Count; i++ ) {
                if( lvStockFlow.Items[ i ].Checked ) {
                    deleteStockFlow( lvStockFlow.Items[ i ].SubItems[ 1 ].Text );
                }
            }

            checkDB();
        }

        private void btnStockFlowAdd_MouseHover( object sender, EventArgs e ) {
            if( sender.GetType() == typeof( Button ) ) {
                cmsAddStockFlow.Show( ( ( Button )sender ).PointToScreen( new Point( 0, ( ( Button )sender ).Height ) ) );
            }
        }

        private void btnStockFlowAdd_MouseLeave( object sender, EventArgs e ) {
            if( cmsAddStockFlow.ClientRectangle.Contains( cmsAddStockFlow.PointToClient( Cursor.Position ) ) == false ) {
                cmsAddStockFlow.Hide();
            }
        }

        private void addStockInToolStripMenuItem_Click( object sender, EventArgs e ) {
            using( frmStockFlowIn flowIn = new frmStockFlowIn() ) {
                if( flowIn.ShowDialog() == DialogResult.OK ) {

                }

                checkDB();
            }
        }

        private void stockOutToolStripMenuItem1_Click( object sender, EventArgs e ) {
            using( frmStockFlowOut flowOut = new frmStockFlowOut() ) {
                if( flowOut.ShowDialog() == DialogResult.OK ) {

                }

                checkDB();
            }
        }

        private void lvStockFlow_ItemChecked( object sender, ItemCheckedEventArgs e ) {
            if( functions.checkListViewCheckbox( lvStockFlow ) ) {
                btnStockFlowEdit.Enabled = true;
                btnStockFlowDelete.Enabled = true;
            } else {
                btnStockFlowEdit.Enabled = false;
                btnStockFlowDelete.Enabled = false;
            }

            lvStockFlow_SelectedIndexChanged( sender, e );
        }

        private void lvStockFlow_SelectedIndexChanged( object sender, EventArgs e ) {
            lvStockProductList.Items.Clear();

            if( lvStockFlow.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand( database.sqlCon );
                SQLiteDataReader dbReader;

                double dGrandPrice = 0;

                dbCommand.CommandText = string.Format( 
                    "SELECT t1.sflow_id, t2.product_name, t2.product_unit, ABS(t1.sflow_quantity) AS sflow_quantity, t1.sflow_price, t1.sflow_priceexchange FROM stock_flow AS t1 LEFT JOIN product AS t2 ON t1.sflow_productid = t2.product_id WHERE t1.sflow_sid = '{0}' ORDER BY t2.product_name",
                    lvStockFlow.SelectedItems[ 0 ].SubItems[ 1 ].Text
                );

                try {
                    dbReader = dbCommand.ExecuteReader();
                    while( dbReader.Read() ) {
                        double dQuantity = Convert.ToDouble( dbReader[ "sflow_quantity" ].ToString() );
                        double dPrice = Convert.ToDouble( dbReader[ "sflow_price" ].ToString() );
                        double dTotalPrice = dQuantity * dPrice;
                        double dTotalLocalPrice = ( dbReader["sflow_priceexchange"].ToString() == frmMain.setting.localExchange ) ? ( dTotalPrice ) : ( dTotalPrice * frmMain.er.exchanges[ dbReader["sflow_priceexchange"].ToString() ] .ForexSelling );

                        dGrandPrice += dTotalLocalPrice;

                        ListViewItem lvi = new ListViewItem(
                        new string[ ] {
                            dbReader[ "product_name" ].ToString(),
                            dbReader[ "sflow_id" ].ToString(),
                            frmMain.resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), frmMain.culInfo ),
                            dQuantity.ToString( "0.000" ),
                            dPrice.ToString( "0.000" ) + " " + dbReader[ "sflow_priceexchange" ].ToString(),
                            dTotalPrice.ToString( "0.000" ) + " " + dbReader[ "sflow_priceexchange" ].ToString(),
                            dTotalLocalPrice.ToString( "0.000" ) + " " + frmMain.setting.localExchange
                        }
                    );

                        lvStockProductList.Items.Add( lvi );
                    }
                    lblGrandTotal.Text = dGrandPrice.ToString( "0.000" ) + " " + frmMain.setting.localExchange;

                    dbReader.Close();
                } catch {

                }
            } else {
                lblGrandTotal.Text = string.Empty;
            }
        }
        #endregion

        #region StockProduct
        private void btnStockProductAdd_Click( object sender, EventArgs e ) {
            if( lvStockFlow.SelectedItems.Count > 0 ) {
                using( frmStockFlowProduct stockflow = new frmStockFlowProduct( lvStockFlow.SelectedItems[ 0 ].SubItems[ 1 ].Text ) ) {
                    if( stockflow.ShowDialog() == DialogResult.OK ) {
                        getStockFlowProductList();
                    }
                }
            }
        }

        private void btnStockProductEdit_Click( object sender, EventArgs e ) {
            for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                if( lvStockProductList.Items[ i ].Checked ) {
                    editStockProduct( lvStockProductList.Items[ i ].SubItems[ 1 ].Text );
                }
            }

            getStockFlowProductList();
        }

        private void btnStockProductDelete_Click( object sender, EventArgs e ) {
            for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                if( lvStockProductList.Items[ i ].Checked ) {
                    deleteStockProduct( lvStockProductList.Items[ i ].SubItems[ 1 ].Text );
                }
            }

            getStockFlowProductList();
        }

        private void lvStockProductList_ItemChecked( object sender, ItemCheckedEventArgs e ) {
            if( functions.checkListViewCheckbox( lvStockProductList ) ) {
                btnStockProductEdit.Enabled = true;
                btnStockProductDelete.Enabled = true;
            } else {
                btnStockProductEdit.Enabled = false;
                btnStockProductDelete.Enabled = false;
            }
        }
        #endregion

        #region listViewSort
        private void listView_ColumnClick( object sender, ColumnClickEventArgs e ) {
            frmMain.listView_ColumnClick( sender, e );
        }

        private void listView_DrawItem( object sender, DrawListViewItemEventArgs e ) {
            frmMain.listView_DrawItem( sender, e );
        }

        private void listView_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e ) {
            frmMain.listView_DrawColumnHeader( sender, e );
        }

        private void listView_DrawSubItem( object sender, DrawListViewSubItemEventArgs e ) {
            frmMain.listView_DrawSubItem( sender, e );
        }
        #endregion

        private void getStockFlowProductList() {
            lvStockFlow_SelectedIndexChanged( null, null );
        }

        private void getStockFlowList() {
            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = "SELECT stock_id, stock_type, stock_date, stock_name, stock_desc, product_price, product_count, product_sum FROM stockflow_list ORDER BY stock_date DESC, stock_name";

            lvStockFlow.ItemChecked -= new ItemCheckedEventHandler( lvStockFlow_ItemChecked );
            lvStockFlow.Items.Clear();
            try {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        ( dbReader[ "stock_type" ].ToString() == "1" )?( frmMain.resMan.GetString( "stockFlowStockTypeIn", frmMain.culInfo ) ):( frmMain.resMan.GetString( "stockFlowStockTypeOut", frmMain.culInfo ) ),
                        dbReader[ "stock_id" ].ToString(),
                        ( (DateTime)dbReader[ "stock_date" ] ).ToString("dd.MM.yyyy"),
                        dbReader[ "stock_name" ].ToString(),
                        dbReader[ "stock_desc" ].ToString(),
                        dbReader[ "product_count" ].ToString() + " / " + dbReader[ "product_sum" ].ToString(),
                        ( dbReader[ "product_price" ].GetType() != typeof( DBNull ) ) ? ( ( Convert.ToDouble( dbReader[ "product_price" ].ToString() ) * ((dbReader[ "stock_type" ].ToString() == "1" )?( 1 ):( -1 )) ).ToString( "0.000" ) + " " + frmMain.setting.localExchange ) :( "" ),
                        dbReader[ "stock_type" ].ToString()
                    } );

                    lvStockFlow.Items.Add( lvi );
                }
            } catch {
                MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );
            }

            lvStockFlow.ItemChecked += new ItemCheckedEventHandler( lvStockFlow_ItemChecked );
            lvStockFlow_ItemChecked( this, new ItemCheckedEventArgs( new ListViewItem() ) );
        }

        private void editStockFlow( string strStockID, string strStockType ) {
            if( strStockType == "1" ) {
                using( frmStockFlowIn stockin = new frmStockFlowIn( strStockID ) ) {
                    if( stockin.ShowDialog() == DialogResult.OK ) {

                    }
                }
            } else if( strStockType == "2" ) {
                using( frmStockFlowOut stockout = new frmStockFlowOut( strStockID ) ) {
                    if( stockout.ShowDialog() == DialogResult.OK ) {

                    }
                }
            }
        }

        private void deleteStockFlow( string strStockID ) {
            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = string.Format( 
                "DELETE FROM stock WHERE stock_id = '{0}'",
                strStockID 
            );

            try {
                dbCommand.ExecuteNonQuery();
            } catch {

            }
        }

        private void editStockProduct( string strStockFlowID ) {
            using( frmStockFlowProduct stockflow = new frmStockFlowProduct( "", strStockFlowID ) ) {
                if( stockflow.ShowDialog() == DialogResult.OK ) {

                }
            }
        }

        private void deleteStockProduct( string strStockFlowID ) {
            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = string.Format( 
                "DELETE FROM stock_flow WHERE sflow_id = '{0}'",
                strStockFlowID
            );

            try {
                dbCommand.ExecuteNonQuery();
            } catch {

            }
        }        

        public void action( string act ) {
            switch( act ) {
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
            stockFlowType.Text = frmMain.resMan.GetString( "stockFlowType", frmMain.culInfo );
            stockFlowDate.Text = frmMain.resMan.GetString( "stockFlowDate", frmMain.culInfo );
            stockFlowSupplier.Text = frmMain.resMan.GetString( "stockFlowSupplier", frmMain.culInfo );
            stockFlowDescription.Text = frmMain.resMan.GetString( "stockFlowDescription", frmMain.culInfo );
            stockFlowQuantity.Text = frmMain.resMan.GetString( "stockFlowQuantity", frmMain.culInfo );
            stockFlowTotalPrice.Text = frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo ) + " (" + frmMain.setting.localExchange + ")";

            btnStockFlowAdd.Text = frmMain.resMan.GetString( "btnAdd", frmMain.culInfo );

            addStockInToolStripMenuItem.Text = frmMain.resMan.GetString( "btnStockIn", frmMain.culInfo );
            stockOutToolStripMenuItem1.Text = frmMain.resMan.GetString( "btnStockOut", frmMain.culInfo );
            btnStockFlowEdit.Text = frmMain.resMan.GetString( "btnEdit", frmMain.culInfo );
            btnStockFlowDelete.Text = frmMain.resMan.GetString( "btnDelete", frmMain.culInfo );

            stockProductName.Text = frmMain.resMan.GetString( "plProductName", frmMain.culInfo );
            stockProductUnit.Text = frmMain.resMan.GetString( "stockProductUnit", frmMain.culInfo );
            stockProductQuantity.Text = frmMain.resMan.GetString( "stockProductQuantity", frmMain.culInfo );
            stockProductPrice.Text = frmMain.resMan.GetString( "stockProductPrice", frmMain.culInfo );
            stockProductTotalPrice.Text = frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo );
            stockProductTotalLocalPrice.Text = stockProductTotalPrice.Text + " (" + frmMain.setting.localExchange + ")";

            btnStockProductAdd.Text = frmMain.resMan.GetString( "btnAdd", frmMain.culInfo );
            btnStockProductEdit.Text = frmMain.resMan.GetString( "btnEdit", frmMain.culInfo );
            btnStockProductDelete.Text = frmMain.resMan.GetString( "btnStockProductDelete", frmMain.culInfo );

            lblGrandTotalPrice.Text = frmMain.resMan.GetString( "lblGrandTotalPrice", frmMain.culInfo );
        }

        private bool checkDB() {
            getStockFlowList();
            getStockFlowProductList();

            mainDBCheck();

            return true;
        }
    }
}
