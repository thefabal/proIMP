using System;
using System.Windows.Forms;
using System.Threading;

// SQLite
using System.Data.SQLite;

namespace proIMP {
    public partial class frmStockFlowProduct:Form {
        private readonly string strStockID = string.Empty;
        private readonly string strStockFlowID = string.Empty;
        private string strStockType = string.Empty;

        public frmStockFlowProduct( string strStockID = "", string strStockFlowID = "", string strStockType = "" ) {
            InitializeComponent();

            this.strStockID = strStockID;
            this.strStockFlowID = strStockFlowID;
            this.strStockType = strStockType;
        }

        private void frmStockFlowProduct_Load( object sender, EventArgs e ) {
            switchLanguage();

            database.getWarehouseList( cbStockProductWarehouse );
            database.getProductList( cbStockProductID );
            database.getExchangeList( cbStockProductCurrency );

            if( strStockFlowID == string.Empty ) {
                cbStockProductID.SelectedIndex = -1;
                cbStockProductID.Text = string.Empty;
                cbStockProductWarehouse.SelectedIndex = 0;
                tbStockProductUnit.Text = string.Empty;
                tbStockProductQuantity.Text = string.Empty;
                tbStockProductPrice.Text = string.Empty;

                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "SELECT stock_type FROM stock WHERE stock_id = '{0}'",
                    strStockID
                 );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                if( dbReader.Read() ) {
                    strStockType = dbReader[ "stock_type" ].ToString();
                } else {
                    this.DialogResult = DialogResult.Cancel;
                }
                dbReader.Close();
            } else {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format(
                    "SELECT t1.sflow_id, t3.stock_type, t1.sflow_productid, t2.product_name, t2.product_unit, t4.warehouse_id, t4.warehouse_name, ABS(t1.sflow_quantity) AS sflow_quantity, t1.sflow_price, t1.sflow_priceexchange FROM stock_flow AS t1 LEFT JOIN product AS t2 ON t1.sflow_productid = t2.product_id LEFT JOIN stock AS t3 ON t1.sflow_sid = t3.stock_id LEFT JOIN warehouse AS t4 ON t1.sflow_warehouseid = t4.warehouse_id WHERE t1.sflow_id = '{0}'",
                    strStockFlowID
                );
                
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

        private void btnCategoryAdd_Click( object sender, EventArgs e ) {
            using( frmProduct product = new frmProduct() ) {
                if( product.ShowDialog() == DialogResult.OK ) {
                    database.getProductList( cbStockProductID );

                    if( product.lastID != string.Empty ) {
                        for( int i = 0; i < cbStockProductID.Items.Count; i++ ) {
                            if( ( ( ProductItem )cbStockProductID.Items[ i ] ).ProductID == product.lastID ) {
                                cbStockProductID.SelectedIndex = i;

                                break;
                            }
                        }
                    }
                }
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
                        SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                        dbCommand.CommandText = string.Format(
                            "INSERT INTO stock_flow (sflow_sid, sflow_productid, sflow_warehouseid, sflow_quantity, sflow_price, sflow_priceexchange) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                            strStockID,
                            ( ( ProductItem )cbStockProductID.SelectedItem ).ProductID,
                            ( ( WarehouseItem )cbStockProductWarehouse.SelectedItem ).WarehouseID,
                            dQuantity,
                            dPrice,
                            ( string )cbStockProductCurrency.SelectedItem
                        );

                        dbCommand.ExecuteNonQuery();
                    } catch {
                        MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );

                        return;
                    }
                } else if( strStockFlowID != string.Empty ) {
                    try {
                        SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                        dbCommand.CommandText = string.Format(
                            "UPDATE stock_flow SET sflow_productid = '{1}', sflow_warehouseid = '{2}', sflow_quantity = '{3}', sflow_price = '{4}', sflow_priceexchange = '{5}' WHERE sflow_id = '{0}'",
                            strStockFlowID,
                            ( ( ProductItem )cbStockProductID.SelectedItem ).ProductID,
                            ( ( WarehouseItem )cbStockProductWarehouse.SelectedItem ).WarehouseID,
                            dQuantity,
                            dPrice,
                            ( string )cbStockProductCurrency.SelectedItem
                        );

                        dbCommand.ExecuteNonQuery();
                    } catch( Exception ex ) {
                        MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) + "\r\n\r\n" + ex.Message );

                        return;
                    }
                } else {
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
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

        private void switchLanguage() {
            this.Text = frmMain.resMan.GetString( "frmStockFlowProduct_Text", frmMain.culInfo );

            lblProductUnit.Text = frmMain.resMan.GetString( "lblProductUnit", frmMain.culInfo ) + " :";
            lblProductWarehouse.Text = frmMain.resMan.GetString( "lblProductWarehouse", frmMain.culInfo ) + " :";
            lblProductQuantity.Text = frmMain.resMan.GetString( "lblProductQuantity", frmMain.culInfo ) + " :";
            lblProductPrice.Text = frmMain.resMan.GetString( "lblProductPrice", frmMain.culInfo );
            lblProductCurrency.Text = frmMain.resMan.GetString( "lblProductCurrency", frmMain.culInfo );

            btnCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
        }
    }
}
