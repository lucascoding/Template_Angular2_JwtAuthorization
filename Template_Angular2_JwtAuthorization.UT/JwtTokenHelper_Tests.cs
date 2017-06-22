using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Template_Angular2_JwtAuthorization.API.Helpers;
using Template_Angular2_JwtAuthorization.API.ViewModel;

namespace Template_Angular2_JwtAuthorization.UT
{
    [TestClass]
    public class JwtTokenHelper_Tests
    {
        [TestMethod]
        public void EncodeAndDecode_Pass()
        {
            var userVmFaker = new Faker<UserViewModel>();
            userVmFaker.RuleFor(x => x.Email, f => "myEmail");
            userVmFaker.RuleFor(x => x.Password, f => "myPassword");
            userVmFaker.RuleFor(x => x.Username, f => "myUsername");

            String token = JwtTokenHelper.EncodeToken(userVmFaker);
            var decodedToken = JwtTokenHelper.DecodeToken(token);

            Assert.AreEqual("myEmail", decodedToken.TokenJson.Email);
            Assert.AreEqual("myPassword", decodedToken.TokenJson.Password);
            Assert.AreEqual("myUsername", decodedToken.TokenJson.Username);
        }
    }
}
