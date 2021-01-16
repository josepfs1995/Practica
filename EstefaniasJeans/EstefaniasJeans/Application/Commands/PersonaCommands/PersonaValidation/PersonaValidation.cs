using EstefaniasJeans.Extensions;
using FluentValidation;

namespace EstefaniasJeans.Application.Commands.PersonaCommands.PersonaValidation
{
  public class PersonaValidation<T>:AbstractValidator<T> where T:PersonaCommand
  {
    protected void ValidarNombres()
    {
      RuleFor(x => x.Nombres)
        .NotEmpty().WithName("Nombres").WithMessage(MensajesValidation.MsgLimpio);
    }
    protected void ValidarApellidos()
    {
      RuleFor(x => x.Apellidos)
        .NotEmpty().WithName("Apellidos").WithMessage(MensajesValidation.MsgLimpio);
    }
    protected void ValidarFechaNacimiento()
    {
      RuleFor(x => x.FechaNacimiento)
        .NotEmpty().WithName("Fecha Nacimiento").WithMessage(MensajesValidation.MsgLimpio)
        .Must(x => x <= System.DateTime.Now.AddYears(-15));
    }
    protected void ValidarDireccion1()
    {
      RuleFor(x => x.Direccion1)
        .NotEmpty().WithName("Dirección").WithMessage(MensajesValidation.MsgLimpio);
    }
    protected void ValidarDocumento()
    {
      RuleFor(x => x.Documento)
        .NotEmpty().WithName("Documento").WithMessage(MensajesValidation.MsgLimpio)
        .Length(8).WithMessage("El {PropertyName} debe tener de {0} caracteres");
    }
    protected void ValidarCelular()
    {
      RuleFor(x => x.Celular)
        .NotEmpty().WithName("Celular").WithMessage(MensajesValidation.MsgLimpio);
    }
  }
}
