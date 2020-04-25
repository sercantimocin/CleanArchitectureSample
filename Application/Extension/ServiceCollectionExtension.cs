using Application.Products.Command;
using Infrastucture.Persistance;
using Infrastucture.Validation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Checkout;

namespace Infrastucture.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IDataHelper, DataHelper>();

            //Repository
            //services.AddScoped<IBasketRepository, BasketRepository>();
            //services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IBasketRepository, FakeBasketRepository>();
            services.AddScoped<IStockRepository, FakeStockRepository>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationHandler<,>));

            services.AddMediatR(typeof(AddProductToBasketRequestHandler));

            return services;
        }
    }
}
