namespace ExercícioAPI1.Models
{
    public class PedidosProdutosModel
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }

        public int? CategoriaId { get; set; }

        public virtual CategoriaModel? Categoria { get; set; }

        public int Quantidade { get; set; }
    }
}
