using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferencePlanner.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Get();

        void Save(TEntity entityToSave);

        void Remove(int id);
    }
}