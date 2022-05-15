using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Take.Api.Challenge.Models.Requests;
using Take.Api.Challenge.Repositories;
using Take.Api.Challenge.Facades.Interfaces;

namespace Take.Api.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenFacade _tokenFacade;
        public LoginController(ITokenFacade tokenFacade)
        {
            _tokenFacade = tokenFacade;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginRequest model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null) 
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _tokenFacade.GenerateToken(user);

            user.Password = "";

            return new { user, token };

        }
    }
}
