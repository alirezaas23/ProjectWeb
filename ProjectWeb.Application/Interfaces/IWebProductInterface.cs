using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb.Domain.ViewModels.WebProduct;

namespace ProjectWeb.Application.Interfaces
{
    public interface IWebProductInterface
    {
        Task AddWebProduct(AddWebProductViewModel model, string fileName);
        IEnumerable<WebProduct> WebProductsList();
        WebProduct FindById(int id);
        void DeleteProduct(int id);
        void EditProduct(WebProduct webProduct);
        int ProductsCount();
    }
}
