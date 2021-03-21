using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

//MD5
using System.Security.Cryptography;

namespace proIMP {
    class functions {
        public static bool checkListViewCheckbox( ListView lv ) {
            for( int i = 0; i < lv.Items.Count; i++ ) {
                if( lv.Items[ i ].Checked == true ) {
                    return true;
                }
            }

            return false;
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

            try {
                return new Bitmap( ms );
            } catch {
                return null;
            }
        }

        public static string GetMd5Hash( MD5 md5Hash, string input ) {
            byte[ ] data = md5Hash.ComputeHash( Encoding.UTF8.GetBytes( input ) );
            StringBuilder sBuilder = new StringBuilder();
            for( int i = 0; i < data.Length; i++ ) {
                sBuilder.Append( data[ i ].ToString( "x2" ) );
            }

            return sBuilder.ToString();
        }

    }
}
