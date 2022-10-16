using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public void AddWebProduct(WebProduct webProduct)
        {
            _webProductRepository.AddWebProduct(webProduct);
        }

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

        public async Task AddWebProduct(AddWebProductViewModel model)
        {
            var webProduct = new WebProduct()
            {
                WebProductDescription = model.WebProductDescription,
                //WebProductImage = _uploadFileInterface.uploadPhoto(model.WebProductImage),
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
