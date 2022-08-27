using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.ViewComponents
{
    public class WebProductViewComponent : ViewComponent
    {
        private readonly IWebProductRepository _webProductRepository;

        public WebProductViewComponent(IWebProductRepository webProductRepository)
        {
            _webProductRepository = webProductRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = _webProductRepository.WebProductsList();
            return View(product);
        }
    }
}
