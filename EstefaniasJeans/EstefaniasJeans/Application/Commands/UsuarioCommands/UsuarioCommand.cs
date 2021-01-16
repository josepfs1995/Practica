using EstefaniasJeans.Application.Commands.PersonaCommands;

namespace EstefaniasJeans.Application.Commands.UsuarioCommands
{
  public abstract class UsuarioCommand:Command
  {
    public string Email { get; set; }
    public string Contrasena { get; set; }
    public string ConfirmarContrasena { get; set; }
    public CrearPersonaCommand Persona { get; set; }
  }
}
