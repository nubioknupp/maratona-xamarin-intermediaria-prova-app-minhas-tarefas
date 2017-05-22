using System.Threading.Tasks;
using TarefasApp.Models;
using TarefasApp.ViewModels.Bases;
using Xamarin.Forms;

namespace TarefasApp.ViewModels.Categorias
{
    public class CategoriaViewModel : BaseViewModel
    {
        private Categoria _categoria;

        public Categoria Categoria
        {
            get { return _categoria; }
            set
            {
                SetProperty(ref _categoria, value);
            }
        }

        public Command SaveCommand { get; }

        public CategoriaViewModel()
        {
            _categoria = new Categoria{ Descricao = "Teste1"};
            SaveCommand = new Command(ExecuteSaveCommandAsync, CanExecute);
        }

        private async void ExecuteSaveCommandAsync()
        {
            await Task.Delay(1000);
        }

        private bool CanExecute()
        {
            return true;
        }
    }
}