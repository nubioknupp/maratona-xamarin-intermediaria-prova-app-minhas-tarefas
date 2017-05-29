using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using TarefasApp.Authentication;
using TarefasApp.Helpers;
using TarefasApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]

namespace TarefasApp.Services
{
    public class AzureService
    {
        private const string AppUrl = "https://tarefasapps.azurewebsites.net";

        public MobileServiceClient Client { get; private set; }
        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    const string message = "Nao conseguimos efetuar o login, tente novamente!";
                    await Application.Current.MainPage.DisplayAlert("Ops!", message, "Ok");
                });

                return false;
            }

            Settings.AuthToken = user.MobileServiceAuthenticationToken;
            Settings.UserId = user.UserId;

            return true;

        }

    }
}