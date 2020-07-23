using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Repositories
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> ListAsync();
        Task AddAsync(Shop shop);
        Task<Shop> FindByIdAsync(int id);
        void Remove(Shop shop);
        void Update(Shop shop);
    }
}
