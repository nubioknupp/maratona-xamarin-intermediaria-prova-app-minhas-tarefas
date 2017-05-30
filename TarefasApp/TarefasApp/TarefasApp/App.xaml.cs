using TarefasApp.Helpers;
using TarefasApp.Views.Categorias;
using TarefasApp.Views.Login;
using Xamarin.Forms;

namespace TarefasApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(GetPage())
            {
                BarBackgroundColor = Color.Orange
            };
        }

        private Page GetPage()
        {
            if (Settings.IsLogged) return new CategoriaListarPage();

            return new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
