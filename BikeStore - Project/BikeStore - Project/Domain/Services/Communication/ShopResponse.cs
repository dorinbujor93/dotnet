using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Services.Communication
{
    public class ShopResponse : BaseResponse
    {
        public Shop Shop { get; private set; }

        private ShopResponse(bool success, string message, Shop shop) : base(success, message)
        {
            Shop = shop;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Shop">Saved shop.</param>
        /// <returns>Response.</returns>
        public ShopResponse(Shop shop) : this(true, string.Empty, shop)
        {
        }


        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ShopResponse(string message) : this(false, message, null)
        {
        }
    }
}