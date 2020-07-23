using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task AddAsync(Bike bike)
        {
            await _context.Bikes.AddAsync(bike);
        }
        public async Task<Bike> FindByIdAsync(int id)
        {
            return await _context.Bikes.FindAsync(id);
        }

        public void Update(Bike bike)
        {
            _context.Bikes.Update(bike);
        }
        public void Remove(Bike bike)
        {
            _context.Bikes.Remove(bike);
        }
    }
}
