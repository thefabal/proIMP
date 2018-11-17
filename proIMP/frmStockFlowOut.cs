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
        public string strStockFlowID = string.Empty;

        private SQLiteCommand dbCommand = new SQLiteCommand();

        public frmStockFlowOut( frmMain frmMain ) {
            this.frmMain = frmMain;
            InitializeComponent();
        }

        private void frmStockFlowOut_Load( object sender, EventArgs e ) {
            switchLanguage();

            getCustomerList();
            getProductList();
            getWarehouseList();

            tbStockProductUnit.Text = string.Empty;
            tbStockProductQuantity.Text = string.Empty;
            tbStockProductPrice.Text = string.Empty;

            if( strStockFlowID == string.Empty ) {
                lvStockProductList.CheckBoxes = false;
                lblProductListNote.Visible = false;

                dtpStockDate.Value = DateTime.Now;
                tbStockDesc.Text = string.Empty;
                tbStockGrandTotal.Text = string.Empty;

                lvStockProductList.Items.Clear();
            } else {
                lvStockProductList.CheckBoxes = true;
                lblProductListNote.Visible = true;

                SQLiteCommand dbCommand = new SQLiteCommand() {
                    Connection = frmMain.sqlCon
                };

                dbCommand.CommandText = "SELECT t1.stock_id, t1.stock_type, t1.stock_date, t1.stock_supplier, t2.customer_name, t1.stock_desc FROM stock AS t1 LEFT JOIN customer AS t2 ON t1.stock_supplier = t2.customer_id WHERE t1.stock_id = '" + strStockFlowID + "'";
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                if( dbReader.Read() ) {
                    tbStockDesc.Text = dbReader[ "stock_desc" ].ToString();

                    dtpStockDate.Value = (DateTime)dbReader[ "stock_date" ];

                    cbStockCustomer.SelectedIndex = cbStockCustomer.FindStringExact( dbReader[ "customer_name" ].ToString() );

                    dbReader.Close();
                    dbCommand.CommandText = "SELECT t1.sflow_id, t2.product_name, t3.warehouse_id, t3.warehouse_name, t2.product_unit, ABS(t1.sflow_quantity) AS sflow_quantity, t1.sflow_price FROM stock_flow AS t1 LEFT JOIN product AS t2 ON t1.sflow_productid = t2.product_id LEFT JOIN warehouse AS t3 ON t1.sflow_warehouseid = t3.warehouse_id WHERE t1.sflow_sid = '" + strStockFlowID + "' ORDER BY t2.product_name";
                    dbReader = dbCommand.ExecuteReader();

                    double dQuantity = 0;
                    double dPrice = 0;
                    double dTotalPrice = 0;
                    double dGrandPrice = 0;
                    lvStockProductList.Items.Clear();
                    while( dbReader.Read() ) {
                        dQuantity = Convert.ToDouble( dbReader[ "sflow_quantity" ].ToString() );
                        dPrice = Convert.ToDouble( dbReader[ "sflow_price" ].ToString() );
                        dTotalPrice = dQuantity * dPrice;
                        dGrandPrice += dTotalPrice;

                        ListViewItem lvi = new ListViewItem(new string[] { dbReader[ "sflow_id" ].ToString(), dbReader[ "product_name" ].ToString(), dbReader[ "warehouse_id" ].ToString(), dbReader[ "warehouse_name" ].ToString(), frmMain.resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), frmMain.culInfo ), dQuantity.ToString("0.000"), dPrice.ToString("0.000"), dTotalPrice.ToString( "0.000" ) });

                        lvStockProductList.Items.Add( lvi );
                    }
                    dbReader.Close();
                    tbStockGrandTotal.Text = dGrandPrice.ToString( "0.000" );

                    this.dbCommand.Connection = frmMain.sqlCon;
                    this.dbCommand.Transaction = frmMain.sqlCon.BeginTransaction();
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
            lblProductPrice.Text = frmMain.resMan.GetString( "lblProductPrice", frmMain.culInfo );
            btnProductAdd.Text = frmMain.resMan.GetString( "btnAdd", frmMain.culInfo );
            chProductName.Text = lblProductName.Text;
            chProductWarehouse.Text = lblWarehouse.Text;
            chProductUnit.Text = lblProductUnit.Text;
            chProductQuantity.Text = lblProductQuantity.Text;
            chProductPrice.Text = lblProductPrice.Text;
            chProductTotalPrice.Text = frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo );
            lblProductListNote.Text = frmMain.resMan.GetString( "lblProductListNote", frmMain.culInfo );
            lblGrandTotalPrice.Text = frmMain.resMan.GetString( "lblGrandTotalPrice", frmMain.culInfo );

            btnStockCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );
            btnStockSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
        }

        private void frmStockFlowOut_FormClosing( object sender, FormClosingEventArgs e ) {
            if( e.CloseReason == CloseReason.UserClosing ) {
                if( strStockFlowID != string.Empty ) {
                    this.dbCommand.Transaction.Rollback();
                }
            }
        }

        private void cbStockProductID_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbStockProductID.SelectedIndex == -1 ) {
                tbStockProductUnit.Text = "";
            } else {
                tbStockProductUnit.Text = ( (ProductItem)cbStockProductID.Items[ cbStockProductID.SelectedIndex ] ).ProductUnit;
            }
        }

        private void btnProductAdd_Click( object sender, EventArgs e ) {
            double dQuantity = 0;
            double dPrice = 0;

            try {
                dQuantity = Convert.ToDouble( tbStockProductQuantity.Text );
            } catch {
                MessageBox.Show( frmMain.resMan.GetString( "errorOnProductQuantity", frmMain.culInfo ) );

                tbStockProductQuantity.Focus();

                return;
            }

            try {
                dPrice = Convert.ToDouble( tbStockProductPrice.Text );
            } catch {
                MessageBox.Show( frmMain.resMan.GetString( "errorOnProductPrice", frmMain.culInfo ) );

                tbStockProductPrice.Focus();

                return;
            }

            try {
                double dTotalPrice = dQuantity * dPrice;

                ListViewItem lvi = new ListViewItem(
                    new string[] {
                        ( (ProductItem)cbStockProductID.Items[ cbStockProductID.SelectedIndex ] ).ProductID,
                        ( (ProductItem)cbStockProductID.Items[ cbStockProductID.SelectedIndex ] ).ProductName,
                        ( (WarehouseItem)cbStockProductWarehouse.Items[ cbStockProductWarehouse.SelectedIndex ] ).WarehouseID,
                        ( (WarehouseItem)cbStockProductWarehouse.Items[ cbStockProductWarehouse.SelectedIndex ] ).WarehouseName,
                        tbStockProductUnit.Text,
                        dQuantity.ToString( "0.000" ),
                        dPrice.ToString( "0.000" ),
                        dTotalPrice.ToString( "0.000" )
                    }
                );

                lvStockProductList.Items.Add( lvi );

                if( strStockFlowID != string.Empty ) {
                    this.dbCommand.CommandText = "INSERT INTO stock_flow (sflow_id, sflow_sid, sflow_productid, sflow_warehouseid, sflow_quantity, sflow_price) VALUES(NULL, '" + strStockFlowID + "', '" + lvi.SubItems[ 0 ].Text + "', '" + lvi.SubItems[ 2 ].Text + "', '-" + lvi.SubItems[ 4 ].Text + "', '" + lvi.SubItems[ 5 ].Text + "')";
                    this.dbCommand.ExecuteNonQuery();
                }

                cbStockProductID.SelectedIndex = -1;
                tbStockProductUnit.Text = string.Empty;
                tbStockProductQuantity.Text = string.Empty;
                tbStockProductPrice.Text = string.Empty;

                tbStockGrandTotal.Text = calculateGrandTotal().ToString( "0.000" );

                cbStockProductID.Focus();
            } catch {
                MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );
            }
        }

        private void btnStockSave_Click( object sender, EventArgs e ) {
            if( cbStockCustomer.SelectedIndex != -1 ) {
                if( strStockFlowID == string.Empty ) {
                    SQLiteCommand dbCommand = new SQLiteCommand() {
                        Connection = frmMain.sqlCon,
                        Transaction = frmMain.sqlCon.BeginTransaction()
                    };

                    try {
                        dbCommand.CommandText = "INSERT INTO stock (stock_id, stock_type, stock_date, stock_supplier, stock_desc) VALUES(NULL, 2, '" + dtpStockDate.Value.ToString( "yyyy-MM-dd" ) + "', '" + ( (SupplierItem)cbStockCustomer.SelectedItem ).SupplierID + "', '" + tbStockDesc.Text.Replace( "'", "''" ) + "')";
                        dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "SELECT last_insert_rowid()";
                        string strStockID = ( (long)dbCommand.ExecuteScalar() ).ToString();

                        for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                            dbCommand.CommandText = "INSERT INTO stock_flow (sflow_id, sflow_sid, sflow_productid, sflow_warehouseid, sflow_quantity, sflow_price) VALUES(NULL, '" + strStockID + "', '" + lvStockProductList.Items[ i ].SubItems[ 0 ].Text + "', '" + lvStockProductList.Items[ i ].SubItems[ 2 ].Text + "', '-" + lvStockProductList.Items[ i ].SubItems[ 5 ].Text + "', '" + lvStockProductList.Items[ i ].SubItems[ 6 ].Text + "')";
                            dbCommand.ExecuteNonQuery();
                        }

                        dbCommand.Transaction.Commit();
                    } catch {
                        dbCommand.Transaction.Rollback();
                        MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );

                        return;
                    }
                } else {
                    string strSQL = string.Empty;
                    for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                        if( lvStockProductList.Items[ i ].Checked == true ) {
                            strSQL += lvStockProductList.Items[ i ].SubItems[ 1 ].Text + ",";
                        }
                    }

                    if( strSQL.Length > 0 ) {
                        dbCommand.CommandText = "DELETE FROM stock_flow WHERE sflow_id IN(" + strSQL.Substring( 0, strSQL.Length - 1 ) + ") AND sflow_sid = '" + strStockFlowID + "'";
                        dbCommand.ExecuteNonQuery();
                    }

                    dbCommand.CommandText = "UPDATE stock SET stock_date = '" + dtpStockDate.Value.ToString( "yyyy-MM-dd" ) + "', stock_supplier = '" + ( (SupplierItem)cbStockCustomer.SelectedItem ).SupplierID + "', stock_desc = '" + tbStockDesc.Text.Replace( "'", "''" ) + "' WHERE stock_id = '" + strStockFlowID + "'";
                    dbCommand.ExecuteNonQuery();

                    dbCommand.Transaction.Commit();
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void tbCheckForNumeric_KeyPress( object sender, KeyPressEventArgs e ) {
            if( (int)e.KeyChar < 48 || (int)e.KeyChar > 57 ) {
                if( e.KeyChar == frmMain.chrThousndSep ) {
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
            if( strStockFlowID != string.Empty ) {
                dbCommand.Transaction.Rollback();
            }

            DialogResult = DialogResult.Cancel;
        }

        private void getCustomerList() {
            try {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT customer_id, customer_name FROM customer ORDER BY customer_name", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbStockCustomer.Items.Clear();
                while( dbReader.Read() ) {
                    cbStockCustomer.Items.Add( new SupplierItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
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

                cbStockProductWarehouse.SelectedIndex = 0;
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

        private double calculateGrandTotal( bool ischecked = false ) {
            double d = 0;

            try {
                for( int i = 0; i < lvStockProductList.Items.Count; i++ ) {
                    if( ischecked == false || lvStockProductList.Items[ i ].Checked == false ) {
                        d += Convert.ToDouble( lvStockProductList.Items[ i ].SubItems[ 7 ].Text );
                    }
                }
            } catch {
                return 0.0;
            }

            return d;
        }
    }
}
