using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CarparkTracker.Common.Configuration
{
    public class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string CarparkJsonFeed
        {
            get => AppSettings.GetValueOrDefault(nameof(CarparkJsonFeed), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(CarparkJsonFeed), value);
        }
    }
}
