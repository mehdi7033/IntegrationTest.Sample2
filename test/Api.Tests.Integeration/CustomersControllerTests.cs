using Api.Data;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Tests.Integeration
{
    public class CustomersControllerTests
    {
        [Fact]
        public async Task GetCount_Should_Return_5_When_There_Are_5_Customers_In_Database()
        {
            //arrange
            var application = new ApplicationSetup();

            var client = application.WithWebHostBuilder(builder => 
            {
                builder.ConfigureServices(services => 
                {
                    var descriptor = services.SingleOrDefault(
                     d => d.ServiceType == typeof(DbContextOptions<MyDbContext>));

                    bool r = services.Remove(descriptor);

                    services.AddDbContext<MyDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
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
            }).CreateClient();

            //act
            
            var response = await client.GetAsync("/customers/getcount");
            var responseString = await response.Content.ReadAsStringAsync();

            //assert
            responseString.Contains("5").Should().BeTrue();
        }
    }
}
