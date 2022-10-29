using ProjectWeb.Domain.Models.Account;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsEmailExist(string email);
        Task CreateUser(User user);
        Task Save();
        Task<User> GetUserByActivationCode(string activationCode);
        Task UpdateUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(long userId);
    }
}
