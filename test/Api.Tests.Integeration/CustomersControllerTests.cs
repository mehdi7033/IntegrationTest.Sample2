using Api.Data;
using FluentAssertions;
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
           
            var client = application.CreateClient();
           
            //act
            
            var response = await client.GetAsync("/customers/getcount");
            var responseString = await response.Content.ReadAsStringAsync();

            //assert
            responseString.Contains("5").Should().BeTrue();
        }
    }
}
