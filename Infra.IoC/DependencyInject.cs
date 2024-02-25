using Application.Mappings;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public static class DependencyInject
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(options => options
                .UseNpgsql(configuration
                .GetConnectionString("DefaulConnection")));

            services
                .AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
