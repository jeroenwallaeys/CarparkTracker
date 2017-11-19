using Autofac;
using CarparkTracker.Business.Handlers;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Handlers.Factories;
using CarparkTracker.Data.Contracts.LocationTrackers;
using CarparkTracker.Data.Contracts.WebRequests;
using CarparkTracker.Data.Location;
using CarparkTracker.Data.Web;
using CarparkTracker.Presentation.Mappers;
using CarparkTracker.Presentation.Mappers.Contracts;
using CarparkTracker.Presentation.ViewModels;
using CarparkTracker.Presentation.ViewModels.Contracts;
using CarparkTracker.Presentation.ViewModels.Factories;

namespace CarparkTracker.Business.Bootstrapper
{
    public class AutofacBuilder
    {
        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HandlerFactory>().As<IHandlerFactory>();
            builder.RegisterType<ViewModelFactory>().As<IViewModelFactory>();

            builder.RegisterType<UserLocationHandler>().As<IUserLocationHandler>();
            builder.RegisterType<CarparkHandler>().As<ICarparkHandler>();
            builder.RegisterType<CoordinateDistanceHandler>().As<ICoordinateDistanceHandler>();

            builder.RegisterType<CarparkMapper>().As<ICarparkMapper>();


            builder.RegisterType<CarparksViewModel>().As<ICarparsViewModel>();
            builder.RegisterType<CarparkDetailViewModel>().As<ICarparkDetailViewModel>();

            builder.RegisterType<WebRequests>().As<IWebRequests>();
            builder.RegisterType<LocationTracker>().As<ILocationTracker>();
            
            return builder.Build();
        }
    }
}
