using EstefaniasJeans.Application.Commands.PersonaCommands.PersonaValidation;
using EstefaniasJeans.Data.Model;
using MediatR;
using System;

namespace EstefaniasJeans.Application.Commands.PersonaCommands
{
  public class CrearPersonaCommand : PersonaCommand, IRequest<ResponseCommand<Persona>>
  {
    public CrearPersonaCommand(string nombres, string apellidos, DateTime fechaNacimiento, string direccion1, string direccion2, string documento, string celular)
    {

      Nombres = nombres;
      Apellidos = apellidos;
      FechaNacimiento = fechaNacimiento;
      Direccion1 = direccion1;
      Direccion2 = direccion2;
      Documento = documento;
      Celular = celular;
    }
    public override bool IsValid()
    {
      ValidationResult = new CrearPersonaValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}
