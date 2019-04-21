using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

// SQLite
using System.Data.SQLite;

namespace proIMP {
    public partial class frmStockFlowProduct:Form {
        public frmMain frmMain;
        public string strStockID = string.Empty;
        public string strStockFlowID = string.Empty;
        public string strStockType = string.Empty;

        public frmStockFlowProduct( frmMain frmMain ) {
            this.frmMain = frmMain;
            InitializeComponent();
        }

        private void frmStockFlowProduct_Load( object sender, EventArgs e ) {
            switchLanguage();
            getWarehouseList();
            getProductList();
            getExchangeList();

            if( strStockFlowID == string.Empty ) {
                cbStockProductID.SelectedIndex = -1;
                cbStockProductID.Text = string.Empty;
                cbStockProductWarehouse.SelectedIndex = 0;
                tbStockProductUnit.Text = string.Empty;
                tbStockProductQuantity.Text = string.Empty;
                tbStockProductPrice.Text = string.Empty;

                SQLiteCommand dbCommand = new SQLiteCommand("SELECT stock_type FROM stock WHERE stock_id = '" + strStockID + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                if( dbReader.Read() ) {
                    strStockType = dbReader[ "stock_type" ].ToString();
                } else {
                    this.DialogResult = DialogResult.Cancel;
                }
                dbReader.Close();
            } else {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT t1.sflow_id, t3.stock_type, t1.sflow_productid, t2.product_name, t2.product_unit, t4.warehouse_id, t4.warehouse_name, ABS(t1.sflow_quantity) AS sflow_quantity, t1.sflow_price, t1.sflow_priceexchange FROM stock_flow AS t1 LEFT JOIN product AS t2 ON t1.sflow_productid = t2.product_id LEFT JOIN stock AS t3 ON t1.sflow_sid = t3.stock_id LEFT JOIN warehouse AS t4 ON t1.sflow_warehouseid = t4.warehouse_id WHERE t1.sflow_id = '" + strStockFlowID + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                if( dbReader.Read() ) {
                    tbStockProductUnit.Text = frmMain.resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), frmMain.culInfo );
                    tbStockProductQuantity.Text = dbReader[ "sflow_quantity" ].ToString();
                    tbStockProductPrice.Text = dbReader[ "sflow_price" ].ToString();

                    cbStockProductID.SelectedIndex = cbStockProductID.FindStringExact( dbReader[ "product_name" ].ToString() );
                    cbStockProductWarehouse.SelectedIndex = cbStockProductWarehouse.FindStringExact( dbReader[ "warehouse_name" ].ToString() );
                    cbStockProductCurrency.SelectedIndex = cbStockProductCurrency.FindStringExact( dbReader[ "sflow_priceexchange" ].ToString() );

                    strStockType = dbReader[ "stock_type" ].ToString();
                }
                dbReader.Close();
            }

            cbStockProductID.Focus();
        }

        private void switchLanguage( ) {
            this.Text = frmMain.resMan.GetString( "frmStockFlowProduct_Text", frmMain.culInfo );

            lblProductUnit.Text = frmMain.resMan.GetString( "lblProductUnit", frmMain.culInfo ) + " :";
            lblProductWarehouse.Text = frmMain.resMan.GetString( "lblProductWarehouse", frmMain.culInfo ) + " :";
            lblProductQuantity.Text = frmMain.resMan.GetString( "lblProductQuantity", frmMain.culInfo ) + " :";
            lblProductPrice.Text = frmMain.resMan.GetString( "lblProductPrice", frmMain.culInfo );
            lblProductCurrency.Text = frmMain.resMan.GetString( "lblProductCurrency", frmMain.culInfo );

            btnCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
        }

        private void cbStockProductID_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbStockProductID.SelectedIndex == -1 ) {
                tbStockProductUnit.Text = "";
            } else {
                tbStockProductUnit.Text = frmMain.resMan.GetString( "unit" + ( (ProductItem)cbStockProductID.SelectedItem ).ProductUnit, frmMain.culInfo );
            }
        }

        private void tbStockProductQuantity_KeyPress( object sender, KeyPressEventArgs e ) {
            if( (int)e.KeyChar < 48 || (int)e.KeyChar > 57 ) {
                if( e.KeyChar == Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator[ 0 ] ) {
                    ( (TextBox)sender ).Text += Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    ( (TextBox)sender ).SelectionStart = ( (TextBox)sender ).Text.Length;
                    ( (TextBox)sender ).SelectionLength = 0;
                } else if( e.KeyChar == (char)( 0x08 ) ) {
                    e.Handled = false;

                    return;
                }
                e.Handled = true;
            }
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            if( cbStockProductID.SelectedIndex != -1 ) {
                if( cbStockProductCurrency.SelectedIndex == -1 ) {
                    MessageBox.Show( frmMain.resMan.GetString( "selectCurrency", frmMain.culInfo ) );

                    cbStockProductCurrency.Focus();

                    return;
                }

                double dQuantity;
                try {
                    dQuantity = Convert.ToDouble( tbStockProductQuantity.Text );
                } catch {
                    MessageBox.Show( frmMain.resMan.GetString( "errorOnProductQuantity", frmMain.culInfo ) );

                    tbStockProductQuantity.Focus();

                    return;
                }

                double dPrice;
                try {
                    dPrice = Convert.ToDouble( tbStockProductPrice.Text );
                } catch {
                    MessageBox.Show( frmMain.resMan.GetString( "errorOnProductPrice", frmMain.culInfo ) );

                    tbStockProductPrice.Focus();

                    return;
                }

                if( strStockType == "2" ) {
                    dQuantity *= -1;
                }

                if( strStockFlowID == string.Empty && strStockID != string.Empty ) {
                    try {
                        SQLiteCommand dbCommand = new SQLiteCommand( "INSERT INTO stock_flow (sflow_sid, sflow_productid, sflow_warehouseid, sflow_quantity, sflow_price, sflow_priceexchange) VALUES(@sflow_sid, @sflow_productid, @sflow_warehouseid, @sflow_quantity, @sflow_price, @sflow_priceexchange)", frmMain.sqlCon );

                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_sid", strStockID ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_productid", ( (ProductItem)cbStockProductID.SelectedItem ).ProductID ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_warehouseid", ( (WarehouseItem)cbStockProductWarehouse.SelectedItem ).WarehouseID ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_quantity", dQuantity ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_price", dPrice ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_priceexchange", (string)cbStockProductCurrency.SelectedItem ) );

                        dbCommand.ExecuteNonQuery();
                    } catch {
                        MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );

                        return;
                    }
                } else if( strStockFlowID != string.Empty ) {
                    try {
                        SQLiteCommand dbCommand = new SQLiteCommand( "UPDATE stock_flow SET sflow_productid = @sflow_productid, sflow_warehouseid = @sflow_warehouseid, sflow_quantity = @sflow_quantity, sflow_price = @sflow_price, sflow_priceexchange = @sflow_priceexchange WHERE sflow_id = @sflow_id", frmMain.sqlCon );

                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_id", strStockFlowID ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_productid", ( (ProductItem)cbStockProductID.SelectedItem ).ProductID ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_warehouseid", ( (WarehouseItem)cbStockProductWarehouse.SelectedItem ).WarehouseID ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_quantity", dQuantity ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_price", dPrice ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_priceexchange", (string)cbStockProductCurrency.SelectedItem ) );

                        dbCommand.ExecuteNonQuery();
                    } catch(Exception ex) {
                        MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) + "\r\n\r\n" + ex.Message );

                        return;
                    }
                } else {
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCategoryAdd_Click( object sender, EventArgs e ) {
            frmMain.product.productID = string.Empty;
            if( frmMain.product.ShowDialog() == DialogResult.OK ) {

            }

            getProductList();

            if( frmMain.product.lastID != string.Empty ) {
                for( int i = 0; i < cbStockProductID.Items.Count; i++ ) {
                    if( ( (ProductItem)cbStockProductID.Items[ i ] ).ProductID == frmMain.product.lastID ) {
                        cbStockProductID.SelectedIndex = i;

                        break;
                    }
                }
            }
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void getWarehouseList() {
            try {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT warehouse_id, warehouse_name FROM warehouse ORDER BY warehouse_name", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbStockProductWarehouse.Items.Clear();
                while( dbReader.Read() ) {
                    cbStockProductWarehouse.Items.Add( new WarehouseItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        private void getProductList() {
            try {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT product_id, product_name, product_unit FROM product ORDER BY product_name", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbStockProductID.Items.Clear();
                while( dbReader.Read() ) {
                    cbStockProductID.Items.Add( new ProductItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString(), dbReader[ 2 ].ToString() ) );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        private void getExchangeList( ) {
            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT DISTINCT currency_code FROM forex_exchange ORDER BY currency_code", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbStockProductCurrency.Items.Clear();
                cbStockProductCurrency.Items.Add( "TL" );
                while( dbReader.Read() ) {
                    cbStockProductCurrency.Items.Add( dbReader[ 0 ].ToString() );
                }
                dbReader.Close();

                cbStockProductCurrency.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }
    }
}
