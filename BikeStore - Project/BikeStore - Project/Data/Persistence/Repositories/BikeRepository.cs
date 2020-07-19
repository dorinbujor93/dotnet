using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Data.Entities;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Data.Persistence.Repositories
{
    public class BikeRepository : BaseRepository, IBikeRepository
    {
        public BikeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Bike>> ListAsync()
        {
            return await _context.Bikes.Include(p => p.Category)
                .ToListAsync();
        }
    }
}
