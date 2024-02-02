using AutoMapper;
using bidCalculation.Server.Controllers;
using bidCalculation.Server.Entities;
using bidCalculation.Server.Entities.DTO;
using bidCalculation.Server.Repository.IRepository;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Xunit;

namespace BidCalculation.Server.Test
{
    public class BidControllerTest
    {
        private readonly IMapper _mapperTest;

        public BidControllerTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public void postBidCalulationSuccessful()
        {
            //Arrange
            var price = 1800;
            var type = "Common";
            try
            {
                BidDTO dataIngres = new BidDTO
                {
                    Price = price,
                    VehicleType = type,
                };
                Bid resp = new Bid
                {
                    Price = 1800,
                    VehicleType = "Common",
                    Basic = 180,
                    Special = 72,
                    Association = 15,
                    Storage = 100,
                    Total = 2167
                };
                Mock<IBidRepository> _bidRepositoryTest = new Mock<IBidRepository>();
                _bidRepositoryTest.Setup(a => a.bidCalculation(price, type)).Returns(resp);

                BidController bidController = new BidController(_bidRepositoryTest.Object, _mapperTest);


                //Act
                var result = bidController.bidCalculation(dataIngres);

                //Assert
                result.Equals(HttpStatusCode.OK);


            }
            catch (Exception ex)
            { }
        }
        [Fact]
        public void postBidCalulationBadRequest()
        {
            //Arrange
            var price = 1800;
            var type = "Common";
            try
            {
                BidDTO dataIngres = new BidDTO
                {
                    Price = price,
                    VehicleType = type,
                };
                Mock<IBidRepository> _bidRepositoryTest = new Mock<IBidRepository>();
                BidController bidController = new BidController(_bidRepositoryTest.Object, _mapperTest);


                //Act
                var result = bidController.bidCalculation(dataIngres);

                //Assert
                result.Equals(HttpStatusCode.BadRequest);


            }
            catch (Exception ex)
            { }
        }

        [Fact]
        public void priceIsZero()
        {
            //Arrange
            var _bidDto = new BidDTO { Price = 0, VehicleType = "Common" };

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_bidDto, new ValidationContext(_bidDto), validationResults, true);

            // Assert
            Assert.False(isValid, "Expected Behavior.");
            Assert.Single(validationResults);
            Assert.Equal("The price must be greater than zero.", validationResults[0].ErrorMessage);
        }
        [Fact]
        public void VehicleTypeIsEmpty()
        {
            //Arrange
            var _bidDto = new BidDTO { Price = 180, VehicleType = string.Empty };

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_bidDto, new ValidationContext(_bidDto), validationResults, true);

            // Assert
            Assert.False(isValid, "Expected Behavior.");
            Assert.Single(validationResults);
            Assert.Equal("The field VehicleType is required", validationResults[0].ErrorMessage);
        }
    }
}
