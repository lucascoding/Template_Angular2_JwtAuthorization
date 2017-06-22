using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Template_Angular2_JwtAuthorization.API.Helpers;

namespace Template_Angular2_JwtAuthorization.UT
{
    [TestClass]
    public class JwtTokenHelper_Tests
    {
        [TestMethod]
        public void EncodeAndDecode_Pass()
        {
             var payload = new Dictionary<string, object>
                    {
                        { "claim1", 0 },
                        { "claim2", "claim2-value" }
                    };

            String token = JwtTokenHelper.EncodeToken(payload);
            var decodedToken = JwtTokenHelper.DecodeToken(token);
        }
    }
}
