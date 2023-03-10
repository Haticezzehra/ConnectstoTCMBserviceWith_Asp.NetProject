using Business.Abstract;
using DataAccess.Abstract;
using Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        ICurrencyDal currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            this.currencyDal = currencyDal;
        }
        public List<Currency> GetAll()
        {
            return currencyDal.GetAll();
        }

        public Currency Add(Currency currency)
        {
            var forex = new Currency()
            {

                CurrencyCode = currency.CurrencyCode, //node.Attributes["CurrencyCode"].Value,
                Unit = currency.Unit,//     node["Unit"].InnerText,
                CurrencyName = currency.CurrencyName,
                ForexBuying = currency.ForexBuying,
                ForexSelling = currency.ForexSelling,
                BanknoteBuying = currency.BanknoteBuying,
                BanknoteSelling = currency.BanknoteSelling,
                Time = DateTime.Now,
            };
            return currencyDal.Add(forex);
        }

        public Currency Delete(Currency currency)
        {
            throw new NotImplementedException();
        }

        public Currency Get(int id)
        {
            throw new NotImplementedException();
        }



        public Currency Update(Currency currency)
        {
            throw new NotImplementedException();
        }
    }
}
