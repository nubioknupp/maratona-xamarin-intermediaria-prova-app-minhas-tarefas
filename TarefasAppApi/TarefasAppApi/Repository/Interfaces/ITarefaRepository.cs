using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.REST.ClienteAPI.Models;

namespace TarefasApp.REST.ClienteAPI.Repository.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        IEnumerable<Tarefa> ObterPorCategoria(Guid categoriaId);
    }
}
