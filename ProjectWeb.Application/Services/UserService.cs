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
    public class UserService : IUserService
    {
        #region Ctor

        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        #endregion

        #region Register

        public async Task<RegisterResult> RegisterUser(RegisterViewModel model)
        {
            if (await _userRepository.IsEmailExist(model.Email.Trim().ToLower().SanitizeText()))
            {
                return RegisterResult.EmailExist;
            }

            var password = PasswordHelper.EncodePasswordMd5(model.Password.SanitizeText());

            var user = new User()
            {
                Email = model.Email.Trim().ToLower().SanitizeText(),
                Password = password,
                ActivationCode = CodeGenerators.CreateActivationCode(),
                Avatar = PathTools.UserAvatar
            };

            await _userRepository.CreateUser(user);
            await _userRepository.Save();

            #region Send Activation Code

            var userEmail = user.Email.Split("@")[0];

            var body = @$"
                <div style='direction: rtl; font-size: 18px;'>
                    <h3>{userEmail} عزیز،</h3>
                    <p>ثبت نام شما با موفقیت انجام شد.</p>
                    <div>برای دسترسی به سایت و فعال سازی حساب کاربری خود روی لینک زیر بزنید : </div>
                    <a style='background-color: green; color: white; display:block; padding: 10px 0; text-decoration: none; border-radius: 15px; width:100%; text-align: center; margin-top: 15px;' 
                        href='{PathTools.SiteAddress}/Email-Activation/{user.ActivationCode}'>فعالسازی حساب کاربری</a>
                </div>";

            await _emailService.SendEmail(user.Email, "فعالسازی حساب کاربری", body);

            #endregion

            return RegisterResult.Success;
        }

        #endregion

        #region Email Activation

        public async Task<bool> ActivationEmail(string emailActivationCode)
        {
            var user = await _userRepository.GetUserByActivationCode(emailActivationCode);
            if (user == null) return false;

            if (user.IsDelete || user.IsBan) return false;

            user.IsEmailConfirmed = true;
            user.ActivationCode = CodeGenerators.CreateActivationCode();

            await _userRepository.UpdateUser(user);
            await _userRepository.Save();

            return true;
        }

        #endregion

        #region Login

        public async Task<LoginResult> CheckUserForLoggedIn(LoginViewModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email.Trim().ToLower().SanitizeText());
            if (user == null || user.IsDelete) return LoginResult.UserNotFound;

            var hashedPassword = PasswordHelper.EncodePasswordMd5(model.Password.SanitizeText());

            if (hashedPassword != user.Password) return LoginResult.UserNotFound;

            if (user.IsBan) return LoginResult.UserIsBan;

            if (!user.IsEmailConfirmed) return LoginResult.EmailNotActivated;

            return LoginResult.Success;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email.Trim().ToLower().SanitizeText());
        }

        #endregion

        #region Forgot Password

        public async Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email.Trim().ToLower().SanitizeText());
            if (user == null || user.IsDelete) return ForgotPasswordResult.UserNotFound;

            if (user.IsBan) return ForgotPasswordResult.UserIsBan;

            #region Send Email

            var userEmail = user.Email.Split("@")[0];

            var body = @$"
                <div style='direction: rtl; font-size: 18px;'>
                    <h3>{userEmail} عزیز ،</h3>
                    <div>برای بازیابی کلمه عبور خود روی لینک زیر بزنید : </div>
                    <a style='background-color: green; color: white; display:block; padding: 10px 0; text-decoration: none; border-radius: 15px; width:100%; text-align: center; margin-top: 15px;'
                        href='{PathTools.SiteAddress}/Reset-Password/{user.ActivationCode}'>بازیابی کلمه عبور</a>
                </div>";

            await _emailService.SendEmail(user.Email, "بازیابی کلمه عبور", body);

            #endregion

            return ForgotPasswordResult.Success;
        }

        #endregion

        #region Reset Password

        public async Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userRepository.GetUserByActivationCode(model.ActivationCode.SanitizeText());
            if (user == null || user.IsDelete) return ResetPasswordResult.UserNotFound;
            if (user.IsBan) return ResetPasswordResult.UserIsBan;

            var password = PasswordHelper.EncodePasswordMd5(model.Password.SanitizeText());

            user.Password = password;
            user.ActivationCode = CodeGenerators.CreateActivationCode();
            user.IsEmailConfirmed = true;

            await _userRepository.UpdateUser(user);
            await _userRepository.Save();

            return ResetPasswordResult.Success;
        }

        public async Task<User> GetUserByActivationCode(string activationCode)
        {
            return await _userRepository.GetUserByActivationCode(activationCode);
        }

        #endregion
    }
}