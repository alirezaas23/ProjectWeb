using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.WebProduct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Interfaces
{
    public interface IWebProductInterface
    {
        Task AddWebProduct(AddWebProductViewModel model, string fileName);
        Task<List<WebProduct>> WebProductsList();
        Task<WebProduct> FindById(long productId);
        Task DeleteProduct(long productId);
        Task EditProduct(EditWebProductViewModel model, string fileName);
        Task<int> ProductsCount();
        Task<ShowWebProductViewModel> FillShowWebProductViewModel(long productId);
    }
}
