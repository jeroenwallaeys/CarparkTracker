using System.Threading.Tasks;

namespace CarparkTracker.Presentation.ViewModels.Contracts
{
    public interface ICarparsViewModel
    {
        Task OnFormAppearingFirstTime();
    }
}