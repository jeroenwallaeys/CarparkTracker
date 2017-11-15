using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarparkTracker.Common.Containers;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Handlers;
using System;
using CarparkTracker.Business.Bootstrapper;
using Autofac.Core.Registration;

namespace CarparkTracker.Tests.Containers
{
    [TestClass]
    public class NinjectTests
    {
        [TestMethod]
        public void ResolveDependencyTest()
        {
            CompositionRoot.Container = new AutofacBuilder().CreateContainer();

            var dependency = Resolver.Get<IWebRequestHandler>();

            Assert.IsNotNull(dependency);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponentNotRegisteredException))]
        public void ResolveUnknownDependencyTest()
        {
            CompositionRoot.Container = new AutofacBuilder().CreateContainer();

            var dependency = Resolver.Get<IDoNotExist>();
        }

        internal interface IDoNotExist { }
    }
}
