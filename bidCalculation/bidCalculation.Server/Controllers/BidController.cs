using AutoMapper;
using bidCalculation.Server.Entities.DTO;
using bidCalculation.Server.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bidCalculation.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;
        public BidController(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Perform the bid calculation based on the data entered.
        /// </summary>
        /// <param name="bidDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(BidDTO))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult bidCalculation([FromBody] BidDTO bidDTO)
        {
            var offer = _bidRepository.bidCalculation(bidDTO.Price, bidDTO.VehicleType);

            if (offer == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(offer);
            }

        }
    }
}
