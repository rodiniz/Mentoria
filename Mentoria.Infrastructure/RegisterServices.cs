using FluentValidation;
using Mentoria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}
