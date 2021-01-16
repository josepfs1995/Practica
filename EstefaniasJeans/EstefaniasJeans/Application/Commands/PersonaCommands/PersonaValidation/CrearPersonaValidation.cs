using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Application.Commands.PersonaCommands.PersonaValidation
{
  public class CrearPersonaValidation:PersonaValidation<CrearPersonaCommand>
  {
    public CrearPersonaValidation()
    {
      ValidarNombres();
      ValidarApellidos();
      ValidarFechaNacimiento();
      ValidarDocumento();
      ValidarDireccion1();
      ValidarCelular();
    }
  }
}
