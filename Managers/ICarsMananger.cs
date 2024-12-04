using CarSalesMgmtContracts;

namespace CarSalesMgmt.Managers
{
    public interface ICarsMananger
    {
        Task<bool> InsertCarDetails(CarModelRequest carModelRequest);
    }
}
