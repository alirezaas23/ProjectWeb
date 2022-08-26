using Microsoft.Extensions.DependencyInjection;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.Services;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Infra.Data.Repositories;

namespace ProjectWeb.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<ITicketInterface, TicketService>();
            services.AddScoped<IWebProductRepository, WebProductRepository>();
            services.AddScoped<IWebProductInterface, WebProductService>();
        }
    }
}
