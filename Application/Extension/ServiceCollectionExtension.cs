using Application.Checkout.Command;
using Application.Products.Command;
using FluentValidation.AspNetCore;
using Infrastucture.Core;
using Infrastucture.Persistance;
using Infrastucture.Validation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Checkout;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IDataHelper, DataHelper>();

            //Repository
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IStockRepository, StockRepository>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationHandler<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommonRequestHandler<,>));
            services.AddTransient(typeof(IRequestHandler<,>), typeof(CommonRequestHandler<,>));

            services.AddMediatR(typeof(AddProductToBasketRequestHandler));


            return services;
        }
    }
}
