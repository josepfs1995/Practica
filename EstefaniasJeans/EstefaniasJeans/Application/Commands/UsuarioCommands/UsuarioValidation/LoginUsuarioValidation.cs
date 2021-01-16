namespace EstefaniasJeans.Application.Commands.UsuarioCommands.UsuarioValidation
{
  public class LoginUsuarioValidation : UsuarioValidation<LoginUsuarioCommand>
  {
    public LoginUsuarioValidation()
    {
      ValidarEmail();
      ValidarContrasena();
    }
  }
}
