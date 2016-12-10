using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EODG.FirebaseAuthTool;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleSandboxTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jwt = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjIyMDdiYTI1M2NjYzdlOWVlODczYWM1NGRkOTg2MDljNTQ4NWYyOWUifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20va25vd3lvdXJrbm9ja291dCIsIm5hbWUiOiJKaW0gRWxyb2QiLCJwaWN0dXJlIjoiaHR0cHM6Ly9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tLy1YZFVJcWRNa0NXQS9BQUFBQUFBQUFBSS9BQUFBQUFBQUFBQS80MjUycnNjYnY1TS9waG90by5qcGciLCJhdWQiOiJrbm93eW91cmtub2Nrb3V0IiwiYXV0aF90aW1lIjoxNDgwOTgxMDk0LCJ1c2VyX2lkIjoiMTlsdXhlM2hYV01UZlZaVGNtTVQzeU1tazFjMiIsInN1YiI6IjE5bHV4ZTNoWFdNVGZWWlRjbU1UM3lNbWsxYzIiLCJpYXQiOjE0ODEwMDY5NTgsImV4cCI6MTQ4MTAxMDU1OCwiZW1haWwiOiJlbHJvZC5kZXZlbG9wbWVudEBnbWFpbC5jb20iLCJlbWFpbF92ZXJpZmllZCI6dHJ1ZSwiZmlyZWJhc2UiOnsiaWRlbnRpdGllcyI6eyJnb29nbGUuY29tIjpbIjExNDM2MjMwMjc1MzY0NDI1NjM2MCJdLCJlbWFpbCI6WyJlbHJvZC5kZXZlbG9wbWVudEBnbWFpbC5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJnb29nbGUuY29tIn19.Dl-IGK0bqM1C7h5onzfQAqzd35mxSl0nlu2onsKeqWHo9H7i09Ucu4i-wM_lNdgcKlU9eZH3c8Sa56bdH4bNQJChXE-u6PUrByj0a-75kCVAxBnCQ7UGHYOmAYtRDF58siVfeOkX1kARsVjayf7rnkIikOhbSbTCrE0tfLFqcblKSrzCv4Gfv3c89oGyKOGahZW0pS6F4Z7bJWU7yEXmooT7ayI0YZwtiZuhyq1tB4XqOnRfgOm8bEscWdgxtdbLr51oEjt9VANDnnEypwPH10639IhN2gMZ3ehO-CK4M5_fYYckxyPJt-bFRJpXrdQTGuOQ582Z09zxqTwSBIKtpA";
            var auth = new FirebaseAuth("knowyourknockout");
            
            SecurityToken token;
            if (auth.TryValidateToken(jwt, out token))
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("ERROR!!! :(");
            }

            Console.ReadLine();
        }
    }
}
