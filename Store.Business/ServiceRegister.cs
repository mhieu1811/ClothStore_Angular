using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using Store.DataAccessor;
using Store.Business.Services;
using Store.Business.Interfaces;

namespace Store.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessorLayer(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICommentService, CommentsService>();

            /*services.AddRefitClient<IIdentityProviderService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:5001"));*/
        }
    }
}