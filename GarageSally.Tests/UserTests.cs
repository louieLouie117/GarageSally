using System;
using Xunit;
using UserLogin.Controllers;
using UserLogin.Models;

namespace GarageSally.Tests
{
    public class UserTests
    {
        private readonly LoginUser _loginUser;

        public UserTests()
        {
            _loginUser = new LoginUser();
        }

        [Fact]
        public void TestUserLogin_Exist()
        {
            // check for user in db
            // assert true
        }

        [Fact]
        public void TestUserLogin_NotExist()
        {
            // check for user in db
            // assert false
        }
    }
}
