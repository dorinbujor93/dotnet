namespace ConferencePlanner.Services
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConferencePlanner.Entities;

public interface IGenericRepository<TEntity> where TEntity : class
{

    Task<TEntity> Get(object id);

    Task<TEntity> Save(TEntity entityToSave);

    Task<TEntity> Remove(object id);
}
}