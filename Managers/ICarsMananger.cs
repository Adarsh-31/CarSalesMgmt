using CarSalesMgmt.CarSalesMgmtContracts;
using CarSalesMgmtContracts;

namespace CarSalesMgmt.Managers
{
    public interface ICarsMananger
    {
        Task<bool> InsertCarDetails(CarModelRequest carModelRequest);
        Task<CarDetailsResponse> GetAllCarDetails(string? searchTerm);
    }
}
