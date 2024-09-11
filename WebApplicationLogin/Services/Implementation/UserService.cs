using Microsoft.EntityFrameworkCore;
using WebApplicationLogin.Models;
using WebApplicationLogin.Services.Contract;

namespace WebApplicationLogin.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext; // Reference to the database

        public UserService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<User> GetUser(string email, string key)
        {
            User getUser = await _dbContext.Users.Where(u => u.UEmail == email && u.UKey == key)
                .FirstOrDefaultAsync();

            return getUser;
        }

        public async Task<User> SaveUser(User model)
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
