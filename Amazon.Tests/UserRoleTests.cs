using Amazon.Repositories;

namespace Amazon.Tests
{
    public class UserRoleTests
    {
        UserRoleRepository? userRoleRepository = new();

        [Fact]
        public void CreateUserRoleTest()
        {
            Assert.NotNull(userRoleRepository.CreateUserRoles());
        }

        [Fact]
        public void GetUserRolesTest()
        {
            Assert.NotEmpty(userRoleRepository.GetUserRoles());
        }
    }
}