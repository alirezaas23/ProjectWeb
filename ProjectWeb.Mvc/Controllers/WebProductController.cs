using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.ViewModels.WebDeisgnViewModels;
using ProjectWeb.Domain.Models;

namespace ProjectWeb.Mvc.Controllers
{
    [Authorize(Roles = "ادمین")]
    public class WebProductController : Controller
    {
        private readonly IWebProductInterface _webProductInterface;
        private readonly IUploadFileInterface _uploadFileInterface;

        public WebProductController(IWebProductInterface webProductInterface, IUploadFileInterface uploadFileInterface)
        {
            _webProductInterface = webProductInterface;
            _uploadFileInterface = uploadFileInterface;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var WebProducts = _webProductInterface.WebProductsList();
            ViewBag.Message = TempData["Message"];
            return View(WebProducts);
        }

        [HttpGet]
        public IActionResult AddWebProduct()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
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
        public IActionResult DeleteProductPost(int id)
        {
            _webProductInterface.DeleteProduct(id);
            TempData["Message"] = "محصول مورد نظر با موفقیت حذف شد.";
            return RedirectToAction(nameof(Index));
        }
    }
}