using System.ComponentModel;

namespace BikeStoreClient.Enums
{
    public enum EGender : byte
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female = 2,

        [Description("Other")]
        Other = 3

    }
}
