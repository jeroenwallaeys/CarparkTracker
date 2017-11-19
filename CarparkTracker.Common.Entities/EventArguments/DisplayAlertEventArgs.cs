using System;

namespace CarparkTracker.Common.Entities.EventArguments
{
    public class DisplayAlertEventArgs : EventArgs
    {
        public DisplayAlertEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}