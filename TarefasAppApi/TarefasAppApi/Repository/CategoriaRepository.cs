using System;
using System.Collections.Generic;
using TarefasApp.REST.ClienteAPI.Models;
using TarefasApp.REST.ClienteAPI.Repository.Interfaces;

namespace TarefasApp.REST.ClienteAPI.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public IEnumerable<Categoria> ObterPorUsuario(Guid usuarioId)
        {
            return Buscar(c => c.UsuarioId == usuarioId);
        }
    }
}