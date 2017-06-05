using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using TarefasApp.Authentication;
using TarefasApp.Helpers;
using TarefasApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureServiceSocialLogin))]

namespace TarefasApp.Services
{
    public class AzureServiceSocialLogin
    {
        private MobileServiceClient _client;
        private void Initialize()
        {
            _client = new MobileServiceClient("https://tarefasapps.azurewebsites.net");

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                _client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }

            //Como adicionar 
            //request.Headers.Add("X-ZUMO-AUTH", AccountService.Instance.AuthenticationToken);   
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(_client, MobileServiceAuthenticationProvider.Facebook);

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