using Autofac;
using CarparkTracker.Business.Handlers;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Presentation.Mappers;
using CarparkTracker.Presentation.Mappers.Contracts;
using CarparkTracker.Presentation.ViewModels;
using CarparkTracker.Presentation.ViewModels.Contracts;

namespace CarparkTracker.Business.Bootstrapper
{
    public class AutofacBuilder
    {
        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CarparkHandler>().As<ICarparkHandler>();
            builder.RegisterType<CoordinateDistanceHandler>().As<ICoordinateDistanceHandler>();
            builder.RegisterType<WebRequestHandler>().As<IWebRequestHandler>();
            builder.RegisterType<CarparkMapper>().As<ICarparkMapper>();
            builder.RegisterType<CarparksViewModel>().As<ICarparsViewModel>();

            return builder.Build();
        }
    }
}
