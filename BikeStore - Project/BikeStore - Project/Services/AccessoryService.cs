using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using BikeStore___Project.Domain.Services;

namespace BikeStore___Project.Services
{
    public class AccessoryService: IAccessoryService
    {
        private readonly IAccessoryRepository _accessoryRepository;

        public AccessoryService(IAccessoryRepository accessoryRepository)
        {
            _accessoryRepository = accessoryRepository;
        }

        public async Task<IEnumerable<Accessory>> ListAsync()
        {
            return await _accessoryRepository.ListAsync();
        }
    }
}
