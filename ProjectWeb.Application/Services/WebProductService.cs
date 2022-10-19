using System;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ProjectWeb.Application.Extensions;
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
        
        public void DeleteProduct(int id)
        {
            _webProductRepository.DeleteProduct(id);
        }

        public void EditProduct(WebProduct webProduct)
        {
            _webProductRepository.EditProduct(webProduct);
        }

        public WebProduct FindById(int id)
        {
            return _webProductRepository.FindById(id);
        }

        public int ProductsCount()
        {
            return _webProductRepository.ProductsCount();
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

        public IEnumerable<WebProduct> WebProductsList()
        {
            return _webProductRepository.WebProductsList();
        }
    }
}
