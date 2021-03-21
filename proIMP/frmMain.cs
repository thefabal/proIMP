using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace proIMP {
    public partial class frmMain : Form {
        public static ResourceManager resMan;
        public static CultureInfo culInfo;

        public static settings setting = new settings();
        public static exchange_rates er = new exchange_rates();

        private Form activeForm = null;
        private Action<string> activeAction = null;

        public frmMain() {
            InitializeComponent();

            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );

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
            menuCustomizeDesing();

            if( connectDB() == false ) {
                MessageBox.Show( resMan.GetString( "dbConnectionError", culInfo ) );
            }
            checkDB();
        }

        private void frmMain_Load( object sender, EventArgs e ) {
            DateTime today = new DateTime( DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day );

            ssBottomCurrency.Items.Add( resMan.GetString( "updatingCurrency", culInfo ) );

#if DEBUG
            er = getCurrencyExchange();
#else
            new Thread( ( ) => { getCurrencyExchange(); } ).Start();
#endif
        }

        private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
            string jsonSettings = ( new JavaScriptSerializer() ).Serialize( setting );

            File.WriteAllText( Path.GetDirectoryName( Application.ExecutablePath ) + "\\config.json", jsonSettings );
        }

        #region leftPanelMenu
        private void menuCustomizeDesing() {
            pnlMenuProduct.Visible = false;
            pnlMenuStock.Visible = false;
            pnlMenuReport.Visible = false;
        }

        private void menuSubMenuHide() {
            if( pnlMenuProduct.Visible == true )
                pnlMenuProduct.Visible = false;

            if( pnlMenuStock.Visible == true )
                pnlMenuStock.Visible = false;

            if( pnlMenuReport.Visible == true )
                pnlMenuReport.Visible = false;
        }

        private void menuSubMenuShow( Panel subMenu ) {
            if( subMenu.Visible == false ) {
                menuSubMenuHide();

                subMenu.Visible = true;
            }
        }

        private void btnProduct_Click( object sender, EventArgs e ) {
            menuSubMenuShow( pnlMenuProduct );

            if( activeForm == null || activeForm.Name != "frmChildProducts" ) {
                frmChildProducts form = new frmChildProducts( checkDB );
                activeAction = form.action;

                openChildForm( form );
            }                
        }

        private void btnWarehouse_Click( object sender, EventArgs e ) {
            btnProduct_Click( sender, e );

            using( frmWarehouse warehouse = new frmWarehouse() ) {
                if( warehouse.ShowDialog() == DialogResult.OK ) {

                }
            }

            checkDB();
        }

        private void btnSupplier_Click( object sender, EventArgs e ) {
            btnProduct_Click( sender, e );

            using( frmSupplier supplier = new frmSupplier() ) {
                if( supplier.ShowDialog() == DialogResult.OK ) {

                }
            }

            checkDB();
        }

        private void btnCustomer_Click( object sender, EventArgs e ) {
            btnProduct_Click( sender, e );

            using( frmCustomer customer = new frmCustomer() ) {
                if( customer.ShowDialog() == DialogResult.OK ) {

                }
            }

            checkDB();
        }

        private void btnCategory_Click( object sender, EventArgs e ) {
            btnProduct_Click( sender, e );

            using( frmCategory category = new frmCategory() ) {
                if( category.ShowDialog() == DialogResult.OK ) {

                }
            }

            checkDB();
        }

        private void btnStock_Click( object sender, EventArgs e ) {
            menuSubMenuShow( pnlMenuStock );

            if( activeForm == null || activeForm.Name != "frmChildInventory" ) {
                frmChildInventory form = new frmChildInventory( checkDB );
                
                activeAction = form.action;

                openChildForm( form );
            }                
        }

        private void btnStockIn_Click( object sender, EventArgs e ) {
            btnStock_Click( sender, e );

            using( frmStockFlowIn stockin = new frmStockFlowIn() ) {
                if( stockin.ShowDialog() == DialogResult.OK ) {

                }
            }

            activeAction( "database" );
        }

        private void btnStockOut_Click( object sender, EventArgs e ) {
            btnStock_Click( sender, e );

            using( frmStockFlowOut stockout = new frmStockFlowOut() ) {
                if( stockout.ShowDialog() == DialogResult.OK ) {

                }
            }

            activeAction( "database" );
        }

        private void btnReports_Click( object sender, EventArgs e ) {
            menuSubMenuShow( pnlMenuReport );

            if( activeForm == null || activeForm.Name != "frmChildReports" ) {
                frmChildReports form = new frmChildReports();
                activeAction = form.action;
                
                openChildForm( form );

                btnReportProductFlow_Click( sender, e );
            }            
        }

        private void btnReportProductFlow_Click( object sender, EventArgs e ) {
            btnReports_Click( sender, e );

            if( ( ( frmChildReports )activeForm ).activePanel == null || ( ( frmChildReports )activeForm ).activePanel.Name != "pnlReport_1" ) {
                ( ( frmChildReports )activeForm ).reportProductFlow();
            }
        }

        private void btnReportProductCount_Click( object sender, EventArgs e ) {
            btnReports_Click( sender, e );

            if( ( ( frmChildReports )activeForm ).activePanel == null || ( ( frmChildReports )activeForm ).activePanel.Name != "pnlReport_2" ) {
                ( ( frmChildReports )activeForm ).reportProductCount();
            }
        }

        private void btnReportExchange_Click( object sender, EventArgs e ) {
            btnReports_Click( sender, e );

            if( ( ( frmChildReports )activeForm ).activePanel == null || ( ( frmChildReports )activeForm ).activePanel.Name != "pnlReport_3" ) {
                ( ( frmChildReports )activeForm ).reportExchange();
            }
        }

        private void openChildForm(Form childForm) {
            if( activeForm != null ) {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlForm.Controls.Add( childForm );
            pnlForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        private void switchLanguage() {
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
             * Count
             **/
            lblTotalProduct.Text = resMan.GetString( "lblTotalProduct", culInfo );
            lblTotalCategory.Text = resMan.GetString( "lblTotalCategory", culInfo );
            lblTotalCustomer.Text = resMan.GetString( "lblTotalCustomer", culInfo );
            lblTotalSupplier.Text = resMan.GetString( "lblTotalSupplier", culInfo );
            lblTotalWarehouse.Text = resMan.GetString( "lblTotalWarehouse", culInfo );

            /**
             * Menu Strip
             **/
            productToolStripMenuItem.Text = resMan.GetString( "btnProduct", culInfo ); ;
            warehouseToolStripMenuItem.Text = resMan.GetString( "btnWarehouse", culInfo ); ;
            supplierToolStripMenuItem.Text = resMan.GetString( "btnSupplier", culInfo );
            customerToolStripMenuItem.Text = resMan.GetString( "btnCustomer", culInfo );
            categoryToolStripMenuItem.Text = resMan.GetString( "btnCategory", culInfo );
            stockToolStripMenuItem.Text = resMan.GetString( "btnStock", culInfo );
            stockInToolStripMenuItem.Text = resMan.GetString( "btnStockIn", culInfo );
            stockOutToolStripMenuItem.Text = resMan.GetString( "btnStockOut", culInfo );
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
            btnReportExchange.Text = resMan.GetString( "btnReportExchange", culInfo );

            /**
             * Menu Strip
             **/
            reportsToolStripMenuItem.Text = btnReports.Text;
            stockFlowToolStripMenuItem.Text = btnReportProductFlow.Text;
            productCountToolStripMenuItem.Text = btnReportProductCount.Text;

            if( activeAction != null ) {
                activeAction( "language" );
            }
        }

        /**
         *  Common Functions
        **/
        public bool checkDB() {
            lblMessage.Text = "";
            lblCountWarehouse.Text = string.Empty;
            lblCountCategory.Text = string.Empty;
            lblCountCustomer.Text = string.Empty;
            lblCountSupplier.Text = string.Empty;
            lblCountProduct.Text = string.Empty;

            try {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                SQLiteDataReader dbReader;

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM warehouse";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    lblCountWarehouse.Text = " : " + dbReader[ "cnt" ].ToString();

                    if( lblCountWarehouse.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountWarehouse", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM supplier";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    lblCountSupplier.Text = " : " + dbReader[ "cnt" ].ToString();

                    if( lblCountSupplier.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountSupplier", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM category";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    lblCountCategory.Text = " : " + dbReader[ "cnt" ].ToString();

                    if( lblCountCategory.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountCategory", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM product";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    lblCountProduct.Text = " : " + dbReader[ "cnt" ].ToString();

                    if( lblCountProduct.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountProduct", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();

                dbCommand.CommandText = "SELECT COUNT(1) AS cnt FROM customer";
                dbReader = dbCommand.ExecuteReader();

                while( dbReader.Read() ) {
                    lblCountCustomer.Text = " : " + dbReader[ "cnt" ].ToString();

                    if( lblCountCustomer.Text == "0" ) {
                        lblMessage.Text = resMan.GetString( "tbCountCustomer", culInfo );

                        dbReader.Close();

                        return false;
                    }
                }
                dbReader.Close();               

                lblMessage.Text = resMan.GetString( "dbAllIsFine", culInfo );
            } catch {
                lblMessage.Text = resMan.GetString( "dbTableError", culInfo );
            }

            return true;
        }

        public bool connectDB() {
            try {
                if( File.Exists( setting.database ) ) {
                    database.sqlCon = new SQLiteConnection( "Data Source=" + setting.database + ";Version=3;" );
                    database.sqlCon.Open();
                } else {
                    MessageBox.Show( "Could not find database file. Please select a database." );

                    return false;
                }
            } catch {
                return false;
            }

            return true;
        }

        /**
         * Exchange related
         **/      
        private void showCurrenctExchange( exchange_rates exchanges ) {
            er = exchanges;
            
            ssBottomCurrency.Items.Clear();
            foreach( KeyValuePair<string, currency> item in er.exchanges ) {
                if( item.Key != setting.localExchange )
                    ssBottomCurrency.Items.Add( item.Key + " : " + item.Value.ForexSelling + " " + setting.localExchange );
            }
        }

        private exchange_rates getCurrencyExchange( DateTime? dt = null ) {
            bool internal_update = false;
            if( dt != null ) {
                internal_update = true;
            } else {
                dt = DateTime.Now;
            }
            
            exchange_rates exchange;

            exchange = database.getCurrency( dt.Value.Date );
            if( exchange == null ) {
                exchange = exchange_rates.getCurrencyExchange( dt );
            }           
            
            if( exchange.exchanges.Count == 0 ) {
                return null;
            } else {
                if( InvokeRequired ) {
                    BeginInvoke( ( MethodInvoker )delegate () { showCurrenctExchange( exchange ); } );
                } else {
                    SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                    dbCommand.CommandText = "INSERT INTO forex_exchange (currency_date, currency_code, forex_buying, forex_selling) VALUES(@currency_date, @currency_code, @forex_buying, @forex_selling) ON CONFLICT(currency_date, currency_code) DO NOTHING";

                    foreach( KeyValuePair<string, currency> entry in exchange.exchanges ) {
                        if( entry.Key != setting.localExchange ) {
                            dbCommand.Parameters.Add( new SQLiteParameter( "@currency_date", exchange.date ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@currency_code", entry.Key ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@forex_buying", entry.Value.ForexBuying ) );
                            dbCommand.Parameters.Add( new SQLiteParameter( "@forex_selling", entry.Value.ForexSelling ) );

                            dbCommand.ExecuteNonQuery();
                        }
                    }

                    if( internal_update == false ) {
                        setting.exchange_update = DateTime.Now;

                        showCurrenctExchange( exchange );
                    }
                }
            }

            return exchange;
        }

        #region listView       
        public static void listView_ColumnClick( object sender, ColumnClickEventArgs e ) {
            ListViewColumnSorter lvs = (ListViewColumnSorter)( ( ListView )( sender ) ).ListViewItemSorter;
            if( e.Column == lvs.SortColumn ) {
                if( lvs.Order == SortOrder.Ascending ) {
                    lvs.Order = SortOrder.Descending;
                } else {
                    lvs.Order = SortOrder.Ascending;
                }
            } else {
                lvs.SortColumn = e.Column;
                lvs.Order = SortOrder.Ascending;
            }

            ( ( ListView )( sender ) ).Sort();
            ( ( ListView )( sender ) ).SetSortIcon( lvs.SortColumn, lvs.Order );
        }

        public static void listView_DrawItem( object sender, DrawListViewItemEventArgs e ) {
            ListView listView = (ListView)sender;

            if( !listView.Focused && e.Item.Selected ) {
                if( e.Item.Checked )
                    ControlPaint.DrawCheckBox( e.Graphics, e.Bounds.X + 3, e.Bounds.Top + 1, 15, 15, ButtonState.Flat | ButtonState.Checked );
                else
                    ControlPaint.DrawCheckBox( e.Graphics, e.Bounds.X + 3, e.Bounds.Top + 1, 15, 15, ButtonState.Flat );

                int leftMargin = e.Item.GetBounds(ItemBoundsPortion.Label).Left;
                Rectangle bounds = new Rectangle(leftMargin, e.Bounds.Top, e.Bounds.Width - leftMargin, e.Bounds.Height);
                e.Graphics.FillRectangle( SystemBrushes.Highlight, bounds );
            } else
                e.DrawDefault = true;
        }

        public static void listView_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e ) {
            e.DrawDefault = true;
        }

        public static void listView_DrawSubItem( object sender, DrawListViewSubItemEventArgs e ) {
            const int TEXT_OFFSET = 2;

            ListView listView = (ListView)sender;

            if( !listView.Focused && e.Item.Selected ) {
                Rectangle labelBounds = e.Item.GetBounds( ItemBoundsPortion.Label );

                int leftMargin = 3; // labelBounds.Left - TEXT_OFFSET;
                Rectangle bounds = new Rectangle(
                    e.ColumnIndex == 0 ? e.SubItem.Bounds.Left + leftMargin + 16 : e.SubItem.Bounds.Left + leftMargin,
                    e.SubItem.Bounds.Top,
                    e.ColumnIndex == 0 ? labelBounds.Width : (e.SubItem.Bounds.Width - leftMargin - TEXT_OFFSET),
                    e.SubItem.Bounds.Height
                );
                TextFormatFlags align;
                switch( listView.Columns[ e.ColumnIndex ].TextAlign ) {
                    case HorizontalAlignment.Right: { align = TextFormatFlags.Right; } break;
                    case HorizontalAlignment.Center: { align = TextFormatFlags.HorizontalCenter; } break;
                    default: { align = TextFormatFlags.Left; } break;
                }
                TextRenderer.DrawText( e.Graphics, e.SubItem.Text, listView.Font, bounds, SystemColors.HighlightText, align | TextFormatFlags.SingleLine | TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis );
            } else
                e.DrawDefault = true;
        }
        #endregion

        private void languageToolStripMenuItem_Click( object sender, EventArgs e ) {
            switch( ( ( ToolStripMenuItem )sender ).Name ) {
                case "turkishToolStripMenuItem": {
                    setting.language = "tr";
                }                    
                break;

                case "englishToolStripMenuItem": {
                    setting.language = "en";
                }                    
                break;

                default:
                    return;
            }

            switchLanguage();
        }

        private void preferencesToolStripMenuItem_Click( object sender, EventArgs e ) {
            using( frmPreferences preferences = new frmPreferences( connectDB, checkDB ) ) {
                if( preferences.ShowDialog() == DialogResult.OK ) {

                }
            }

            checkDB();
        }

        private void aboutToolStripMenuItem_Click( object sender, EventArgs e ) {
            using( frmAbout about = new frmAbout() ) {
                if( about.ShowDialog() == DialogResult.OK ) {

                }
            }
        }
    }
}
