﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> ListAsync();
        Task AddAsync(Order order);
        Task<Order> FindByIdAsync(int id);
        void Update(Order order);
        void Remove(Order order);
    }
}