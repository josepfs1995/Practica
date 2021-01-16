using EstefaniasJeans.Data.Model;
using MediatR;
using System;

namespace EstefaniasJeans.Application.Commands.MercaderiaCommands
{
  public class EliminarMercaderiaCommand: IRequest<ResponseCommand<Mercaderia>>
  {
    public EliminarMercaderiaCommand(Guid id_Mercaderia)
    {
      Id_Mercaderia = id_Mercaderia;
    }
    public Guid Id_Mercaderia { get; set; }
  }
}
