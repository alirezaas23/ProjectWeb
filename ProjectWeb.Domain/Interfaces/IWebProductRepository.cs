using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IWebProductRepository
    {
        Task AddWebProduct(WebProduct webProduct);
        Task SaveChanges();
        IEnumerable<WebProduct> WebProductsList();
        WebProduct FindById(int id);
        void DeleteProduct(int id);
        void EditProduct(WebProduct webProduct);
        int ProductsCount();
    }
}
