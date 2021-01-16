using AutoMapper;
using EstefaniasJeans.Application.Commands.MercaderiaCommands;
using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;
using EstefaniasJeans.Extensions;
using EstefaniasJeans.Repository;
using EstefaniasJeans.ViewModels;
using EstefaniasJeans.ViewModels.Mercaderia;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Controllers
{
  [Authorize(Roles = "Administrador")]
  [Route("api/[controller]")]
  public class MercaderiaController : MainController
  {
    private readonly IMercaderiaRepository _mercaderiaService;
    private readonly IMediator _mediator;
    public MercaderiaController(IMapper mapper,
                        IMercaderiaRepository mercaderiaService,
                        IMediator mediator) : base(mapper)
    {
      _mediator = mediator;
      _mercaderiaService = mercaderiaService;
    }
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ResponseViewModel<ICollection<GetMercaderiaViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<ICollection<GetMercaderiaViewModel>>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
      var mercaderias = _mapper.Map<ICollection<GetMercaderiaViewModel>>(await _mercaderiaService.Get());
      return ResponseCustomizado(mercaderias);
    }
    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(Guid id)
    {
      var mercaderias = _mapper.Map<GetMercaderiaViewModel>(await _mercaderiaService.Get(id));
      if(mercaderias == null)
      {
        return CrearError("La mercaderia no existe!");
      }
      return ResponseCustomizado(mercaderias);
    }
    [HttpPost]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(PostMercaderiaViewModel model)
    {
      var command = new CrearMercaderiaCommand(model.Id_Persona, model.Id_Categoria, model.Nombre, model.Descripcion, model.Stock, model.Precio, model.MercaderiaFoto.Select(x=>new CrearMercaderiaFotoCommand(x.Nombre, x.Base64)).ToList());
      var result = await _mediator.Send(command);
      return ResponseCustomizado(result, new GetMercaderiaViewModel());
    }
    [HttpPut]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(PutMercaderiaViewModel model)
    {
      var command = new EditarMercaderiaCommand(model.Id_Mercaderia, model.Id_Persona, model.Id_Categoria, model.Nombre, model.Descripcion, model.Stock, model.Precio, model.MercaderiaFoto.Select(x=>new EditarMercaderiaFotoCommand(x.Id_MercaderiaFoto, x.Nombre, x.Base64)).ToList());
      var result = await _mediator.Send(command);
      return ResponseCustomizado(result, new GetMercaderiaViewModel());
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<GetMercaderiaViewModel>),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var command = new EliminarMercaderiaCommand(id);
      var result = await _mediator.Send(command);
      return ResponseCustomizado(result, new GetMercaderiaViewModel());
    }
  }
}
