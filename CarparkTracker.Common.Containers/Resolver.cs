using Ninject;

namespace CarparkTracker.Common.Containers
{
    public static class Resolver
    {
        public static TType Get<TType>()
        {
            return CompositionRoot.Kernel.Get<TType>();
        }
    }
}
