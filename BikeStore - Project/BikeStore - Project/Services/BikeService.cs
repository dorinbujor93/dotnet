using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using BikeStore___Project.Domain.Services;

namespace BikeStore___Project.Services
{
    public class BikeService: IBikeService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task<IEnumerable<Bike>> ListAsync()
        {
            return await _bikeRepository.ListAsync();
        }
    }
}
