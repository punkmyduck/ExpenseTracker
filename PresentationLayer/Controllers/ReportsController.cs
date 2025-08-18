using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Reports;
using ExpenseTracker.DomainLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using ExpenseTracker.InfrastructureLayer.Extensions;
using ExpenseTracker.ApplicationLayer.DTO.Transactions;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportWorkingService _reportWorkingService;
        public ReportsController(
            IReportWorkingService reportGeneratorService)
        {
            _reportWorkingService = reportGeneratorService;
        }

        [Authorize]
        [HttpGet("generatereport")]
        public async Task<IActionResult> GenerateReportAsync([FromQuery] TransactionsFilterParams reportParams)
        {
            var userId = User.GetRequiredUserId();
            var report = await _reportWorkingService.GenerateReport(reportParams, userId);
            return Ok(report);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> RemoveReportAsync([FromQuery] int reportId)
        {
            var userId = User.GetRequiredUserId();
            await _reportWorkingService.DeleteReportByIdAsync(reportId, userId);
            return NoContent();
        }

        [Authorize]
        [HttpGet("getreports")]
        public async Task<IActionResult> GetUserReportsAsync()
        {
            var userId = User.GetRequiredUserId();
            var reports = await _reportWorkingService.GetUsersReportsByUserIdAsync(userId);
            return Ok(reports);
        }
    }
}
