using System.ComponentModel;
using TarefasApp.ViewModels.Categorias;
using Xamarin.Forms;

namespace TarefasApp.Views.Categorias
{
    public partial class CategoriaListarPage : ContentPage
    {
        private CategoriaListarViewModel ViewModel => BindingContext as CategoriaListarViewModel;
        public CategoriaListarPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null) return;
            Title = ViewModel.Title;
            ViewModel.PropertyChanged += TitlePropertyChanged;
            await ViewModel.LoadAsync();
        }

        private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ViewModel.Title)) return;

            Title = ViewModel.Title;
        }
    }
}
