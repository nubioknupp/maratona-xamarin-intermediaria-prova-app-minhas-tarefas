using System.Threading.Tasks;
using TarefasApp.Models;
using TarefasApp.ViewModels.Bases;
using Xamarin.Forms;
using System;

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