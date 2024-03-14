using ExercícioAPI1.Data;
using ExercícioAPI1.Models;
using ExercícioAPI1.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExercícioAPI1.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {

        private readonly ExercicioDbContext _dbContext;

        public CategoriaRepositorio(ExercicioDbContext exercicioDbContext)
        {
            _dbContext = exercicioDbContext;
        }

        public async Task<CategoriaModel> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriaModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do Id: {id} não foi encontrado");
            }

            _dbContext.Categorias.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do Id: {id} não foi encontrado");
            }

            categoriaPorId.Nome = categoria.Nome;
            categoriaPorId.Status = categoria.Status;

            _dbContext.Categorias.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoriaPorId;
        }
    }
}
