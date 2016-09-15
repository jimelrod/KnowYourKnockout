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
        public KnowYourKnockoutDataApi(IKnowYourKnockoutRepository<User, Guid> userRepository)
        {
            UserRepository = userRepository;
        }

        public IKnowYourKnockoutRepository<User, Guid> UserRepository { get; private set; }
    }
}
