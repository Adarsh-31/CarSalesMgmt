using CarSalesMgmt.Models;

namespace CarSalesMgmt.Services
{
    public interface ICarsService
    {
        Task<bool> InsertCarDetails(CarModel car);
    }
}
