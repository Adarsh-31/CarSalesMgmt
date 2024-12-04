namespace CarSalesMgmt.Models
{
    public class InsertCarDetails
    {
        public int BrandId { get; set; }
        public int ClassId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string ModelCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Features { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
        public byte[]? Images { get; set; }
    }
}
