using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Handles.Queries;
using devboost.Domain.Handles.Queries.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        readonly IClienteHandler _clienteHandler;
        readonly IClientQueryHandler _clientQueryHandler;

        public ClienteController(IClienteHandler clienteHandler, IClientQueryHandler clientQueryHandler)
        {
            _clienteHandler = clienteHandler;
            _clientQueryHandler = clientQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _clientQueryHandler.GetAll();
            return Ok(result);
        }

        [HttpPost("adicionarcliente")]
        public async Task<ActionResult> AdicionarCliente([FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                await _clienteHandler.AddCliente(clienteRequest);
                return Ok("Cliente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
