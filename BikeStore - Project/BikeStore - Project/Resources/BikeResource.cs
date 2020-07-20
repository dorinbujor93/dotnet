using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Resources
{
    public class BikeResource
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public EFrameType FrameType { get; set; }
        public EFrameSize FrameSize { get; set; }
        public CategoryResource Category { get; set; }
        public int BikeOwner { get; set; }


    }

}

