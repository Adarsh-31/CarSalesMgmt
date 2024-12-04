namespace CarSalesMgmt.CarSalesMgmtContracts
{
    public class CarDetailsResponse
    {
        public CarDetailsResponse()
        {
            carDetails = new List<CarDetails>(); 
        }
        public List<CarDetails>? carDetails { get; set; }
    }
}
