using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiComentarios.WebApi.Middelwere
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection service, IConfiguration configuration)
        {
            var secret = configuration.GetSection("JWT").GetSection("ClaveSecreta").Value;
            var key = Encoding.ASCII.GetBytes(secret);
            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("JWT").GetSection("ValidIssuer").Value,
                    ValidAudience = configuration.GetSection("JWT").GetSection("ValidAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            return service;

        }
    }
}