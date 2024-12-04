namespace CarSalesMgmt.CarSalesMgmtContracts
{
    public class CarDetails
    {
        public string BrandName { get; set; }
        public string ClassName { get; set; }
        public string ModelName { get; set; }
        public string ModelCode { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public List<string>? Images { get; set; }
    }
}
