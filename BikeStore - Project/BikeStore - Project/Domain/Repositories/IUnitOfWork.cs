using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore___Project.Domain.Repositories
{
   public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
