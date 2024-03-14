using ExercícioAPI1.Enums;

namespace ExercícioAPI1.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCategoria Status { get; set; }
    }
}
