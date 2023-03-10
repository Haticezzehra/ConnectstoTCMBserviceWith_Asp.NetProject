using DataAccessLayer.Abstract;
using Entitiess;
using System.Data.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;



namespace DataAccessLayer.Concrete
{
    public class CurrencyDal : ICurrencyDal
    {
        public List<Currency> GetAll(Expression<Func<Currency, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return filter == null
                ? context.Set<Currency>().ToList()
                 : context.Set<Currency>().Where(filter).ToList();

            }
        }
        public Currency Get(Expression<Func<Currency, bool>> filter)
        {
            using (var context = new Context())
            {
                return context.Set<Currency>().SingleOrDefault(filter);
            }


        }
        public Currency Add(Currency entity)
        {
            using (var context = new Context())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public Currency Update(Currency entity)
        {
            using (var context = new Context())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return entity;

            }
        }
        public void Delete(Currency entity)
        {
            using (var context = new Context())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();


            }
        }
    }
}