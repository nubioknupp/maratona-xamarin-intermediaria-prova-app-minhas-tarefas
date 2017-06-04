using System;
using System.Collections.Generic;
using TarefasApp.REST.ClienteAPI.Models;
using TarefasApp.REST.ClienteAPI.Repository.Interfaces;

namespace TarefasApp.REST.ClienteAPI.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public IEnumerable<Tarefa> ObterPorCategoria(Guid categoriaId)
        {
            return Buscar(t => t.CategoriaId == categoriaId);
        }
    }
}