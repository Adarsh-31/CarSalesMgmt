using CarSalesMgmt.CarSalesMgmtContracts;
using CarSalesMgmt.Services;
using CarSalesMgmtContracts;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;

namespace CarSalesMgmt.Managers
{
    public class SalesManagers:ISalesManagers
    {
        private readonly ILogger<SalesManagers> _logger;
        private readonly ISalesService _salesService;
        public SalesManagers(ILogger<SalesManagers> logger, ISalesService salesService)
        {
            _logger = logger;
            _salesService = salesService;
        }

        public async Task<SalesmanCommissionResponse> GetCommissionData()
        {
            _logger.LogInformation("SalesManagers GetCommissionData() called.");
            SalesmanCommissionResponse salesmanCommissionResponse = new SalesmanCommissionResponse();

            var salesmanCommissions = await _salesService.GetCommissionData();

            foreach (var s in salesmanCommissions)
            {
                var saleCommission = new SalesmanCommision()
                {
                    SalesmanName = s.SalesmanName,
                    TotalCommission = s.TotalCommission
                };

                salesmanCommissionResponse.SalesmanCommisions.Add(saleCommission);
            }

            return salesmanCommissionResponse;
        }
    }
}
