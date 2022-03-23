using System;  
using System.Text;  
using System.Security.Claims;  
using Microsoft.IdentityModel.Tokens;  
using System.IdentityModel.Tokens.Jwt;  
using Microsoft.Extensions.Configuration;

namespace ApiComentarios.WebApi.Auth
{
    public class JwtServices
    {
        private readonly string secret;
        private readonly string _expDate;

        public JwtServices(IConfiguration configuration)
        {
            secret = configuration.GetSection("JWT").GetSection("ClaveSecreta").Value;
            _expDate = configuration.GetSection("JWT").GetSection("ExperationDate").Value;
        }

        public string GenerateSecurityToken(string email)
        {
            var tokenHandleder =  new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new [] 
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandleder.CreateToken(tokenDescription);

            return tokenHandleder.WriteToken(token);
        }
    }
    
}