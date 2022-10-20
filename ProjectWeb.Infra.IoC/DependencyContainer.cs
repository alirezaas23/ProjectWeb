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
            #region Services

            services.AddTransient<ITicketInterface, TicketService>();
            services.AddTransient<IOrderInterface, OrderService>();
            services.AddTransient<IOrderDetailInterface, OrderDetailService>();
            services.AddScoped<IWebProductInterface, WebProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUploadFileInterface, UploadFileService>();
            services.AddScoped<IEmailService, EmailService>();

            #endregion

            #region Repositories

            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IWebProductRepository, WebProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISiteSettingRepository, SiteSettingRepository>();

            #endregion
        }
    }
}
