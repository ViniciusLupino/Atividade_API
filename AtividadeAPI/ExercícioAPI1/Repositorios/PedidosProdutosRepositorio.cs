using ExercícioAPI1.Data;
using ExercícioAPI1.Models;
using ExercícioAPI1.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExercícioAPI1.Repositorios
{
    public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
    {
        private readonly ExercicioDbContext _dbContext;

        public PedidosProdutosRepositorio(ExercicioDbContext exercicioDbContext)
        {
            _dbContext = exercicioDbContext;
        }

        public async Task<PedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos.ToListAsync();
        }

        public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidoproduto)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidoproduto);
            await _dbContext.SaveChangesAsync();
            return pedidoproduto;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidosProdutosModel pedidoprodutoPorId = await BuscarPorId(id);

            if (pedidoprodutoPorId == null)
            {
                throw new Exception($"Produto do Id: {id} não foi encontrado.");
            }

            _dbContext.PedidosProdutos.Remove(pedidoprodutoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidoproduto, int id)
        {
            PedidosProdutosModel pedidoprodutoPorId = await BuscarPorId(id);

            if (pedidoprodutoPorId == null)
            {
                throw new Exception($"Produto do Id: {id} não foi encontrado.");
            }

            pedidoprodutoPorId.Quantidade = pedidoproduto.Quantidade;

            _dbContext.PedidosProdutos.Update(pedidoprodutoPorId);
            await _dbContext.SaveChangesAsync();

            return pedidoprodutoPorId;
        }


    }
}
