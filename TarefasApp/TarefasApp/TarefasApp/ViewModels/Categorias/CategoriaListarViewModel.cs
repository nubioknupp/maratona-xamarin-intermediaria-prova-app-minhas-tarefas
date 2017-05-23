using TarefasApp.Models;
using TarefasApp.ViewModels.Bases;
using Xamarin.Forms;

namespace TarefasApp.ViewModels.Categorias
{
    public class CategoriaListarViewModel : BaseViewModel
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

        public CategoriaListarViewModel()
        {
            _categoria = new Categoria{ Descricao = "Teste1"};
            //SaveCommand = new Command(ExecuteSaveCommandAsync, CanExecute);
        }

        //private void ExecuteSaveCommandAsync()
        //{
        //    _categoria = Categoria;
        //    CanExecute();
        //}

        //private bool CanExecute()
        //{
        //    return true;
        //}
    }
}