using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Data.Entities;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Services
{
    public interface IBikeService
    {
        Task<IEnumerable<Bike>> ListAsync();
    }
}
