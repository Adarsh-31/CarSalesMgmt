using CarSalesMgmt.Models;
using CarSalesMgmt.Services;
using CarSalesMgmtContracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace CarSalesMgmt.Managers
{
    public class CarsManager:ICarsMananger
    {
        private readonly ILogger<CarsManager> _logger;
        private readonly ICarsService _carsService;
        public CarsManager(ILogger<CarsManager> logger, ICarsService carsService)
        {
            _logger = logger;
            _carsService = carsService;
        }

        public async Task<bool> InsertCarDetails(CarModelRequest carModelRequest)
        {
            _logger.LogInformation("CarsManager InsertCarDetails() called. CarModelRequest : {CarModelRequest}",JsonConvert.SerializeObject(carModelRequest));

            var combinedImages = carModelRequest.Images
            .Select(Convert.FromBase64String) 
            .SelectMany(imageBytes => imageBytes)                   
            .ToArray();

            CarModel carModel = new CarModel()
            {
                ClassId = carModelRequest.ClassId,
                BrandId = carModelRequest.BrandId,
                ModelName = carModelRequest.ModelName,
                ModelCode = carModelRequest.ModelCode,
                Description = carModelRequest.Description,
                Features = carModelRequest.Features,
                Price = carModelRequest.Price,
                DateOfManufacturing = carModelRequest.DateOfManufacturing,
                Active = carModelRequest.Active,
                SortOrder = carModelRequest.SortOrder,
                Images = combinedImages
            };

            return await _carsService.InsertCarDetails(carModel);
        }
    }
}
