using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Application.Commands.UsuarioCommands.UsuarioValidation
{
  public class RegistrarUsuarioValidation:UsuarioValidation<RegistrarUsuarioCommand>
  {
    public RegistrarUsuarioValidation()
    {
      ValidarEmail();
      ValidarContrasena();
      ValidarConfirmacionContraseña();
    }
  }
}
