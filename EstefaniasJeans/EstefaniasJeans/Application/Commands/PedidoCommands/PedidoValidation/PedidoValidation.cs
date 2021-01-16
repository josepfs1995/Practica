using FluentValidation;
using System.Linq;

namespace EstefaniasJeans.Application.Commands.PedidoCommands.PedidoValidation
{
  public class PedidoValidation<T>:AbstractValidator<T> where T:PedidoCommand
  {
    protected void ValidarDetalle()
    {
      RuleFor(x => x.PedidoDetalle)
         .Must(x => x.Count > 0)
         .WithMessage("No tiene productos seleccionados.")
         .Must(x=> !x.Any(y=>y.Cantidad == 0))
         .WithMessage("No puede realizar pedido con cantidad en 0 o vacío.");
    }
  }
}
