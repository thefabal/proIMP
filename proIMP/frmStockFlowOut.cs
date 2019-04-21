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
    public partial class frmStockFlowOut:Form {
        public frmMain frmMain;
        public string stockFlowID = string.Empty;

        private SQLiteCommand dbCommand;
        private exchange_rates er;

        public frmStockFlowOut( frmMain frmMain ) {
            this.frmMain = frmMain;

            InitializeComponent();
        }

        private void frmStockFlowOut_Load( object sender, EventArgs e ) {
            switchLanguage();

            dbCommand = new SQLiteCommand() {
                Connection = frmMain.sqlCon
            };

            frmMain.getSupplierList( cbStockCustomer, "customer" );
            frmMain.getProductList( cbStockProductID );
            frmMain.getWarehouseList( cbStockProductWarehouse );
            frmMain.getExchangeList( cbStockProductCurrency );

            er = frmMain.getCurrency( DateTime.Now.Date );

            tbStockProductUnit.Text = string.Empty;
            tbStockProductQuantity.Text = string.Empty;
            tbStockProductPrice.Text = string.Empty;

            if( stockFlowID == string.Empty ) {
                lvStockProductList.CheckBoxes = false;
                lblProductListNote.Visible = false;

                dtpStockDate.Value = DateTime.Now.Date;
                tbStockDesc.Text = string.Empty;
                lblStockGrandTotal.Text = string.Empty;

                lvStockProductList.Items.Clear();
            } else {
                lvStockProductList.CheckBoxes = true;
                lblProductListNote.Visible = true;

                dbCommand.CommandText = "SELECT t1.stock_type, t1.stock_date, t1.stock_supplier, t2.customer_name, t1.stock_desc FROM stock AS t1 LEFT JOIN customer AS t2 ON t1.stock_supplier = t2.customer_id WHERE t1.stock_id = '" + stockFlowID + "'";
                dbCommand.Parameters.Add( new SQLiteParameter( "@stock_id", stockFlowID ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                if( dbReader.Read() ) {
                    tbStockDesc.Text = dbReader[ "stock_desc" ].ToString();
                    dtpStockDate.Value = (DateTime)dbReader[ "stock_date" ];
                    cbStockCustomer.SelectedIndex = cbStockCustomer.FindStringExact( dbReader[ "customer_name" ].ToString() );

                    dbReader.Close();
                    dbCommand.CommandText = "SELECT t1.sflow_id, t2.product_name, t3.warehouse_id, t3.warehouse_name, t2.product_unit, ABS(t1.sflow_quantity) AS sflow_quantity, t1.sflow_price, t1.sflow_priceexchange FROM stock_flow AS t1 LEFT JOIN product AS t2 ON t1.sflow_productid = t2.product_id LEFT JOIN warehouse AS t3 ON t1.sflow_warehouseid = t3.warehouse_id WHERE t1.sflow_sid = @sflow_sid ORDER BY t2.product_name";
                    dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_sid", stockFlowID ) );

                    dbReader = dbCommand.ExecuteReader();

                    double dGrandPrice = 0;
                    lvStockProductList.Items.Clear();
                    while( dbReader.Read() ) {
                        double dQuantity = Convert.ToDouble( dbReader[ "sflow_quantity" ].ToString() );
                        double dPrice = Convert.ToDouble( dbReader[ "sflow_price" ].ToString() );
                        double dTotalPrice = dQuantity * dPrice;
                        double dTotalLocalPrice = dTotalPrice * er.exchanges[ dbReader[ "sflow_priceexchange" ].ToString() ].ForexSelling;

                        dGrandPrice += dTotalLocalPrice;

                        ListViewItem lvi = new ListViewItem(
                            new string[] {
                                dbReader[ "product_name" ].ToString(),
                                dbReader[ "sflow_id" ].ToString(),
                                dbReader[ "warehouse_id" ].ToString(),
                                dbReader[ "warehouse_name" ].ToString(),
                                frmMain.resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), frmMain.culInfo ),
                                dQuantity.ToString("0.000"),
                                dPrice.ToString("0.000") + " " + dbReader[ "sflow_priceexchange" ].ToString(),
                                dTotalPrice.ToString( "0.000" ) + " " + dbReader[ "sflow_priceexchange" ].ToString(),
                                dTotalLocalPrice.ToString( "0.000" ) + " " + frmMain.setting.localExchange
                            } 
                        );

                        lvStockProductList.Items.Add( lvi );
                    }
                    dbReader.Close();
                    lblStockGrandTotal.Text = dGrandPrice.ToString( "0.000" ) + " " + frmMain.setting.localExchange;

                    dbCommand.Connection = frmMain.sqlCon;
                    dbCommand.Transaction = frmMain.sqlCon.BeginTransaction();
                } else {
                    dbReader.Close();
                }
            }
        }

        private void switchLanguage( ) {
            this.Text = frmMain.resMan.GetString( "frmStockFlowOut_Text", frmMain.culInfo );

            lblDate.Text = frmMain.resMan.GetString( "lblDate", frmMain.culInfo ) + " :";
            lblCustomer.Text = frmMain.resMan.GetString( "lblCustomer", frmMain.culInfo ) + " :";
            lblDescription.Text = frmMain.resMan.GetString( "lblDescription", frmMain.culInfo ) + " :";
            lblProductName.Text = frmMain.resMan.GetString( "lblProductName", frmMain.culInfo );
            lblWarehouse.Text = frmMain.resMan.GetString( "lblWarehouse", frmMain.culInfo );
            lblProductUnit.Text = frmMain.resMan.GetString( "lblProductUnit", frmMain.culInfo );
            lblProductQuantity.Text = frmMain.resMan.GetString( "lblProductQuantity", frmMain.culInfo );
            lblProductCurrency.Text = frmMain.resMan.GetString( "lblProductCurrency", frmMain.culInfo );
            lblProductPrice.Text = frmMain.resMan.GetString( "lblProductPrice", frmMain.culInfo );
            btnProductAdd.Text = frmMain.resMan.GetString( "btnAdd", frmMain.culInfo );
            chProductName.Text = lblProductName.Text;
            chProductWarehouse.Text = lblWarehouse.Text;
            chProductUnit.Text = lblProductUnit.Text;
            chProductQuantity.Text = lblProductQuantity.Text;
            chProductPrice.Text = lblProductPrice.Text;
            chProductTotalPrice.Text = frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo );
            chProductTotalLocalPrice.Text = chProductTotalPrice.Text + " (" + frmMain.setting.localExchange + ")";
            lblProductListNote.Text = frmMain.resMan.GetString( "lblProductListNote", frmMain.culInfo );
            lblProductLocalPriceNote.Text = frmMain.resMan.GetString( "lblProductLocalPriceNote", frmMain.culInfo );
            lblGrandTotalPrice.Text = frmMain.resMan.GetString( "lblGrandTotalPrice", frmMain.culInfo );

            btnStockCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnStockSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
        }

        private void frmStockFlowOut_FormClosing( object sender, FormClosingEventArgs e ) {
            if( e.CloseReason == CloseReason.UserClosing ) {
                if( stockFlowID != string.Empty ) {
                    this.dbCommand.Transaction.Rollback();
                }
            }
        }

        private void cbStockProductID_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbStockProductID.SelectedIndex == -1 ) {
                tbStockProductUnit.Text = "";
            } else {
                tbStockProductUnit.Text = frmMain.resMan.GetString( "unit" + ( (ProductItem)cbStockProductID.Items[ cbStockProductID.SelectedIndex ] ).ProductUnit, frmMain.culInfo );
            }
        }

        private void btnProductAdd_Click( object sender, EventArgs e ) {
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

            try {
                double dTotalLocalPrice = dQuantity * dPrice * er.exchanges[ (string)cbStockProductCurrency.SelectedItem ].ForexSelling;
                double dTotalPrice = dTotalLocalPrice * dQuantity;

                ListViewItem lvi = new ListViewItem(
                    new string[] {
                        ( (ProductItem)cbStockProductID.SelectedItem ).ProductName,
                        ( (ProductItem)cbStockProductID.SelectedItem ).ProductID,
                        ( (WarehouseItem)cbStockProductWarehouse.SelectedItem ).WarehouseID,
                        ( (WarehouseItem)cbStockProductWarehouse.SelectedItem ).WarehouseName,
                        tbStockProductUnit.Text,
                        dQuantity.ToString( "0.000" ),
                        dPrice.ToString( "0.000" ) + " " + (string)cbStockProductCurrency.SelectedItem,
                        dTotalPrice.ToString( "0.000" ) + " " + (string)cbStockProductCurrency.SelectedItem,
                        dTotalLocalPrice.ToString( "0.000" ) + " " + frmMain.setting.localExchange
                    }
                );

                lvStockProductList.Items.Add( lvi );

                if( stockFlowID != string.Empty ) {
                    dbCommand.CommandText = "INSERT INTO stock_flow (sflow_sid, sflow_productid, sflow_warehouseid, sflow_quantity, sflow_price, sflow_priceexchange) VALUES(@sflow_sid, @sflow_productid, @sflow_warehouseid, @sflow_quantity, @sflow_price, @sflow_priceexchange)";
                    dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_sid", stockFlowID ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_productid", lvi.SubItems[ 0 ].Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_warehouseid", lvi.SubItems[ 3 ].Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_quantity", -dQuantity ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_price", dPrice ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_priceexchange", (string)cbStockProductCurrency.SelectedItem ) );

                    dbCommand.ExecuteNonQuery();
                }

                cbStockProductID.SelectedIndex = -1;
                tbStockProductUnit.Text = string.Empty;
                tbStockProductQuantity.Text = string.Empty;
                tbStockProductPrice.Text = string.Empty;
                cbStockProductCurrency.SelectedIndex = 0;

                lblStockGrandTotal.Text = calculateGrandTotal().ToString( "0.000" );

                cbStockProductID.Focus();
            } catch( Exception ex ) {
                MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) + "\r\n" + ex.Message );
            }
        }

        private void btnStockSave_Click( object sender, EventArgs e ) {
            if( cbStockCustomer.SelectedIndex != -1 ) {
                if( stockFlowID == string.Empty ) {
                    dbCommand = new SQLiteCommand() {
                        Connection = frmMain.sqlCon,
                        Transaction = frmMain.sqlCon.BeginTransaction()
                    };

                    try {
                        dbCommand.CommandText = "INSERT INTO stock (stock_type, stock_date, stock_supplier, stock_desc) VALUES(@stock_type, @stock_date, @stock_supplier, @stock_desc)";
                        dbCommand.Parameters.Add( new SQLiteParameter( "@stock_type", 2 ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@stock_date", dtpStockDate.Value ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@stock_supplier", ( (SupplierItem)cbStockCustomer.SelectedItem ).SupplierID ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@stock_desc", tbStockDesc.Text ) );

                        dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "SELECT last_insert_rowid()";
                        string stock_id = ( (long)dbCommand.ExecuteScalar() ).ToString();

                        dbCommand.CommandText = "INSERT INTO stock_flow (sflow_sid, sflow_productid, sflow_warehouseid, sflow_quantity, sflow_price, sflow_priceexchange) VALUES(@sflow_sid, @sflow_productid, @sflow_warehouseid, @sflow_quantity, @sflow_price, @sflow_priceexchange)";
                        for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                            dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_sid", stock_id ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_productid", lvStockProductList.Items[ i ].SubItems[ 0 ].Text ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_warehouseid", lvStockProductList.Items[ i ].SubItems[ 2 ].Text ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_quantity", -Convert.ToDouble( lvStockProductList.Items[ i ].SubItems[ 5 ].Text ) ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_price", Convert.ToDouble( lvStockProductList.Items[ i ].SubItems[ 7 ].Text.Substring( 0, lvStockProductList.Items[ i ].SubItems[ 7 ].Text.IndexOf( " " ) ) ) ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_priceexchange", lvStockProductList.Items[ i ].SubItems[ 7 ].Text.Substring( lvStockProductList.Items[ i ].SubItems[ 7 ].Text.IndexOf( " " ) ) ) );

                            dbCommand.ExecuteNonQuery();
                        }

                        dbCommand.Transaction.Commit();
                    } catch {
                        dbCommand.Transaction.Rollback();
                        MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );

                        return;
                    }
                } else {
                    string SQL = string.Empty;
                    for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                        if( lvStockProductList.Items[ i ].Checked == true ) {
                            SQL += lvStockProductList.Items[ i ].SubItems[ 1 ].Text + ",";
                        }
                    }

                    if( SQL.Length > 0 ) {
                        dbCommand.CommandText = "DELETE FROM stock_flow WHERE sflow_id IN(@sflow_id) AND sflow_sid = @sflow_sid";
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_id", SQL.Substring( 0, SQL.Length - 1 ) ) );
                        dbCommand.Parameters.Add( new SQLiteParameter( "@sflow_sid", stockFlowID ) );

                        dbCommand.ExecuteNonQuery();
                    }

                    dbCommand.CommandText = "UPDATE stock SET stock_date = @stock_date, stock_supplier = @stock_supplier, stock_desc = @stock_desc WHERE stock_id = @stock_id";
                    dbCommand.Parameters.Add( new SQLiteParameter( "@stock_id", stockFlowID ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@stock_date", dtpStockDate.Value ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@stock_supplier", ( (SupplierItem)cbStockCustomer.SelectedItem ).SupplierID ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@stock_desc", tbStockDesc.Text ) );

                    dbCommand.ExecuteNonQuery();
                    dbCommand.Transaction.Commit();
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void tbCheckForNumeric_KeyPress( object sender, KeyPressEventArgs e ) {
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

        private void btnStockCancel_Click( object sender, EventArgs e ) {
            if( stockFlowID != string.Empty ) {
                dbCommand.Transaction.Rollback();
            }

            DialogResult = DialogResult.Cancel;
        }

        private double calculateGrandTotal( bool ischecked = false ) {
            double d = 0;

            try {
                for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                    if( ischecked == false || lvStockProductList.Items[ i ].Checked == false ) {
                        d += Convert.ToDouble( lvStockProductList.Items[ i ].SubItems[ 8 ].Text.Substring( 0, lvStockProductList.Items[ i ].SubItems[ 8 ].Text.IndexOf( " " ) ) );
                    }
                }
            } catch {
                return 0.0;
            }

            return d;
        }

        private void LvStockProductList_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e ) {
            frmMain.listView_DrawColumnHeader( sender, e );
        }

        private void LvStockProductList_MouseMove( object sender, MouseEventArgs e ) {
            frmMain.listView_MouseMove( sender, e );
        }

        private void LvStockProductList_DrawItem( object sender, DrawListViewItemEventArgs e ) {
            frmMain.listView_DrawItem( sender, e );
        }
    }
}