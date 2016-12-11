using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Claims;

namespace EODG.FirebaseAuthTool
{
    /// <summary>
    /// Using https://firebase.google.com/docs/auth/admin/verify-id-tokens
    /// as reference for validation
    /// </summary>
    public class FirebaseAuth
    {
        // TODO: Refactor to use config... somehow...
        private const string EXPECTED_ALGORITHM = "RS256";
        private const string PUBLIC_KEY_URL = "https://www.googleapis.com/robot/v1/metadata/x509/securetoken@system.gserviceaccount.com";

        private string _projectId;
        private JwtSecurityTokenHandler _tokenHandler;
        private FirebasePublicKeyHandler _publicKeyHandler;

        public FirebaseAuth(string projectId)
        {
            _projectId = projectId;
            _tokenHandler = new JwtSecurityTokenHandler();
            _publicKeyHandler = new FirebasePublicKeyHandler(PUBLIC_KEY_URL);
        }

        public bool TryValidateToken(string rawJwt, out SecurityToken token)
        {
            token = null;

            var jwt = _tokenHandler.ReadJwtToken(rawJwt);

            jwt.Payload.AddClaim(new Claim("nbf", ((int)jwt.Payload.Iat).ToString()));

            // Get public key
            X509SecurityKey publicKey;
            if (!_publicKeyHandler.TryGetKey(jwt.Header.Kid, out publicKey))
            {
                return false;
            }

            // verify key
            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = publicKey,
                ValidAudience = _projectId,
                ValidIssuer = $"https://securetoken.google.com/{_projectId}",
                ValidateLifetime = true
            };

            try
            {
                _tokenHandler.ValidateToken(jwt.RawData, tokenValidationParameters, out token);
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Don't know if we need to do anything with the exception...
                return false;
            }
        }

        public ClaimsPrincipal ValidateToken(string rawJwt, out SecurityToken token)
        {
            token = null;

            var jwt = _tokenHandler.ReadJwtToken(rawJwt);

            jwt.Payload.AddClaim(new Claim("nbf", ((int)jwt.Payload.Iat).ToString()));

            // Get public key
            X509SecurityKey publicKey;
            if (!_publicKeyHandler.TryGetKey(jwt.Header.Kid, out publicKey))
            {
                return null;
            }

            // verify key
            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = publicKey,
                ValidAudience = _projectId,
                ValidIssuer = $"https://securetoken.google.com/{_projectId}",
                ValidateLifetime = true
            };

            try
            {
                return _tokenHandler.ValidateToken(jwt.RawData, tokenValidationParameters, out token);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
