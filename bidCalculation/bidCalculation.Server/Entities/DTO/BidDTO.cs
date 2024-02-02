using System.ComponentModel.DataAnnotations;

namespace bidCalculation.Server.Entities.DTO
{
    public class BidDTO
    {
        [Required(ErrorMessage = "The field price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The price must be greater than zero.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "The field VehicleType is required")]
        public string? VehicleType { get; set; }
    }
}
