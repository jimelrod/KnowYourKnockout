using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Business
{
    public class AccountLogic
    {
        private IKnowYourKnockoutDataApi _dataApi;

        public AccountLogic(IKnowYourKnockoutDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        public void SignUp(User user)
        {

        }

        public void SignIn(User user)
        {

        }
    }
}
