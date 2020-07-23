using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services.Communication;

namespace BikeStore___Project.Domain.Services
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> ListAsync();
        Task<ShopResponse> SaveAsync(Shop shop);
        Task<ShopResponse> UpdateAsync(int id, Shop shop, string eTag);
        Task<ShopResponse> DeleteAsync(int id);
        Task<Shop> GetAsync(int id);

    }
}
