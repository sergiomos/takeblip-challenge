using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using Take.Api.Challenge.Models;


namespace Take.Api.Challenge.Services.Interfaces
{
    [Header("User-Agent", "github.com/sergiomos")]
    public interface IGitHubClient {
        [Get("/orgs/{organization}/repos")]
        Task<List<Repository>> GetRepositories(
            [Path] string organization,
            [Query("per_page")] int reposAmount, 
            [Query] string language,
            [Query("sort")] string sortBy,
            [Query] string direction
        );
    }
}
