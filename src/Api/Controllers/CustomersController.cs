using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private MyDbContext _dbContext;

        public CustomersController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/customers/getcount")]
        public async Task<IActionResult> GetCount()
        {
            var count = _dbContext.Customers.Count();

            return Ok(count);
        }
    }
}
