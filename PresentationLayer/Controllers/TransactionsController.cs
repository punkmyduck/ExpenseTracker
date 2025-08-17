using ExpenseTracker.DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        [HttpPost("create")]
        public Task<IActionResult> CreateTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
