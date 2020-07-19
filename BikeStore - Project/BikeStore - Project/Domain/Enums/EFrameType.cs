using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore___Project.Domain.Enums
{
    public enum EFrameType : byte
    {
        [Description("AL")]
        Aluminum = 1,

        [Description("CF")]
        Carbon = 2,

        [Description("T")]
        Titanium = 3,

        [Description("S")]
        Steel = 4
    }
}
