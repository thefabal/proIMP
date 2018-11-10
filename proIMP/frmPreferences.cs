﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//JSON
using System.Web.Script.Serialization;

// SQLite
using System.Data.SQLite;

namespace proIMP {
    public partial class frmPreferences:Form {
        public TreeNode previousSelectedNode = null;

        private frmMain frmMain;

        public frmPreferences(frmMain frmMain) {
            this.frmMain = frmMain;

            InitializeComponent();
        }

        private void frmPreferences_Load( object sender, EventArgs e ) {
            cbProductOrder.SelectedIndex = frmMain.setting.productOrder;

            tvPreference.ExpandAll();
            tvPreference.SelectedNode = tvPreference.Nodes[ 0 ].Nodes[ 0 ];

            tbCurrentDB.Text = frmMain.setting.database;
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            frmMain.setting.productOrder = cbProductOrder.SelectedIndex;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tvPreference_AfterSelect( object sender, TreeViewEventArgs e ) {
            if( tvPreference.SelectedNode.Name == "nodeVisual" ) {
                tvPreference.SelectedNode = tvPreference.Nodes[ 0 ].Nodes[ 0 ];
            } else if( tvPreference.SelectedNode.Name == "nodeVisualGeneral" ) {
                gbVisual.Show();
                gbDatabase.Hide();
            } else if( tvPreference.SelectedNode.Name == "nodeDatabase" ) {
                gbVisual.Hide();
                gbDatabase.Show();
            }
        }

        private void btnDatabaseBrowse_Click( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog() {
                Title = "Please select an existing database",
                FileName = frmMain.setting.database,
                Multiselect = false
            };

            if( ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length != 0 ) {
                if( System.IO.File.Exists( ofd.FileName ) == false ) {
                    MessageBox.Show( "You have selected a non-existing file. Please select an existing file." );

                    return;
                } else {
                    frmMain.sqlCon.Close();
                    if( ofd.FileName.IndexOf( Path.GetDirectoryName( Application.ExecutablePath ) ) == 0 ) {
                        frmMain.setting.database = ofd.FileName.Substring( Path.GetDirectoryName( Application.ExecutablePath ).Length + 1 );
                    } else {
                        frmMain.setting.database = ofd.FileName;
                    }

                    if( frmMain.connectDB() == false ) {
                        MessageBox.Show( "Could not connect to new database. Please make sure you selected right file." );
                    }
                }
            } else {
                MessageBox.Show( "You do not select any file. Please select a file." );
            }
        }

        private void btnDatabaseCreate_Click( object sender, EventArgs e ) {
            SaveFileDialog sfd = new SaveFileDialog();

            if( sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length != 0 ) {
                if( System.IO.File.Exists( sfd.FileName ) ) {
                    MessageBox.Show( "You have selected an existing file. Please select a non-existing file." );

                    return;
                } else {
                    frmMain.sqlCon.Close();
                    SQLiteConnection.CreateFile( sfd.FileName );
                    if( sfd.FileName.IndexOf( Path.GetDirectoryName( Application.ExecutablePath ) ) == 0 ) {
                        frmMain.setting.database = sfd.FileName.Substring( Path.GetDirectoryName( Application.ExecutablePath ).Length + 1 );
                    } else {
                        frmMain.setting.database = sfd.FileName;
                    }

                    frmMain.sqlCon = null;
                    if( frmMain.connectDB() == false ) {
                        return;
                    }

                    SQLiteCommand dbCommand = new SQLiteCommand( frmMain.sqlCon );
                    try {
                        List<string> sql = new List<string>() {
                            "CREATE TABLE category (category_id INTEGER PRIMARY KEY AUTOINCREMENT, category_name VARCHAR (48) UNIQUE ON CONFLICT IGNORE, category_desc TEXT)",
                            "CREATE INDEX category_id ON category (category_id)",
                            "CREATE TABLE customer (customer_id INTEGER PRIMARY KEY AUTOINCREMENT, customer_name VARCHAR (48) UNIQUE ON CONFLICT IGNORE, customer_desc TEXT)",
                            "CREATE INDEX customer_id ON customer (customer_id)",
                            "CREATE TABLE image (image_id INTEGER PRIMARY KEY AUTOINCREMENT, image_md5 VARCHAR (32) UNIQUE ON CONFLICT IGNORE, image_binary BLOB)",
                            "CREATE INDEX image_id ON image (image_id)",
                            "CREATE INDEX image_md5 ON image (image_md5)",
                            "CREATE TABLE product (product_id INTEGER PRIMARY KEY AUTOINCREMENT, product_name VARCHAR (64) UNIQUE ON CONFLICT IGNORE, product_catid INTEGER, product_desc TEXT, product_unit VARCHAR (3), product_barcode VARCHAR (32), product_imageid VARCHAR (32))",
                            "CREATE INDEX product_id ON product (product_id)",
                            "CREATE INDEX product_catid ON product (product_catid)",
                            "CREATE INDEX product_imageid ON product (product_imageid)",
                            "CREATE TABLE stock_flow (sflow_id INTEGER PRIMARY KEY AUTOINCREMENT, sflow_sid INTEGER, sflow_productid INTEGER, sflow_quantity DOUBLE, sflow_price DOUBLE)",
                            "CREATE INDEX sflow_id ON stock_flow (sflow_id)",
                            "CREATE INDEX sflow_sid ON stock_flow (sflow_sid)",
                            "CREATE INDEX sflow_productid ON stock_flow (sflow_productid)",
                            "CREATE TABLE stock (stock_id INTEGER PRIMARY KEY AUTOINCREMENT, stock_type INT, stock_date DATETIME, stock_supplier INTEGER, stock_desc TEXT)",
                            "CREATE INDEX stock_id ON stock (stock_id)",
                            "CREATE INDEX stock_supplier ON stock (stock_supplier)",
                            "CREATE TRIGGER stock_afterdelete AFTER DELETE ON stock FOR EACH ROW BEGIN DELETE FROM stock_flow WHERE sflow_sid = OLD.stock_id; END",
                            "CREATE TABLE supplier (supplier_id INTEGER PRIMARY KEY AUTOINCREMENT, supplier_name VARCHAR (48) UNIQUE ON CONFLICT IGNORE, supplier_desc TEXT)",
                            "CREATE INDEX supplier_id ON supplier (supplier_id)",
                            "CREATE TABLE warehouse (warehouse_id INTEGER PRIMARY KEY ASC AUTOINCREMENT, warehouse_name VARCHAR (48) UNIQUE ON CONFLICT IGNORE, warehouse_desc TEXT)",
                            "CREATE INDEX warehouse_id ON warehouse (warehouse_id)",
                            "CREATE VIEW product_list AS SELECT t1.product_id, t1.product_name, t2.category_name, CASE WHEN t3.product_count IS NULL THEN NULL ELSE t3.product_count END AS product_count, CASE WHEN t4.product_price IS NULL THEN NULL ELSE t4.product_price END AS sflow_price FROM product AS t1 LEFT JOIN category AS t2 ON t1.product_catid = t2.category_id LEFT JOIN( SELECT sflow_productid, SUM(sflow_quantity) AS product_count FROM stock_flow GROUP BY sflow_productid ) AS t3 ON t1.product_id = t3.sflow_productid LEFT JOIN( SELECT t1.sflow_productid, MAX(t1.sflow_price) AS product_price FROM stock_flow AS t1 INNER JOIN stock AS t2 ON t1.sflow_sid = t2.stock_id INNER JOIN (SELECT t1.sflow_productid, MAX(t2.stock_date) AS stock_date FROM stock_flow AS t1 INNER JOIN stock AS t2 ON t1.sflow_sid = t2.stock_id WHERE t2.stock_type = 1 GROUP BY t1.sflow_productid) AS t3 ON t1.sflow_productid = t3.sflow_productid AND t2.stock_date = t3.stock_date WHERE t2.stock_type = 1 GROUP BY t1.sflow_productid) AS t4 ON t1.product_id = t4.sflow_productid",
                            "CREATE VIEW stockflow_list AS SELECT t1.stock_id, t1.stock_type, t1.stock_date, CASE WHEN t2.supplier_id IS NULL THEN t3.customer_name ELSE t2.supplier_name END AS stock_name, t1.stock_desc, CASE WHEN t3.product_price IS NULL THEN 0 ELSE t3.product_price END AS product_price, CASE WHEN t3.product_count IS NULL THEN 0 ELSE t3.product_count END AS product_count, CASE WHEN t3.product_sum IS NULL THEN 0 ELSE CASE WHEN t1.stock_type = 1 THEN t3.product_sum ELSE ABS( t3.product_sum ) END END AS product_sum FROM stock AS t1 LEFT JOIN supplier AS t2 ON t1.stock_supplier = t2.supplier_id AND t1.stock_type = 1 LEFT JOIN customer AS t3 ON t1.stock_supplier = t3.customer_id AND t1.stock_type = 2 LEFT JOIN( SELECT sflow_sid AS sflow_sid, COUNT(1) AS product_count, SUM(sflow_quantity) AS product_sum, SUM(sflow_quantity * sflow_price) AS product_price FROM stock_flow GROUP BY sflow_sid) AS t3 ON t1.stock_id = t3.sflow_sid",
                            "CREATE VIEW report_product_count AS SELECT t2.product_id, t2.product_name, t4.category_name, SUM(CASE WHEN t5.stock_type = 1 THEN t1.sflow_quantity ELSE 0 END) AS product_quantity_in, SUM(CASE WHEN t5.stock_type = 2 THEN t1.sflow_quantity ELSE 0 END) AS product_quantity_out FROM stock_flow AS t1 INNER JOIN product AS t2 ON t2.product_id = t1.sflow_productid INNER JOIN warehouse AS t3 ON t1.sflow_warehouseid = t3.warehouse_id INNER JOIN category AS t4 ON t2.product_catid = t4.category_id INNER JOIN stock AS t5 ON t1.sflow_sid = t5.stock_id GROUP BY t2.product_id, t2.product_name, t4.category_name",
                            "CREATE VIEW report_product_flow AS SELECT t4.stock_date, t2.product_id, t2.product_name, t2.product_unit, t3.category_id, t3.category_name, t1.sflow_warehouseid AS warehouse_id, CASE WHEN t4.stock_type = 1 THEN t1.sflow_quantity ELSE 0 END AS product_quantity_in, CASE WHEN t4.stock_type = 2 THEN t1.sflow_quantity ELSE 0 END AS product_quantity_out FROM stock_flow AS t1 INNER JOIN product AS t2 ON t2.product_id = t1.sflow_productid INNER JOIN category AS t3 ON t2.product_catid = t3.category_id INNER JOIN stock AS t4 ON t1.sflow_sid = t4.stock_id"
                        };

                        dbCommand.Transaction = frmMain.sqlCon.BeginTransaction();
                        foreach(string query in sql) {
                            dbCommand.CommandText = query;
                            dbCommand.ExecuteNonQuery();
                        }

                        dbCommand.Transaction.Commit();

                        frmMain.checkDB();
                    } catch( Exception ex ) {
                        dbCommand.Transaction.Rollback();

                        MessageBox.Show( "An error occured while creating tables and indexes.\r\n" + ex.Message );

                        return;
                    }
                }
            } else {
                MessageBox.Show( "You do not select any file. Please select a file." );
            }
        }

        private void btnDatabaseCheck_Click( object sender, EventArgs e ) {
            SQLiteCommand dbCommand = new SQLiteCommand( "SELECT type, name FROM sqlite_master WHERE type IN('table','view') AND name NOT IN('sqlite_sequence') ORDER BY type, name", frmMain.sqlCon);
            SQLiteDataReader dbReader = dbCommand.ExecuteReader();

            Dictionary<string, List<string>> db_content = new Dictionary<string, List<string>> {
                { "table", new List<string>( new string[ ] { "category", "customer", "image", "product", "stock_flow", "stock", "supplier", "warehouse" } ) },
                { "view", new List<string>( new string[ ] { "product_list", "report_product_count", "report_product_flow", "stockflow_list" } ) }
            };

            while( dbReader.Read() ) {
                if( db_content[ dbReader[ "type" ].ToString() ].Contains( dbReader[ "name" ].ToString() ) == false ) { 
                    MessageBox.Show( "There is a problem with DB. Please create it again." );

                    return;
                } else {
                    db_content[ dbReader[ "type" ].ToString() ].RemoveAt( db_content[ dbReader[ "type" ].ToString() ].IndexOf( dbReader[ "name" ].ToString() ) );
                }
            }

            if( db_content[ "table" ].Count != 0 || db_content[ "view" ].Count != 0 ) {
                MessageBox.Show( "There is a problem with DB. Please create it again." );

                return;
            } else {
                MessageBox.Show( "Database is solid without any problem." );
            }
        }

        private void btnDatabaseClean_Click( object sender, EventArgs e ) {
            int numberOfRecords = 0;

            SQLiteCommand dbCommand = new SQLiteCommand() {
                Connection = frmMain.sqlCon
            };

            dbCommand.CommandText = "DELETE FROM image WHERE image_id IN(SELECT t1.image_id FROM image AS t1 LEFT JOIN product AS t2 ON t1.image_id = t2.product_imageid WHERE t2.product_id IS NULL)";
            try {
                numberOfRecords += dbCommand.ExecuteNonQuery();
            } catch {
                
            }

            dbCommand.CommandText = "DELETE FROM stock_flow WHERE sflow_id IN(SELECT t1.sflow_id FROM stock_flow AS t1 LEFT JOIN stock AS t2 ON t1.sflow_sid = t2.stock_id WHERE t2.stock_id IS NULL)";
            try {
                numberOfRecords += dbCommand.ExecuteNonQuery();
            } catch {

            }

            MessageBox.Show( "Database cleaned. Total " + numberOfRecords + " unnecessary entry deleted." );
        }

        private void tvPreference_DrawNode( object sender, DrawTreeNodeEventArgs e ) {
            if( e.Node == null ) return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if( selected && unfocused ) {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle( SystemBrushes.Highlight, e.Bounds );
                TextRenderer.DrawText( e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding );
            } else {
                e.DrawDefault = true;
            }
        }
    }
}
