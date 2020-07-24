using System.ComponentModel;

namespace BikeStoreClient.Enums
{
    public enum EUserRoles : byte
    {
        [Description("Customer")]
        Customer = 1,

        [Description("Staff")]
        Staff = 2
    }
}
