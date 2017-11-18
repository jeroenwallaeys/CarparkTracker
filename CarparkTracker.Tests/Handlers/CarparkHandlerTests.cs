using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Handlers;
using CarparkTracker.Business.Handlers.UrlBuilders;
using CarparkTracker.Data.Contracts.LocationTrackers;
using CarparkTracker.Data.Contracts.WebRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarparkTracker.Tests.Handlers
{
    [TestClass]
    public class CarparkHandlerTests
    {
        CarparkDto[] _carparkDtoResult;

        public CarparkHandlerTests()
        {
            _carparkDtoResult = new CarparkDto[]
            {
                new CarparkDto()
                {
                    Name = "Carpark1",
                    Id =1, Latitude=0, Longitude=0,
                    ContactInfo ="ContactInfo1", Address="StreetName",
                    Description ="Carpark",
                    CarparkStatus = new CarparkStatusDto(){
                        IsOpen = true, AvailableCapacity=5, TotalCapacity=200, LastModifiedDate="18/11/2017"
                    }
                },
                new CarparkDto()
                {
                    Name = "Carpark2",
                    Id =2, Latitude=1, Longitude=1,
                    ContactInfo ="ContactInfo2", Address="StreetName",
                    Description ="Carpark",
                    CarparkStatus = new CarparkStatusDto(){
                        IsOpen =true, AvailableCapacity=5, TotalCapacity=200, LastModifiedDate="18/11/2017"
                    }
                },
            };
        }

        [TestMethod]
        public void GetCarparksTest()
        {
            var webRequestsMock = new Mock<IWebRequests>();
            webRequestsMock
                .Setup(foo => foo.GetJsonRequest<CarparkDto[]>(UrlBuilder.GetParkingsUrl()))
                .Returns(_carparkDtoResult);

            var locationTrackerMock = new Mock<ILocationTracker>();

            var carparkHandler = new CarparkHandler(webRequestsMock.Object, locationTrackerMock.Object);

            var carparks = carparkHandler.GetCarparks();

            Assert.AreEqual(_carparkDtoResult, carparks);
        }
    }
}