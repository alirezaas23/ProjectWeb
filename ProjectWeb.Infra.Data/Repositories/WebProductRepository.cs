using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class WebProductRepository : IWebProductRepository
    {
        private readonly ApplicationContext _ctx;

        public WebProductRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddWebProduct(WebProduct webProduct)
        {
            await _ctx.WebProducts.AddAsync(webProduct);
        }

        public async Task DeleteProduct(long productId)
        {
            var product = await FindById(productId);
            product.IsDelete = true;
        }

        public async Task EditProduct(WebProduct webProduct)
        {
            _ctx.Update(webProduct);
        }

        public async Task<WebProduct> FindById(long productId)
        {
            return await _ctx.WebProducts.SingleOrDefaultAsync(w => w.Id.Equals(productId) && !w.IsDelete);
        }

        public async Task<int> ProductsCount()
        {
            return await _ctx.WebProducts.CountAsync();
        }

        public async Task SaveChanges()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<WebProduct>> WebProductsList()
        {
            return await _ctx.WebProducts.Where(w => !w.IsDelete).ToListAsync();
        }
    }
}
