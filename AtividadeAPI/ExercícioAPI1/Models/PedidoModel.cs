namespace ExercícioAPI1.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
        public string enderecoEntrega { get; set;}
    }
}
