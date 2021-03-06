﻿using System;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Data.Repositories;

namespace KnowYourKnockout.Data
{
    public interface IKnowYourKnockoutDataApi
    {
        IKnowYourKnockoutRepository<User, int> UserRepository { get; }
    }
}