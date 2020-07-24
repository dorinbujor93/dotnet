using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStoreClient.Enums;

namespace BikeStoreClient.Models
{
    public class BikeModel
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public EFrameType FrameType { get; set; }
        public EFrameSize FrameSize { get; set; }
        public int CategoryId { get; set; }
        public int BikeOwnerId { get; set; }
    }
}
