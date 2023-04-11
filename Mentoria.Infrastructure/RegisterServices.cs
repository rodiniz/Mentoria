using FluentValidation;
using Mentoria.Application;
using Mentoria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Mentoria.Infrastructure
{
    public static class RegisterServices
    {
        public static void ConfigureInfraStructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("MyConnection"));
            });

             services.AddScoped<IValidator<Customer>, CustomerValidator>();
             services.AddScoped<ICrudService<Customer>, CustomersService>();
        }
    }
}
