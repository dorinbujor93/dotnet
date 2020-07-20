using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore___Project.Domain.Enums
{
    public enum EUserRoles : byte
    {
        [Description("Customer")]
        Customer = 1,

        [Description("Staff")]
        Staff = 2
    }
}
