using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarefasApp.REST.ClienteAPI.Models
{
    public class Categoria
    {
        public Categoria()
        {
            CategoriaId = Guid.NewGuid();            
        }

        public Guid CategoriaId { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        /// <summary> Esse ID vai vir da rede social (facebook) </summary>
        public Guid UsuarioId { get; set; }

        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}