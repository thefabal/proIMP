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
        public frmMain frmMain;

        public frmAbout( frmMain frmMain ) {
            InitializeComponent();

            this.frmMain = frmMain;
        }

        private void frmAbout_Load( object sender, EventArgs e ) {
            switchLanguage();

            lblProgramName.Text += String.Format( " v{0}", Assembly.GetExecutingAssembly().GetName().Version );
            lblBuildTime.Text = GetLinkerTime( Assembly.GetExecutingAssembly().Location ).ToString( "dd.MM.yyyy HH:mm:ss" );
        }

        private void switchLanguage( ) {
            this.Text = frmMain.resMan.GetString( "frmAbout_Text", frmMain.culInfo );
            lblProgramName.Text = frmMain.resMan.GetString( "mainForm_Text", frmMain.culInfo );
            lblAboutAuthor.Text = frmMain.resMan.GetString( "lblAboutAuthor", frmMain.culInfo ) + " :";
            lblBuildTimeText.Text = frmMain.resMan.GetString( "lblBuildTimeText", frmMain.culInfo ) + " :";
            lblLicence.Text = frmMain.resMan.GetString( "lblLicence", frmMain.culInfo );
            btnOK.Text = frmMain.resMan.GetString( "btnOK", frmMain.culInfo );
        }

        public static DateTime GetLinkerTime( string filePath ) {
            byte[] buffer = new byte[2048];

            FileStream stream = new FileStream( filePath, FileMode.Open, FileAccess.Read );
            stream.Read( buffer, 0, 2048 );

            int offset = BitConverter.ToInt32(buffer, 60);
            int secondsSince1970 = BitConverter.ToInt32(buffer, offset + 8);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return TimeZoneInfo.ConvertTimeFromUtc( epoch.AddSeconds( secondsSince1970 ), TimeZoneInfo.Local );
        }

        private void labelURL_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            System.Diagnostics.Process.Start( "http://www.progedia.com" );
        }

        private void btnOK_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
