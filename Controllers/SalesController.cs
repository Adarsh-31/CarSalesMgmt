using CarSalesMgmt.CarSalesMgmtContracts;
using CarSalesMgmt.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMgmt.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;
        private readonly ISalesManagers _salesMananger;

        public SalesController(ILogger<SalesController> logger, ISalesManagers salesMananger)
        {
            _logger = logger;
            _salesMananger = salesMananger;
        }

        [HttpGet]
        [Route("commission")]
        public async Task<ActionResult<SalesmanCommissionResponse>> GetCommissionData()
        {
            _logger.LogInformation("GetCommissionData called.");
            var response = await _salesMananger.GetCommissionData();
            if (response.SalesmanCommisions?.Count > 0)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
