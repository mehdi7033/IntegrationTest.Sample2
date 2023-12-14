//install-package Microsoft.Aspnetcore.Mvc.Test

using Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Tests.Integeration
{
    internal class ApplicationSetup : WebApplicationFactory<Api.Controllers.CustomersController>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<MyDbContext>));

                bool r = services.Remove(descriptor);

                services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

                    dbContext.Customers.Add(new Customer("ali"));
                    dbContext.Customers.Add(new Customer("hassan"));
                    dbContext.Customers.Add(new Customer("hossein"));
                    dbContext.Customers.Add(new Customer("sajad"));
                    dbContext.Customers.Add(new Customer("mohammad"));
                    dbContext.SaveChanges();
                }

            });
         }
    }
}
