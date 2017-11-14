using Ninject;

namespace CarparkTracker.Common.Containers
{
    public class CompositionRoot
    {
        private static IKernel _kernel;

        public static IKernel Kernel
        {
            get
            {
                return _kernel;
            }
            set
            {
                if ( _kernel == null || _kernel != value )
                    _kernel = value;
            }
        }

    }
}
