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

        public async Task<bool> InsertCarDetails(InsertCarDetails car)
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

        public async Task<List<GetCarDetails>> GetCarDetails(string? searchTerm)
        {
            _logger.LogInformation("CarsService, GetCarDetails() called, SearchTerm : {SearchTerm}", searchTerm);

            var carDetails = new List<GetCarDetails>();
            using (var sqlCon = new SqlConnection(_sqlConnectionString))
            {
                try
                {

                    await sqlCon.OpenAsync();
                    using (SqlCommand sqlCmnd = new SqlCommand(Constants.GetAllCarDetails, sqlCon))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.Parameters.AddWithValue("@SearchTerm", SqlDbType.VarChar).Value = searchTerm;

                        var reader = await sqlCmnd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            carDetails.Add(new GetCarDetails()
                            {
                                BrandName = reader["BrandName"].ToString() ?? string.Empty,
                                ClassName = reader["ClassName"].ToString() ?? string.Empty,
                                ModelName = reader["ModelName"].ToString() ?? string.Empty,
                                ModelCode = reader["ModelCode"].ToString() ?? string.Empty,
                                Description = reader["Description"].ToString() ?? string.Empty,
                                Features = reader["Features"].ToString() ?? string.Empty,
                                Price = reader.GetDecimal("Price"),
                                DateOfManufacturing = reader.GetDateTime("DateOfManufacturing"),
                                Images = await reader.IsDBNullAsync(reader.GetOrdinal("Images")) ? null : (byte[])reader["Images"]
                            });
                        }
                    }
                    return carDetails;
                }
                finally
                {
                    await sqlCon.CloseAsync();
                }
            }

        }
    }
}
