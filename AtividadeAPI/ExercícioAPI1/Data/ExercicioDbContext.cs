using ExercícioAPI1.Data.Map;
using ExercícioAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercícioAPI1.Data
{
    public class ExercicioDbContext : DbContext
    {
    public ExercicioDbContext(DbContextOptions<ExercicioDbContext> options) : base(options) { }
    
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
