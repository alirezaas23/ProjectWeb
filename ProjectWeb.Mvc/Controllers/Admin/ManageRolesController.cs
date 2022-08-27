using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers.Admin
{
    [Authorize(Roles = "ادمین")]
    public class ManageRolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public ManageRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsRoleInUse(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return Json(true);
            }
            else
            {
                return Json("این مقام از قبل وجود دارد");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var roleModel = new ShowRoleViewModel()
            {
                RoleId = id,
                RoleName = role.Name,
            };
            return View(roleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteRole")]
        public async Task<IActionResult> DeleteRolePost(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            await _roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var roleModel = new ShowRoleViewModel()
            {
                RoleId = role.Id,
                RoleName = role.Name
            };

            return View(roleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(ShowRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                if (role == null) return NotFound();
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);
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
        public IActionResult SearchRoles(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("Index", "ManageRoles");
            }
            var user = _roleManager.Roles.Where(r => r.Name.Contains(name));
            return View("Index", user);
        }
    }
}
