using EstefaniasJeans.Extensions;
using FluentValidation;
namespace EstefaniasJeans.Application.Commands.UsuarioCommands.UsuarioValidation
{
  public class UsuarioValidation<T>:AbstractValidator<T> where T:UsuarioCommand
  {
    protected void ValidarEmail()
    {
      RuleFor(x => x.Email)
        .NotEmpty().WithName("Email").WithMessage(MensajesValidation.MsgLimpio);
    }
    protected void ValidarContrasena()
    {
      RuleFor(x => x.Contrasena)
        .NotEmpty().WithName("Contraseña").WithMessage(MensajesValidation.MsgLimpio)
        .Length(6,20).WithMessage("La {PropertyName} debe tener de {0} a {1} caracteres");
    }
    protected void ValidarConfirmacionContraseña()
    {
      RuleFor(x => x.ConfirmarContrasena)
        .NotEmpty().WithName("Contraseña").WithMessage(MensajesValidation.MsgLimpio)
        .Length(6, 20).WithMessage("La {PropertyName} debe tener de {0} a {1} caracteres")
        .Equal(x=>x.Contrasena).WithMessage("Las contraseñas no coinciden");
    }

 
  }
}
