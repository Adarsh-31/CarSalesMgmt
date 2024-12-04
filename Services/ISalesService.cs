using CarSalesMgmt.Models;

namespace CarSalesMgmt.Services
{
    public interface ISalesService
    {
        Task<List<SalesmanCommissionModel>> GetCommissionData();
    }
}
