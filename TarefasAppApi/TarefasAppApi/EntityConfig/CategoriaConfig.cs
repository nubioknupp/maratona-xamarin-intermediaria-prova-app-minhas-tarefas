using System.Data.Entity.ModelConfiguration;
using TarefasApp.REST.ClienteAPI.Models;

namespace TarefasApp.REST.ClienteAPI.EntityConfig
{
    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            HasKey(c => c.CategoriaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.UsuarioId)
                .IsRequired();

            ToTable("Categorias");
        }
    }
}