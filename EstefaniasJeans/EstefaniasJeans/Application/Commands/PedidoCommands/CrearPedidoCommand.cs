using EstefaniasJeans.Application.Commands.PedidoCommands.PedidoValidation;
using EstefaniasJeans.Application.Commands.PedidoDetalleCommands;
using EstefaniasJeans.Data.Model;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;

namespace EstefaniasJeans.Application.Commands.PedidoCommands
{
  public class CrearPedidoCommand: PedidoCommand, IRequest<ResponseCommand<Pedido>>
  {
    public CrearPedidoCommand(string descripcion, ICollection<PedidoDetalleCommand> pedidoDetalle)
    {
      Id_Pedido = Guid.NewGuid();
      Descripcion = descripcion;
      PedidoDetalle = pedidoDetalle;
      Fecha = DateTime.Now;
    }

    public override bool IsValid()
    {
      ValidationResult = new CrearPedidoValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}
