using System.ComponentModel;

namespace BikeStoreClient.Enums
{
    public enum EAccessoryType : byte
    {
        [Description("Bell")]
        Bell = 1,

        [Description("Front Light")]
        FrontLight = 2,

        [Description("Rear Light")]
        RearLight = 3,

        [Description("White Reflector")]
        WhiteReflector = 4,
        
        [Description("Red Reflector")]
        RedReflector = 5,
        
        [Description("Cyclocomputer")]
        Cyclocomputer = 6
    }
}
