using System;
using Xunit;
using UserLogin.Controllers;
using UserLogin.Models;

namespace GarageSally.Tests
{
    public class LoginTests
    {
        private readonly LoginUser _LoginUser;

        public LoginTests()
        {
            _LoginUser = new LoginUser();
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
