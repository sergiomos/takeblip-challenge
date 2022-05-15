using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Take.Api.Challenge.Models;
using Take.Api.Challenge.Facades.Interfaces;
using Serilog;
using Microsoft.AspNetCore.Authorization;

namespace Take.Api.Challenge.Controllers
{
    /// <summary>
    /// Repositories controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoriesController : ControllerBase
    {
        // Injeção de depêndendicas
        private readonly IRepositoryFacade _repositoryFacade;
        private readonly ILogger _logger;

        /// <summary>
        /// Contructor.
        /// </summary>
        public RepositoriesController(IRepositoryFacade repositoryFacade, ILogger logger)
        {
            _repositoryFacade = repositoryFacade;
            _logger = logger;
        }

        /// <summary>
        /// Get github repositories from an organization
        /// </summary>
        /// <param name="organization">The organization's name</param>
        /// <param name="language">Code language of repositories</param>
        /// <param name="reposAmount">Amount of repositories to be returned</param>
        /// <param name="sortBy">Main property to be sorted (created, full_name, updated, pushed), </param>
        /// <param name="direction">Define direction of the sort(asc, desc)</param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Repository>>> GetRepositoriesAsync([FromQuery]
            string organization,
            string language,
            int reposAmount = 5,
            string sortBy = "created",
            string direction = "asc"
        )
        {
            try
            {

                if (string.IsNullOrWhiteSpace(organization))
                    return BadRequest("Organizations is required");

                if (string.IsNullOrWhiteSpace(language))
                    return BadRequest("Language is required");

                var result = await _repositoryFacade.GetRepositoriesAsync(
                     organization,
                     reposAmount,
                     language,
                     sortBy,
                     direction
                 );
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    
    }
}
