using System;
using System.Collections.Generic;
using System.Text;

using Take.Api.Challenge.Models;

namespace Take.Api.Challenge.Facades.Interfaces
{
    public interface ITokenFacade
    {
        public string GenerateToken(User user);
    }
}
