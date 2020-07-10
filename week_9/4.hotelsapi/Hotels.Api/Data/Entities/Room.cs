using System.Collections.Generic;

namespace Hotels.Api.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Room
    {


        public long Id { get; set; }
        public long HotelId { get; set; }

        [Required]
        [StringLength(10)]

        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
