using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models.Account;
using ProjectWeb.Infra.Data.Context;
using System.Threading.Tasks;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Ctor

        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<bool> IsEmailExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.Equals(email));
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByActivationCode(string activationCode)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.ActivationCode.Equals(activationCode));
        }

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task<User> GetUserById(long userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }
    }
}
