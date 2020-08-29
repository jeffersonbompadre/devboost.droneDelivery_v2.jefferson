using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        readonly IPedidoHandler _pedidoService;

        public PedidoController(IPedidoHandler pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("realizarpedido")]
        public async Task<ActionResult> RealizarPedido([FromBody] RealizarPedidoRequest pedido)
        {
            try
            {
                var result = await _pedidoService.RealizarPedido(pedido);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("distribuirpedido")]
        public async Task<ActionResult> DistribuirPedido()
        {
            await _pedidoService.DistribuirPedido();
            return Ok();
        }
    }
}
