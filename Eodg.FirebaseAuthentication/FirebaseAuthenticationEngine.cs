using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Eodg.FirebaseAuthentication
{
    internal class FirebaseAuthenticationEngine
    {
        private JwtSecurityTokenHandler _tokenHandler;
        private FirebasePublicKeyHandler _publicKeyHandler;
        private FirebaseAuthenticationSettings _settings;

        public FirebaseAuthenticationEngine(FirebaseAuthenticationSettings settings)
        {
            _settings = settings;
            _tokenHandler = new JwtSecurityTokenHandler();
            _publicKeyHandler = new FirebasePublicKeyHandler(settings.PublicKeyUrl);
        }

        // TODO: Better handle this exception shit...
        public ClaimsPrincipal ValidateToken(string rawJwt, out SecurityToken token)
        {
            token = null;

            var jwt = _tokenHandler.ReadJwtToken(rawJwt);

            // Make sure email is verified... Not google specific, just to lock down this API to verified accounts
            if (!(bool)jwt.Payload["email_verified"])
            {
                throw new Exception("Email address not verified for account");
            }

            jwt.Payload.AddClaim(new Claim("nbf", ((int)jwt.Payload.Iat).ToString()));

            // Get public key
            X509SecurityKey publicKey;
            if (!_publicKeyHandler.TryGetKey(jwt.Header.Kid, out publicKey))
            {
                // TODO: There is no inner exception for this to reference...
                throw new Exception("Invalid kid supplied in token.");
            }

            // verify key
            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = publicKey,
                ValidAudience = _settings.ProjectId,
                ValidIssuer = _settings.Issuer,
                ValidateLifetime = true
            };

            try
            {
                return _tokenHandler.ValidateToken(jwt.RawData, tokenValidationParameters, out token);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to validate token. See inner exception for details.", ex);
            }
        }
    }
}
