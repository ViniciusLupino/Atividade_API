using ExercícioAPI1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExercícioAPI1.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Usuario);

            builder.Property(x => x.CategoriaId);

            builder.Property(x => x.Quantidade).IsRequired();
        }
    }
}
