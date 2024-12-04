using CarSalesMgmt.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace CarSalesMgmt.Services
{
    public class CarsService:ICarsService
    {
        private readonly string _sqlConnectionString;
        private readonly ILogger<CarsService> _logger;
        public CarsService(ILogger<CarsService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _sqlConnectionString = configuration["CarsMgmtSqlConnectionString"] ?? "";
        }

        public async Task<bool> InsertCarDetails(CarModel car)
        {
            _logger.LogInformation("CarsService, InsertCarDetails() called, CarModel : {CarModel}" , JsonConvert.SerializeObject(car));

            using (var sqlCon = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    await sqlCon.OpenAsync();
                    using (SqlCommand sqlCmnd = new SqlCommand(Constants.InsertCarDetails, sqlCon))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.Parameters.AddWithValue("@BrandId", car.BrandId);
                        sqlCmnd.Parameters.AddWithValue("@ClassId", car.ClassId);
                        sqlCmnd.Parameters.AddWithValue("@ModelName", car.ModelName);
                        sqlCmnd.Parameters.AddWithValue("@ModelCode", car.ModelCode);
                        sqlCmnd.Parameters.AddWithValue("@Description", car.Description);
                        sqlCmnd.Parameters.AddWithValue("@Features", car.Features);
                        sqlCmnd.Parameters.AddWithValue("@Price", car.Price);
                        sqlCmnd.Parameters.AddWithValue("@DateOfManufacturing", car.DateOfManufacturing);
                        sqlCmnd.Parameters.AddWithValue("@Active", car.Active);
                        sqlCmnd.Parameters.AddWithValue("@SortOrder", car.SortOrder);
                        sqlCmnd.Parameters.AddWithValue("@Images", car.Images);
                        int affectedRows = await sqlCmnd.ExecuteNonQueryAsync();

                        return affectedRows > 0;  
                    }
                }
                finally
                {
                    await sqlCon.CloseAsync();
                }
            }
        }
    }
}
