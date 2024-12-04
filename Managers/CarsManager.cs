using CarSalesMgmt.CarSalesMgmtContracts;
using CarSalesMgmt.Models;
using CarSalesMgmt.Services;
using CarSalesMgmtContracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace CarSalesMgmt.Managers
{
    public class CarsManager : ICarsMananger
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
            _logger.LogInformation("CarsManager InsertCarDetails() called. CarModelRequest : {CarModelRequest}", JsonConvert.SerializeObject(carModelRequest));

            var combinedImages = carModelRequest.Images
            .Select(Convert.FromBase64String)
            .SelectMany(imageBytes => imageBytes)
            .ToArray();

            InsertCarDetails carModel = new InsertCarDetails()
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

        public async Task<CarDetailsResponse> GetAllCarDetails(string searchTerm)
        {
            CarDetailsResponse carDetailsResponse = new CarDetailsResponse();

            var carDetails = await _carsService.GetCarDetails(searchTerm);

            foreach (var c in carDetails)
            {
                var carDetail = new CarDetails()
                {
                    BrandName = c.BrandName,
                    ClassName = c.ClassName,
                    ModelName = c.ModelName,
                    ModelCode = c.ModelCode,
                    Description = c.Description,
                    Features = c.Features,
                    Price = c.Price,
                    DateOfManufacturing = c.DateOfManufacturing,
                    Images = new List<string>()
                };

                if (c.Images != null)
                {
                    var base64String = Convert.ToBase64String(c.Images);
                    if (base64String != null)
                    {
                        carDetail.Images.Add(base64String);
                    }
                }

                carDetailsResponse.carDetails?.Add(carDetail);
            }

            return carDetailsResponse;
        }
    }
}
