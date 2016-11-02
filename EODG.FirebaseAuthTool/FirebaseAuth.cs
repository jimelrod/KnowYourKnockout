using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;

namespace EODG.FirebaseAuthTool
{
    public class FirebaseAuth
    {
        private const string FIREBASE_PUBLIC_KEY_URL = "https://www.googleapis.com/robot/v1/metadata/x509/securetoken@system.gserviceaccount.com";
        private const string EXPECTED_ALGORITHM = "RS256";
        private const string FIREBASE_PROJECT_ID = "knowyourknockout";

        private static FirebaseAuth _instance;
        private readonly string _issuer;

        private Dictionary<string, string> _certificatesByKey;
        private DateTime _previousPublicKeyCallTime;
        private TimeSpan _maxAge;
        private JwtSecurityTokenHandler _tokenHandler;

        private FirebaseAuth()
        {
            _previousPublicKeyCallTime = DateTime.Now;
            _maxAge = new TimeSpan(0);
            _issuer = $"https://securetoken.google.com/{FIREBASE_PROJECT_ID}";
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public static FirebaseAuth GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FirebaseAuth();
            }

            return _instance;
        }

        public bool ValidateToken(string rawToken, string uid)
        {
            var token = _tokenHandler.ReadJwtToken(rawToken);

            var parameters = new TokenValidationParameters
            {
                ValidAudience = FIREBASE_PROJECT_ID,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidateIssuer = true
            };

            SecurityToken outputToken;
            var x = _tokenHandler.ValidateToken(rawToken, new TokenValidationParameters(), out outputToken);
            var y = (JwtSecurityToken)outputToken;


            return
                VerifyHeader(token) &&
                VerifyPayload(token, uid) &&
                VerifySignature(token);
        }

        public bool ValidateShit()
        {
            return true;
        }

        #region Verification

        private bool VerifyHeader(JwtSecurityToken token)
        {
            if (token.Header.Alg != EXPECTED_ALGORITHM)
            {
                return false;
            }

            if (DateTime.Now - _previousPublicKeyCallTime > _maxAge)
            {
                GetPublicKeys().Wait();
            }

            return _certificatesByKey.ContainsKey(token.Header.Kid);
        }

        private bool VerifyPayload(JwtSecurityToken token, string uid)
        {
            return
                   // Verify expiration is in future
                   FromUnixTime((int)token.Payload.Exp) > DateTime.Now &&

                   // Verify issue time is in the past
                   DateTime.Now < FromUnixTime((int)token.Payload.Exp) &&

                   // Verify audience is firebase project id
                   token.Payload.Aud.Contains(FIREBASE_PROJECT_ID) &&

                   // verify issuer is valid
                   token.Payload.Iss == _issuer &&

                   // verify sub matches uid
                   token.Payload.Sub == uid;
        }

        private bool VerifySignature(JwtSecurityToken token)
        {
            var x = token.Header.Kid;


            return true;
        }

        #endregion

        #region Helpers

        private async Task GetPublicKeys()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(FIREBASE_PUBLIC_KEY_URL);
                    response.EnsureSuccessStatusCode();
                    _maxAge = (TimeSpan)response.Headers.CacheControl.MaxAge;
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    _certificatesByKey = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringResponse);
                }
                catch(HttpRequestException hEx)
                {
                    Console.WriteLine($"Request exception: {hEx.Message}");
                }
                
            }
        }

        /// <summary>
        /// http://stackoverflow.com/a/2883645/2285245
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns></returns>
        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        #endregion
    }
}
