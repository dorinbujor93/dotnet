using System.ComponentModel;

namespace BikeStoreClient.Enums
{
    public enum EFrameSize : byte
    {
        [Description("XS")]
        ExtraSmall = 1,

        [Description("S")]
        Small = 2,

        [Description("M")]
        Medium = 3,

        [Description("L")]
        Large = 4,
        
        [Description("XL")]
        ExtraLarge = 5,
    }
}
