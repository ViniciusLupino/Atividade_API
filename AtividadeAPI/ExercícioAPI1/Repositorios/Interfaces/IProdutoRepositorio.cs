using ExercícioAPI1.Models;

namespace ExercícioAPI1.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();

        Task<ProdutoModel> BuscarPorId(int id);

        Task<ProdutoModel> Adicionar(ProdutoModel produto);

        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);

        Task<bool> Apagar(int id);
    }
}
