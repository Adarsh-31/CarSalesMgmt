using CarSalesMgmt.CarSalesMgmtContracts;

namespace CarSalesMgmt.Managers
{
    public interface ISalesManagers
    {
        Task<SalesmanCommissionResponse> GetCommissionData();
    }
}
