using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectWeb.Domain.Models.Account;

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
