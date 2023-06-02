using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Controllers;
using NSE.Core.Mediator;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public ClientesController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediator.EnviarComando(new RegistrarClienteCommand(Guid.NewGuid(), "Pedro", "pedro@gmail.com", "47520206025"));

            return CustomResponse(resultado);
        }
    }
}
