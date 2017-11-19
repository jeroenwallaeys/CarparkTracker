using System.Threading.Tasks;

namespace CarparkTracker.Presentation.ViewModels.Contracts
{
    public interface ICarparsViewModel : IViewModel
    {
        Task OnFormAppearingFirstTime();
    }
}