using System.Data.Entity.ModelConfiguration;
using TarefasApp.REST.ClienteAPI.Models;

namespace TarefasApp.REST.ClienteAPI.EntityConfig
{
    public class TarefaConfig : EntityTypeConfiguration<Tarefa>
    {
        public TarefaConfig()
        {
            HasKey(t => t.TarefaId);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.DataCadastro)
                .IsRequired();

            HasRequired(t => t.Categoria)
                .WithMany(c => c.Tarefas)
                .HasForeignKey(t => t.CategoriaId);

            ToTable("Tarefas");
        }
    }
}