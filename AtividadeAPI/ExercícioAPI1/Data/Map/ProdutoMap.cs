using ExercícioAPI1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExercícioAPI1.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(225);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(225);
            builder.Property(x => x.Preco).IsRequired().HasColumnType("decimal(8,2)");
        }
    }
}
