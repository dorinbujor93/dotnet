﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Repositories
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> ListAsync(CancellationToken token);
        Task AddAsync(Bike bike);
        Task<Bike> FindByIdAsync(int id);
        void Update(Bike bike);
        void Remove(Bike bike);
    }
}
