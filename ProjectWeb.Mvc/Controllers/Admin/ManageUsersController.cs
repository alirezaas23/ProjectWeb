using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.ViewModels;
using ProjectWeb.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers.Admin
{
    [Authorize(Roles = "ادمین")]
    public class ManageUsersController : Controller
    {
        private UserManager<UserApp> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public ManageUsersController(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users.
                Select(u => new ShowUsersViewModel()
                {
                    UserId = u.Id,
                    UserEmail = u.Email,
                    UserName = u.UserName
                }).ToList();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var userModel = new ShowUserViewModel()
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserName = user.UserName
            };

            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(ShowUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) return NotFound();
                user.UserName = model.UserName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var userModel = new ShowUserViewModel()
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserName = user.UserName
            };
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(ShowUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return NotFound();
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = _roleManager.Roles.ToList();
            var userModel = new AddUserToRoleViewModel() { UserId = user.Id };
            foreach (var role in roles)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userModel.UserRoles.Add(new UserRolesViewModel { RoleName = role.Name });
                }
            }
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null) return NotFound();
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) return NotFound();
                var requestRoles = model.UserRoles.Where(u => u.IsSelected)
                    .Select(u => u.RoleName).ToList();
                var result = await _userManager.AddToRolesAsync(user, requestRoles);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> DeleteUserFromRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var userModel = new AddUserToRoleViewModel() { UserId = user.Id };
            var roles = _roleManager.Roles.ToList();
            foreach (var role in roles)
            {
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userModel.UserRoles.Add(new UserRolesViewModel { RoleName = role.Name });
                }
            }

            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserFromRole(AddUserToRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null) return NotFound();
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) return NotFound();
                var requestRoles = model.UserRoles.Where(u => u.IsSelected)
                    .Select(u => u.RoleName).ToList();
                var result = await _userManager.RemoveFromRolesAsync(user, requestRoles);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }

            return View(model);
        }
    }
}
