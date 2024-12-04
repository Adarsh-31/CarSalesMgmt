namespace CarSalesMgmt.CarSalesMgmtContracts
{
    public class CarDetailsResponse
    {
        public CarDetailsResponse()
        {
            CarDetails = new List<CarDetails>(); 
        }
        public List<CarDetails>? CarDetails { get; set; }
    }
}
