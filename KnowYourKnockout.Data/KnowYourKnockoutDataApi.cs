using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Data
{
    public class KnowYourKnockoutDataApi : IKnowYourKnockoutDataApi
    {
        public KnowYourKnockoutDataApi(IKnowYourKnockoutRepository<User, int> userRepository)
        {
            UserRepository = userRepository;
        }

        public IKnowYourKnockoutRepository<User, int> UserRepository { get; private set; }
    }
}
