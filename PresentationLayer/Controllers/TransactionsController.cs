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
        private readonly ITransactionService _transactionCreatorService;
        public TransactionsController(ITransactionService transactionCreatorService)
        {
            _transactionCreatorService = transactionCreatorService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var userId = User.GetRequiredUserId();

            var result = await _transactionCreatorService.GetTransactionsAsync(userId);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromQuery] TransactionCreationRequestDto transactionCreationRequestDto)
        {
            var userId = User.GetRequiredUserId();
            var result = await _transactionCreatorService.CreateTransactionAsync(userId, transactionCreationRequestDto);
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUserCategory(UpdateTransactionDto updateTransactionDto)
        {
            var userId = User.GetRequiredUserId();

            await _transactionCreatorService.UpdateTransactionAsync(userId, updateTransactionDto);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{transactionId:int}")]
        public async Task<IActionResult> DeleteUserCategory(int transactionId)
        {
            var userId = User.GetRequiredUserId();

            await _transactionCreatorService.RemoveTransactionAsync(userId, transactionId);

            return NoContent();
        }
    }
}
