using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Data.Persistence.Repositories
{
    public class AccessoryRepository : BaseRepository, IAccessoryRepository
    {
        public AccessoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Accessory>> ListAsync()
        {
            return await _context.Accessories.Include(p => p.Bike)
                .ToListAsync();
        }
    }
}
