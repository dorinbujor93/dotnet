using System.ComponentModel;

namespace BikeStoreClient.Enums
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
