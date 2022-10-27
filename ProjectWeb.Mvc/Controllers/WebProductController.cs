using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Extensions;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.Statics;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.WebProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers
{
    public class WebProductController : BaseController
    {
        private readonly IWebProductInterface _webProductInterface;

        public WebProductController(IWebProductInterface webProductInterface, IUploadFileInterface uploadFileInterface)
        {
            _webProductInterface = webProductInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var webProducts = await _webProductInterface.WebProductsList();

            return View(webProducts);
        }

        [HttpGet]
        public IActionResult AddWebProduct()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWebProduct(AddWebProductViewModel model)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(model.WebProductImage.FileName);

            var validFormats = new List<string>()
            {
                ".png",
                ".jpg",
                ".jpeg",
                ".webp"
            };

            var result = model.WebProductImage.UploadFile(fileName, PathTools.ProductImageServerPath, validFormats);
            if(!result)
            {
                TempData[ErrorMessage] = "فرمت عکس وارد شده معتبر نمی باشد.";
                return View(model);
            }

            await _webProductInterface.AddWebProduct(model, fileName);

            TempData[SuccessMessage] = "محصول جدید با موفقیت ثبت شد.";
            return RedirectToAction("Index", "WebProduct");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            var product = await _webProductInterface.FindById(productId);

            var modelProduct = new ShowWebProductViewModel()
            {
                WebProductDeliverDate = product.WebProductDeliverDate,
                WebProductDescription = product.WebProductDescription,
                WebProductId = product.Id,
                WebProductImage = product.WebProductImage,
                WebProductName = product.WebProductName,
                WebProductPrice = product.WebProductPrice
            };

            return View(modelProduct);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteProductPost(int id)
        {
            await _webProductInterface.DeleteProduct(id);

            TempData[SuccessMessage] = "محصول مورد نظر با موفقیت حذف شد.";
            return RedirectToAction("Index", "WebProduct");
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(long productId)
        {
            var product = await _webProductInterface.FindById(productId);

            var productModel = new EditWebProductViewModel()
            {
                ImageUrl = product.WebProductImage,
                WebProductDeliverDate = product.WebProductDeliverDate,
                WebProductDescription = product.WebProductDescription,
                WebProductId = product.Id,
                WebProductName = product.WebProductName,
                WebProductPrice = product.WebProductPrice
            };

            return View(productModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditWebProductViewModel model)
        {
            var fileName = "";

            if (model.WebProductImage != null)
            {
                var validFormat = new List<string>()
                {
                    ".png",
                    ".jpeg",
                    ".jpg",
                    ".webp"
                };

                fileName = Guid.NewGuid() + Path.GetExtension(model.WebProductImage.FileName);
                var result = model.WebProductImage.UploadFile(fileName, PathTools.ProductImageServerPath, validFormat);

                if (!result)
                {
                    TempData[ErrorMessage] = "فرمت عکس وارد شده معتبر نمی باشد.";
                    return View(model);
                }
            }

            await _webProductInterface.EditProduct(model, fileName);

            TempData[SuccessMessage] = "محصول مورد نظر با موفقیت ویرایش شد.";
            return RedirectToAction("Index", "WebProduct");
        }

        [HttpGet]
        public async Task<IActionResult> WebProductInfo(long productId)
        {
            var result = await _webProductInterface.FillShowWebProductViewModel(productId);

            return View(result);
        }
    }
}