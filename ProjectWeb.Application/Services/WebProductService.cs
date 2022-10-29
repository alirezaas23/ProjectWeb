using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.Security;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.WebProduct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Services
{
    public class WebProductService : IWebProductInterface
    {
        #region Ctor

        private readonly IWebProductRepository _webProductRepository;

        public WebProductService(IWebProductRepository webProductRepository, IUploadFileInterface uploadFileInterface)
        {
            _webProductRepository = webProductRepository;
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

        public async Task<ShowWebProductViewModel> FillShowWebProductViewModel(long productId)
        {
            var product = await _webProductRepository.FindById(productId);

            return new ShowWebProductViewModel()
            {
                WebProductImage = product.WebProductImage,
                WebProductDescription = product.WebProductDescription,
                WebProductName = product.WebProductName,
                WebProductPrice = product.WebProductPrice,
                WebProductDeliverDate = product.WebProductPrice.ToString(),
                WebProductId = product.Id
            };
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
