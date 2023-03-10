using Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICurrencyService
    {
        List<Currency> GetAll();

        Currency Get(int id);

        Currency Add(Currency currency);
        Currency Update(Currency currency);
        Currency Delete(Currency currency);

    }
}



