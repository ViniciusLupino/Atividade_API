using ExercícioAPI1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExercícioAPI1.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Usuario);

            builder.Property(x => x.enderecoEntrega).IsRequired().HasMaxLength(255);
        }
    }
}
