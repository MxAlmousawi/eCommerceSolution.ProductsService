using BuisnessLogicLayer.Mappers;
using BuisnessLogicLayer.ServiceContracts;
using BuisnessLogicLayer.Services;
using BuisnessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BuisnessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBuisnessLogicLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
