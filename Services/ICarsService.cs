using CarSalesMgmt.Models;

namespace CarSalesMgmt.Services
{
    public interface ICarsService
    {
        Task<bool> InsertCarDetails(InsertCarDetails car);
        Task<List<GetCarDetails>> GetCarDetails(string searchTerm);
    }
}
