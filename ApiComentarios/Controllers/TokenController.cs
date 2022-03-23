using ApiComentarios.WebApi.Auth;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;  

namespace ApiComentarios.WebApi.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]  
    public class TokenController : ControllerBase
    {
        private IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string GetToken()
        {
            var jwt = new JwtServices(_configuration);
            var token = jwt.GenerateSecurityToken("fake@mail.com");
            return token;
        }
    }   
}