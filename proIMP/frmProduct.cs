using System;

// SQLite
using System.Data.SQLite;
using System.Drawing;
using System.IO;

//MD5
using System.Security.Cryptography;
using System.Windows.Forms;

namespace proIMP {
    public partial class frmProduct : Form {
        public string productID = string.Empty;
        public string lastID = string.Empty;

        private string productImageID = string.Empty;
        private string productImage = string.Empty;

        public frmProduct( string productID = "" ) {
            InitializeComponent();

            this.productID = productID;
            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );

            switchLanguage();
        }

        private void frmProduct_Load( object sender, EventArgs e ) {
            productImage = string.Empty;
                    
            database.getCategoryList( cbProductCategory );

            if( productID == string.Empty ) {
                productImageID = string.Empty;

                tbProductID.Text = string.Empty;
                tbProductName.Text = string.Empty;
                cbProductCategory.SelectedIndex = -1;
                tbProductDesc.Text = string.Empty;
                cbProductUnit.SelectedIndex = -1;
                tbProductBarcode.Text = string.Empty;
                if( frmMain.setting.language == "tr" ) {
                    pbProductImage.Image = Properties.Resources.noimage_tr;
                } else {
                    pbProductImage.Image = Properties.Resources.noimage_en;
                }
            } else {
                tbProductID.Text = productID;

                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.CommandText = string.Format( 
                    "SELECT t1.product_id, t1.product_name, t1.product_catid, t3.category_name, t1.product_desc, t1.product_unit, t1.product_barcode, t1.product_imageid, t2.image_binary FROM product AS t1 LEFT JOIN image AS t2 ON t1.product_imageid = t2.image_id LEFT JOIN category AS t3 ON t1.product_catid = t3.category_id WHERE t1.product_id = '{0}'",
                    productID
                );

                try {
                    SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                    if( dbReader.HasRows ) {
                        dbReader.Read();

                        tbProductName.Text = dbReader[ "product_name" ].ToString();
                        tbProductDesc.Text = dbReader[ "product_desc" ].ToString();
                        tbProductBarcode.Text = dbReader[ "product_barcode" ].ToString();

                        cbProductCategory.SelectedIndex = cbProductCategory.FindStringExact( dbReader[ "category_name" ].ToString() );
                        switch( dbReader[ "product_unit" ].ToString() ) {
                            case "G": cbProductUnit.SelectedIndex = 0; break;
                            case "M": cbProductUnit.SelectedIndex = 1; break;
                            case "P": cbProductUnit.SelectedIndex = 2; break;
                        }

                        productImageID = dbReader[ "product_imageid" ].ToString();
                        if( productImageID.Length == 0 ) {
                            pbProductImage.Image = Properties.Resources.noimage_en;
                        } else {
                            pbProductImage.Image = functions.DeserializeImage( ( byte[ ] )dbReader[ "image_binary" ] );
                        }
                    }

                    dbReader.Close();
                } catch {

                }
            }
        }        

        private void btnSave_Click( object sender, EventArgs e ) {
            if( tbProductName.Text.Length > 0 && cbProductCategory.SelectedIndex != -1 ) {
                SQLiteCommand dbCommand = database.sqlCon.CreateCommand();
                dbCommand.Transaction = database.sqlCon.BeginTransaction();

                try {
                    if( productImage.Length > 0 && File.Exists( productImage ) ) {
                        productImageID = "";

                        string image_binary = functions.SerializeImage( productImage );
                        string image_md5 = functions.GetMd5Hash( MD5.Create(), image_binary );

                        dbCommand.CommandText = string.Format( 
                            "SELECT image_id FROM image WHERE image_md5 = '{0}'",
                            image_md5
                        );

                        SQLiteDataReader dbReader = dbCommand.ExecuteReader();
                        if( dbReader.HasRows ) {
                            dbReader.Read();

                            productImageID = dbReader[ 0 ].ToString();
                        }
                        dbReader.Close();

                        if( productImageID == string.Empty ) {
                            dbCommand.CommandText = string.Format( 
                                "INSERT INTO image (image_md5, image_binary) VALUES('{0}', '{1}')",
                                image_md5,
                                image_binary
                            );

                            dbCommand.ExecuteNonQuery();

                            dbCommand.CommandText = "SELECT last_insert_rowid()";
                            productImageID = ( ( long )dbCommand.ExecuteScalar() ).ToString();
                        }
                    }

                    string product_unit = string.Empty;
                    switch( cbProductUnit.SelectedIndex ) {
                        case 0: product_unit = "G"; break;
                        case 1: product_unit = "M"; break;
                        case 2: product_unit = "P"; break;

                        default:
                            dbCommand.Transaction.Rollback();

                            MessageBox.Show( frmMain.resMan.GetString( "errorProductUnit", frmMain.culInfo ) );                            

                            return;
                    }

                    if( tbProductID.Text.Length == 0 ) {
                        dbCommand.CommandText = "INSERT INTO product (product_name, product_catid, product_desc, product_unit, product_barcode, product_imageid) VALUES(@product_name, @product_catid, @product_desc, @product_unit, @product_barcode, @product_imageid)";
                    } else {
                        dbCommand.CommandText = "UPDATE product SET product_name = @product_name, product_catid = @product_catid, product_desc = @product_desc, product_unit = @product_unit, product_barcode = @product_barcode, product_imageid = @product_imageid WHERE product_id = @product_id";
                    }

                    dbCommand.Parameters.Add( new SQLiteParameter( "@product_name", tbProductName.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@product_catid", ( ( CategoryItem )cbProductCategory.SelectedItem ).CategoryID ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@product_desc", tbProductDesc.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@product_unit", product_unit ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@product_barcode", tbProductBarcode.Text ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@product_imageid", productImageID ) );
                    dbCommand.Parameters.Add( new SQLiteParameter( "@product_id", tbProductID.Text ) );

                    dbCommand.ExecuteNonQuery();

                    if( tbProductID.Text.Length == 0 ) {                    
                        dbCommand.CommandText = "SELECT last_insert_rowid()";
                        lastID = ( ( long )dbCommand.ExecuteScalar() ).ToString();
                    }

                    dbCommand.Transaction.Commit();
                } catch(Exception ex) {
                    dbCommand.Transaction.Rollback();

                    MessageBox.Show( frmMain.resMan.GetString( "couldNotSaveProduct", frmMain.culInfo ) + "\r\n\r\n" + ex.Message );

                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCategoryAdd_Click( object sender, EventArgs e ) {
           using( frmCategory category = new frmCategory() ) {
                if( category.ShowDialog() == DialogResult.OK ) {

                }

                database.getCategoryList( cbProductCategory );

                if( category.getLastID() != -1 ) {
                    for( int i = 0; i < cbProductCategory.Items.Count; i++ ) {
                        if( ( ( CategoryItem )cbProductCategory.Items[ i ] ).CategoryID == category.getLastID().ToString() ) {
                            cbProductCategory.SelectedIndex = i;

                            break;
                        }
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
                Title = frmMain.resMan.GetString( "searchImage", frmMain.culInfo )
            };

            if( ofdImage.ShowDialog() == DialogResult.OK ) {
                productImage = ofdImage.FileName;

                try {
                    pbProductImage.Image = Image.FromFile( productImage );
                } catch( Exception ex ) {
                    MessageBox.Show( frmMain.resMan.GetString( "couldNoReadImage", frmMain.culInfo ) + "\r\n\r\n" + ex.Message );
                }
            }
        }

        private void deleteToolStripMenuItem_Click( object sender, EventArgs e ) {
            if( frmMain.setting.language == "tr" ) {
                pbProductImage.Image = Properties.Resources.noimage_tr;
            } else {
                pbProductImage.Image = Properties.Resources.noimage_en;
            }
        }

        private void switchLanguage() {
            if( frmMain.setting.language == "tr" ) {
                pbProductImage.Image = Properties.Resources.noimage_tr;
            } else {
                pbProductImage.Image = Properties.Resources.noimage_en;
            }

            this.Text = frmMain.resMan.GetString( "frmProduct_Text", frmMain.culInfo );

            lblProductID.Text = frmMain.resMan.GetString( "lblProductID", frmMain.culInfo ) + " :";
            lblProductName.Text = frmMain.resMan.GetString( "lblProductName", frmMain.culInfo ) + " :";
            lblProductCategory.Text = frmMain.resMan.GetString( "lblProductCategory", frmMain.culInfo ) + " :";
            lblProductDesc.Text = frmMain.resMan.GetString( "lblProductDesc", frmMain.culInfo ) + " :";
            lblProductUnit.Text = frmMain.resMan.GetString( "lblProductUnit", frmMain.culInfo ) + " :";
            lblProductBarcode.Text = frmMain.resMan.GetString( "lblProductBarcode", frmMain.culInfo ) + " :";

            btnSave.Text = frmMain.resMan.GetString( "btnSave", frmMain.culInfo );
            btnCancel.Text = frmMain.resMan.GetString( "btnCancel", frmMain.culInfo );

            changeToolStripMenuItem.Text = frmMain.resMan.GetString( "changeToolStripMenuItem", frmMain.culInfo );
            deleteToolStripMenuItem.Text = frmMain.resMan.GetString( "deleteToolStripMenuItem", frmMain.culInfo );

            cbProductUnit.Items.Clear();
            cbProductUnit.Items.Add( frmMain.resMan.GetString( "unitG", frmMain.culInfo ) );
            cbProductUnit.Items.Add( frmMain.resMan.GetString( "unitM", frmMain.culInfo ) );
            cbProductUnit.Items.Add( frmMain.resMan.GetString( "unitP", frmMain.culInfo ) );
        }
    }
}


