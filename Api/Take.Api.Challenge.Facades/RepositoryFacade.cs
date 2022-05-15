using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Take.Api.Challenge.Facades.Interfaces;
using Take.Api.Challenge.Models;
using Take.Api.Challenge.Services.Interfaces;

namespace Take.Api.Challenge.Facades
{
    public class RepositoryFacade : IRepositoryFacade
    {
        // Injeção de depêndendicas
        private readonly IGitHubClient _gitHubClient;

        public RepositoryFacade(IGitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }

        public async Task<List<Repository>> GetRepositoriesAsync(
            string organization,
            int reposAmount,
            string language,
            string sortBy,
            string direction
            )
        {
            var response = await _gitHubClient.GetRepositories(
                 organization,
                 reposAmount,
                 language,
                 sortBy,
                 direction
                );

            return response;
        }
    }
}
