using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Transactions;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.InfrastructureLayer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionCreatorService _transactionCreatorService;
        public TransactionsController(ITransactionCreatorService transactionCreatorService)
        {
            _transactionCreatorService = transactionCreatorService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTransaction([FromQuery] TransactionCreationRequestDto transactionCreationRequestDto)
        {
            var userId = User.GetRequiredUserId();
            var result = await _transactionCreatorService.CreateTransaction(userId, transactionCreationRequestDto);
            return Ok(result);
        }
    }
}
