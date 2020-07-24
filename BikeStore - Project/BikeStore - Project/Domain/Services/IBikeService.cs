using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services.Communication;

namespace BikeStore___Project.Domain.Services
{
    public interface IBikeService
    {
        Task<IEnumerable<Bike>> ListAsync(CancellationToken token);
        Task<BikeResponse> SaveAsync(Bike bike);
        Task<BikeResponse> UpdateAsync(int id, Bike bike, string eTag);
        Task<BikeResponse> DeleteAsync(int id);
        Task<Bike> GetAsync(int id);

    }
}
