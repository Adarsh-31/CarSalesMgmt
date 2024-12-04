namespace CarSalesMgmtContracts
{
    public class CarModelRequest
    {
        public required int BrandId { get; set; }
        public required int ClassId { get; set; }
        public required string ModelName { get; set; }
        public required string ModelCode { get; set; }
        public required string Description { get; set; }
        public required string Features { get; set; }
        public required decimal Price { get; set; }
        public required DateTime DateOfManufacturing { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
        public required List<string> Images { get; set; }
    }
}
