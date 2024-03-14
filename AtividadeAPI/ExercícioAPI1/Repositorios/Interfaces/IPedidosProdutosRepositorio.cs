using ExercícioAPI1.Models;

namespace ExercícioAPI1.Repositorios.Interfaces
{
    public interface IPedidosProdutosRepositorio
    {
        Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos();

        Task<PedidosProdutosModel> BuscarPorId(int id);

        Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidoproduto);

        Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidoproduto, int id);

        Task<bool> Apagar(int id);
    }
}
