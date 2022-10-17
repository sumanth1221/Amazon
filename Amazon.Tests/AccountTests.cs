using Amazon.Controllers;
using Amazon.Data;
using Amazon.Models;
using Amazon.Repositories;

namespace Amazon.Tests
{
    public class AccountTests
    {
        private readonly AmazonContext? _context;

        [Fact]
        public void LoginTest()
        {
            AccountController? accountController = new(_context);
            Assert.NotNull(accountController.Login());
        }

        [Fact]
        public void SignupTest()
        {
            AccountController? accountController = new(_context);
            Assert.NotNull(accountController.Signup());
        }
    }
}