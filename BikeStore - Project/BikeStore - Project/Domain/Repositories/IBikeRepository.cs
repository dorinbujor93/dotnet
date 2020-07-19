using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Repositories
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> ListAsync();
    }
}
