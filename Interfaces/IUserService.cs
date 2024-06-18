using Coding_Challenge.Models.DTO;
using Coding_Challenge.Models;

namespace Coding_Challenge.Interfaces
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);
        public Task<User> RemoveUser(int id);
        public Task<User> GetUser(int userId);
        public Task<List<User>> GetAllUser();
        public Task<User> UpdateUser(User user);
        public Task<User> Login(LoginDTO loginDTO);
    }
}
