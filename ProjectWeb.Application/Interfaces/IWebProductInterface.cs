﻿using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb.Domain.ViewModels.WebProduct;

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
    }
}
