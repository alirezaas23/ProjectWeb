using System.Collections.Generic;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.Account;
using ProjectWeb.Mvc.ActionFilters;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.Security;
using ProjectWeb.Application.Services;

namespace ProjectWeb.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        #region Ctor

        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IUserService _userService;

        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager, ICaptchaValidator captchaValidator, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _captchaValidator = captchaValidator;
            _userService = userService;
        }

        #endregion

        #region Register

        [HttpGet("Register")]
        [RedirectToHomeIfLoggedInActionFilter]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha موفق نبود. لطفا مجدد تلاش کنید.";
                return View(model);
            }

            var result = await _userService.RegisterUser(model);

            switch (result)
            {
                case RegisterResult.EmailExist:
                    TempData[ErrorMessage] = "ایمیل وارد شده از قبل وجود دارد.";
                    break;
                case RegisterResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد. ایمیلی حاوی لینک فعالسازی حساب کاربری برای شما ارسال شد.";
                    return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        #endregion

        #region Activation Email

        [HttpGet("Email-Activation/{emailActivationCode}")]
        public async Task<IActionResult> ActivationEmail(string emailActivationCode)
        {
            var result = await _userService.ActivationEmail(emailActivationCode);
            if (!result)
            {
                TempData[ErrorMessage] = "عملیات فعالسازی با خطا مواجه شد";
            }

            else
            {
                TempData[SuccessMessage] = "حساب کاربری با موفقیت فعال شد.";
            }

            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region Login

        [HttpGet("Login")]
        [RedirectToHomeIfLoggedInActionFilter]
        public IActionResult Login(string ReturnUrl = "")
        {
            var result = new LoginViewModel();

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                result.ReturnUrl = ReturnUrl;
            }

            return View(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha موفق نبود. لطفا مجدد تلاش کنید.";
                return View(model);
            }

            var result = await _userService.CheckUserForLoggedIn(model);

            switch (result)
            {
                case LoginResult.UserIsBan:
                    TempData[WarningMessage] = "دسترسی شما به سایت مسدود می باشد.";
                    break;
                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری با مشخصات وارد شده یافت نشد.";
                    break;
                case LoginResult.EmailNotActivated:
                    TempData[WarningMessage] = "برای وارد شدن به سایت حساب کاربری خود را تایید کنید.";
                    break;
                case LoginResult.Success:
                    var user = await _userService.GetUserByEmail(model.Email);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties { IsPersistent = model.RememberMe };

                    await HttpContext.SignInAsync(principal, properties);
                    TempData[SuccessMessage] = "خوش آمدید.";

                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);

                    return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        #endregion

        #region Logout

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Forgot Password

        [HttpGet("Forgot-Password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha موفق نبود. لطفا مجدد تلاش کنید.";
                return View(model);
            }

            var result = await _userService.ForgotPassword(model);
            switch (result)
            {
                case ForgotPasswordResult.UserIsBan:
                    TempData[WarningMessage] = "دسترسی شما به سایت مسدود می باشد.";
                    break;
                case ForgotPasswordResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری با مشخصات وارد شده یافت نشد.";
                    break;
                case ForgotPasswordResult.Success:
                    TempData[SuccessMessage] = "ایمیلی حاوی لینک بازیابی کلمه عبور برای شما ارسال شد.";
                    return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        #endregion

        #region Reset Password

        [HttpGet("Reset-Password/{activationCode}")]
        public async Task<IActionResult> ResetPassword(string activationCode)
        {
            var result = await _userService.GetUserByActivationCode(activationCode);
            if (result == null) return NotFound();

            return View(new ResetPasswordViewModel()
            {
                ActivationCode = activationCode
            });
        }

        [HttpPost("Reset-Password/{activationCode}")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha موفق نبود. لطفا مجدد تلاش کنید.";
                return View(model);
            }

            var result = await _userService.ResetPassword(model);
            switch (result)
            {
                case ResetPasswordResult.UserIsBan:
                    TempData[WarningMessage] = "دسترسی شما به سایت مسدود می باشد.";
                    break;
                case ResetPasswordResult.UserNotFound:
                    TempData[ErrorMessage] = "بازیابی کلمه عبور با خطا مواجه شد.";
                    break;
                case ResetPasswordResult.Success:
                    TempData[SuccessMessage] = "بازیابی کلمه عبور با موفقیت انجام شد.";
                    return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        #endregion

        #region Show Profile

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ShowProfile(string id)
        {
            ViewBag.Message = TempData["Message"];
            var user = await _userManager.FindByIdAsync(id);
            if (string.IsNullOrEmpty(id)) return NotFound();
            if (user == null) return NotFound();
            var userModel = new ShowProfileViewModel()
            {
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            if (user.PhoneNumber == null)
            {
                ViewBag.Warning = "لطفا شماره تماس خود را در قسمت ویرایش حساب ثبت کنید";
            }
            return View(userModel);
        }

        #endregion

        #region Confirm Account

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AccountConfirm(string userId, int productId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userModel = new AccountConfirmViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id,
                UserName = user.UserName,
                WebProductId = productId
            };
            return View(userModel);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("AccountConfirm")]
        public async Task<IActionResult> AccountConfirmPost(AccountConfirmViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return NotFound();
            user.AccountConfirm = true;
            await _userManager.UpdateAsync(user);
            TempData["Message"] = "حساب کاربری شما تایید شد. با تشکر.";
            return RedirectToAction("WebProductInfo", "WebProduct", new { id = model.WebProductId });
        }

        #endregion
    }
}
