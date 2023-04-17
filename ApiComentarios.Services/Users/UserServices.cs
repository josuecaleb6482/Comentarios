using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.Entities.DTOs;
using ApiComentarios.Services.Auth;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public UserServices(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public Task<User> CreateUser(UserInfoDTO userInfo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserInfoDTO>> FindUser(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfoDTO> Login(string email, string pass)
        {
            var user = await _userRepository
                .Find(x => x.Email == email && x.Password == pass);

            if (user != null)
                return new UserInfoDTO()
                {
                    Email = user.Email,
                    Name = user.Nombre + " " + user.Apellidos,
                    Rol = user.Rol
                };

            return new UserInfoDTO();
        }
    }
}
