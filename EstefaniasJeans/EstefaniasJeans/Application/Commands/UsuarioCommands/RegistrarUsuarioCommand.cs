using EstefaniasJeans.Application.Commands.PersonaCommands;
using EstefaniasJeans.Application.Commands.UsuarioCommands.UsuarioValidation;
using EstefaniasJeans.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EstefaniasJeans.Application.Commands.UsuarioCommands
{
  public class RegistrarUsuarioCommand : UsuarioCommand, IRequest<ResponseCommand<IdentityUser>>
  {
    public RegistrarUsuarioCommand(string email, string contrasena, string confirmarContrasena, CrearPersonaCommand persona)
    {
      Email = email;
      Contrasena = contrasena;
      ConfirmarContrasena = confirmarContrasena;
      Persona = persona;
    }
    public override bool IsValid()
    {
      ValidationResult = new RegistrarUsuarioValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}
