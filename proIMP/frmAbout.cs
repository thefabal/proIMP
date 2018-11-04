using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace proIMP {
    public partial class frmAbout:Form {
        public frmAbout() {
            InitializeComponent();
        }

        private void frmAbout_Load( object sender, EventArgs e ) {
            lblProductName.Text += String.Format( " v{0}", Assembly.GetExecutingAssembly().GetName().Version );
            lblBuildTime.Text = GetLinkerTime( Assembly.GetExecutingAssembly().Location ).ToString( "dd.MM.yyyy HH:mm:ss" );
        }

        public static DateTime GetLinkerTime( string filePath, TimeZoneInfo target = null ) {
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            byte[] buffer = new byte[2048];

            FileStream stream = new FileStream( filePath, FileMode.Open, FileAccess.Read );
            stream.Read( buffer, 0, 2048 );

            int offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            int secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            DateTime linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            TimeZoneInfo tz = target ?? TimeZoneInfo.Local;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        private void labelURL_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            System.Diagnostics.Process.Start( "http://www.progedia.com" );
        }

        private void btnOK_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
