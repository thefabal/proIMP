using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace proIMP {
    public partial class frmChildReports : Form {
        public Panel activePanel = null;

        public frmChildReports() {
            InitializeComponent();
            switchLanguage();

            pnlReport_1.BringToFront();
        }

        #region reportProductFlow
        public bool reportProductFlow() {
            dtReport_1To.Value = DateTime.Now;
            dtReport_1From.Value = DateTime.Now.AddYears( -1 );

            SQLiteCommand dbCommand =  database.sqlCon.CreateCommand();
            
            dbCommand.CommandText = "SELECT category_id, category_name FROM category ORDER BY category_name";
            try {
                cbReport_1Category.Items.Clear();
                cbReport_1Category.Items.Add( new CategoryItem( "-1", frmMain.resMan.GetString( "AllCategories", frmMain.culInfo ) ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_1Category.Items.Add( new CategoryItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();

                cbReport_1Category.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            dbCommand.CommandText = "SELECT supplier_id, supplier_name FROM supplier ORDER BY supplier_name";
            try {
                cbReport_1Supplier.Items.Clear();
                cbReport_1Supplier.Items.Add( new SupplierItem( "-1", frmMain.resMan.GetString( "AllSuppliers", frmMain.culInfo ) ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_1Supplier.Items.Add( new SupplierItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();

                cbReport_1Supplier.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            dbCommand.CommandText = "SELECT customer_id, customer_name FROM customer ORDER BY customer_name";
            try {
                cbReport_1Customer.Items.Clear();
                cbReport_1Customer.Items.Add( new SupplierItem( "-1", frmMain.resMan.GetString( "AllCustomers", frmMain.culInfo ) ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_1Customer.Items.Add( new SupplierItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();

                cbReport_1Customer.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            dbCommand.CommandText = "SELECT product_id, product_name, product_unit FROM product ORDER BY product_name";
            try {
                cbReport_1Product.Items.Clear();
                cbReport_1Product.Items.Add( new ProductItem( "-1", frmMain.resMan.GetString( "AllProducts", frmMain.culInfo ), frmMain.resMan.GetString( "unitP", frmMain.culInfo ) ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_1Product.Items.Add( new ProductItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString(), frmMain.resMan.GetString( "unit" + dbReader[ 2 ].ToString(), frmMain.culInfo ) ) );
                }
                dbReader.Close();

                cbReport_1Product.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            activePanel = pnlReport_1;
            pnlReport_1.BringToFront();

            return true;
        }

        private void btnReport_1Run_Click( object sender, EventArgs e ) {
            // btnReport_1Run_Click( sender, e );
            string strSQL = string.Empty;

            strSQL += "SELECT sflow_id, stock_date, supplier_name, product_id, product_catid, product_name, product_unit, sflow_quantity, sflow_price, sflow_exchange, total_price, total_price * forex_selling AS total_localprice FROM report_product_flow WHERE";

            /* DateTime filter */
            strSQL += " stock_date BETWEEN '" + dtReport_1From.Value.ToString( "yyyy-MM-dd" ) + "' AND '" + dtReport_1To.Value.ToString( "yyyy-MM-dd" ) + "'";

            /* Product category filter */
            if( cbReport_1Category.SelectedIndex > 0 ) {
                strSQL += " AND product_catid = " + ( ( CategoryItem )cbReport_1Category.SelectedItem ).CategoryID;
            }

            /* Product filter */
            if( cbReport_1Product.SelectedIndex > 0 ) {
                strSQL += " AND product_id = " + ( ( ProductItem )cbReport_1Product.SelectedItem ).ProductID;
            }

            /* Supplier filter */
            if( cbReport_1Supplier.SelectedIndex > 0 ) {
                strSQL += " AND stock_type = 1 AND supplier_id = " + ( ( SupplierItem )cbReport_1Supplier.SelectedItem ).SupplierID;
            }

            /* Customer filter */
            if( cbReport_1Customer.SelectedIndex > 0 ) {
                strSQL += " AND stock_type = 2 AND supplier_id = " + ( ( SupplierItem )cbReport_1Customer.SelectedItem ).SupplierID;
            }

            /* Stock flow out filter */
            if( cbReport_1FlowIn.Checked == true && cbReport_1FlowOut.Checked == false ) {
                strSQL += " AND stock_type = 1";
            }

            /* Stock flow in filter */
            if( cbReport_1FlowIn.Checked == false && cbReport_1FlowOut.Checked == true ) {
                strSQL += " AND stock_type = 2";
            }

            strSQL += " ORDER BY stock_date DESC";

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = strSQL;

            try {
                lvReport_1.Items.Clear();

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    string currency = ( dbReader[ "sflow_exchange" ].GetType() != typeof( DBNull ) ) ?( dbReader[ "sflow_exchange" ].ToString() ) :( "" );

                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        dbReader[ "sflow_id" ].ToString(),
                        dbReader[ "stock_date" ].ToString().Substring(0, 10),
                        dbReader[ "supplier_name" ].ToString(),
                        dbReader[ "product_name" ].ToString(),
                        frmMain.resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), frmMain.culInfo ),
                        ( dbReader[ "sflow_quantity" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "sflow_quantity" ].ToString() ).ToString( "0.000" ) ) :( "" ),
                        ( dbReader[ "sflow_price" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "sflow_price" ].ToString() ).ToString( "0.00000" ) + " " + currency ) :( "" ),
                        ( dbReader[ "total_price" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "total_price" ].ToString() ).ToString( "0.000" ) + " " + currency ) :( "" ),
                        ( dbReader[ "total_localprice" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "total_localprice" ].ToString() ).ToString( "0.000" ) + " " + frmMain.setting.localExchange ) :( "" )
                    } );

                    lvReport_1.Items.Add( lvi );
                }
            } catch {
                MessageBox.Show( frmMain.resMan.GetString( "unknownError", frmMain.culInfo ) );
            }
        }

        private void cbReport_1Category_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbReport_1Category.SelectedIndex != 0 ) {
                cbReport_1Product.SelectedIndex = 0;
            }
        }

        private void cbReport_1Product_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbReport_1Product.SelectedIndex != 0 ) {
                cbReport_1Category.SelectedIndex = 0;
            }
        }

        private void cbReport_1FlowIn_CheckedChanged( object sender, EventArgs e ) {
            if( cbReport_1FlowOut.Checked == true ) {
                cbReport_1FlowIn.Checked = false;
                cbReport_1FlowOut.Checked = false;
            }

            if( cbReport_1FlowIn.Checked == true ) {
                cbReport_1Customer.SelectedIndex = 0;
            }
        }

        private void cbReport_1FlowOut_CheckedChanged( object sender, EventArgs e ) {
            if( cbReport_1FlowIn.Checked == true ) {
                cbReport_1FlowIn.Checked = false;
                cbReport_1FlowOut.Checked = false;
            }

            if( cbReport_1FlowOut.Checked == true ) {
                cbReport_1Supplier.SelectedIndex = 0;
            }
        }

        private void btnReport_1Export_Click( object sender, EventArgs e ) {
            if( lvReport_1.Items.Count == 0 ) {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel File|*.xlsx",
                FileName = "ProductFlowReport_" + DateTime.Now.ToString( "yyyyMMdd" ) + ".xlsx"
            };

            string reportFile;
            if( sfd.ShowDialog() == DialogResult.OK ) {
                reportFile = sfd.FileName;
            } else {
                return;
            }

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage ExcelFile = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelFile.Workbook.Worksheets.Add( "Sheet1" );

            string[ ] strHeader = { frmMain.resMan.GetString( "lblReportDate", frmMain.culInfo ), frmMain.resMan.GetString( "chReport_1Supplier", frmMain.culInfo ), frmMain.resMan.GetString( "plProductName", frmMain.culInfo ), frmMain.resMan.GetString( "stockProductUnit", frmMain.culInfo ), frmMain.resMan.GetString( "stockProductQuantity", frmMain.culInfo ), frmMain.resMan.GetString( "plProductPrice", frmMain.culInfo ), frmMain.resMan.GetString( "lblProductCurrency", frmMain.culInfo ), frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo ), frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo ) + "( " + frmMain.setting.localExchange + " )" };
            int[ ] iColumnWidth = { 75, 150, 300, 64, 70, 70, 70, 70, 70 };

            for( int i = 0; i < strHeader.Length; i++ ) {
                worksheet.Column( i + 1 ).Width = 1.0 * iColumnWidth[ i ] / 7;

                worksheet.Cells[ 1, i + 1 ].Value = strHeader[ i ];
            }

            ExcelRange er;
            er = worksheet.Cells[ "A1:I1" ];
            er.Style.Border.Top.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Left.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Right.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

            worksheet.Row( 1 ).Height = 30;
            worksheet.Row( 1 ).Style.Font.Bold = true;
            worksheet.Row( 1 ).Style.WrapText = true;
            worksheet.Row( 1 ).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Row( 1 ).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            double dTotalPrice = 0;

            for( int i = 0; i < lvReport_1.Items.Count; i++ ) {
                worksheet.Cells[ i + 2, 1 ].Value = Convert.ToDateTime( lvReport_1.Items[ i ].SubItems[ 1 ].Text );
                worksheet.Cells[ i + 2, 1 ].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;

                worksheet.Cells[ i + 2, 2 ].Value = lvReport_1.Items[ i ].SubItems[ 2 ].Text;
                worksheet.Cells[ i + 2, 3 ].Value = lvReport_1.Items[ i ].SubItems[ 3 ].Text;
                worksheet.Cells[ i + 2, 4 ].Value = lvReport_1.Items[ i ].SubItems[ 4 ].Text;

                worksheet.Cells[ i + 2, 5 ].Value = Convert.ToDouble( lvReport_1.Items[ i ].SubItems[ 5 ].Text );
                worksheet.Cells[ i + 2, 6 ].Value = Convert.ToDouble( lvReport_1.Items[ i ].SubItems[ 6 ].Text.Substring( 0, lvReport_1.Items[ i ].SubItems[ 6 ].Text.IndexOf( " " ) ) );
                worksheet.Cells[ i + 2, 7 ].Value = lvReport_1.Items[ i ].SubItems[ 7 ].Text.Substring( lvReport_1.Items[ i ].SubItems[ 7 ].Text.IndexOf( " " ) + 1 );
                worksheet.Cells[ i + 2, 8 ].Value = Convert.ToDouble( lvReport_1.Items[ i ].SubItems[ 7 ].Text.Substring( 0, lvReport_1.Items[ i ].SubItems[ 7 ].Text.IndexOf( " " ) ) );
                worksheet.Cells[ i + 2, 9 ].Value = Convert.ToDouble( lvReport_1.Items[ i ].SubItems[ 8 ].Text.Substring( 0, lvReport_1.Items[ i ].SubItems[ 8 ].Text.IndexOf( " " ) ) );

                dTotalPrice += ( double )worksheet.Cells[ i + 2, 9 ].Value;
            }

            er = worksheet.Cells[ "A2:I" + ( lvReport_1.Items.Count + 1 ) ];
            er.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            worksheet.Cells[ "E2:F" + ( lvReport_1.Items.Count + 1 ) ].Style.Numberformat.Format = "#,##0.000";
            worksheet.Cells[ "H2:I" + ( lvReport_1.Items.Count + 1 ) ].Style.Numberformat.Format = "#,##0.000";

            worksheet.Cells[ "G" + ( lvReport_1.Items.Count + 2 ) + ":H" + ( lvReport_1.Items.Count + 2 ) ].Merge = true;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 7 ].Value = frmMain.resMan.GetString( "lblGrandTotalPrice", frmMain.culInfo ) + " : ";
            worksheet.Cells[ lvReport_1.Items.Count + 2, 7 ].Style.Font.Bold = true;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 7 ].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 9 ].Value = dTotalPrice;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 9 ].Style.Font.Bold = true;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 9 ].Style.Numberformat.Format = "#,##0.000";

            ExcelFile.Workbook.Properties.Title = "Invertory";
            ExcelFile.Workbook.Properties.Author = "Fatih \"fabal\" BALCI";
            ExcelFile.Workbook.Properties.Comments = "proIMP report with EPlus";
            ExcelFile.Workbook.Properties.Company = "proGEDIA";

            ExcelFile.Compression = CompressionLevel.BestCompression;
            ExcelFile.SaveAs( new FileInfo( reportFile ) );

            if( cbReport_1OpenReport.Checked == true ) {
                System.Diagnostics.Process.Start( reportFile );
            } else {
                MessageBox.Show( frmMain.resMan.GetString( "reportExported", frmMain.culInfo ) );
            }
        }
        #endregion

        #region reportProductCount
        public bool reportProductCount() {
            dtReport_2To.Value = DateTime.Now;
            dtReport_2From.Value = DateTime.Now.AddYears( -1 );

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();

            dbCommand.CommandText = "SELECT category_id, category_name FROM category ORDER BY category_name";
            try {
                cbReport_2Category.Items.Clear();
                cbReport_2Category.Items.Add( new CategoryItem( "-1", frmMain.resMan.GetString( "AllCategories", frmMain.culInfo ) ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_2Category.Items.Add( new CategoryItem( dbReader.GetInt64( 0 ).ToString(), dbReader.GetString( 1 ) ) );
                }
                dbReader.Close();

                cbReport_2Category.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            dbCommand.CommandText = "SELECT product_id, product_name, product_unit FROM product ORDER BY product_name";
            try {
                cbReport_2Product.Items.Clear();
                cbReport_2Product.Items.Add( new ProductItem( "-1", frmMain.resMan.GetString( "AllProducts", frmMain.culInfo ), frmMain.resMan.GetString( "unitP", frmMain.culInfo ) ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_2Product.Items.Add( new ProductItem( dbReader.GetInt64( 0 ).ToString(), dbReader.GetString( 1 ), frmMain.resMan.GetString( "unit" + dbReader[ 2 ].ToString(), frmMain.culInfo ) ) );
                }
                dbReader.Close();

                cbReport_2Product.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            dbCommand.CommandText = "SELECT warehouse_id, warehouse_name FROM warehouse ORDER BY warehouse_name";
            try {
                cbReport_2Warehouse.Items.Clear();
                cbReport_2Warehouse.Items.Add( new WarehouseItem( "-1", frmMain.resMan.GetString( "allWarehouses", frmMain.culInfo ) ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_2Warehouse.Items.Add( new WarehouseItem( dbReader.GetInt64( 0 ).ToString(), dbReader.GetString( 1 ) ) );
                }
                dbReader.Close();

                cbReport_2Warehouse.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            activePanel = pnlReport_2;
            pnlReport_2.BringToFront();

            return true;
        }

        private void btnReport_2Run_Click( object sender, EventArgs e ) {
            string SQL = string.Empty;

            SQL += "SELECT product_name, category_name, product_unit, SUM(product_quantity_in) AS product_quantity_in, SUM(product_quantity_out) AS product_quantity_out, SUM(product_quantity_in + product_quantity_out)  AS product_quantity_total FROM report_product_count";

            /* DateTime filter */
            SQL += " WHERE stock_date BETWEEN '" + dtReport_2From.Value.ToString( "yyyy-MM-dd" ) + "' AND '" + dtReport_2To.Value.ToString( "yyyy-MM-dd" ) + "'";

            /* Product category filter */
            if( cbReport_2Category.SelectedIndex > 0 ) {
                SQL += " AND category_id = " + ( ( CategoryItem )cbReport_2Category.SelectedItem ).CategoryID;
            }

            /* Product filter */
            if( cbReport_2Product.SelectedIndex > 0 ) {
                SQL += " AND product_id = " + ( ( ProductItem )cbReport_2Product.SelectedItem ).ProductID;
            }

            /* Product warehouse filter */
            if( cbReport_2Warehouse.SelectedIndex > 0 ) {
                SQL += " AND warehouse_id = " + ( ( WarehouseItem )cbReport_2Warehouse.SelectedItem ).WarehouseID;
            }

            SQL += " GROUP BY product_id, product_name, product_unit, category_name";
            SQL += " ORDER BY ";

            if( frmMain.setting.productOrder == 0 ) {
                SQL += "product_name, category_name";
            } else {
                SQL += "category_name, product_name";
            }

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = SQL;

            try {
                lvReport_2.Items.Clear();

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        dbReader.GetString( 0 ),
                        dbReader.GetString( 1 ),
                        frmMain.resMan.GetString( "unit" + dbReader.GetString(2), frmMain.culInfo ),
                        dbReader.GetFloat( 3 ).ToString(),
                        dbReader.GetFloat( 4 ).ToString(),
                        dbReader.GetFloat( 5 ).ToString()
                    } );

                    lvReport_2.Items.Add( lvi );
                }
                dbReader.Close();

            } catch( Exception ex ) {
                MessageBox.Show( "An unknown error occured.\r\n\r\n" + ex.Message );
            }            
        }

        private void cbReport_2Category_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbReport_2Category.SelectedIndex != 0 ) {
                cbReport_2Product.SelectedIndex = 0;
            }
        }

        private void cbReport_2Product_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cbReport_2Product.SelectedIndex != 0 ) {
                cbReport_2Category.SelectedIndex = 0;
            }
        }

        private void btnReport_2Export_Click( object sender, EventArgs e ) {
            if( lvReport_2.Items.Count == 0 ) {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel File|*.xlsx",
                FileName = "ProductStockReport_" + DateTime.Now.ToString( "yyyyMMdd" ) + ".xlsx"
            };


            string reportFile;
            if( sfd.ShowDialog() == DialogResult.OK ) {
                reportFile = sfd.FileName;
            } else {
                return;
            }

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage ExcelFile = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelFile.Workbook.Worksheets.Add( "Sheet1" );

            string[ ] strHeader = { frmMain.resMan.GetString( "plProductName", frmMain.culInfo ), frmMain.resMan.GetString( "plProductCategory", frmMain.culInfo ), frmMain.resMan.GetString( "stockProductUnit", frmMain.culInfo ), frmMain.resMan.GetString( "btnStockIn", frmMain.culInfo ), frmMain.resMan.GetString( "btnStockOut", frmMain.culInfo ), frmMain.resMan.GetString( "chReport_2TotalStock", frmMain.culInfo ) };
            int[ ] iColumnWidth = { 300, 150, 64, 70, 70, 70 };

            for( int i = 0; i < strHeader.Length; i++ ) {
                worksheet.Column( i + 1 ).Width = 1.0 * iColumnWidth[ i ] / 7;

                worksheet.Cells[ 1, i + 1 ].Value = strHeader[ i ];
            }

            ExcelRange er;
            er = worksheet.Cells[ "A1:F1" ];
            er.Style.Border.Top.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Left.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Right.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

            worksheet.Row( 1 ).Height = 30;
            worksheet.Row( 1 ).Style.Font.Bold = true;
            worksheet.Row( 1 ).Style.WrapText = true;
            worksheet.Row( 1 ).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Row( 1 ).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            for( int i = 0; i < lvReport_2.Items.Count; i++ ) {
                worksheet.Cells[ i + 2, 1 ].Value = lvReport_2.Items[ i ].SubItems[ 0 ].Text;
                worksheet.Cells[ i + 2, 2 ].Value = lvReport_2.Items[ i ].SubItems[ 1 ].Text;
                worksheet.Cells[ i + 2, 3 ].Value = lvReport_2.Items[ i ].SubItems[ 2 ].Text;

                worksheet.Cells[ i + 2, 4 ].Value = Convert.ToDouble( lvReport_2.Items[ i ].SubItems[ 3 ].Text );
                worksheet.Cells[ i + 2, 5 ].Value = Convert.ToDouble( lvReport_2.Items[ i ].SubItems[ 4 ].Text );
                worksheet.Cells[ i + 2, 6 ].Value = Convert.ToDouble( lvReport_2.Items[ i ].SubItems[ 5 ].Text );
            }

            er = worksheet.Cells[ "A2:F" + ( lvReport_2.Items.Count + 1 ) ];
            er.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            worksheet.Cells[ "D2:F" + ( lvReport_2.Items.Count + 1 ) ].Style.Numberformat.Format = "#,##0.000";

            ExcelFile.Workbook.Properties.Title = "Invertory";
            ExcelFile.Workbook.Properties.Author = "Fatih \"fabal\" BALCI";
            ExcelFile.Workbook.Properties.Comments = "proIMP report with EPlus";
            ExcelFile.Workbook.Properties.Company = "proGEDIA";

            ExcelFile.Compression = CompressionLevel.BestCompression;
            ExcelFile.SaveAs( new FileInfo( reportFile ) );

            if( cbReport_2OpenReport.Checked == true ) {
                System.Diagnostics.Process.Start( reportFile );
            } else {
                MessageBox.Show( frmMain.resMan.GetString( "reportExported", frmMain.culInfo ) );
            }
        }        
        #endregion

        #region reportExchange
        public bool reportExchange() {
            dtReport_3To.Value = DateTime.Now;
            dtReport_3From.Value = DateTime.Now.AddYears( -1 );

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = "SELECT DISTINCT currency_code FROM forex_exchange ORDER BY currency_code";

            try {
                cbReport_3Currency.Items.Clear();
                cbReport_3Currency.Items.Add( frmMain.resMan.GetString( "allCurrencies", frmMain.culInfo ) );

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    cbReport_3Currency.Items.Add( dbReader.GetString( 0 ) );
                }
                dbReader.Close();

                cbReport_3Currency.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );

                return false;
            }

            activePanel = pnlReport_3;
            pnlReport_3.BringToFront();

            return true;
        }

        private void btnReport_3Run_Click( object sender, EventArgs e ) {
            string SQL = string.Empty;

            SQL += "SELECT currency_date, currency_code, forex_buying, forex_selling FROM forex_exchange WHERE currency_date BETWEEN '" + dtReport_3From.Value.ToString( "yyyy-MM-dd" ) + " 00:00:00' AND '" + dtReport_3To.Value.ToString( "yyyy-MM-dd" ) + " 00:00:00'";
            if( cbReport_3Currency.SelectedIndex > 0 ) {
                SQL += " AND currency_code = '" + ( string )cbReport_3Currency.SelectedItem + "'";
            }
            SQL += " ORDER BY currency_date DESC, currency_code";

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = SQL;

            try {
                lvReport_3.Items.Clear();

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        Convert.ToDateTime( dbReader.GetString( 0 ) ).ToString("dd.MM.yyyy"),
                        dbReader.GetString( 1 ),
                        dbReader.GetFloat( 2 ).ToString(),
                        dbReader.GetFloat( 3 ).ToString()
                    } );

                    lvReport_3.Items.Add( lvi );
                }

                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( "An unknown error occured.\r\n\r\n" + ex.Message );
            }
        }

        private void btnReport_3Export_Click( object sender, EventArgs e ) {
            if( lvReport_3.Items.Count == 0 ) {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel File|*.xlsx",
                FileName = "ExchangeRateReport_" + DateTime.Now.ToString( "yyyyMMdd" ) + ".xlsx"
            };


            string reportFile;
            if( sfd.ShowDialog() == DialogResult.OK ) {
                reportFile = sfd.FileName;
            } else {
                return;
            }

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage ExcelFile = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelFile.Workbook.Worksheets.Add( "Sheet1" );

            string[ ] strHeader = { frmMain.resMan.GetString( "lblReportDate", frmMain.culInfo ), frmMain.resMan.GetString( "lblReport_3Currency", frmMain.culInfo ), frmMain.resMan.GetString( "chReport_3ForexBuying", frmMain.culInfo ), frmMain.resMan.GetString( "chReport_3ForexSelling", frmMain.culInfo ) };
            int[ ] iColumnWidth = { 150, 70, 70, 70 };

            for( int i = 0; i < strHeader.Length; i++ ) {
                worksheet.Column( i + 1 ).Width = 1.0 * iColumnWidth[ i ] / 7;

                worksheet.Cells[ 1, i + 1 ].Value = strHeader[ i ];
            }

            ExcelRange er;
            er = worksheet.Cells[ "A1:D1" ];
            er.Style.Border.Top.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Left.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Right.Style = ExcelBorderStyle.Medium;
            er.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

            worksheet.Row( 1 ).Height = 30;
            worksheet.Row( 1 ).Style.Font.Bold = true;
            worksheet.Row( 1 ).Style.WrapText = true;
            worksheet.Row( 1 ).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Row( 1 ).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            for( int i = 0; i < lvReport_3.Items.Count; i++ ) {
                worksheet.Cells[ i + 2, 1 ].Value = Convert.ToDateTime( lvReport_3.Items[ i ].SubItems[ 0 ].Text );
                worksheet.Cells[ i + 2, 1 ].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;

                worksheet.Cells[ i + 2, 2 ].Value = lvReport_3.Items[ i ].SubItems[ 1 ].Text;

                worksheet.Cells[ i + 2, 3 ].Value = Convert.ToDouble( lvReport_3.Items[ i ].SubItems[ 2 ].Text );
                worksheet.Cells[ i + 2, 4 ].Value = Convert.ToDouble( lvReport_3.Items[ i ].SubItems[ 3 ].Text );
            }

            er = worksheet.Cells[ "A2:D" + ( lvReport_3.Items.Count + 1 ) ];
            er.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            worksheet.Cells[ "C2:D" + ( lvReport_3.Items.Count + 1 ) ].Style.Numberformat.Format = "#,##0.0000";

            ExcelFile.Workbook.Properties.Title = "Invertory";
            ExcelFile.Workbook.Properties.Author = "Fatih \"fabal\" BALCI";
            ExcelFile.Workbook.Properties.Comments = "proIMP report with EPlus";
            ExcelFile.Workbook.Properties.Company = "proGEDIA";

            ExcelFile.Compression = CompressionLevel.BestCompression;
            ExcelFile.SaveAs( new FileInfo( reportFile ) );

            if( cbReport_3OpenReport.Checked == true ) {
                System.Diagnostics.Process.Start( reportFile );
            } else {
                MessageBox.Show( frmMain.resMan.GetString( "reportExported", frmMain.culInfo ) );
            }
        }
        #endregion

        public void action( string act ) {
            switch( act ) {
                case "language": {
                    switchLanguage();
                }
                break;
            }
        }

        public void switchLanguage() {
            /**
             * report
             **/
            lblReport_1Date.Text = frmMain.resMan.GetString( "lblReportDate", frmMain.culInfo );
            lblReport_1Category.Text = frmMain.resMan.GetString( "btnCategory", frmMain.culInfo );
            lblReport_1Product.Text = frmMain.resMan.GetString( "btnProduct", frmMain.culInfo );
            lblReport_1Supplier.Text = frmMain.resMan.GetString( "btnSupplier", frmMain.culInfo );
            btnReport_1Customer.Text = frmMain.resMan.GetString( "btnCustomer", frmMain.culInfo );
            lblReport_1StockFlowType.Text = frmMain.resMan.GetString( "lblReport_1StockFlowType", frmMain.culInfo );
            cbReport_1FlowIn.Text = frmMain.resMan.GetString( "cbReport_1FlowIn", frmMain.culInfo );
            cbReport_1FlowOut.Text = frmMain.resMan.GetString( "cbReport_1FlowOut", frmMain.culInfo );
            btnReport_1Run.Text = frmMain.resMan.GetString( "btnReport_1Run", frmMain.culInfo );

            chReport_1Date.Text = lblReport_1Date.Text;
            chReport_1Supplier.Text = frmMain.resMan.GetString( "chReport_1Supplier", frmMain.culInfo );
            chReport_1Product.Text = frmMain.resMan.GetString( "btnProduct", frmMain.culInfo ); ;
            chReport_1Unit.Text = frmMain.resMan.GetString( "stockProductUnit", frmMain.culInfo );
            chReport_1Quantity.Text = frmMain.resMan.GetString( "stockProductQuantity", frmMain.culInfo );
            chReport_1Price.Text = frmMain.resMan.GetString( "stockProductPrice", frmMain.culInfo );
            chReport_1TotalPrice.Text = frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo );
            chReport_1TotalLocalPrice.Text = frmMain.resMan.GetString( "stockTotalPrice", frmMain.culInfo ) + "( " + frmMain.setting.localExchange + " )";

            btnReport_1Export.Text = frmMain.resMan.GetString( "btnReport_1Export", frmMain.culInfo );
            cbReport_1OpenReport.Text = frmMain.resMan.GetString( "cbReport_1OpenReport", frmMain.culInfo );

            lblReport_2Date.Text = lblReport_1Date.Text;
            lblReport_2Category.Text = frmMain.resMan.GetString( "btnCategory", frmMain.culInfo );
            lblReport_2Product.Text = frmMain.resMan.GetString( "btnProduct", frmMain.culInfo );
            lblReport_2Warehouse.Text = frmMain.resMan.GetString( "btnWarehouse", frmMain.culInfo ); ;
            btnReport_2Run.Text = btnReport_1Run.Text;

            chReport_2Product.Text = frmMain.resMan.GetString( "btnProduct", frmMain.culInfo );
            chReport_2Category.Text = frmMain.resMan.GetString( "plProductCategory", frmMain.culInfo );
            chReport_2Unit.Text = frmMain.resMan.GetString( "stockProductUnit", frmMain.culInfo );
            chReport_2StockIn.Text = frmMain.resMan.GetString( "btnStockIn", frmMain.culInfo );
            chReport_2StockOut.Text = frmMain.resMan.GetString( "btnStockOut", frmMain.culInfo );
            chReport_2TotalStock.Text = frmMain.resMan.GetString( "chReport_2TotalStock", frmMain.culInfo );

            btnReport_2Export.Text = btnReport_1Export.Text;
            cbReport_2OpenReport.Text = cbReport_1OpenReport.Text;

            lblReport_3Date.Text = lblReport_1Date.Text;
            btnReport_3Run.Text = btnReport_1Run.Text;

            btnReport_3Export.Text = btnReport_1Export.Text;
            cbReport_3OpenReport.Text = cbReport_1OpenReport.Text;

            chReport_3Date.Text = lblReport_1Date.Text;
            lblReport_3Currency.Text = frmMain.resMan.GetString( "lblReport_3Currency", frmMain.culInfo );
            chReport_3CurrencyCode.Text = frmMain.resMan.GetString( "chReport_3CurrencyCode", frmMain.culInfo );
            chReport_3ForexBuying.Text = frmMain.resMan.GetString( "chReport_3ForexBuying", frmMain.culInfo );
            chReport_3ForexSelling.Text = frmMain.resMan.GetString( "chReport_3ForexSelling", frmMain.culInfo );
        }
    }
}
