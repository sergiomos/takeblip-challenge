using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Take.Api.Challenge.Models;

namespace Take.Api.Challenge.Facades.Interfaces
{
    public interface IRepositoryFacade
    {
        Task<List<Repository>> GetRepositoriesAsync(
            string organization,
            int reposAmount, 
            string language, 
            string sortBy,
            string direction
            );
    }
}
