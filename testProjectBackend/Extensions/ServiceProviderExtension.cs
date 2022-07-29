using Microsoft.Extensions.DependencyInjection;
using testProjectBackend.Models;
using testProjectBackend.Services;

namespace testProjectBackend.Extensions
{
    public static class ServiceProviderExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookMarkService, BookMarkService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}