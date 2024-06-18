using Coding_Challenge.Context;
using Coding_Challenge.Exceptions;
using Coding_Challenge.Interfaces;
using Coding_Challenge.Models;

using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly AppDbContext _context;
        ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> Add(User items)
        {
            _context.Add(items);
            _context.SaveChanges();
            _logger.LogInformation("User added with id " + items.UserId);
            return items;
        }

        public async Task<User> Delete(int key)
        {
            var user = await GetAsync(key);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
                _logger.LogInformation("User deleted with id " + key);
                return user;
            }
            throw new NoSuchUserException();
        }

        public Task<User?> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(int key)
        {
            var users = await GetAsync();
            var user = users.FirstOrDefault(e => e.UserId == key);
            if (user != null)
            {
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<List<User>> GetAsync()
        {
            return _context.Users.ToList();
        }

        public async Task<User> Update(User items)
        {
            var user = await GetAsync(items.UserId);
            if (user != null)
            {
                _context.Entry<User>(items).State = EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation("User updated with id " + items.UserId);
                return user;
            }
            throw new NoSuchUserException();
        }
    }
}