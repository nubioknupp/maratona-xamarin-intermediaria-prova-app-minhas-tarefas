using System.Collections.ObjectModel;
using TarefasApp.ViewModels.Bases;
using System.Threading.Tasks;
using TarefasApp.Helpers;
using TarefasApp.Models;
using TarefasApp.Services;
using Xamarin.Forms;

namespace TarefasApp.ViewModels.Categorias
{
    public class CategoriaListarViewModel : BaseViewModel
    {
        private readonly ITarefasAppService _tarefasAppService;
        public ObservableCollection<Categoria> Categorias { get; }

        public CategoriaListarViewModel()
        {
            _tarefasAppService = DependencyService.Get<ITarefasAppService>();
            Categorias = new ObservableCollection<Categoria>();

            Title = "Categorias"; 

        }

        public override async Task LoadAsync()
        {
            var categorias = await _tarefasAppService.BuscarCategoriasPorUsuarioAsync(Settings.UserId);

            Categorias.Clear();

            foreach (var item in categorias)
            {
                Categorias.Add(item);
            }
        }
    }
}