using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineFoodOrderingSystem.UserMicroservice.DataAccessLayer;

namespace OnlineFoodOrderingSystem.UserMicroservice.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task CreateUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await _userRepository.CreateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            user.UpdatedAt = DateTime.Now;

            await _userRepository.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}

