using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Common.Entities;
using CarparkTracker.Presentation.Entities;
using CarparkTracker.Presentation.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarparkTracker.Tests.Mappers
{
    [TestClass]
    public class CarparkMapperTests
    {
        private CarparkDto _carparkDto;

        public CarparkMapperTests()
        {
            _carparkDto = new CarparkDto()
            {
                Name = "Carpark1",
                Id = 1,
                Latitude = 0,
                Longitude = 0,
                ContactInfo = "ContactInfo1",
                Address = "StreetName",
                Description = "Carpark",
                CarparkStatus = new CarparkStatusDto()
                {
                    IsOpen = true,
                    AvailableCapacity = 5,
                    TotalCapacity = 200,
                    LastModifiedDate = "18/11/2017"
                }
            };
        }

        [TestMethod]
        public void GetCarparkTest()
        {
            var distanceMock = new Mock<ICoordinateDistanceHandler>();
            distanceMock.Setup(m => m.GetDistance(It.IsAny<Coordinate>(), It.IsAny<Coordinate>())).Returns(1200);
            var mapper = new CarparkMapper(distanceMock.Object);

            var carpark = mapper.GetCarpark(_carparkDto, new Coordinate(0, 0));

            Assert.AreEqual(_carparkDto.Id, carpark.Id);
            Assert.AreEqual(_carparkDto.Latitude, carpark.Coordinate.Latitude);
            Assert.AreEqual(_carparkDto.Longitude, carpark.Coordinate.Longitude);
            Assert.AreEqual(_carparkDto.Name, carpark.Name);
            Assert.AreEqual(_carparkDto.CarparkStatus.AvailableCapacity, carpark.AvailableSpaces);
            Assert.AreEqual(_carparkDto.CarparkStatus.IsOpen, carpark.IsOpen);
        }

        [TestMethod]
        public void UpdateCarparkTest()
        {
            var distanceMock = new Mock<ICoordinateDistanceHandler>();
            distanceMock.Setup(m => m.GetDistance(It.IsAny<Coordinate>(), It.IsAny<Coordinate>())).Returns(1200);
            var mapper = new CarparkMapper(distanceMock.Object);

            var oldCarpark = new Carpark()
            {
                Name = "Carpark1",
                Id = 1,
                Coordinate = new Coordinate(0, 0),
                AvailableSpaces = 4,
                IsOpen = false,
            };

            mapper.UpdateCarpark(oldCarpark, _carparkDto);

            Assert.AreEqual(oldCarpark.IsOpen, true);
            Assert.AreEqual(oldCarpark.AvailableSpaces, 5);
        }
    }
}