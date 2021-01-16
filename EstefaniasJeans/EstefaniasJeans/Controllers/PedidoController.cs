using AutoMapper;
using EstefaniasJeans.Application.Commands.PedidoCommands;
using EstefaniasJeans.Application.Commands.PedidoDetalleCommands;
using EstefaniasJeans.Data.Repository;
using EstefaniasJeans.Extensions;
using EstefaniasJeans.ViewModels;
using EstefaniasJeans.ViewModels.Pedido;
using EstefaniasJeans.ViewModels.PedidoDetalle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Controllers
{
  [Authorize(Roles = "Administrador")]
  [Route("api/[controller]")]
  public class PedidoController: MainController
  {
    private readonly IMediator _mediator;
    private readonly IPedidoRepository _pedidoRepository;
    public PedidoController(IMapper mapper,
                            IMediator mediator,
                            IPedidoRepository pedidoRepository):base(mapper)
    {
      _mediator = mediator;
      _pedidoRepository = pedidoRepository;
    }
    [HttpGet]
    [ProducesResponseType(typeof(ResponseViewModel<GetPedidoViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      var pedido = _mapper.Map<ICollection<GetPedidoViewModel>>(await _pedidoRepository.Get());
      return ResponseCustomizado(pedido);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseViewModel<GetPedidoViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id)
    {
      var pedido = _mapper.Map<GetPedidoViewModel>(await _pedidoRepository.Get(id));
      if (pedido == null)
      {
        return CrearError("El pedido no existe!");
      }
      return ResponseCustomizado(pedido);
    }
    [HttpPost]
    [ProducesResponseType(typeof(ResponseViewModel<GetPedidoViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<GetPedidoViewModel>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(PostPedidoViewModel model)
    {
      var command = new CrearPedidoCommand(model.Descripcion, model.PedidoDetalle.Select(x => new PedidoDetalleCommand(x.Id_Mercaderia, x.Cantidad, x.Precio)).ToList());
      var result = await _mediator.Send(command);
      return ResponseCustomizado(result, new GetPedidoViewModel());
    }
  }
}
