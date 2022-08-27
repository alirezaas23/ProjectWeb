using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Interfaces
{
    public interface IWebProductInterface
    {
        void AddWebProduct(WebProduct webProduct);
        IEnumerable<WebProduct> WebProductsList();
        WebProduct FindById(int id);
        void DeleteProduct(int id);
        void EditProduct(WebProduct webProduct);
    }
}
