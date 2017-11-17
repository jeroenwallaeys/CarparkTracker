using CarparkTracker.Business.Handlers;
using CarparkTracker.Data.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CarparkTracker.Tests.Handlers
{
    [TestClass]
    public class CarparkHandlerTests
    {
        [TestMethod]
        public void GetCarparkTests()
        {
            var carparkHandler = new CarparkHandler(new WebRequests());

            var results = carparkHandler.GetCarparks();

            Assert.IsNotNull(results.First().CarparkStatus);
        }
    }
}