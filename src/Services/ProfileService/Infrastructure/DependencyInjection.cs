using Portfolio.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.ProfileService.Infrastructure.Persistence;
using Portfolio.ProfileService.Infrastructure.Services;
using Audit.Core;

namespace Portfolio.ProfileService.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuration.AuditDisabled = true;
            // Configuration.Setup().UseEntityFramework(_ =>
            //     _.AuditEntityCreator);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));

            services.AddScoped<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}