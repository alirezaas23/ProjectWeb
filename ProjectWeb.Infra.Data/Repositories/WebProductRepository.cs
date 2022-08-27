using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System.Collections.Generic;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class WebProductRepository : IWebProductRepository
    {
        private readonly ApplicationContext _ctx;

        public WebProductRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public void AddWebProduct(WebProduct webProduct)
        {
            _ctx.WebProducts.Add(webProduct);
            SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = FindById(id);
            _ctx.WebProducts.Remove(product);
            SaveChanges();
        }

        public void EditProduct(WebProduct webProduct)
        {
            var product = FindById(webProduct.WebProductID);
            product.WebProductID = webProduct.WebProductID;
            product.WebProductDeliverDate = webProduct.WebProductDeliverDate;
            product.WebProductDescription = webProduct.WebProductDescription;
            if (webProduct.WebProductImage != null && webProduct.WebProductImage != "")
            {
                product.WebProductImage = webProduct.WebProductImage;
            }
            product.WebProductName = webProduct.WebProductName;
            product.WebProductPrice = webProduct.WebProductPrice;
            SaveChanges();
        }

        public WebProduct FindById(int id)
        {
            return _ctx.WebProducts.Find(id);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public IEnumerable<WebProduct> WebProductsList()
        {
            return _ctx.WebProducts;
        }
    }
}
