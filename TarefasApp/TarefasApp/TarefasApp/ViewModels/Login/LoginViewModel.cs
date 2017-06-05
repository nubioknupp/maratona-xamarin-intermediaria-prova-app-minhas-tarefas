using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Helpers;
using TarefasApp.Services;
using TarefasApp.ViewModels.Bases;
using TarefasApp.ViewModels.Categorias;
using TarefasApp.Views.Login;
using Xamarin.Forms;

namespace TarefasApp.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(ExecuteLoginCommand);
            _azureService = DependencyService.Get<AzureServiceSocialLogin>();
        }

        public Command LoginCommand { get; }
        private readonly AzureServiceSocialLogin _azureService;

        private async void ExecuteLoginCommand(object obj)
        {
            if (!await LoginAsync())
            {
                return;
            }

            await PushAsync<CategoriaListarViewModel>("Categorias");
            RemovePageFromStack();
        }

        private static void RemovePageFromStack()
        {
            var navegation = Application.Current.MainPage.Navigation;
            var navegationStack = navegation.NavigationStack.ToList();
            foreach (var page in navegationStack)
            {
                if (page.GetType() == typeof(LoginPage))
                {
                    navegation.RemovePage(page);
                }
            }
        }

        private Task<bool> LoginAsync()
        {
            return Settings.IsLogged ? Task.FromResult(true) : _azureService.LoginAsync();
        }
    }
}