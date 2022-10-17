
using MessagePack;

namespace Amazon.Enums
{
    public enum UserRoleEnum
    {

        [Key("Admin")]
        Admin,
        [Key("Customer")]
        Customer 
    }
}
