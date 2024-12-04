using CarSalesMgmt.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarSalesMgmt.Services
{
    public class SalesService : ISalesService
    {
        private readonly string _sqlConnectionString;
        private readonly ILogger<SalesService> _logger;
        public SalesService(ILogger<SalesService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _sqlConnectionString = configuration["CarsMgmtSqlConnectionString"] ?? "";
        }

        public async Task<List<SalesmanCommissionModel>> GetCommissionData()
        {
            _logger.LogInformation("SalesService, GetCommissionData() called");

            var salesmanCommission = new List<SalesmanCommissionModel>();
            using (var sqlCon = new SqlConnection(_sqlConnectionString))
            {
                try
                {

                    await sqlCon.OpenAsync();
                    using (SqlCommand sqlCmnd = new SqlCommand(Constants.CalculateSalesmanCommission, sqlCon))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;

                        var reader = await sqlCmnd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            salesmanCommission.Add(new SalesmanCommissionModel()
                            {
                                SalesmanName = reader["SalesmanName"].ToString() ?? string.Empty,
                                TotalCommission = reader.GetDecimal("TotalCommission"),
                            });
                        }
                    }
                    return salesmanCommission;
                }
                finally
                {
                    await sqlCon.CloseAsync();
                }
            }

        }
    }
}
