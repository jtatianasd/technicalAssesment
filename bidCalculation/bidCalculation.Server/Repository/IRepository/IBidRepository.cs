using bidCalculation.Server.Entities;

namespace bidCalculation.Server.Repository.IRepository
{
    public interface IBidRepository
    {
        Bid bidCalculation(double price, string? vehicleType);
    }
}
