using System.Collections.Generic;

namespace Hotels.Api.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Hotel
    {


        public long Id { get; set; }

        [Required]
        [StringLength(10)]

        public string Name { get; set; }

        [StringLength(10)]
        public string City { get; set; }

        public IList<Room> Rooms { get; set; }
    }
}
