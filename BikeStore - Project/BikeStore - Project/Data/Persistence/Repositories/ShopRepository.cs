using System.Collections.Generic;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Data.Persistence.Repositories
{
    public class ShopRepository : BaseRepository, IShopRepository
    {
        public ShopRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Shop>> ListAsync()
        {
            return await _context.Shops.ToListAsync();
        }
         public async Task AddAsync(Shop shop)
        {
            await _context.Shops.AddAsync(shop);
        }

        public async Task<Shop> FindByIdAsync(int id)
        {
            return await _context.Shops.FindAsync(id);
        }

        public void Update(Shop shop)
        {
            _context.Entry(shop).State = EntityState.Modified;
            _context.Shops.Update(shop);
        }

        public void Remove(Shop shop)
        {
            _context.Shops.Remove(shop);
        }
    }
}
