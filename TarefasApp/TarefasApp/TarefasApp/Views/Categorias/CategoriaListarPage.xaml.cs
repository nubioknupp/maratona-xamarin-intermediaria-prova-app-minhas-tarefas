using TarefasApp.ViewModels;
using TarefasApp.ViewModels.Categorias;
using Xamarin.Forms;

namespace TarefasApp.Views.Categorias
{
    public partial class CategoriaListarPage : ContentPage
    {
        public CategoriaListarPage()
        {
            InitializeComponent();
            BindingContext = new CategoriaViewModel();
        }
    }
}
