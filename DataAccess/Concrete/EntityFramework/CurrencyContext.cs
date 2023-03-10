using DataAccess.Concrete.EntityFramework.Mapping;
using Entitiess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext():base("name=CurrencyContext")
        {
            Database.SetInitializer<CurrencyContext>(null);
        }
        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CurrencyMap());
        }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true");
        }*/
        public DbSet<Currency> Currencies { get; set; }
    }

}
