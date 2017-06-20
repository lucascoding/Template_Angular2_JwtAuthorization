using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template_Angular2_JwtAuthorization.API.Data;
using Template_Angular2_JwtAuthorization.API.Models;

namespace Template_Angular2_JwtAuthorization.UT
{
    [TestClass]
    public class UserRepository_Tests
    {
        private ApplicationDbContext _ctx;
        private UserRepository _userRepo;

        [TestInitialize]
        public void InitializeTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("dbName");

            _ctx = new ApplicationDbContext(optionsBuilder.Options);
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            _userRepo = new UserRepository(_ctx);
        }

        [TestMethod]
        public void RegisterUser()
        {
            var user = new User { Email = "x@x.x", Name = "xx", Password = "xxx" };

            _userRepo.RegisterUser(user);

            var dbUser = _ctx.Users.First(x => x.Name == "xx");

            Assert.AreEqual("xx", dbUser.Name);
        }
    }
}
