using Entitiess;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mapping
{
    public class CurrencyMap : EntityTypeConfiguration<Currency>
    {
        public CurrencyMap()
        {
            ToTable(@"Currencies", @"dbo");
            HasKey(x => x.ID);
            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.CurrencyCode).HasColumnName("CurrencyCode");
            Property(x => x.Unit).HasColumnName("Unit");
            Property(x => x.CurrencyName).HasColumnName("CurrencyName");
            Property(x => x.ForexBuying).HasColumnName("ForexBuying");
            Property(x => x.ForexSelling).HasColumnName("ForexSelling");
            Property(x => x.BanknoteBuying).HasColumnName("BanknoteBuying");
            Property(x => x.BanknoteSelling).HasColumnName("BanknoteSelling");
            Property(x => x.Time).HasColumnName("Time");

        }


    }
}
