using bidCalculation.Server.Entities;

namespace bidCalculation.Server.Helpers
{
    public class BidHelper
    {
        public Bid CalculationFeeds(double price, string vehicleType)
        {
            Bid bid = new Bid();
            bid.Price = price;
            bid.Basic = calculateBasic(price, vehicleType);
            bid.Special = calculateSpecial(price, vehicleType);
            bid.Association = calculateAssociation(price);
            bid.Storage = calculateStorage(price);
            bid.Total = bid.Price + bid.Basic + bid.Special + bid.Association + bid.Storage;
            bid.VehicleType = vehicleType;
            return bid;
        }

        private double calculateBasic(double price, string vehicleType)
        {
            double basicFee = 0;
            basicFee = price * 0.1;
            if (price > 0)
            {
                switch (vehicleType)
                {
                    case "Common":
                        if (basicFee < 10)
                        {
                            basicFee = 10;
                        }
                        else if (basicFee > 50)
                        {
                            basicFee = 50;
                        }
                        break;
                    case "Luxury":
                        if (basicFee < 25)
                        {
                            basicFee = 25;
                        }
                        else if (basicFee > 200)
                        {
                            basicFee = 200;
                        }
                        break;
                    default:
                        break;
                }
            }

            return basicFee;
        }
        private double calculateSpecial(double price, string vehicleType)
        {
            double specialFee = 0;
            if (price > 0)
            {
                switch (vehicleType)
                {
                    case "Common":
                        specialFee = price * 0.02;
                        break;
                    case "Luxury":
                        specialFee = price * 0.04;
                        break;
                    default:
                        break;
                }
            }

            return specialFee;
        }
        private int calculateAssociation(double price)
        {
            int associationFee = 0;
            if (price >= 1 && price <= 500)
            {
                associationFee = 5;
            }
            else if (price > 500 && price <= 1000)
            {
                associationFee = 10;
            }
            else if (price > 1000 && price <= 3000)
            {
                associationFee = 15;
            }
            else if (price > 3000)
            {
                associationFee = 20;
            }
            else
            {
                associationFee = 0;
            }

            return associationFee;
        }
        private int calculateStorage(double price)
        {
            int storageFee = 0;
            if (price > 0)
            {
                storageFee = 100;
            }
            return storageFee;
        }
    }
}
