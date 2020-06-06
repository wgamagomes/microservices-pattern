using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Data.SqlClient;


namespace EShop.Catalog.FunctionalTests.Host
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder = null)
            where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                var policy = Policy.Handle<SqlException>()
                     .WaitAndRetry(
                         retryCount: 10,
                         sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                         onRetry: (exception, timeSpan, retry, ctx) =>
                         {
                             // TODO: Need error  log here
                         });

                policy.Execute(() =>
                {
                    context.Database.Migrate();
                    seeder?.Invoke(context, services);
                });
            }

            return webHost;
        }
    }
}
