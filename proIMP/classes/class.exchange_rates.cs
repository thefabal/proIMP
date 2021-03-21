using System;
using System.Collections.Generic;

namespace proIMP {
    public class exchange_rates {
        public DateTime date;
        public Dictionary<string, currency> exchanges;

        public static exchange_rates getCurrencyExchange( DateTime? dt = null ) {
            string[ ] exchange = new string[ ] { "USD", "EUR" };

            exchange_rates result = new exchange_rates {
                exchanges = new Dictionary<string, currency>()
            };
            System.Xml.XmlDocument document = new System.Xml.XmlDocument();

            if( dt == null ) {
                try {
                    document.Load( "http://www.tcmb.gov.tr/kurlar/today.xml" );
                } catch {
                    return result;
                }
            } else {
                while( true ) {
                    try {
                        document.Load( string.Format( "http://www.tcmb.gov.tr/kurlar/{0}{1:D2}/{2:D2}{1:D2}{0}.xml", dt.Value.Year, dt.Value.Month, dt.Value.Day ) );

                        break;
                    } catch {
                        dt = dt.Value.AddDays( -1 );
                    }
                }
            }

            result.date = Convert.ToDateTime( document.SelectSingleNode( "//Tarih_Date" ).Attributes[ "Tarih" ].Value );
            for( int i = 0; i < exchange.Length; i++ ) {
                result.exchanges[ exchange[ i ] ] = new currency() {
                    ForexBuying = Convert.ToDouble( document.SelectSingleNode( "Tarih_Date/Currency[@Kod='" + exchange[ i ] + "']/BanknoteBuying" ).InnerXml ),
                    ForexSelling = Convert.ToDouble( document.SelectSingleNode( "Tarih_Date/Currency[@Kod='" + exchange[ i ] + "']/BanknoteSelling" ).InnerXml )
                };
            }

            result.exchanges[ "TL" ] = new currency() {
                ForexBuying = 1,
                ForexSelling = 1
            };

            return result;
        }
    }
}
