using TarefasApp.ViewModels.Login;
using Xamarin.Forms;

namespace TarefasApp.Views.Login
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}