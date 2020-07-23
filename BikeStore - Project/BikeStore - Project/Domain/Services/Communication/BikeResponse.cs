using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Services.Communication
{
    public class BikeResponse : BaseResponse
    {
        public Bike Bike { get; private set; }

        private BikeResponse(bool success, string message, Bike bike) : base(success, message)
        {
            Bike = bike;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Bike">Saved bike.</param>
        /// <returns>Response.</returns>
        public BikeResponse(Bike bike) : this(true, string.Empty, bike)
        {
        }


        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BikeResponse(string message) : this(false, message, null)
        {
        }
    }
}