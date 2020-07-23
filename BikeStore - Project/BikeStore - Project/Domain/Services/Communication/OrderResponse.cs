using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Services.Communication
{
    public class OrderResponse : BaseResponse
    {
        public Order Order { get; private set; }
        public OrderResponse(bool success, string message, Order order) : base(success, message)
        {
            Order = order;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Order">Saved order.</param>
        /// <returns>Response.</returns>
        public OrderResponse(Order order) : this(true, string.Empty, order)
        { }

        /// <summary>
        /// Creates am error response.  
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public OrderResponse(string message) : this(false, message, null)
        { }
    }
}