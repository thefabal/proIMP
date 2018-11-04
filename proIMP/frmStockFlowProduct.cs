﻿using System;
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
        public string strStockID = string.Empty;
        public string strStockFlowID = string.Empty;
        public string strStockType = string.Empty;

        public frmStockFlowProduct() {
            InitializeComponent();
        }

        private void frmStockFlowProduct_Load( object sender, EventArgs e ) {
            getWarehouseList();
            getProductList();

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
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT t1.sflow_id, t3.stock_type, t1.sflow_productid, t2.product_name, t2.product_unit, t4.warehouse_id, t4.warehouse_name, ABS(t1.sflow_quantity) AS sflow_quantity, t1.sflow_price FROM stock_flow AS t1 LEFT JOIN product AS t2 ON t1.sflow_productid = t2.product_id LEFT JOIN stock AS t3 ON t1.sflow_sid = t3.stock_id LEFT JOIN warehouse AS t4 ON t1.sflow_warehouseid = t4.warehouse_id WHERE t1.sflow_id = '" + strStockFlowID + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                if( dbReader.Read() ) {
                    tbStockProductUnit.Text = dbReader[ "product_unit" ].ToString();
                    tbStockProductQuantity.Text = dbReader[ "sflow_quantity" ].ToString();
                    tbStockProductPrice.Text = dbReader[ "sflow_price" ].ToString();

                    cbStockProductID.SelectedIndex = cbStockProductID.FindStringExact( dbReader[ "product_name" ].ToString() );
                    cbStockProductWarehouse.SelectedIndex = cbStockProductWarehouse.FindStringExact( dbReader[ "warehouse_name" ].ToString() );

                    strStockType = dbReader[ "stock_type" ].ToString();
                }
                dbReader.Close();
            }
        }

        private void cbStockProductID_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbStockProductID.SelectedIndex == -1 ) {
                tbStockProductUnit.Text = "";
            } else {
                tbStockProductUnit.Text = ( (ProductItem)cbStockProductID.Items[ cbStockProductID.SelectedIndex ] ).ProductUnit;
            }
        }

        private void tbStockProductQuantity_KeyPress( object sender, KeyPressEventArgs e ) {
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

        private void btnSave_Click( object sender, EventArgs e ) {
            if( cbStockProductID.SelectedIndex != -1 ) {
                if( tbStockProductQuantity.Text != string.Empty && tbStockProductPrice.Text != string.Empty ) {
                    double dQuantity = Convert.ToDouble( tbStockProductQuantity.Text );
                    double dPrice = Convert.ToDouble( tbStockProductPrice.Text );

                    if( strStockType == "2" ) {
                        dQuantity *= -1;
                    }

                    if( strStockFlowID == string.Empty && strStockID != string.Empty ) {
                        try {
                            SQLiteCommand dbCommand = new SQLiteCommand("INSERT INTO stock_flow (sflow_id, sflow_sid, sflow_productid, sflow_warehouseid, sflow_quantity, sflow_price) VALUES(NULL, '" + strStockID + "', '" + ( (ProductItem)cbStockProductID.Items[ cbStockProductID.SelectedIndex ] ).ProductID + "', '" + ( (WarehouseItem)cbStockProductWarehouse.Items[ cbStockProductWarehouse.SelectedIndex ] ).WarehouseID + "', '" + dQuantity.ToString("0.000") + "', '" + dPrice.ToString("0.000") + "')", frmMain.sqlCon);
                            dbCommand.ExecuteNonQuery();
                        } catch {
                            MessageBox.Show( "Could not save product in stock movement. Please try again." );

                            return;
                        }
                    } else if( strStockFlowID != string.Empty ) {
                        try {
                            SQLiteCommand dbCommand = new SQLiteCommand("UPDATE stock_flow SET sflow_productid = '" +  ( (ProductItem)cbStockProductID.Items[ cbStockProductID.SelectedIndex ] ).ProductID + "', sflow_warehouseid = '" + ( (WarehouseItem)cbStockProductWarehouse.Items[ cbStockProductWarehouse.SelectedIndex ] ).WarehouseID + "', sflow_quantity = '" + dQuantity.ToString("0.000") + "', sflow_price = '" + dPrice.ToString("0.000") + "' WHERE sflow_id = '" + strStockFlowID + "'", frmMain.sqlCon );
                            dbCommand.ExecuteNonQuery();
                        } catch {
                            MessageBox.Show( "Could not save product in stock movement. Please try again." );

                            return;
                        }
                    } else {
                        return;
                    }
                } else {
                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCategoryAdd_Click( object sender, EventArgs e ) {
            frmMain.product.strProductID = string.Empty;
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
    }
}
