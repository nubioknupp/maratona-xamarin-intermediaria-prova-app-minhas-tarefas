// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace TarefasApp.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string UserIdKey = "userid";
        private static readonly string UserIdDefault = string.Empty;

        private const string AuthTokenKey = "authtoken";
        private static readonly string AuthTokenDefault = string.Empty;

        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue(UserIdKey, value); }
        }

        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault(AuthTokenKey, AuthTokenDefault); }
            set { AppSettings.AddOrUpdateValue(AuthTokenKey, value); }
        }

        public static bool IsLogged => !string.IsNullOrWhiteSpace(UserId);
    }
}