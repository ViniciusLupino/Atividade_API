using ExercícioAPI1.Models;
using ExercícioAPI1.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExercícioAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {

        private readonly IPedidosProdutosRepositorio _pedidosProdutosRepositorio;

        public PedidosProdutosController(IPedidosProdutosRepositorio pedidosProdutosRepositorio)
        {
            _pedidosProdutosRepositorio = pedidosProdutosRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<PedidosProdutosModel>>> BuscarTodospedidosProdutos()
        {
            List<PedidosProdutosModel> pedidospedidoprodutos = await _pedidosProdutosRepositorio.BuscarTodosPedidosProdutos();
            return Ok(pedidospedidoprodutos);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PedidosProdutosModel>> BuscarPorId(int id)
        {
            PedidosProdutosModel pedidoproduto = await _pedidosProdutosRepositorio.BuscarPorId(id);
            return Ok(pedidoproduto);
        }

        [HttpPost]

        public async Task<ActionResult<PedidosProdutosModel>> Adicionar([FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            PedidosProdutosModel pedidoproduto = await _pedidosProdutosRepositorio.Adicionar(pedidosProdutosModel);
            return Ok(pedidoproduto);
        }

        [HttpPatch("{id}")]

        public async Task<ActionResult<PedidosProdutosModel>> Atualizar(int id, [FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            pedidosProdutosModel.Id = id;
            PedidosProdutosModel pedidoproduto = await _pedidosProdutosRepositorio.Atualizar(pedidosProdutosModel, id);
            return Ok(pedidoproduto);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<PedidosProdutosModel>> Apagar(int id)
        {
            bool apagado = await _pedidosProdutosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
