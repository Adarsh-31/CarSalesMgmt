namespace CarSalesMgmt.Managers
{
    public class CarsManager:ICarsMananger
    {
        private readonly ILogger<CarsManager> _logger;
        public CarsManager(ILogger<CarsManager> logger)
        {
            _logger = logger;
        }
    }
}
