namespace CarSalesMgmt.CarSalesMgmtContracts
{
    public class CarDetails
    {
        public string BrandName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public string ModelCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Features { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public List<string>? Images { get; set; }
    }
}
