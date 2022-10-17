
using MessagePack;

namespace RoyalNet.Enums
{
    public enum CustomerStatusEnum
    { 

        [Key("Beginner")]
        Beginner,
        [Key("Reseller")]
        Reseller,
        [Key("VIP")]
        VIP
    }
}
