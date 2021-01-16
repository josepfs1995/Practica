using AutoMapper;
using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EstefaniasJeans.Extensions;

namespace EstefaniasJeans.Application.Commands.PedidoCommands
{
  public class PedidoCommandHandler : CommandHandler<Pedido>, IRequestHandler<CrearPedidoCommand, ResponseCommand<Pedido>>
  {
    private readonly IMapper _mapper;
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IHttpContextAccessor _context;
    public PedidoCommandHandler(IMapper mapper,
                              IPedidoRepository pedidoRepository,
                              IHttpContextAccessor context)
    {
      _mapper = mapper;
      _pedidoRepository = pedidoRepository;
      _context = context;
    }
    public async Task<ResponseCommand<Pedido>> Handle(CrearPedidoCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) return ManejarRespuesta(request.ValidationResult);

      var pedido = _mapper.Map<Pedido>(request);
      pedido.Id_Persona = _context.HttpContext.User.ObtenerId();
      foreach (var detalle in pedido.PedidoDetalle)
      {
        detalle.PrecioTotal = detalle.Cantidad * detalle.Precio;
        pedido.PrecioTotal += detalle.PrecioTotal;
      }
      _pedidoRepository.Create(pedido);

      await _pedidoRepository.UoW.Save();
      return ManejarRespuesta(request.ValidationResult, pedido);
    }
  }
}
