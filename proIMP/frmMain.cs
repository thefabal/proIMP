using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

// Multilanguage support
using System.Globalization;
using System.Resources;

//SQLite
using System.Data.SQLite;

//MD5
using System.Security.Cryptography;

//JSON
using System.Web.Script.Serialization;

//Excel
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace proIMP {
    public partial class frmMain : Form {
        public static SQLiteConnection sqlCon;

        public ResourceManager resMan;
        public CultureInfo culInfo;

        /**
         * forms
        **/
        public static frmAbout about;
        public static frmCategory category;
        public static frmCustomer customer;
        public static frmProduct product;
        public static frmStockFlowProduct stockflow;
        public static frmStockFlowIn stockin;
        public static frmStockFlowOut stockout;
        public static frmSupplier supplier;
        public static frmWarehouse warehouse;
        public static frmPreferences preferences;

        public static settings setting = new settings();

        /**
         *  
        **/
        private string sortedColumn = string.Empty;

        /**
         * -1: do not sort
         *  0: int
         *  1: double
         *  2: string
         *  3: date
        **/
        private Type[] sortProduct = new Type[] { typeof( string ), typeof( int ), typeof( string ), typeof( int ), typeof( double )};
        private Type[] sortStock = new Type[] { typeof( string ), null, typeof( DateTime ), typeof( string ), typeof( string ), typeof( string ), typeof( double ), null };
        private Type[] sortStockProduct = new Type[] { typeof( string ), typeof( int ), typeof( string ), typeof( double ), typeof( double ), typeof( double )};

        public frmMain() {
            InitializeComponent();

            warehouse = new frmWarehouse( this );
            supplier = new frmSupplier( this );
            customer = new frmCustomer( this );
            category = new frmCategory( this );
            product = new frmProduct( this );
            stockin = new frmStockFlowIn( this );
            stockout = new frmStockFlowOut( this );
            stockflow = new frmStockFlowProduct( this );
            about = new frmAbout( this );
            preferences = new frmPreferences( this );

            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        private void frmMain_Load( object sender, EventArgs e ) {
            lvProductList_SelectedIndexChanged( null, null );

            if( File.Exists( Path.GetDirectoryName( Application.ExecutablePath ) + "\\config.json" ) ) {
                string strSettings = File.ReadAllText( Path.GetDirectoryName( Application.ExecutablePath ) + "\\config.json" );
                if( strSettings.Length > 0 ) {
                    try {
                        setting = new JavaScriptSerializer().Deserialize<settings>( strSettings );
                    } catch {
                        setting = new settings();
                    }
                }
            }

            if( setting.language.Length == 0 ) {
                if( CultureInfo.InstalledUICulture.Name == "tr-TR" ) {
                    setting.language = "tr";
                } else {
                    setting.language = "en";
                }
            }

            switchLanguage();

            if( connectDB() == false ) {
                MessageBox.Show( resMan.GetString( "dbConnectionError", culInfo ) );
            }
            checkDB();

            pnlMenuProduct.Height = 29;
            pnlMenuStock.Height = 29;
            pnlMenuReport.Height = 29;
            pnlMenuStock.Location = new Point( pnlMenuStock.Location.X, pnlMenuProduct.Location.Y + pnlMenuProduct.Height + 6 );
            pnlMenuReport.Location = new Point( pnlMenuReport.Location.X, pnlMenuStock.Location.Y + pnlMenuStock.Height + 6 );

            btnProduct_Click( btnProduct, null );
        }

        private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
            string strSettings = (new JavaScriptSerializer()).Serialize( setting );

            File.WriteAllText( Path.GetDirectoryName( Application.ExecutablePath ) + "\\config.json", strSettings );
        }

        private void switchLanguage( ) {
            if( setting.language == "tr" ) {
                culInfo = CultureInfo.CreateSpecificCulture( "tr" );
                turkishToolStripMenuItem.Checked = true;
                englishToolStripMenuItem.Checked = false;
            } else {
                culInfo = CultureInfo.CreateSpecificCulture( "en" );
                turkishToolStripMenuItem.Checked = false;
                englishToolStripMenuItem.Checked = true;
            }

            resMan = new ResourceManager( "proIMP.Resource.Res", typeof( frmMain ).Assembly );

            Text = resMan.GetString( "mainForm_Text", culInfo );

            /**
             * Main Left Menu
             **/
            btnProduct.Text = resMan.GetString( "btnProduct", culInfo );
            btnWarehouse.Text = resMan.GetString( "btnWarehouse", culInfo );
            btnSupplier.Text = resMan.GetString( "btnSupplier", culInfo );
            btnCustomer.Text = resMan.GetString( "btnCustomer", culInfo );
            btnCategory.Text = resMan.GetString( "btnCategory", culInfo );
            btnStock.Text = resMan.GetString( "btnStock", culInfo );
            btnStockIn.Text = resMan.GetString( "btnStockIn", culInfo );
            btnStockOut.Text = resMan.GetString( "btnStockOut", culInfo );
            btnReports.Text = resMan.GetString( "btnReports", culInfo );
            btnReportProductFlow.Text = resMan.GetString( "btnReportProductFlow", culInfo );
            btnReportProductCount.Text = resMan.GetString( "btnReportProductCount", culInfo );

            /**
             * Menu Strip
             **/
            productToolStripMenuItem.Text = btnProduct.Text;
            warehouseToolStripMenuItem.Text = btnWarehouse.Text;
            supplierToolStripMenuItem.Text = btnSupplier.Text;
            customerToolStripMenuItem.Text = btnCustomer.Text;
            categoryToolStripMenuItem.Text = btnCategory.Text;
            stockToolStripMenuItem.Text = btnStock.Text;
            stockInToolStripMenuItem.Text = btnStockIn.Text;
            stockOutToolStripMenuItem.Text = btnStockOut.Text;
            reportsToolStripMenuItem.Text = btnReports.Text;
            stockFlowToolStripMenuItem.Text = btnReportProductFlow.Text;
            productCountToolStripMenuItem.Text = btnReportProductCount.Text;
            helpToolStripMenuItem.Text = resMan.GetString( "helpToolStripMenuItem", culInfo );
            languageToolStripMenuItem.Text = resMan.GetString( "languageToolStripMenuItem", culInfo );
            englishToolStripMenuItem.Text = resMan.GetString( "englishToolStripMenuItem", culInfo );
            turkishToolStripMenuItem.Text = resMan.GetString( "turkishToolStripMenuItem", culInfo );
            preferencesToolStripMenuItem.Text = resMan.GetString( "preferencesToolStripMenuItem", culInfo );
            helpToolStripMenuItem1.Text = helpToolStripMenuItem.Text;
            aboutToolStripMenuItem.Text = resMan.GetString( "aboutToolStripMenuItem", culInfo );

            /**
             * Count
             **/
            lblTotalProduct.Text = resMan.GetString( "lblTotalProduct", culInfo );
            lblTotalCategory.Text = resMan.GetString( "lblTotalCategory", culInfo );
            lblTotalCustomer.Text = resMan.GetString( "lblTotalCustomer", culInfo );
            lblTotalSupplier.Text = resMan.GetString( "lblTotalSupplier", culInfo );
            lblTotalWarehouse.Text = resMan.GetString( "lblTotalWarehouse", culInfo );

            btnProductFilter.Text = resMan.GetString( "btnProductFilter", culInfo );
            btnProductFilterClear.Text = resMan.GetString( "btnClear", culInfo );

            plProductName.Text = resMan.GetString( "plProductName", culInfo );
            plProductID.Text = resMan.GetString( "plProductID", culInfo );
            plProductCategory.Text = resMan.GetString( "plProductCategory", culInfo );
            plProductStock.Text = resMan.GetString( "plProductStock", culInfo );
            plProductPrice.Text = resMan.GetString( "plProductPrice", culInfo );

            /**
             * Product Info
             **/
            lblProductID.Text = plProductName.Text;
            lblProductName.Text = plProductName.Text;
            lblProductCategory.Text = plProductCategory.Text;
            lblProductDesc.Text = resMan.GetString( "lblProductDesc", culInfo );
            lblProductUnit.Text = resMan.GetString( "lblProductUnit", culInfo );
            lblProductBarcode.Text = resMan.GetString( "lblProductBarcode", culInfo );

            btnProductAdd.Text = resMan.GetString( "btnAdd", culInfo );
            btnProductEdit.Text = resMan.GetString( "btnEdit", culInfo );
            btnProductDelete.Text = resMan.GetString( "btnDelete", culInfo );

            editProductToolStripMenuItem.Text = resMan.GetString( "editProductToolStripMenuItem", culInfo );
            deleteProductToolStripMenuItem.Text = resMan.GetString( "deleteProductToolStripMenuItem", culInfo );
            duplicateProductToolStripMenuItem.Text = resMan.GetString( "duplicateProductToolStripMenuItem", culInfo );

            gbProductInfo.Text = resMan.GetString( "gbProductInfo", culInfo );

            /**
             * Stock Flow
             **/
            stockFlowType.Text = resMan.GetString( "stockFlowType", culInfo );
            stockFlowDate.Text = resMan.GetString( "stockFlowDate", culInfo );
            stockFlowSupplier.Text = resMan.GetString( "stockFlowSupplier", culInfo );
            stockFlowDescription.Text = resMan.GetString( "stockFlowDescription", culInfo );
            stockFlowQuantity.Text = resMan.GetString( "stockFlowQuantity", culInfo );
            stockFlowTotalPrice.Text = resMan.GetString( "stockTotalPrice", culInfo );

            btnStockFlowAdd.Text = resMan.GetString( "btnAdd", culInfo );
            addStockInToolStripMenuItem.Text = btnStockIn.Text;
            stockOutToolStripMenuItem1.Text = btnStockOut.Text;
            btnStockFlowEdit.Text = resMan.GetString( "btnEdit", culInfo );
            btnStockFlowDelete.Text = resMan.GetString( "btnDelete", culInfo );

            stockProductName.Text = plProductName.Text;
            stockProductUnit.Text = resMan.GetString( "stockProductUnit", culInfo );
            stockProductQuantity.Text = resMan.GetString( "stockProductQuantity", culInfo );
            stockProductPrice.Text = resMan.GetString( "stockProductPrice", culInfo );
            stockProductTotalPrice.Text = resMan.GetString( "stockTotalPrice", culInfo );

            btnStockProductAdd.Text = resMan.GetString( "btnAdd", culInfo );
            btnStockProductEdit.Text = resMan.GetString( "btnEdit", culInfo );
            btnStockProductDelete.Text = resMan.GetString( "btnStockProductDelete", culInfo );

            lblGrandTotalPrice.Text = resMan.GetString( "lblGrandTotalPrice", culInfo );

            lblReport_1Date.Text = resMan.GetString( "lblReportDate", culInfo );
            lblReport_1Category.Text = btnCategory.Text;
            lblReport_1Product.Text = btnProduct.Text;
            lblReport_1Supplier.Text = btnSupplier.Text;
            btnReport_1Customer.Text = btnCustomer.Text;
            lblReport_1StockFlowType.Text = resMan.GetString( "lblReport_1StockFlowType", culInfo );
            cbReport_1FlowIn.Text = resMan.GetString( "cbReport_1FlowIn", culInfo );
            cbReport_1FlowOut.Text = resMan.GetString( "cbReport_1FlowOut", culInfo );
            btnReport_1Run.Text = resMan.GetString( "btnReport_1Run", culInfo );

            chReport_1Date.Text = lblReport_1Date.Text;
            chReport_1Supplier.Text = resMan.GetString( "chReport_1Supplier", culInfo );
            chReport_1Product.Text = btnProduct.Text;
            chReport_1Unit.Text = stockProductUnit.Text;
            chReport_1Quantity.Text = stockProductQuantity.Text;
            chReport_1Price.Text = stockProductPrice.Text;
            chReport_1TotalPrice.Text = stockProductTotalPrice.Text;

            btnReport_1Export.Text = resMan.GetString( "btnReport_1Export", culInfo );
            cbReport_1OpenReport.Text = resMan.GetString( "cbReport_1OpenReport", culInfo );

            lblReport_2Date.Text = lblReport_1Date.Text;
            lblReport_2Category.Text = btnCategory.Text;
            lblReport_2Product.Text = btnProduct.Text;
            lblReport_2Warehouse.Text = btnWarehouse.Text;
            btnReport_2Run.Text = btnReport_1Run.Text;

            chReport_2Product.Text = btnProduct.Text;
            chReport_2Category.Text = btnCategory.Text;
            chReport_2Unit.Text = stockProductUnit.Text;
            chReport_2StockIn.Text = btnStockIn.Text;
            chReport_2StockOut.Text = btnStockOut.Text;
            chReport_2TotalStock.Text = resMan.GetString( "chReport_2TotalStock", culInfo );

            btnReport_2Export.Text = btnReport_1Export.Text;
            cbReport_2OpenReport.Text = cbReport_1OpenReport.Text;
        }

        /**
         * Menu Strip
         **/

        /**
         * Menu Strip
         * Events
        **/
        private void languageToolStripMenuItem_Click( object sender, EventArgs e ) {
            switch( ( (ToolStripMenuItem)sender ).Name ) {
                case "turkishToolStripMenuItem":
                    setting.language = "tr";
                    break;

                case "englishToolStripMenuItem":
                    setting.language = "en";
                    break;

                default:
                    return;
            }

            switchLanguage();
        }

        private void preferencesToolStripMenuItem_Click( object sender, EventArgs e ) {
            if( preferences.ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void aboutToolStripMenuItem_Click( object sender, EventArgs e ) {
            if( about.ShowDialog() == DialogResult.OK ) {

            }
        }

        /**
         * Menu 
         **/

        /**
         * Menu
         * Events
        **/
        private void btnProduct_Click( object sender, EventArgs e ) {
            menuAccordion( ( (Button)sender ).Parent.Name );

            pnlProduct.BringToFront();
        }

        private void btnWarehouse_Click( object sender, EventArgs e ) {
            if( warehouse.ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void btnSupplier_Click( object sender, EventArgs e ) {
            if( supplier.ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void btnCategory_Click( object sender, EventArgs e ) {
            if( category.ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void btnCustomer_Click( object sender, EventArgs e ) {
            if( customer.ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void btnStock_Click( object sender, EventArgs e ) {
            menuAccordion( ( (Button)sender ).Parent.Name );

            pnlStock.BringToFront();
        }

        private void btnStockIn_Click( object sender, EventArgs e ) {
            stockin.strStockFlowID = string.Empty;

            if( stockin.ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void btnStockOut_Click( object sender, EventArgs e ) {
            stockout.strStockFlowID = string.Empty;

            if( stockout.ShowDialog() == DialogResult.OK ) {

            }

            checkDB();
        }

        private void btnReport_Click( object sender, EventArgs e ) {
            menuAccordion( ( (Button)sender ).Parent.Name );

            btnReportProductFlow_Click( sender, e );
            pnlReport.BringToFront();
            pnlReport_1.BringToFront();
        }

        private void btnReportProductFlow_Click( object sender, EventArgs e ) {
            dtReport_1From.Value = DateTime.Now.AddYears( -1 );

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT category_id, category_name FROM category ORDER BY category_name", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbReport_1Category.Items.Clear();
                cbReport_1Category.Items.Add( new CategoryItem( "-1", resMan.GetString( "AllCategories", culInfo ) ) );
                while( dbReader.Read() ) {
                    cbReport_1Category.Items.Add( new CategoryItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();
                cbReport_1Category.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT supplier_id, supplier_name FROM supplier ORDER BY supplier_name", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbReport_1Supplier.Items.Clear();
                cbReport_1Supplier.Items.Add( new SupplierItem( "-1", resMan.GetString( "AllSuppliers", culInfo ) ) );
                while( dbReader.Read() ) {
                    cbReport_1Supplier.Items.Add( new SupplierItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();
                cbReport_1Supplier.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT customer_id, customer_name FROM customer ORDER BY customer_name", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbReport_1Customer.Items.Clear();
                cbReport_1Customer.Items.Add( new SupplierItem( "-1", resMan.GetString( "AllCustomers", culInfo ) ) );
                while( dbReader.Read() ) {
                    cbReport_1Customer.Items.Add( new SupplierItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();
                cbReport_1Customer.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT product_id, product_name, product_unit FROM product ORDER BY product_name", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbReport_1Product.Items.Clear();
                cbReport_1Product.Items.Add( new ProductItem( "-1", resMan.GetString( "AllProducts", culInfo ), resMan.GetString( "unitP", culInfo ) ) );
                while( dbReader.Read() ) {
                    cbReport_1Product.Items.Add( new ProductItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString(), resMan.GetString( "unit" + dbReader[ 2 ].ToString(), culInfo ) ) );
                }
                dbReader.Close();
                cbReport_1Product.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }

            pnlReport.BringToFront();
            pnlReport_1.BringToFront();
        }

        private void btnReportProductCount_Click( object sender, EventArgs e ) {
            dtReport_2From.Value = DateTime.Now.AddYears( -1 );

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT category_id, category_name FROM category ORDER BY category_name", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbReport_2Category.Items.Clear();
                cbReport_2Category.Items.Add( new CategoryItem( "-1", resMan.GetString( "AllCategories", culInfo ) ) );
                while( dbReader.Read() ) {
                    cbReport_2Category.Items.Add( new CategoryItem( dbReader.GetInt64( 0 ).ToString(), dbReader.GetString( 1 ) ) );
                }
                dbReader.Close();
                cbReport_2Category.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT product_id, product_name, product_unit FROM product ORDER BY product_name", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbReport_2Product.Items.Clear();
                cbReport_2Product.Items.Add( new ProductItem( "-1", resMan.GetString( "AllProducts", culInfo ), resMan.GetString( "unitP", culInfo ) ) );
                while( dbReader.Read() ) {
                    cbReport_2Product.Items.Add( new ProductItem( dbReader.GetInt64( 0 ).ToString(), dbReader.GetString( 1 ), resMan.GetString( "unit" + dbReader[ 2 ].ToString(), culInfo ) ) );
                }
                dbReader.Close();
                cbReport_2Product.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT warehouse_id, warehouse_name FROM warehouse ORDER BY warehouse_name", frmMain.sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbReport_2Warehouse.Items.Clear();
                cbReport_2Warehouse.Items.Add( new WarehouseItem( "-1", resMan.GetString( "allWarehouses", culInfo ) ) );
                while( dbReader.Read() ) {
                    cbReport_2Warehouse.Items.Add( new WarehouseItem( dbReader.GetInt64( 0 ).ToString(), dbReader.GetString( 1 ) ) );
                }
                dbReader.Close();
                cbReport_2Warehouse.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }

            pnlReport.BringToFront();
            btnReport_2Run_Click( sender, e );
            pnlReport_2.BringToFront();
        }

        private void pnlMenuLeft_Resize( object sender, EventArgs e ) {
            foreach( Control c in pnlMenuLeft.Controls ) {
                if( c.GetType() == typeof( Panel ) ) {
                    if( ( (Panel)c ).Height > 25 ) {
                        menuAccordion( ( (Panel)c ).Name );
                    }
                }
            }
        }

        /**
         * Menu
         * Functions
        **/
        private void menuAccordion( string controller_name ) {
            foreach( Control c in pnlMenuLeft.Controls ) {
                if( c.GetType() == typeof( Panel ) ) {
                    if( ( (Panel)c ).Name == controller_name ) {
                        ( (Panel)c ).BackColor = SystemColors.Highlight;
                        ( (Panel)c ).Height = pnlMenuLeft.Height - ( 2 * 35 );
                    } else {
                        ( (Panel)c ).BackColor = SystemColors.Control;
                        ( (Panel)c ).Height = 25;
                    }
                }
            }

            pnlMenuStock.Location = new Point( pnlMenuStock.Location.X, pnlMenuProduct.Location.Y + pnlMenuProduct.Height + 6 );
            pnlMenuReport.Location = new Point( pnlMenuReport.Location.X, pnlMenuStock.Location.Y + pnlMenuStock.Height + 6 );
        }

        /**
         * Product Page
         **/

        /**
         * Product Page
         * Events
         **/
        private void btnProductFilter_Click( object sender, EventArgs e ) {
            getProductList( tbProductFilter.Text );
        }

        private void btnProductFilterClear_Click( object sender, EventArgs e ) {
            tbProductFilter.Clear();
            getProductList();
        }

        private void lvProductList_ItemChecked( object sender, ItemCheckedEventArgs e ) {
            if( checkListViewCheckbox( lvProductList ) ) {
                btnProductEdit.Enabled = true;
                btnProductDelete.Enabled = true;
            } else {
                btnProductEdit.Enabled = false;
                btnProductDelete.Enabled = false;
            }
        }

        private void lvProductList_SelectedIndexChanged( object sender, EventArgs e ) {
            if( lvProductList.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT t1.product_id, t1.product_name, t2.category_name, t1.product_desc, t1.product_unit, t1.product_barcode, t1.product_imageid, t3.image_binary FROM product AS t1 LEFT JOIN category AS t2 ON t1.product_catid = t2.category_id LEFT JOIN image AS t3 ON t1.product_imageid = t3.image_id WHERE t1.product_id = '" + lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text + "'", sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                while( dbReader.Read() ) {
                    lblProductIDT.Text = ": " + dbReader[ "product_id" ].ToString();
                    lblProductNameT.Text = ": " + dbReader[ "product_name" ].ToString();
                    lblProductCategoryT.Text = ": " + dbReader[ "category_name" ].ToString();
                    lblProductDescT.Text = ": " + dbReader[ "product_desc" ].ToString();
                    lblProductUnitT.Text = ": " + resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), culInfo );
                    lblProductBarcodeT.Text = ": " + dbReader[ "product_barcode" ].ToString();

                    if( dbReader[ "product_imageid" ].ToString().Length != 0 ) {
                        pbProductImage.Visible = true;
                        pbProductImage.Image = DeserializeImage( (byte[ ])dbReader[ "image_binary" ] );
                    } else {
                        pbProductImage.Visible = false;
                    }
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

        private void btnProductAdd_Click( object sender, EventArgs e ) {
            product.strProductID = string.Empty;
            if( product.ShowDialog() == DialogResult.OK ) {

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

        private void editProductToolStripMenuItem_Click( object sender, EventArgs e ) {
            if( lvProductList.SelectedItems.Count > 0 ) {
                editProduct( lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text );
            }
        }

        private void btnProductDelete_Click( object sender, EventArgs e ) {
            for( int i = 0; i < lvProductList.Items.Count; i++ ) {
                if( lvProductList.Items[ i ].Checked ) {
                    deleteProduct( lvProductList.Items[ i ].SubItems[ 1 ].Text );
                }
            }
        }

        private void deleteProductToolStripMenuItem_Click( object sender, EventArgs e ) {
            if( lvProductList.SelectedItems.Count > 0 ) {
                deleteProduct( lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text );
            }
        }

        private void duplicateProductToolStripMenuItem_Click( object sender, EventArgs e ) {
            string product_name = string.Empty;
            string product_catid = string.Empty;
            string product_desc = string.Empty;
            string product_unit = string.Empty;
            string product_barcode = string.Empty;
            string product_imageid = string.Empty;

            SQLiteCommand dbCommand = new SQLiteCommand( sqlCon );
            SQLiteDataReader dbReader;

            dbCommand.CommandText = "SELECT product_name, product_catid, product_desc, product_unit, product_barcode, product_imageid FROM product WHERE product_id = '" + lvProductList.SelectedItems[ 0 ].SubItems[ 1 ].Text + "'";
            try {
                dbReader = dbCommand.ExecuteReader();
                if( dbReader.Read() ) {
                    product_name = dbReader[ "product_name" ].ToString();
                    product_catid = dbReader[ "product_catid" ].ToString();
                    product_desc = dbReader[ "product_desc" ].ToString();
                    product_unit = dbReader[ "product_unit" ].ToString();
                    product_barcode = dbReader[ "product_barcode" ].ToString();
                    product_imageid = dbReader[ "product_imageid" ].ToString();

                    dbReader.Close();
                }
            } catch {
                return;
            }

            string product_id = string.Empty;
            dbCommand.CommandText = "INSERT INTO product (product_id, product_name, product_catid, product_desc, product_unit, product_barcode, product_imageid) VALUES(NULL, '" + product_name.Replace( "'", "''" ) + " (1)', '" + product_catid + "', '" + product_desc.Replace( "'", "''" ) + "', '" + product_unit + "', '" + product_barcode.Replace( "'", "''" ) + "', '" + product_imageid + "')";
            try {
                dbCommand.ExecuteNonQuery();

                dbCommand.CommandText = "SELECT last_insert_rowid()";
                product_id = ( (long)dbCommand.ExecuteScalar() ).ToString();
            } catch {
                return;
            }

            editProduct( product_id );

            checkDB();
        }

        private void cmsProduct_Opening( object sender, CancelEventArgs e ) {
            if( lvProductList.SelectedItems.Count == 0 ) {
                e.Cancel = true;
            }
        }

        /**
         * Product Page
         * Functions
         **/
        private void getProductList( string filter = "" ) {
            SQLiteCommand dbCommand = frmMain.sqlCon.CreateCommand();
            if( filter.Length > 0 ) {
                dbCommand.CommandText = "SELECT product_id, product_name, category_name, product_count, sflow_price FROM product_list WHERE product_name LIKE '%" + filter + "%' ORDER BY ";
            } else {
                dbCommand.CommandText = "SELECT product_id, product_name, category_name, product_count, sflow_price FROM product_list ORDER BY ";
            }

            if( setting.productOrder == 0 ) {
                dbCommand.CommandText += "product_name, category_name";
            } else {
                dbCommand.CommandText += "category_name, product_name";
            }

            try {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lvProductList.Items.Clear();
                lvProductList.ItemChecked -= new ItemCheckedEventHandler( lvProductList_ItemChecked );
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        dbReader[ "product_name" ].ToString(),
                        dbReader[ "product_id" ].ToString(),
                        dbReader[ "category_name" ].ToString(),
                        dbReader[ "product_count" ].ToString(),
                        ( dbReader[ "sflow_price" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "sflow_price" ].ToString() ).ToString( "0.000" ) ) :( "" )
                    } );

                    lvProductList.Items.Add( lvi );
                }
                lvProductList.ItemChecked += new ItemCheckedEventHandler( lvProductList_ItemChecked );
                lvProductList_ItemChecked( this, new ItemCheckedEventArgs( new ListViewItem() ) );
            } catch {
                MessageBox.Show( resMan.GetString( "unknownError", culInfo ) );
            }
        }

        private void editProduct( string strProductID ) {
            product.strProductID = strProductID;
            if( product.ShowDialog() == DialogResult.OK ) {

            }
        }

        private void deleteProduct( string strProductID ) {
            SQLiteCommand dbCommand = new SQLiteCommand( "DELETE FROM product WHERE product_id = '" + strProductID + "'", sqlCon );
            dbCommand.ExecuteNonQuery();
        }

        /**
         * Stock Page
         **/

        /*
         * Stock Page
         * Events
         **/
        private void lvStockFlow_ItemChecked( object sender, ItemCheckedEventArgs e ) {
            if( checkListViewCheckbox( lvStockFlow ) ) {
                btnStockFlowEdit.Enabled = true;
                btnStockFlowDelete.Enabled = true;
            } else {
                btnStockFlowEdit.Enabled = false;
                btnStockFlowDelete.Enabled = false;
            }
        }

        private void lvStockFlow_SelectedIndexChanged( object sender, EventArgs e ) {
            lvStockProductList.Items.Clear();
            if( lvStockFlow.SelectedItems.Count > 0 ) {
                SQLiteCommand dbCommand = new SQLiteCommand( "SELECT t1.sflow_id, t2.product_name, t2.product_unit, ABS(t1.sflow_quantity) AS sflow_quantity, t1.sflow_price FROM stock_flow AS t1 LEFT JOIN product AS t2 ON t1.sflow_productid = t2.product_id WHERE t1.sflow_sid = '" + lvStockFlow.SelectedItems[ 0 ].SubItems[ 1 ].Text + "' ORDER BY t2.product_name", sqlCon );
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                double dQuantity = 0;
                double dPrice = 0;
                double dTotalPrice = 0;
                double dGrandPrice = 0;
                while( dbReader.Read() ) {
                    dQuantity = Convert.ToDouble( dbReader[ "sflow_quantity" ].ToString() );
                    dPrice = Convert.ToDouble( dbReader[ "sflow_price" ].ToString() );
                    dTotalPrice = dQuantity * dPrice;
                    dGrandPrice += dTotalPrice;

                    ListViewItem lvi = new ListViewItem( new string[ ] { dbReader[ "product_name" ].ToString(), dbReader[ "sflow_id" ].ToString(), resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), culInfo ), dQuantity.ToString( "0.000" ), dPrice.ToString( "0.000" ), dTotalPrice.ToString( "0.000" ) } );

                    lvStockProductList.Items.Add( lvi );
                }
                lblGrandTotal.Text = dGrandPrice.ToString( "0.000" );

                dbReader.Close();
            } else {
                lblGrandTotal.Text = string.Empty;
            }
        }

        private void btnStockFlowAdd_Click( object sender, EventArgs e ) {
            btnStockFlowAdd_MouseHover( sender, e );
        }

        private void btnStockFlowAdd_MouseHover( object sender, EventArgs e ) {
            if( sender.GetType() == typeof(Button) ) {
                cmsAddStockFlow.Show( ( (Button)sender ).PointToScreen( new Point( 0, ( (Button)sender ).Height ) ) );
            }
        }

        private void stockFlowAdd_MouseLeave( object sender, EventArgs e ) {
            if( cmsAddStockFlow.ClientRectangle.Contains( cmsAddStockFlow.PointToClient( Cursor.Position ) ) == false ) {
                cmsAddStockFlow.Hide();
            }
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

        private void lvStockProductList_ItemChecked( object sender, ItemCheckedEventArgs e ) {
            if( checkListViewCheckbox( lvStockProductList ) ) {
                btnStockProductEdit.Enabled = true;
                btnStockProductDelete.Enabled = true;
            } else {
                btnStockProductEdit.Enabled = false;
                btnStockProductDelete.Enabled = false;
            }
        }

        private void btnStockProductAdd_Click( object sender, EventArgs e ) {
            if( lvStockFlow.SelectedItems.Count > 0 ) {
                stockflow.strStockID = lvStockFlow.SelectedItems[ 0 ].SubItems[ 1 ].Text;
                stockflow.strStockFlowID = string.Empty;
                if( stockflow.ShowDialog() == DialogResult.OK ) {
                    getStockFlowProductList();
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

        /*
         * Stock Page
         * Functions
         **/
        private void getStockFlowList( ) {
            SQLiteCommand dbCommand = new SQLiteCommand( "SELECT stock_id, stock_type, stock_date, stock_name, stock_desc, product_price, product_count, product_sum FROM stockflow_list ORDER BY stock_date DESC, stock_name", sqlCon );

            try {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lvStockFlow.ItemChecked -= new ItemCheckedEventHandler( lvStockFlow_ItemChecked );
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        ( dbReader[ "stock_type" ].ToString() == "1" )?( resMan.GetString( "stockFlowStockTypeIn", culInfo ) ):( resMan.GetString( "stockFlowStockTypeOut", culInfo ) ),
                        dbReader[ "stock_id" ].ToString(),
                        ( (DateTime)dbReader[ "stock_date" ] ).ToString("dd.MM.yyyy"),
                        dbReader[ "stock_name" ].ToString(),
                        dbReader[ "stock_desc" ].ToString(),
                        dbReader[ "product_count" ].ToString() + " / " + dbReader[ "product_sum" ].ToString(),
                        ( dbReader[ "product_price" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "product_price" ].ToString() ).ToString( "0.000" ) ) :( "" ),
                        dbReader[ "stock_type" ].ToString()
                    } );

                    lvStockFlow.Items.Add( lvi );
                }
                lvStockFlow.ItemChecked += new ItemCheckedEventHandler( lvStockFlow_ItemChecked );
                lvStockFlow_ItemChecked( this, new ItemCheckedEventArgs( new ListViewItem() ) );
            } catch {
                MessageBox.Show( resMan.GetString( "unknownError", culInfo ) );
            }
        }

        private void getStockFlowProductList( ) {
            lvStockFlow_SelectedIndexChanged( null, null );
        }

        private void editStockFlow( string strStockID, string strStockType ) {
            if( strStockType == "1" ) {
                stockin.strStockFlowID = strStockID;
                if( stockin.ShowDialog() == DialogResult.OK ) {

                }
            } else if( strStockType == "2" ) {
                stockout.strStockFlowID = strStockID;
                if( stockout.ShowDialog() == DialogResult.OK ) {

                }
            }
        }

        private void deleteStockFlow( string strStockID ) {
            SQLiteCommand dbCommand = new SQLiteCommand( "DELETE FROM stock WHERE stock_id = '" + strStockID + "'", sqlCon );
            dbCommand.ExecuteNonQuery();
        }

        private void editStockProduct( string strStockFlowID ) {
            stockflow.strStockFlowID = strStockFlowID;
            stockflow.strStockID = string.Empty;
            if( stockflow.ShowDialog() == DialogResult.OK ) {
                
            }
        }

        private void deleteStockProduct( string strStockFlowID ) {
            SQLiteCommand dbCommand = new SQLiteCommand( "DELETE FROM stock_flow WHERE sflow_id = '" + strStockFlowID + "'", sqlCon );
            dbCommand.ExecuteNonQuery();
        }

        /**
         * Report Page 
         **/

        /**
         * Report Page 
         * Events
         **/
        private void btnReport_1Run_Click( object sender, EventArgs e ) {
            string strSQL = string.Empty;

            strSQL += "SELECT sflow_id, stock_date, supplier_name, product_id, product_catid, product_name, product_unit, sflow_quantity, sflow_price, total_price FROM report_product_flow WHERE";

            /* DateTime filter */
            strSQL += " stock_date BETWEEN '" + dtReport_1From.Value.ToString( "yyyy-MM-dd" ) + "' AND '" + dtReport_1To.Value.ToString( "yyyy-MM-dd" ) + "'";

            /* Product category filter */
            if( cbReport_1Category.SelectedIndex > 0 ) {
                strSQL += " AND product_catid = " + ( (CategoryItem)cbReport_1Category.SelectedItem ).CategoryID;
            }

            /* Product filter */
            if( cbReport_1Product.SelectedIndex > 0 ) {
                strSQL += " AND product_id = " + ( (ProductItem)cbReport_1Product.SelectedItem ).ProductID;
            }

            /* Supplier filter */
            if( cbReport_1Supplier.SelectedIndex > 0 ) {
                strSQL += " AND stock_type = 1 AND supplier_id = " + ( (SupplierItem)cbReport_1Supplier.SelectedItem ).SupplierID;
            }

            /* Customer filter */
            if( cbReport_1Customer.SelectedIndex > 0 ) {
                strSQL += " AND stock_type = 2 AND supplier_id = " + ( (SupplierItem)cbReport_1Customer.SelectedItem ).SupplierID;
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

            SQLiteCommand dbCommand = new SQLiteCommand() {
                Connection = sqlCon,
                CommandText = strSQL
            };

            try {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lvReport_1.Items.Clear();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        dbReader[ "sflow_id" ].ToString(),
                        dbReader[ "stock_date" ].ToString().Substring(0, 10),
                        dbReader[ "supplier_name" ].ToString(),
                        dbReader[ "product_name" ].ToString(),
                        resMan.GetString( "unit" + dbReader[ "product_unit" ].ToString(), culInfo ),
                        ( dbReader[ "sflow_quantity" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "sflow_quantity" ].ToString() ).ToString( "0.000" ) ) :( "" ),
                        ( dbReader[ "sflow_price" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "sflow_price" ].ToString() ).ToString( "0.000" ) ) :( "" ),
                        ( dbReader[ "total_price" ].GetType() != typeof( DBNull ) ) ?( Convert.ToDouble( dbReader[ "total_price" ].ToString() ).ToString( "0.000" ) ) :( "" )
                    } );

                    lvReport_1.Items.Add( lvi );
                }
            } catch {
                MessageBox.Show( resMan.GetString( "unknownError", culInfo ) );
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

            string strReportFile = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel File|*.xlsx",
                FileName = "ProductFlowReport_" + DateTime.Now.ToString( "yyyyMMdd" ) + ".xlsx"
            };

            if( sfd.ShowDialog() == DialogResult.OK ) {
                strReportFile = sfd.FileName;
            } else {
                return;
            }

            ExcelPackage ExcelFile = new ExcelPackage();
            ExcelWorksheet worksheet = ExcelFile.Workbook.Worksheets.Add( "Sheet1" );

            string[ ] strHeader = { resMan.GetString( "lblReportDate", culInfo ), resMan.GetString( "chReport_1Supplier", culInfo ), resMan.GetString( "plProductName", culInfo ), resMan.GetString( "stockProductUnit", culInfo ), resMan.GetString( "stockProductQuantity", culInfo ), resMan.GetString( "plProductPrice", culInfo ), resMan.GetString( "stockFlowTotalPrice", culInfo ) };
            int[ ] iColumnWidth = { 75, 150, 300, 64, 70, 70, 70 };

            for( int i = 0; i < strHeader.Length; i++ ) {
                worksheet.Column( i + 1 ).Width = 1.0 * iColumnWidth[ i ] / 7;

                worksheet.Cells[ 1, i + 1 ].Value = strHeader[ i ];
            }

            ExcelRange er;
            er = worksheet.Cells[ "A1:G1" ];
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
                worksheet.Cells[ i + 2, 6 ].Value = Convert.ToDouble( lvReport_1.Items[ i ].SubItems[ 6 ].Text );
                worksheet.Cells[ i + 2, 7 ].Value = Convert.ToDouble( lvReport_1.Items[ i ].SubItems[ 7 ].Text );

                dTotalPrice += (double)worksheet.Cells[ i + 2, 7 ].Value;
            }

            er = worksheet.Cells[ "A2:G" + ( lvReport_1.Items.Count + 1 ) ];
            er.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            er.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            worksheet.Cells[ "E2:G" + ( lvReport_1.Items.Count + 1 ) ].Style.Numberformat.Format = "#,##0.000";

            worksheet.Cells[ "E" + ( lvReport_1.Items.Count + 2 ) + ":F" + ( lvReport_1.Items.Count + 2 ) ].Merge = true;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 5 ].Value = resMan.GetString( "lblGrandTotalPrice", culInfo ) + " : ";
            worksheet.Cells[ lvReport_1.Items.Count + 2, 5 ].Style.Font.Bold = true;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 5 ].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 7 ].Value = dTotalPrice;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 7 ].Style.Font.Bold = true;
            worksheet.Cells[ lvReport_1.Items.Count + 2, 7 ].Style.Numberformat.Format = "#,##0.000";

            ExcelFile.Workbook.Properties.Title = "Invertory";
            ExcelFile.Workbook.Properties.Author = "Fatih \"fabal\" BALCI";
            ExcelFile.Workbook.Properties.Comments = "proIMP report with EPlus";
            ExcelFile.Workbook.Properties.Company = "proGEDIA";

            ExcelFile.Compression = CompressionLevel.BestCompression;
            ExcelFile.SaveAs( new FileInfo( strReportFile ) );

            if( cbReport_1OpenReport.Checked == true ) {
                System.Diagnostics.Process.Start( strReportFile );
            } else {
                MessageBox.Show( resMan.GetString( "reportExported", culInfo ) );
            }
        }

        private void btnReport_2Run_Click( object sender, EventArgs e ) {
            string SQL = string.Empty;

            SQL += "SELECT product_name, category_name, product_unit, SUM(product_quantity_in) AS product_quantity_in, SUM(product_quantity_out) AS product_quantity_out, SUM(product_quantity_in + product_quantity_out)  AS product_quantity_total FROM report_product_count";

            /* DateTime filter */
            SQL += " WHERE stock_date BETWEEN '" + dtReport_2From.Value.ToString( "yyyy-MM-dd" ) + "' AND '" + dtReport_2To.Value.ToString( "yyyy-MM-dd" ) + "'";

            /* Product category filter */
            if( cbReport_2Category.SelectedIndex > 0 ) {
                SQL += " AND category_id = " + ( (CategoryItem)cbReport_2Category.SelectedItem ).CategoryID;
            }

            /* Product filter */
            if( cbReport_2Product.SelectedIndex > 0 ) {
                SQL += " AND product_id = " + ( (ProductItem)cbReport_2Product.SelectedItem ).ProductID;
            }

            /* Product warehouse filter */
            if( cbReport_2Warehouse.SelectedIndex > 0 ) {
                SQL += " AND warehouse_id = " + ( (WarehouseItem)cbReport_2Warehouse.SelectedItem ).WarehouseID;
            }

            SQL += " GROUP BY product_id, product_name, product_unit, category_name";
            SQL += " ORDER BY ";

            if( setting.productOrder == 0 ) {
                SQL += "product_name, category_name";
            } else {
                SQL += "category_name, product_name";
            }

            SQLiteCommand dbCommand = new SQLiteCommand() {
                Connection = sqlCon,
                CommandText = SQL
            };

            try {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lvReport_2.Items.Clear();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[ ] {
                        dbReader.GetString( 0 ),
                        dbReader.GetString( 1 ),
                        resMan.GetString( "unit" + dbReader.GetString(2), culInfo ),
                        dbReader.GetFloat( 3 ).ToString(),
                        dbReader.GetFloat( 4 ).ToString(),
                        dbReader.GetFloat( 5 ).ToString()
                    } );

                    lvReport_2.Items.Add( lvi );
                }
            } catch(Exception ex) {
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

        /**
         * Common Events
         **/
        private void ListViewOrder_ColumnClick( object sender, ColumnClickEventArgs e ) {
            if( ( (ListView)( sender ) ).Name + "_" + e.Column != sortedColumn ) {
                sortedColumn = ( (ListView)( sender ) ).Name + "_" + e.Column;

                ( (ListView)( sender ) ).Sorting = SortOrder.Ascending;
            } else {
                if( ( (ListView)( sender ) ).Sorting == SortOrder.Ascending )
                    ( (ListView)( sender ) ).Sorting = SortOrder.Descending;
                else
                    ( (ListView)( sender ) ).Sorting = SortOrder.Ascending;
            }
            
            ( (ListView)( sender ) ).Sort();

            Type[ ] sorter;

            switch( ( (ListView)( sender ) ).Name ) {
                case "lvProductList": sorter = sortProduct; break;
                case "lvStockFlow": sorter = sortStock; break;
                case "lvStockProductList": sorter = sortStockProduct; break;

                default:
                    return;
            }
            
            ( (ListView)( sender ) ).ListViewItemSorter = new ListViewItemComparer( e.Column, ( (ListView)( sender ) ).Sorting, sorter[ e.Column ] );
        }

        private void ListViewFocus_Enter( object sender, EventArgs e ) {
            if( ( (ListView)sender ).SelectedItems.Count > 0 ) {
                ( (ListView)sender ).SelectedItems[ 0 ].BackColor = SystemColors.Window;
                ( (ListView)sender ).SelectedItems[ 0 ].ForeColor = SystemColors.WindowText;
            }
        }

        private void ListViewFocus_Leave( object sender, EventArgs e ) {
            if( ( (ListView)sender ).SelectedItems.Count > 0 ) {
                ( (ListView)sender ).SelectedItems[ 0 ].BackColor = SystemColors.Highlight;
                ( (ListView)sender ).SelectedItems[ 0 ].ForeColor = SystemColors.HighlightText;
            }
        }

        private bool checkListViewCheckbox( ListView lv ) {
            for( int i = 0; i < lv.Items.Count; i++ ) {
                if( lv.Items[ i ].Checked == true ) {
                    return true;
                }
            }

            return false;
        }

        /**
         *  Common Functions
         **/
        public bool checkDB( ) {
            lblMessage.Text = "";

            lvProductList.Items.Clear();
            lvStockFlow.Items.Clear();
            lvStockProductList.Items.Clear();

            tbCountWarehouse.Text = string.Empty;
            tbCountCategory.Text = string.Empty;
            tbCountCustomer.Text = string.Empty;
            tbCountSupplier.Text = string.Empty;
            tbCountProduct.Text = string.Empty;

            lvProductList_SelectedIndexChanged( this, new EventArgs() );

            try {
                SQLiteCommand dbCommand = new SQLiteCommand( sqlCon );
                SQLiteDataReader dbReader;

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM warehouse";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbCountWarehouse.Text = dbReader[ "cnt" ].ToString();

                    if( tbCountWarehouse.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountWarehouse", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM supplier";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbCountSupplier.Text = dbReader[ "cnt" ].ToString();

                    if( tbCountSupplier.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountSupplier", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM category";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbCountCategory.Text = dbReader[ "cnt" ].ToString();

                    if( tbCountCategory.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountCategory", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM product";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbCountProduct.Text = dbReader[ "cnt" ].ToString();

                    if( tbCountProduct.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountProduct", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM customer";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    tbCountCustomer.Text = dbReader[ "cnt" ].ToString();

                    if( tbCountCustomer.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountCustomer", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                getProductList( tbProductFilter.Text );
                getStockFlowList();
                getStockFlowProductList();
            } catch {
                lblMessage.Text = resMan.GetString( "dbTableError", culInfo );
            }

            lblMessage.Text = resMan.GetString( "dbAllIsFine", culInfo );

            return true;
        }

        public static bool connectDB( ) {
            try {
                if( File.Exists( setting.database ) ) {
                    sqlCon = new SQLiteConnection( "Data Source=" + setting.database + ";Version=3;" );

                    sqlCon.Open();
                } else {
                    MessageBox.Show( "Could not find database file. Please select a database." );

                    return false;
                }
            } catch {
                return false;
            }

            return true;
        }

        public static string SerializeImage( string strFileName ) {
            Image photo = new Bitmap( strFileName );
            MemoryStream ms = new MemoryStream();

            photo.Save( ms, photo.RawFormat );

            return Convert.ToBase64String( ms.ToArray() );
        }

        public static Image DeserializeImage( byte[ ] imageBytes ) {
            imageBytes = Convert.FromBase64String( Encoding.UTF8.GetString( imageBytes ) );
            MemoryStream ms = new MemoryStream( imageBytes, 0, imageBytes.Length );
            ms.Write( imageBytes, 0, imageBytes.Length );
            return new Bitmap( ms );
        }

        public static string GetMd5Hash( MD5 md5Hash, string input ) {
            byte[ ] data = md5Hash.ComputeHash( Encoding.UTF8.GetBytes( input ) );
            StringBuilder sBuilder = new StringBuilder();
            for( int i = 0; i < data.Length; i++ ) {
                sBuilder.Append( data[ i ].ToString( "x2" ) );
            }

            return sBuilder.ToString();
        }

        private void tbProductFilter_KeyDown( object sender, KeyEventArgs e ) {
            if( e.KeyCode == Keys.Enter ) {
                btnProductFilter_Click( this, new EventArgs() );
            } else if( e.KeyCode == Keys.Escape ) {
                btnProductFilterClear_Click( this, new EventArgs() );
            }
        }
    }

    public class ListViewItemComparer:System.Collections.IComparer {
        private readonly int col;
        private Type type;
        private readonly SortOrder order;

        public ListViewItemComparer() {
            col = 0;
            order = SortOrder.Ascending;
        }

        public ListViewItemComparer( int column, SortOrder order, Type type ) {
            col = column;
            this.order = order;
            this.type = type;
        }

        public int Compare( object x, object y ) {
            int returnVal= -1;

            switch( type.Name ) {
                case "Int32":
                    returnVal = Convert.ToInt32( ( ( (ListViewItem)x ).SubItems[ col ].Text == "") ?("0"):( ( (ListViewItem)x ).SubItems[ col ].Text ) ).CompareTo( Convert.ToInt32( ( ( (ListViewItem)y ).SubItems[ col ].Text == "") ?("0"):( ( (ListViewItem)y ).SubItems[ col ].Text ) ) );
                break;

                case "Double":
                    returnVal = Convert.ToDouble( ( ( (ListViewItem)x ).SubItems[ col ].Text == "") ?("0"):( ( (ListViewItem)x ).SubItems[ col ].Text ) ).CompareTo( Convert.ToDouble( ( ( (ListViewItem)y ).SubItems[ col ].Text == "") ?("0"):( ( (ListViewItem)y ).SubItems[ col ].Text ) ) );
                break;

                case "string":
                case "String":
                    returnVal = String.Compare( ( (ListViewItem)x ).SubItems[ col ].Text, ( (ListViewItem)y ).SubItems[ col ].Text );
                break;

                case "DateTime":
                    returnVal = DateTime.Parse( ( ( (ListViewItem)x ).SubItems[ col ].Text == "" ) ?("1900-01-01"):( ( (ListViewItem)x ).SubItems[ col ].Text ) ).CompareTo( DateTime.Parse( ( ( (ListViewItem)y ).SubItems[ col ].Text == "") ?("1900-01-01"):( ( (ListViewItem)y ).SubItems[ col ].Text ) ) );
                break;

                default:
                    MessageBox.Show( type.Name );
                    return 0;
            }
            
            if( order == SortOrder.Descending )
                returnVal *= -1;

            return returnVal;
        }
    }

    public class settings {
        public int productOrder { get; set; } = 0;

        public string language { get; set; } = "en";
        public string database { get; set; } = Path.GetDirectoryName( Application.ExecutablePath ) + "\\db\\database.sqlite";
    }

    public class CategoryItem {
        private readonly string categoryID;
        private readonly string categoryName;

        public CategoryItem( string categoryID, string categoryName ) {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public string CategoryID {
            get {
                return categoryID;
            }
        }

        public string CategoryName {
            get {
                return CategoryName;
            }
        }

        public override string ToString() {
            return categoryName;
        }
    }

    public class SupplierItem {
        private readonly string supplierID;
        private readonly string supplierName;

        public SupplierItem( string supplierID, string supplierName ) {
            this.supplierID = supplierID;
            this.supplierName = supplierName;
        }

        public string SupplierID {
            get {
                return supplierID;
            }
        }

        public string SupplierName {
            get {
                return supplierName;
            }
        }

        public override string ToString() {
            return supplierName;
        }
    }

    public class WarehouseItem {
        private readonly string warehouseID;
        private readonly string warehouseName;

        public WarehouseItem( string WarehouseID, string WarehouseName ) {
            this.warehouseID = WarehouseID;
            this.warehouseName = WarehouseName;
        }

        public string WarehouseID {
            get {
                return warehouseID;
            }
        }

        public string WarehouseName {
            get {
                return warehouseName;
            }
        }

        public override string ToString() {
            return warehouseName;
        }
    }

    public class ProductItem {
        private readonly string productID;
        private readonly string productName;
        private readonly string productUnit;

        public ProductItem( string productID, string productName, string productUnit ) {
            this.productID = productID;
            this.productName = productName;
            this.productUnit = productUnit;
        }

        public string ProductID {
            get {
                return productID;
            }
        }

        public string ProductUnit {
            get {
                return productUnit;
            }
        }

        public string ProductName {
            get {
                return productName;
            }
        }

        public override string ToString() {
            return productName;
        }
    }
}