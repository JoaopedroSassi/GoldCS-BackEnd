﻿using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces
{
    public interface IWebTokenService
    {
        LoginResponse ReturnResponseLogin(User user);

    }
}
