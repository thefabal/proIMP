﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// SQLite
using System.Data.SQLite;

//MD5
using System.Security.Cryptography;

namespace proIMP {
    public partial class frmProduct:Form {
        public string strProductID = string.Empty;
        public string lastID = string.Empty;

        private string strProductImageID = string.Empty;
        private string strProductImage = string.Empty;

        public frmProduct() {
            InitializeComponent();
        }

        private void frmProduct_Load( object sender, EventArgs e ) {
            getListCategory();

            strProductImage = string.Empty;

            if( strProductID == string.Empty ) {
                strProductImageID = string.Empty;

                tbProductID.Text = string.Empty;
                tbProductName.Text = string.Empty;
                cbProductCategory.SelectedIndex = -1;
                tbProductDesc.Text = string.Empty;
                cbProductUnit.SelectedIndex = -1;
                tbProductBarcode.Text = string.Empty;
                pbProductImage.Image = Properties.Resources.noimage_en;
            } else {
                tbProductID.Text = strProductID;

                SQLiteCommand dbCommand = new SQLiteCommand("SELECT t1.product_id, t1.product_name, t1.product_catid, t3.category_name, t1.product_desc, t1.product_unit, t1.product_barcode, t1.product_imageid, t2.image_binary FROM product AS t1 LEFT JOIN image AS t2 ON t1.product_imageid = t2.image_id LEFT JOIN category AS t3 ON t1.product_catid = t3.category_id WHERE t1.product_id = '" + strProductID + "'", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                if( dbReader.Read() ) {
                    tbProductName.Text = dbReader[ "product_name" ].ToString();
                    tbProductDesc.Text = dbReader[ "product_desc" ].ToString();
                    tbProductBarcode.Text = dbReader[ "product_barcode" ].ToString();

                    cbProductCategory.SelectedIndex = cbProductCategory.FindStringExact( dbReader[ "category_name" ].ToString() );
                    cbProductUnit.SelectedIndex = cbProductUnit.FindStringExact( dbReader[ "product_unit" ].ToString() );

                    strProductImageID = dbReader[ "product_imageid" ].ToString();
                    if( strProductImageID.Length == 0 ) {
                        pbProductImage.Image = Properties.Resources.noimage_en;
                    } else {
                        pbProductImage.Image = frmMain.DeserializeImage( (byte[])dbReader[ "image_binary" ] );
                    }
                }
            }
        }

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbProductName.Text.Length > 0 && cbProductCategory.SelectedIndex != -1 ) {
                SQLiteCommand dbCommand = new SQLiteCommand() {
                    Connection = frmMain.sqlCon,
                    Transaction = frmMain.sqlCon.BeginTransaction()
                };

                try {
                    if( strProductImage.Length > 0 && File.Exists( strProductImage ) ) {
                        strProductImageID = "";

                        string strImage = frmMain.SerializeImage( strProductImage );
                        string strMD5 = frmMain.GetMd5Hash(MD5.Create(), strImage);
                        dbCommand.CommandText = "SELECT image_id FROM image WHERE image_md5 = '" + strMD5 + "'";
                        SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                        while( dbReader.Read() ) {
                            strProductImageID = dbReader[ 0 ].ToString();

                            break;
                        }
                        dbReader.Close();

                        if( strProductImageID == string.Empty ) {
                            dbCommand.CommandText = "INSERT INTO image (image_id, image_md5, image_binary) VALUES(NULL, '" + strMD5 + "', '" + strImage + "')";
                            dbCommand.ExecuteNonQuery();

                            dbCommand.CommandText = "SELECT last_insert_rowid()";
                            strProductImageID = ( (long)dbCommand.ExecuteScalar() ).ToString();
                        }
                    }

                    if( tbProductID.Text.Length == 0 ) {
                        dbCommand.CommandText = "INSERT INTO product (product_id, product_name, product_catid, product_desc, product_unit, product_barcode, product_imageid) VALUES(NULL, '" + tbProductName.Text.Replace( "'", "''" ) + "', '" + ( (CategoryItem)cbProductCategory.SelectedItem ).CategoryID + "', '" + tbProductDesc.Text.Replace( "'", "''" ) + "', '" + cbProductUnit.SelectedItem.ToString() + "', '" + tbProductBarcode.Text.Replace( "'", "''" ) + "', '" + strProductImageID + "')";
                        dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "SELECT last_insert_rowid()";
                        lastID = ( (long)dbCommand.ExecuteScalar() ).ToString();
                    } else {
                        dbCommand.CommandText = "UPDATE product SET product_name = '" + tbProductName.Text.Replace( "'", "''" ) + "', product_catid = '" + ( (CategoryItem)cbProductCategory.SelectedItem ).CategoryID + "', product_desc = '" + tbProductDesc.Text.Replace( "'", "''" ) + "', product_unit = '" + cbProductUnit.SelectedItem.ToString() + "', product_barcode = '" + tbProductBarcode.Text.Replace( "'", "''" ) + "', product_imageid = '" + strProductImageID + "' WHERE product_id = '" + tbProductID.Text + "'";
                        dbCommand.ExecuteNonQuery();
                    }
                    dbCommand.Transaction.Commit();
                } catch {
                    dbCommand.Transaction.Rollback();
                    MessageBox.Show( "Could not save product to database. Please try again." );

                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCategoryAdd_Click( object sender, EventArgs e ) {
            if( frmMain.category.ShowDialog() == DialogResult.OK ) {

            }

            getListCategory();

            if( frmMain.category.getLastID() != -1 ) {
                for( int i = 0; i < cbProductCategory.Items.Count; i++ ) {
                    if( ( (CategoryItem)cbProductCategory.Items[ i ] ).CategoryID == frmMain.category.getLastID().ToString() ) {
                        cbProductCategory.SelectedIndex = i;

                        break;
                    }
                }
            }
        }

        private void changeToolStripMenuItem_Click( object sender, EventArgs e ) {
            OpenFileDialog ofdImage = new OpenFileDialog() {
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "png",
                Filter = "Image Files (*.bmp, *.jpg, *.gif, *.png, *.tiff)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF",
                Title = "Search for image files"
            };

            if( ofdImage.ShowDialog() == DialogResult.OK ) {
                strProductImage = ofdImage.FileName;

                try {
                    pbProductImage.Image = Image.FromFile( strProductImage );
                } catch(Exception ex) {
                    MessageBox.Show( "Error on reading product image.\r\n\r\n" + ex.Message );
                }
            }
        }

        private void deleteToolStripMenuItem_Click( object sender, EventArgs e ) {
            pbProductImage.Image = Properties.Resources.noimage_en;
        }

        private void getListCategory() {
            try {
                SQLiteCommand dbCommand = new SQLiteCommand("SELECT category_id, category_name FROM category ORDER BY category_name", frmMain.sqlCon);
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                cbProductCategory.Items.Clear();
                while( dbReader.Read() ) {
                    cbProductCategory.Items.Add( new CategoryItem( dbReader[ 0 ].ToString(), dbReader[ 1 ].ToString() ) );
                }
                dbReader.Close();
            } catch(Exception ex) {
                MessageBox.Show( ex.Message );
            }
        }
    }
}


