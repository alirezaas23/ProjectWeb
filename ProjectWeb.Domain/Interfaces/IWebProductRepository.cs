using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IWebProductRepository
    {
        Task AddWebProduct(WebProduct webProduct);
        Task SaveChanges();
        Task<List<WebProduct>> WebProductsList();
        Task<WebProduct> FindById(long productId);
        Task DeleteProduct(long productId);
        Task EditProduct(WebProduct webProduct);
        Task<int> ProductsCount();
    }
}
