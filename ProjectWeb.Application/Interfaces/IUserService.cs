using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectWeb.Application.Generators;
using ProjectWeb.Application.Security;
using ProjectWeb.Application.Services;
using ProjectWeb.Application.Statics;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models.Account;
using ProjectWeb.Domain.ViewModels.Account;

namespace ProjectWeb.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterResult> RegisterUser(RegisterViewModel model);
        Task<bool> ActivationEmail(string emailActivationCode);
        Task<LoginResult> CheckUserForLoggedIn(LoginViewModel model);
        Task<User> GetUserByEmail(string email);
        Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel model);
        Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel model);
        Task<User> GetUserByActivationCode(string activationCode);
    }
}
