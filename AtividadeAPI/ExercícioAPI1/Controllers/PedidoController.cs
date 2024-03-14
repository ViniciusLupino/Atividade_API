using ExercícioAPI1.Models;
using ExercícioAPI1.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExercícioAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]

        public async Task<ActionResult<List<PedidoModel>>> BuscarTodosPedidos()
        {
            List<PedidoModel> pedidos = await _pedidoRepositorio.BuscarTodosPedidos();
            return Ok(pedidos);
        }

        [HttpGet("pedido/{id}")]

        public async Task<ActionResult<PedidoModel>> BuscarPorId(int id)
        {
            PedidoModel pedidos = await _pedidoRepositorio.BuscarPorId(id);
            return Ok(pedidos);
        }

        [HttpPost]

        public async Task<ActionResult<PedidoModel>> Adicionar([FromBody] PedidoModel pedidoModel)
        {
            PedidoModel pedido = await _pedidoRepositorio.Adicionar(pedidoModel);
            return Ok(pedido);
        }

        [HttpPatch("pedido/{id}")]

        public async Task<ActionResult<PedidoModel>> Atualizar(int id, [FromBody] PedidoModel pedidoModel)
        {
            pedidoModel.Id = id;
            PedidoModel pedido = await _pedidoRepositorio.Atualizar(pedidoModel, id);
            return Ok(pedido);
        }

        [HttpDelete("pedido/{id}")]

        public async Task<ActionResult<PedidoModel>> Apagar(int id)
        {
            bool apagado = await _pedidoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
