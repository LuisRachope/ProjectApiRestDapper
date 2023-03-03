using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectApiRestDapper.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, DbContext>(provider => 
                new DbContext(configuration["ConnectionString:SecretNameDbContext"])
            );
        }

    }
}
