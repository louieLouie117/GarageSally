using System;
using Xunit;
using UserLogin.Controllers;
using UserLogin.Models;

namespace GarageSally.Tests
{
    public class RegTests
    {
        private readonly RegUser _RegUser;

        public RegTests()
        {
            _RegUser = new RegUser();
        }

        [Fact]
        public void TestUserReg_Exist()
        {
            // check for user in db
            // assert true
        }

        [Fact]
        public void TestUserReg_NotExist()
        {
            // check for user in db
            // assert false
        }
    }
}
