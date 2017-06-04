using System;
using System.Collections.Generic;
using TarefasApp.REST.ClienteAPI.Models;

namespace TarefasApp.REST.ClienteAPI.Repository.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> ObterPorUsuario(Guid usuarioId);
    }
}
