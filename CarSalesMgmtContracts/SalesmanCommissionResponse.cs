namespace CarSalesMgmt.CarSalesMgmtContracts
{
    public class SalesmanCommissionResponse
    {
        public SalesmanCommissionResponse()
        {
            SalesmanCommisions = new List<SalesmanCommision>();
        }
        public List<SalesmanCommision> SalesmanCommisions {  get; set; }
    }
}
