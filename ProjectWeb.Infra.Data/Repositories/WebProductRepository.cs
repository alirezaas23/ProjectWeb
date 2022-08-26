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

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
