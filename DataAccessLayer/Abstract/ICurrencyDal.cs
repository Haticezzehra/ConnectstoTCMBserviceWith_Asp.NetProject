using Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{

    public interface ICurrencyDal
    {
        List<Currency> GetAll(Expression<Func<Currency, bool>> filter = null);
        Currency Get(Expression<Func<Currency, bool>> filter);
        Currency Add(Currency entity);
        Currency Update(Currency entity);
        void Delete(Currency entity);
    }

}
