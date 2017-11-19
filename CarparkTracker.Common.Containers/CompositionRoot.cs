using Autofac;

namespace CarparkTracker.Common.Containers
{
    public class CompositionRoot
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                return _container;
            }
            set
            {
                if ( _container == null || _container != value )
                    _container = value;
            }
        }

    }
}
