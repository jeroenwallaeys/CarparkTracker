using CarparkTracker.Business.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarparkTracker.Tests.Handlers
{
    [TestClass]
    public class CarparkHandlerTests
    {
        [TestMethod]
        public void GetCarparks()
        {
            var handler = new CarparkHandler(new WebRequestHandler());

            var carparks = handler.GetCarparks();

            Assert.IsNotNull(carparks);
        }
    }
}
