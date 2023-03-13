using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                SourceCurrency.currencySource();
                Thread.Sleep(1000 * 60 * 5);
            }
        }
    }
}
