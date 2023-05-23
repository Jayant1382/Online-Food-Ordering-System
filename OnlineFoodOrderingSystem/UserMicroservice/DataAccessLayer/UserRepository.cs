using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserMicroservice.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _dbContext.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw;
            }
        }

        public async Task CreateUser(User user)
        {
            try
            {
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw;
            }
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                user.UpdatedAt = DateTime.Now;

                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(id);

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw;
            }
        }
    }

    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
