using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectApiRestDapper.Context;
using ProjectApiRestDapper.Repository;
using ProjectApiRestDapper.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Extensions
{
    public static class ServiceExtensions
    {
        #region

        public static void AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, DbContext>(provider =>
               new DbContext(configuration["ConnectionString:SecretName"])
           );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        #endregion
    }
}
