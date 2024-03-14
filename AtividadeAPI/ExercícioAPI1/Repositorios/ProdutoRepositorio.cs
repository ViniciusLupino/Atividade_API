using ExercícioAPI1.Data;
using ExercícioAPI1.Models;
using ExercícioAPI1.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExercícioAPI1.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly ExercicioDbContext _dbContext;

        public ProdutoRepositorio(ExercicioDbContext exercicioDbContext)
        {
            _dbContext = exercicioDbContext;
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Produto do Id: {id} não foi encontrado.");
            }

            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Produto do Id: {id} não foi encontrado.");
            }

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Preco = produto.Preco;

            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

 
    }
}
