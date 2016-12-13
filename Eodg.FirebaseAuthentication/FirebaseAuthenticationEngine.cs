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
                ValidAudience = _settings.ProjectId,
                ValidIssuer = _settings.Issuer,
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
