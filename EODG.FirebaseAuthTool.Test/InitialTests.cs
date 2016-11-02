using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EODG.FirebaseAuthTool.Test
{
    public class InitialTests
    {
        //public InitialTests()
        //{
        //}
        private string _testToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjFjZjgyZWY3YWI0YzUzZDUzN2U5MTMxOWVmYmJjYzgyMGFjYjAwN2YifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20va25vd3lvdXJrbm9ja291dCIsIm5hbWUiOiJKaW0gRWxyb2QiLCJwaWN0dXJlIjoiaHR0cHM6Ly9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tLy1YZFVJcWRNa0NXQS9BQUFBQUFBQUFBSS9BQUFBQUFBQUFBQS80MjUycnNjYnY1TS9waG90by5qcGciLCJhdWQiOiJrbm93eW91cmtub2Nrb3V0IiwiYXV0aF90aW1lIjoxNDc0NTQ4MjAyLCJ1c2VyX2lkIjoiMTlsdXhlM2hYV01UZlZaVGNtTVQzeU1tazFjMiIsInN1YiI6IjE5bHV4ZTNoWFdNVGZWWlRjbU1UM3lNbWsxYzIiLCJpYXQiOjE0NzQ5NDg3MDMsImV4cCI6MTQ3NDk1MjMwMywiZW1haWwiOiJlbHJvZC5kZXZlbG9wbWVudEBnbWFpbC5jb20iLCJlbWFpbF92ZXJpZmllZCI6dHJ1ZSwiZmlyZWJhc2UiOnsiaWRlbnRpdGllcyI6eyJnb29nbGUuY29tIjpbIjExNDM2MjMwMjc1MzY0NDI1NjM2MCJdLCJlbWFpbCI6WyJlbHJvZC5kZXZlbG9wbWVudEBnbWFpbC5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJnb29nbGUuY29tIn19.NcTzQ-hTOMU_segAtI3j55d1Wkp2E8ohCMp8uXTm8dGG-w_xeqa_DYs7LhyZIXHUkoqUyogG0NVoWQnr9lygze0om3LvBiaqpLwtwEgzpGoAEUBtYK_8DqFd2lf7wX6E9tNzXi2EwDAPHhcvq7-6W4QmdhQ8VPqCIEPvfYhv5xuOyuIMkZrE5nKLX4WsnG9kJxuN1YIC2-Ku15za9JuzJpW8evo52-OXqWoA0Uz95w1g_BimxGuw4lDVhai7dyEU75uvRCtPGCZT5HbhSxhgFnxNihh-6PfBoyBoZjTBHSGihTfrM7JWLkhh8sTpPI8Jn4aQKvfdBl6zLikbp5K2Mg";
        private string _testUid = "19luxe3hXWMTfVZTcmMT3yMmk1c2";

        [Fact]
        public void Test1()
        {
            var auth = FirebaseAuth.GetInstance();

            var x = auth.ValidateToken(_testToken, _testUid);

            Assert.True(x);
        }
    }
}
