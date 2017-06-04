using System;

namespace TarefasApp.REST.ClienteAPI.Models
{
    public class Tarefa
    {
        public Tarefa()
        {
            TarefaId = Guid.NewGuid();
        }

        public Guid TarefaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        public Guid CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}