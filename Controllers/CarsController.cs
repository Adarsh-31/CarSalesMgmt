using CarSalesMgmtContracts;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("cardetails")]
        public async Task<IActionResult> AddCarDetails([FromBody] CarModelRequest carModelRequest)
        {
            _logger.LogInformation("Cars Controller called. " + "CarModel Request : {CarModelRequest}", JsonConvert.SerializeObject(carModelRequest);

        }
    }
}
