using System;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ProjectWeb.Application.Extensions;
using ProjectWeb.Application.Security;
using ProjectWeb.Application.Statics;
using ProjectWeb.Domain.ViewModels.WebProduct;

namespace ProjectWeb.Application.Services
{
    public class WebProductService : IWebProductInterface
    {
        #region Ctor

        private readonly IWebProductRepository _webProductRepository;
        private readonly IUploadFileInterface _uploadFileInterface;

        public WebProductService(IWebProductRepository webProductRepository, IUploadFileInterface uploadFileInterface)
        {
            _webProductRepository = webProductRepository;
            _uploadFileInterface = uploadFileInterface;
        }

        #endregion
        
        public async Task DeleteProduct(long productId)
        {
            await _webProductRepository.DeleteProduct(productId);
            await _webProductRepository.SaveChanges();
        }

        public async Task EditProduct(EditWebProductViewModel model, string fileName)
        {
            var product = await FindById(model.WebProductId);

            product.WebProductDeliverDate = model.WebProductDeliverDate.SanitizeText();
            product.WebProductDescription = model.WebProductDescription.SanitizeText();
            product.WebProductImage = model.WebProductImage != null ? fileName : product.WebProductImage;
            product.WebProductName = model.WebProductName.SanitizeText();
            product.WebProductPrice = model.WebProductPrice;

            await _webProductRepository.EditProduct(product);
            await _webProductRepository.SaveChanges();
        }

        public async Task<WebProduct> FindById(long productId)
        {
            return await _webProductRepository.FindById(productId);
        }

        public async Task<int> ProductsCount()
        {
            return await _webProductRepository.ProductsCount();
        }

        public async Task AddWebProduct(AddWebProductViewModel model, string fileName)
        {
            var webProduct = new WebProduct()
            {
                WebProductDescription = model.WebProductDescription,
                WebProductImage = fileName,
                WebProductName = model.WebProductName,
                WebProductPrice = model.WebProductPrice,
                WebProductDeliverDate = model.WebProductDeliverDate
            };

            await _webProductRepository.AddWebProduct(webProduct);
            await _webProductRepository.SaveChanges();
        }

        public async Task<List<WebProduct>> WebProductsList()
        {
            return await _webProductRepository.WebProductsList();
        }
    }
}
