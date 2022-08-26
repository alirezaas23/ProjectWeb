using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Services
{
    public class WebProductService : IWebProductInterface
    {
        private readonly IWebProductRepository _webProductRepository;

        public WebProductService(IWebProductRepository webProductRepository)
        {
            _webProductRepository = webProductRepository;
        }

        public void AddWebProduct(WebProduct webProduct)
        {
            _webProductRepository.AddWebProduct(webProduct);
        }
    }
}
