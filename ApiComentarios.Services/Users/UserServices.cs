using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.Entities.DTOs;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserServices(IRepository<User> userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(UserInfoDTO userInfo)
        {
            var user = _mapper.Map<User>(userInfo);

            await _userRepository.Save(user);

            return user;
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.GetById(userId);
            await _userRepository.Delete(userId);
        }

        public async Task<IList<UserInfoDTO>> FindUser(string name)
        {
            var user = await _userRepository.SearchList(x => x.Nombre == name);

            return _mapper.Map<List<UserInfoDTO>>(user);
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
