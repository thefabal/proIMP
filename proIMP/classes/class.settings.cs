using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace proIMP {
    public class settings {
        public int productOrder { get; set; } = 0;
        
        public string localExchange = "TL";
        public string language = "en";
        public string database = Path.GetDirectoryName( Application.ExecutablePath ) + "\\db\\database.sqlite";

        public DateTime exchange_update = new DateTime( 1900, 1, 1 );
    }
}
