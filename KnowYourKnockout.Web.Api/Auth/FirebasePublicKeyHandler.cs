using KnowYourKnockout.Web.Api.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KnowYourKnockout.Web.Api.Auth
{
    // TODO: FIGURE OUT THIS ASYNCH SHIT!!!!

    /// <summary>
    /// 
    /// </summary>
    public class FirebasePublicKeyHandler
    {
        private string _keyUrl;
        private Dictionary<string, string> _certificatesByKid;
        private DateTime _previousPublicKeyCallTime;
        private TimeSpan _maxAge;

        public FirebasePublicKeyHandler(IOptions<FirebaseAuthSettings> firebaseAuthSettings)
        {
            _keyUrl = firebaseAuthSettings.Value.PublicKeyUrl;
            GetCertificates().Wait();
        }

        public bool TryGetKey(string kid, out X509SecurityKey publicKey)
        {
            publicKey = null;

            if (CertificateLinkIsExpired())
            {
                GetCertificates().Wait();
            }

            if (!_certificatesByKid.ContainsKey(kid))
            {
                return false;
            }

            publicKey = new X509SecurityKey(new X509Certificate2(Encoding.UTF8.GetBytes(_certificatesByKid[kid])));

            return true;
        }

        public IEnumerable<SecurityKey> GetAllKeys()
        {
            var publicKeys = new List<X509SecurityKey>();

            if (CertificateLinkIsExpired())
            {
                GetCertificates().Wait();
            }

            new List<string>(_certificatesByKid.Values).ForEach(publicKey =>
            {
                publicKeys.Add(new X509SecurityKey(new X509Certificate2(Encoding.UTF8.GetBytes(publicKey))));
            });

            return publicKeys;
        }

        private bool CertificateLinkIsExpired()
        {
            return DateTime.Now - _previousPublicKeyCallTime > _maxAge;
        }

        private async Task GetCertificates()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    _previousPublicKeyCallTime = DateTime.Now;

                    var response = await client.GetAsync(_keyUrl);
                    response.EnsureSuccessStatusCode();

                    _maxAge = (TimeSpan)response.Headers.CacheControl.MaxAge;

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    _certificatesByKid = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringResponse);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request exception: {ex.Message}");
                    throw ex;
                }
            }
        }
    }
}
