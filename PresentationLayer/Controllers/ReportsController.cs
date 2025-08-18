using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Reports;
using ExpenseTracker.DomainLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using ExpenseTracker.InfrastructureLayer.Extensions;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportGeneratorService _reportGeneratorService;
        public ReportsController(
            IReportGeneratorService reportGeneratorService)
        {
            _reportGeneratorService = reportGeneratorService;
        }

        [Authorize]
        [HttpGet("report")]
        public async Task<IActionResult> GetReportAsync([FromQuery] ReportParamsDto reportParams)
        {
            var userId = User.GetRequiredUserId();
            var report = await _reportGeneratorService.GenerateReport(reportParams, userId);
            return Ok(report);
        }
    }
}
