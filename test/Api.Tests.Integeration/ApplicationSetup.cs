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

    }
}
