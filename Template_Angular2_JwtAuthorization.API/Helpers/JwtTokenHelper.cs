using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template_Angular2_JwtAuthorization.API.ViewModel;

namespace Template_Angular2_JwtAuthorization.API.Helpers
{
    public class JwtTokenHelper
    {
        private static string _secret = "GQDst!S!scKsx0NHjPOuXOYg5Mbekasdka12d2ld!!J1XT0uFiwDVvVBrk";

        public static string EncodeToken(UserViewModel obj)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(obj, _secret);

            return token;
        }

        public static DecodedToken DecodeToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, _secret, verify: true);
                var payload = decoder.DecodeToObject<UserViewModel>(token, _secret, true);

                return new DecodedToken { IsValid = true, TokenJson = payload, TokenString = json };
            }
            catch (TokenExpiredException)
            {
                return new DecodedToken { IsValid = false, ErrorMsg = "Token has expired" };
            }
            catch (SignatureVerificationException)
            {
                return new DecodedToken { IsValid = false, ErrorMsg = "Token has invalid signature" };
            }
        }

        public class DecodedToken
        {
            public bool IsValid { get; set; }
            public string ErrorMsg { get; set; }
            public UserViewModel TokenJson { get; set; }
            public string TokenString { get; set; }
        }
    }
}
