
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using CarSalesMgmt.Managers;
using CarSalesMgmtContracts;

namespace CarSalesMgmt.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<CarsController> _logger;
        private readonly ICarsMananger _carsMananger;

        public CarsController(ILogger<CarsController> logger, ICarsMananger carsMananger)
        {
            _logger = logger;
            _carsMananger = carsMananger;
        }

        [HttpPost]
        [Route("cardetails")]
        public async Task<IActionResult> InsertCarDetails([FromBody] CarModelRequest carModelRequest)
        {
            _logger.LogInformation("Cars Controller called. " + "CarModel Request : {CarModelRequest}", JsonConvert.SerializeObject(carModelRequest));
            DefaultResponse defaultResponse = new DefaultResponse();
            var response = await _carsMananger.InsertCarDetails(carModelRequest);

            if (response)
            {
                defaultResponse.Success = true;
                defaultResponse.Message = Constants.InsertCarDetailsSuccessfully;
                return Ok(defaultResponse);
            }
            else
            {
                defaultResponse.Success = false;
                defaultResponse.Message = Constants.InsertCarDetailsFailure;
                return BadRequest(defaultResponse);
            }

        }
    }
}
