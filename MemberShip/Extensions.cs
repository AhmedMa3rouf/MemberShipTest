using DAL;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShip
{
    public static class Extensions
    {
        public static IHost CreateDbIfNotExist<TContext>(this IHost host) where TContext : ApplicationDbContext
        {
            // Create a scope to get scoped services.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
                    databaseInitializer.SeedAsync().Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<TContext>>();
                    //logger.LogCritical(LoggingEvents.INIT_DATABASE, ex, LoggingEvents.INIT_DATABASE.Name);

                    //throw new Exception(LoggingEvents.INIT_DATABASE.Name, ex);
                }

                //var logger2 = services.GetRequiredService<ILogger<TContext>>();
                // get the service provider and db context.
                //var context = services.GetService<TContext>();

                // do something you can customize.
                // For example, I will migrate the database.
                //context.Database.Migrate();
            }

            return host;
        }

        public static IEnumerable<String> GetModelErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors)
                                    .Select(v => v.ErrorMessage + " " + v.Exception).ToList();

        }
    }
}
