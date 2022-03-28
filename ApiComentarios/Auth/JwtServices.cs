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
        private readonly string _audience;
        private readonly string _issuer;

        public JwtServices(IConfiguration configuration)
        {
            secret = configuration.GetSection("JWT").GetSection("ClaveSecreta").Value;
            _expDate = configuration.GetSection("JWT").GetSection("ExperationDate").Value;
            _audience = configuration.GetSection("JWT").GetSection("Audience").Value;
            _issuer = configuration.GetSection("JWT").GetSection("Issuer").Value;
        }

        public string GenerateSecurityToken(string email, string name, string role)
        {
            //Header
            var symetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret));
            var signingCredentials = new SigningCredentials(
                symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //var jwt = new JwtServices(_configuration);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Email, name),
                new Claim(ClaimTypes.Role, role)
            };

            //Payload
            var payload = new JwtPayload
            (
                _issuer,
                _audience,
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(double.Parse(_expDate))
            );

            var token = new JwtSecurityToken(header, payload);
            var tokenHandleder =  new JwtSecurityTokenHandler();

            return tokenHandleder.WriteToken(token);
        }
    }
    
}