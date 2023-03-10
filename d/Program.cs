using CurrencyConsole;
///using DataAccess.Concrete.EntityFramework;
using Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CurrencyConsole
{
    using System.Threading;
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SourceCurrency.currencySource();
                Thread.Sleep(1000 * 60 * 5);
            }

        }
    }
}


