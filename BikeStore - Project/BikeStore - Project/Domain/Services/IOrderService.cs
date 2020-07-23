using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services.Communication;

namespace BikeStore___Project.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<OrderResponse> SaveAsync(Order order);
        Task<OrderResponse> UpdateAsync(int id, Order order, string eTag);
        Task<OrderResponse> DeleteAsync(int id);
        Task<Order> GetAsync(int id);

    }
}
