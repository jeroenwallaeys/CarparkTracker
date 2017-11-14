using Ninject;

namespace CarparkTracker.Common.Containers
{
    public class Resolver
    {
        public void Get<TType>()
        {
            CompositionRoot.Kernel.Get<TType>();
        }
    }
}
