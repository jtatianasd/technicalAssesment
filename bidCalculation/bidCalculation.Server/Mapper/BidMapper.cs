using bidCalculation.Server.Entities.DTO;
using bidCalculation.Server.Entities;
using AutoMapper;

namespace bidCalculation.Server.Mapper
{
    public class BidMapper:Profile
    {
        public BidMapper()
        {
            CreateMap<Bid, BidDTO>().ReverseMap();
        }
    }
}
