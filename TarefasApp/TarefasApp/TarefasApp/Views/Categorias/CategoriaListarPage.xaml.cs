using System.ComponentModel;
using TarefasApp.Services;
using TarefasApp.ViewModels.Categorias;
using Xamarin.Forms;

namespace TarefasApp.Views.Categorias
{
    public partial class CategoriaListarPage 
    {
        private CategoriaListarViewModel ViewModel => BindingContext as CategoriaListarViewModel;
        public CategoriaListarPage()
        {
            InitializeComponent();
            var tarefasAppService = DependencyService.Get<ITarefasAppService>();
            BindingContext = new CategoriaListarViewModel(tarefasAppService);
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
