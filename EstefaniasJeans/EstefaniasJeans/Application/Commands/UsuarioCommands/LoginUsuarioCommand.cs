using EstefaniasJeans.Application.Commands.UsuarioCommands.UsuarioValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EstefaniasJeans.Application.Commands.UsuarioCommands
{
  public class LoginUsuarioCommand : UsuarioCommand, IRequest<ResponseCommand<IdentityUser>>
  {
    public LoginUsuarioCommand(string email, string contrasena)
    {
      Email = email;
      Contrasena = contrasena;
    }
    public override bool IsValid()
    {
      ValidationResult = new LoginUsuarioValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}
