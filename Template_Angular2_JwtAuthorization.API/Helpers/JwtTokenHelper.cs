using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template_Angular2_JwtAuthorization.API.Helpers
{
    public class JwtTokenHelper
    {
        private static string _secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public static string EncodeToken(object obj)
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
                var payload = decoder.DecodeToObject<IDictionary<string, object>>(token, _secret, true);

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
            public IDictionary<string, object> TokenJson { get; set; }
            public string TokenString { get; set; }
        }
    }
}
