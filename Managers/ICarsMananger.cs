using CarSalesMgmtContracts;

namespace CarSalesMgmt.Managers
{
    public interface ICarsMananger
    {
        Task<bool> AddCarDetails(CarModelRequest carModelRequest);
    }
}
