using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TarefasApp.Models;

namespace TarefasApp.Services
{
    public interface ITarefasAppService
    {
        Task<List<Categoria>> BuscarCategoriasPorUsuarioAsync(string usuarioId);

        Task<bool> GravarCategoriaAsync(Categoria categoria);

        Task<bool> GravarTarefaAsync(Tarefa tarefa);

        Task<List<Tarefa>> BuscarTarefasPorCategoriaAsync(string categoriaId);

    }
}