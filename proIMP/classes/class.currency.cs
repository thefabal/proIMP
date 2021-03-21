using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proIMP {
    public class currency {
        public double ForexBuying { get; set; }
        public double ForexSelling { get; set; }

        public currency() {

        }

        public currency( double ForexBuying, double ForexSelling ) {
            this.ForexBuying = ForexBuying;
            this.ForexSelling = ForexSelling;
        }
    }
}
