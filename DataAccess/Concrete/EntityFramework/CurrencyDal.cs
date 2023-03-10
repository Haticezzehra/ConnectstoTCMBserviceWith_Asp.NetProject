//using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitiess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CurrencyDal : ICurrencyDal
    {
        public List<Currency> GetAll(Expression<Func<Currency, bool>> filter = null)
        {
            using (CurrencyContext context = new CurrencyContext())
            {
                return filter == null
                ? context.Set<Currency>().ToList()
                 : context.Set<Currency>().Where(filter).ToList();

            }
        }
        public Currency Get(Expression<Func<Currency, bool>> filter)
        {
            using (var context = new CurrencyContext())
            {
                return context.Set<Currency>().SingleOrDefault(filter);
            }


        }
        public Currency Add(Currency entity)
        {
            using (var context = new CurrencyContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public Currency Update(Currency entity)
        {
            using (var context = new CurrencyContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;

            }
        }
        public void Delete(Currency entity)
        {
            using (var context = new CurrencyContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }
        }





    }
}
