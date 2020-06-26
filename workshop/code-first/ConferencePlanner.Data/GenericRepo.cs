using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.Data
{
    public class GenericRepo<TEntity> : IRepository<TEntity> where TEntity : class

    {
        internal ApplicationDbContext context;

        public GenericRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public TEntity Get(int id)
        {
            return context.Find<TEntity>(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Remove(int id)
        {
            context.Remove<TEntity>(context.Find<TEntity>(id));
        }

        public void Save(TEntity entityToSave)
        {
            context.Add<TEntity>(entityToSave);
        }
    }
}