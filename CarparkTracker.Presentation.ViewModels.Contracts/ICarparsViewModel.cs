using CarparkTracker.Common.Entities.EventArguments;
using System;
using System.Threading.Tasks;

namespace CarparkTracker.Presentation.ViewModels.Contracts
{
    public interface ICarparsViewModel : IViewModel
    {
        Task OnFormAppearingFirstTime();
        event EventHandler<DisplayAlertEventArgs> DisplayAlertEvent;
    }
}