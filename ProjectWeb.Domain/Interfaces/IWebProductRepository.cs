using ProjectWeb.Domain.Models;
using System.Collections.Generic;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IWebProductRepository
    {
        void AddWebProduct(WebProduct webProduct);
        void SaveChanges();
        IEnumerable<WebProduct> WebProductsList();
        WebProduct FindById(int id);
        void DeleteProduct(int id);
        void EditProduct(WebProduct webProduct);
    }
}
