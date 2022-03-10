using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Portfolio.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(Assembly.GetCallingAssembly());

            return services;
        }
    }
}
