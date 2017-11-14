using CarparkTracker.Business.Handlers;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Presentation.Mappers;
using CarparkTracker.Presentation.Mappers.Contracts;
using CarparkTracker.Presentation.ViewModels;
using CarparkTracker.Presentation.ViewModels.Contracts;
using Ninject.Modules;

namespace CarparkTracker.Business.Bootstrapper
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarparkHandler>().To<CarparkHandler>();
            Bind<ICoordinateDistanceHandler>().To<CoordinateDistanceHandler>();
            Bind<IWebRequestHandler>().To<WebRequestHandler>();
            Bind<ICarparkMapper>().To<CarparkMapper>();
            Bind<ICarparsViewModel>().To<CarparksViewModel>();
        }
    }
}