using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proIMP {
    public static class database {
        public static SQLiteConnection sqlCon;

        public static void getSupplierList( ListView lv ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT supplier_id, supplier_name, supplier_desc FROM supplier ORDER BY supplier_name";
                
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lv.Items.Clear();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() } );

                    lv.Items.Add( lvi );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getSupplierList( ComboBox cb, string table ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format("SELECT {0}_id AS t_id, {0}_name AS t_name FROM {0} ORDER BY {0}_name", table);

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cb.Items.Clear();
                while( dbReader.Read() ) {
                    cb.Items.Add( new SupplierItem( dbReader[ "t_id" ].ToString(), dbReader[ "t_name" ].ToString() ) );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getProductList( ComboBox cb ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT product_id, product_name, product_unit FROM product ORDER BY product_name";

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cb.Items.Clear();
                while( dbReader.Read() ) {
                    cb.Items.Add( new ProductItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString(), dbReader[ 2 ].ToString() ) );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getWarehouseList( ListView lv ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT warehouse_id, warehouse_name, warehouse_desc FROM warehouse ORDER BY warehouse_name";

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lv.Items.Clear();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() } );

                    lv.Items.Add( lvi );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getWarehouseList( ComboBox cb ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT warehouse_id, warehouse_name FROM warehouse ORDER BY warehouse_name";

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cb.Items.Clear();
                while( dbReader.Read() ) {
                    cb.Items.Add( new WarehouseItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();

                cb.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getCustomerList( ListView lv ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT customer_id, customer_name, customer_desc FROM customer ORDER BY customer_name";

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lv.Items.Clear();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() } );

                    lv.Items.Add( lvi );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getCategoryList( ListView lv ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT category_id, category_name, category_desc FROM category ORDER BY category_name";

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                lv.Items.Clear();
                while( dbReader.Read() ) {
                    ListViewItem lvi = new ListViewItem( new string[] { dbReader[0].ToString(), dbReader[1].ToString(), dbReader[2].ToString() } );

                    lv.Items.Add( lvi );
                }
                dbReader.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getCategoryList( ComboBox cb ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT category_id, category_name, category_desc FROM category ORDER BY category_name";

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cb.Items.Clear();
                while( dbReader.Read() ) {
                    cb.Items.Add( new CategoryItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();

                cb.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static void getExchangeList( ComboBox cb ) {
            try {
                SQLiteCommand dbCommand = sqlCon.CreateCommand();
                dbCommand.CommandText = "SELECT DISTINCT currency_code FROM forex_exchange ORDER BY currency_code";

                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cb.Items.Clear();
                cb.Items.Add( "TL" );
                while( dbReader.Read() ) {
                    cb.Items.Add( dbReader[ 0 ].ToString() );
                }
                dbReader.Close();

                cb.SelectedIndex = 0;
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        public static exchange_rates getCurrency( DateTime dt ) {
            exchange_rates result;

            if( dt.Date == DateTime.Now.Date && DateTime.Now.Hour <= 16 ) {
                dt = dt.AddDays( -1 );
            }

            if( dt.DayOfWeek == DayOfWeek.Saturday ) {
                dt = dt.AddDays( -1 );
            } else if( dt.DayOfWeek == DayOfWeek.Sunday ) {
                dt = dt.AddDays( -2 );
            }

            SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
            dbCommand.CommandText = "SELECT currency_code, forex_buying, forex_selling FROM forex_exchange WHERE currency_date = '" + dt.ToString( "yyyy-MM-dd HH:mm:ss" ) + "'";

            SQLiteDataReader dbReader = dbCommand.ExecuteReader();
            if( dbReader.HasRows == false ) {
                dbReader.Close();

                return null;
            } else {
                dbReader.Close();

                result = new exchange_rates {
                    date = dt,
                    exchanges = new Dictionary<string, currency>()
                };

                try {
                    dbReader = dbCommand.ExecuteReader();

                    while( dbReader.Read() ) {
                        result.exchanges.Add( dbReader[ "currency_code" ].ToString(), new currency( Convert.ToDouble( dbReader[ "forex_buying" ].ToString() ), Convert.ToDouble( dbReader[ "forex_selling" ].ToString() ) ) );
                    }
                } catch( Exception ex ) {
                    throw new Exception( ex.Message );
                }
            }

            result.exchanges[ "TL" ] = new currency() {
                ForexBuying = 1,
                ForexSelling = 1
            };

            return result;
        }
    }
}
