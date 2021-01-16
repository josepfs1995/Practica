using AutoMapper;
using EstefaniasJeans.Application.Commands.MercaderiaCommands;
using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;
using EstefaniasJeans.Application.Commands.PedidoCommands;
using EstefaniasJeans.Application.Commands.PedidoDetalleCommands;
using EstefaniasJeans.Application.Commands.PersonaCommands;
using EstefaniasJeans.Data.Model;

namespace EstefaniasJeans.Application.Mapper
{
  public class CommandToDataMapper:Profile
  {
    public CommandToDataMapper()
    {
      CreateMap<CrearMercaderiaCommand, Mercaderia>();
      CreateMap<MercaderiaFotoCommand, MercaderiaFoto>();
      CreateMap<CrearMercaderiaFotoCommand, MercaderiaFoto>();
      CreateMap<EditarMercaderiaFotoCommand, MercaderiaFoto>();
      CreateMap<CrearPedidoCommand, Pedido>();
      CreateMap<PedidoDetalleCommand, PedidoDetalle>();
      CreateMap<CrearPersonaCommand, Persona>();
    }
  }
}
