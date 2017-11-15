using Autofac;

namespace CarparkTracker.Common.Containers
{
    public static class Resolver
    {
        public static TType Get<TType>()
        {
            using ( var scope = CompositionRoot.Container.BeginLifetimeScope() )
            {
                return scope.Resolve<TType>();
            }
        }
    }
}
