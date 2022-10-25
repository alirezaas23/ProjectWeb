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
        #region Ctor

        private readonly ApplicationContext _context;

        public WebProductRepository(ApplicationContext ctx)
        {
            _context = ctx;
        }

        #endregion

        public async Task AddWebProduct(WebProduct webProduct)
        {
            await _context.WebProducts.AddAsync(webProduct);
        }

        public async Task DeleteProduct(long productId)
        {
            var product = await FindById(productId);
            product.IsDelete = true;
        }

        public Task EditProduct(WebProduct webProduct)
        {
            _context.Update(webProduct);
            return Task.CompletedTask;
        }

        public async Task<WebProduct> FindById(long productId)
        {
            return await _context.WebProducts.SingleOrDefaultAsync(w => w.Id.Equals(productId) && !w.IsDelete);
        }

        public async Task<int> ProductsCount()
        {
            return await _context.WebProducts.CountAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<WebProduct>> WebProductsList()
        {
            return await _context.WebProducts.Where(w => !w.IsDelete).ToListAsync();
        }
    }
}
