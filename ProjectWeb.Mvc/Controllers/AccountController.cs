using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.ViewModels;
using ProjectWeb.Domain.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly ITicketInterface _ticketInterface;

        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager, ITicketInterface ticketInterface)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ticketInterface = ticketInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new RegisterViewModel
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserApp()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = false
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            model.ReturnUrl = returnUrl;
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به دلیل 5 بار ورود ناموفق به مدت 5 دقیقه قفل شد!";
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "نام کاربری یا کلمه عبور اشتباه است!");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json("اکانتی با این ایمیل وجود دارد");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json("اکانتی با این نام کاربری وجود دارد");
            }
        }

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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditAccount(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (string.IsNullOrEmpty(id)) return NotFound();
            if (user == null) return NotFound();
            var userModel = new EditAccountViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id,
                UserName = user.UserName
            };
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccount(EditAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) return NotFound();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["Message"] = "اطلاعات جدید با موفقیت ثبت شد";
                    return RedirectToAction("ShowProfile", "Account", new { id = user.Id });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }
            return View(model);
        }

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

        [HttpPost]
        public IActionResult ExternalLogins(string provider, string returnUrl)
        {
            var redirectUrl =
                Url.Action("ExternalLoginsCallBack", "Account", new { returnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginsCallBack(string returnUrl = null, string remoteError = null)
        {
            returnUrl =
                (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? returnUrl : Url.Content("~/");

            var loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if(remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
                return View("Login", loginViewModel);
            }

            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if(externalLoginInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingGetExternalLoginInfo", "مشکلی پیش آمد ! چند دقیقه دیگر امتحان کنید !");
                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, true, true);
            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);
            if(email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if(user == null)
                {
                    var userName = email.Split("@")[0];
                    user = new UserApp
                    {
                        UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };
                    await _userManager.CreateAsync(user);
                }
                await _userManager.AddLoginAsync(user, externalLoginInfo);
                await _signInManager.SignInAsync(user, true);
                return Redirect(returnUrl);
            }
            return View();
        }
    }
}
