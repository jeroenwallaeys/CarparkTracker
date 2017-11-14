using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarparkTracker.Common.Containers;
using CarparkTracker.Business.Handlers.Contracts;
using Ninject;
using CarparkTracker.Business.Handlers;
using System;

namespace CarparkTracker.Tests.Containers
{
    [TestClass]
    public class NinjectTests
    {
        [TestMethod]
        public void ResolveDependencyTest()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IWebRequestHandler>().To<WebRequestHandler>();
            CompositionRoot.Kernel = kernel;

            var dependency = Resolver.Get<IWebRequestHandler>();

            Assert.IsNotNull(dependency);
        }

        [TestMethod]
        [ExpectedException(typeof(ActivationException))]
        public void ResolveUnknownDependencyTest()
        {
            var kernel = new StandardKernel();
            CompositionRoot.Kernel = kernel;

            var dependency = Resolver.Get<IWebRequestHandler>();
        }
    }
}
