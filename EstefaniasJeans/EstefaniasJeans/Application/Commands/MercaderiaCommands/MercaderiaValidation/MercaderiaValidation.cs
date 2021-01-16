using EstefaniasJeans.Extensions;
using FluentValidation;
using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;

namespace EstefaniasJeans.Application.Commands.MercaderiaCommands.MercaderiaValidation
{
  public class MercaderiaValidation<T, E>:AbstractValidator<T> where T: MercaderiaCommand<E> where E: MercaderiaFotoCommand
  {
    protected void ValidarNombre()
    {
      RuleFor(x => x.Nombre)
        .NotEmpty()
        .WithMessage(MensajesValidation.MsgLimpio);
    }
    protected void ValidarStock()
    {
      RuleFor(x => x.Stock)
        .NotEmpty()
        .WithMessage(MensajesValidation.MsgLimpio)
        .Must(x => x > 0)
        .WithMessage("El stock debe ser mayor a 0");
    }
    protected void ValidarPrecio()
    {
      RuleFor(x => x.Precio)
        .NotEmpty()
        .WithMessage(MensajesValidation.MsgLimpio);
    }
    protected void ValidarFotos(){
      RuleFor(x=>x.MercaderiaFoto)
        .NotNull().WithName("Fotos").WithMessage("Debes agregar {PropertyName}.")
        .Must(x=>x.Count > 0).WithMessage("Debes agregar {PropertyName}.");
    }
  } 
}
