using bidCalculation.Server.Entities;
using bidCalculation.Server.Helpers;
using bidCalculation.Server.Repository.IRepository;

namespace bidCalculation.Server.Repository
{
    public class BidRepository:IBidRepository
    {
        public Bid bidCalculation(double price, string? vehicleType)
        {
            BidHelper _bidHelper = new BidHelper();
            var bid = _bidHelper.CalculationFeeds(price, vehicleType);
            return bid;

        }
    }
}
