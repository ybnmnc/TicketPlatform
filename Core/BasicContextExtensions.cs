using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketPlatform.Data;

namespace TicketPlatform.Core
{
    public static class BasicContextExtensions
    {
        //confıguratıon ve connectıonStrıng ayarlarının yapılması.
        public static IServiceCollection AddBasicContext(this IServiceCollection collection)
        {
            var configuration = collection.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            collection.AddDbContext<BasicContext>(options =>
            {
                options.UseSqlServer(connectionString);
                //options.UseCustomSqlServerQuerySqlGenerator();
            }, ServiceLifetime.Scoped);

            collection
                .AddHealthChecks();
            return collection;
        }
    }
}
