using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.ViewModels.WebDeisgnViewModels;
using ProjectWeb.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers
{
    public class WebProductController : Controller
    {
        private readonly IWebProductInterface _webProductInterface;
        private readonly IUploadFileInterface _uploadFileInterface;
        private readonly UserManager<UserApp> _userManager;

        public WebProductController(IWebProductInterface webProductInterface, IUploadFileInterface uploadFileInterface, UserManager<UserApp> userManager)
        {
            _webProductInterface = webProductInterface;
            _uploadFileInterface = uploadFileInterface;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "ادمین")]
        public IActionResult Index()
        {
            var WebProducts = _webProductInterface.WebProductsList();
            ViewBag.Message = TempData["Message"];
            return View(WebProducts);
        }

        [HttpGet]
        [Authorize(Roles = "ادمین")]
        public IActionResult AddWebProduct()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "ادمین")]
        public IActionResult AddWebProduct(AddWebProductViewModel model)
        {
            WebProduct webProduct = new WebProduct();
            webProduct.WebProductName = model.WebProductName;
            webProduct.WebProductPrice = model.WebProductPrice;
            webProduct.WebProductDeliverDate = model.WebProductDeliverDate;
            webProduct.WebProductDescription = model.WebProductDescription;
            webProduct.WebProductImage = _uploadFileInterface.uploadPhoto(model.WebProductImage);
            _webProductInterface.AddWebProduct(webProduct);
            TempData["Message"] = "محصول جدید با موفقیت ثبت شد.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "ادمین")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _webProductInterface.FindById(id);
            var modelProduct = new ShowWebProductViewModel()
            {
                WebProductDeliverDate = product.WebProductDeliverDate,
                WebProductDescription = product.WebProductDescription,
                WebProductID = product.WebProductID,
                WebProductImage = product.WebProductImage,
                WebProductName = product.WebProductName,
                WebProductPrice = product.WebProductPrice
            };
            return View(modelProduct);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteProduct")]
        [Authorize(Roles = "ادمین")]
        public IActionResult DeleteProductPost(int id)
        {
            _webProductInterface.DeleteProduct(id);
            TempData["Message"] = "محصول مورد نظر با موفقیت حذف شد.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "ادمین")]
        public IActionResult EditProduct(int id)
        {
            var product = _webProductInterface.FindById(id);
            var productModel = new EditWebProductViewModel()
            {
                ImageUrl = product.WebProductImage,
                WebProductDeliverDate = product.WebProductDeliverDate,
                WebProductDescription = product.WebProductDescription,
                WebProductID = product.WebProductID,
                WebProductName = product.WebProductName,
                WebProductPrice = product.WebProductPrice
            };
            return View(productModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "ادمین")]
        public IActionResult EditProduct(EditWebProductViewModel model)
        {
            var product = new WebProduct();
            product.WebProductDeliverDate = model.WebProductDeliverDate;
            product.WebProductDescription = model.WebProductDescription;
            product.WebProductID = model.WebProductID;
            product.WebProductImage = _uploadFileInterface.uploadPhoto(model.WebProductImage);
            product.WebProductName = model.WebProductName;
            product.WebProductPrice = model.WebProductPrice;
            _webProductInterface.EditProduct(product);
            TempData["Message"] = "محصول مورد نظر با موفقیت ویرایش شد.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> WebProductInfo(int id)
        {
            ViewBag.Message = TempData["Message"];
            var product = _webProductInterface.FindById(id);
            var user =  await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user.AccountConfirm == false)
            {
                return RedirectToAction("AccountConfirm", "Account", new {userId = user.Id, productId = id });
            }
            return View(product);
        }
    }
}