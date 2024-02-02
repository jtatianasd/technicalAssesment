namespace bidCalculation.Server.Entities
{
    public class Bid
    {
        public double Price { get; set; }
        public string? VehicleType { get; set; }
        public double Basic { get; set; }
        public double Special { get; set; }
        public double Association { get; set; }
        public double Storage { get; set; }
        public double Total { get; set; }
    }
}
