using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiess
{
    public class Currency:IEntity
    {
        public int ID { get; set; }
        public string CurrencyCode { get; set; }
        public string Unit { get; set; }
        public string CurrencyName { get; set; }
        public string ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;
    }

}

