using EstefaniasJeans.Application.Commands.PedidoDetalleCommands;
using System;
using System.Collections.Generic;

namespace EstefaniasJeans.Application.Commands.PedidoCommands
{
  public abstract class PedidoCommand : Command
  {
    public Guid Id_Pedido { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; }
    public ICollection<PedidoDetalleCommand> PedidoDetalle { get; set; }
  }
}
