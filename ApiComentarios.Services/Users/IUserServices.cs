using ApiComentarios.Entities.DTOs;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services.Users
{
    public interface IUserServices
    {
        Task<User> CreateUser(UserInfoDTO userInfo);
        Task<UserInfoDTO> Login(string email, string pass);
        Task DeleteUser(int userId);
        Task<IList<UserInfoDTO>> FindUser(string name);
    }
}