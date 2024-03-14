using ExercícioAPI1.Data;
using ExercícioAPI1.Models;
using ExercícioAPI1.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExercícioAPI1.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {

        private readonly ExercicioDbContext _dbContext;

        public PedidoRepositorio(ExercicioDbContext exercicioDbContext)
        {
            _dbContext = exercicioDbContext;
        }

        public async Task<PedidoModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidoModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

        public async Task<PedidoModel> Adicionar(PedidoModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidoModel pedidoPorId = await BuscarPorId(id);

            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do Id: {id} não foi encontrado.");
            }

            _dbContext.Pedidos.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidoModel> Atualizar(PedidoModel pedido, int id)
        {
            PedidoModel pedidoPorId = await BuscarPorId(id);

            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do Id: {id} não foi encontrado.");
            }

            pedidoPorId.enderecoEntrega = pedido.enderecoEntrega;

            _dbContext.Pedidos.Update(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return pedidoPorId;
        }
    }
}
