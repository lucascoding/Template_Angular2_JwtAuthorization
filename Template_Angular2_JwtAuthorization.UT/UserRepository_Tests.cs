using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template_Angular2_JwtAuthorization.API.Data;
using Template_Angular2_JwtAuthorization.API.Models;
using Template_Angular2_JwtAuthorization.API.ViewModel;

namespace Template_Angular2_JwtAuthorization.UT
{
    [TestClass]
    public class UserRepository_Tests
    {
        private ApplicationDbContext _ctx;
        private IUserRepository _userRepo;

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
            var user = new UserViewModel { Email = "x@x.x", Username = "xx", Password = "xxx" };

            _userRepo.RegisterUser(user);

            var dbUser = _ctx.Users.First(x => x.Username == "xx");

            Assert.AreEqual("xx", dbUser.Username);
        }

        [TestMethod]
        public void LogUser_Pass()
        {
            var user = _ctx.Users.Add(new User { Email = "x@x.x", Username = "name", Password = "pass" });
            _ctx.SaveChanges();

            var userVm = _userRepo.LogUser(new UserViewModel { Username = "name", Password = "pass" });

            Assert.AreNotEqual(null, userVm);
        }

        [TestMethod]
        public void LogUser_Fail()
        {
            var userVm = _userRepo.LogUser(new UserViewModel { Username = "name", Password = "pass" });

            Assert.AreEqual(null, userVm);
        }

    }
}
