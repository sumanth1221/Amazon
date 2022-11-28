
using MessagePack;

namespace Amazon.Enums
{
    // Roles definition
    public enum UserRoleEnum
    {

        [Key("Admin")]
        Admin,
        [Key("Customer")]
        Customer 
    }
}
