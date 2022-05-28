using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QV.CORE.EF
{
    public class EfRepository<TContext, TEntity> : IRepository<TEntity>
            where TContext : DbContext, new()
            where TEntity : class, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var res = context.Set<TEntity>().SingleOrDefault(filter);
                return res;
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> Filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(Filter).ToList();
            }
        }

        public int Insert(TEntity model)
        {
            using (var context = new TContext())
            {
                var Inserted = context.Entry(model);
                Inserted.State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public int Remove(Expression<Func<TEntity, bool>> Filter)
        {
            using (var Context = new TContext())
            {
                var Record = Context.Set<TEntity>().FirstOrDefault(Filter);
                if (Record != null)
                {
                    var Removed = Context.Entry(Record);
                    Removed.State = EntityState.Deleted;
                    return Context.SaveChanges();
                }
                return 0;
            }
        }

        public int RemoveByID(TEntity model)
        {
            using (var Context = new TContext())
            {
                var Removed = Context.Entry(model);
                Removed.State = EntityState.Deleted;
                return Context.SaveChanges();
            }
        }

        public int SaveChanges()
        {
            using (var Context = new TContext())
            {
                return Context.SaveChanges();
            }
        }

        public int Update(TEntity model)
        {
            using (var Context = new TContext())
            {
                var Removed = Context.Entry(model);
                Removed.State = EntityState.Modified;
                return Context.SaveChanges();
            }
        }
    }
}
