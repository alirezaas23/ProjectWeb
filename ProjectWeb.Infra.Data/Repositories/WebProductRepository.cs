using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

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
